using GorusmeKayitlari.Updater.Forms;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GorusmeKayitlari.Updater.Classes
{
    /// <summary>
    /// C#'da Uygulamaya güncelleme desteği sağlar.
    /// </summary>
    public class Updater : IDisposable
    {
        /// <summary>
        /// Programın güncelleme bilgileri tutar
        /// </summary>
        private IUpdatable applicationInfo;
        /// <summary>
        /// Güncelleme bulmak için iş parçacığı.
        /// </summary>
        private BackgroundWorker bgWorker;
        /// <summary>
        /// Yeni bir AppUpdate nesnesi oluşturur.
        /// </summary>
        /// <param name="applicationInfo">Programın güncelleme bilgileri.</param>
        public Updater(IUpdatable applicationInfo)
        {
            this.applicationInfo = applicationInfo;

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(BgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgWorker_RunWorkerCompleted);
        }

        #region ### Dispose Kodları ###
        /// <summary>
        /// Nesnemize ait yıkıcı (destructor) metodumuz.
        /// </summary>
        ~Updater()
        {
            // Bir şekilde destroctor tetiklendiğinde yönetilmeyen nesneleri ele 
            // almalıyız. Bunu da Dispose() metodumuzu burada çağırarak 
            // sadece unmanaged resources'ın ele alınması sağlıyoruz.
            // İş buraya geldiğinde managed resources kısmını zaten çöp toplayıcının 
            // kendisi ele alacak.
            Dispose(false);
        }
        /// <summary>
        /// IDisposable arayüzü uygulandıktan sonra içeriğini bizim doldurmamız 
        /// gereken Dispose metodu.
        /// </summary>
        public void Dispose()
        {
            // Dispose metoduna "true" değeri verilerek hem yönetilen hem de 
            // yönetilemeyen kaynakların serbest bırakılmaları sağlanıyor.
            Dispose(true);
            // Önce ki adımda yönetilen ve yönetilmeyen kaynakların tamamı 
            // ele alındığı için destructor'a gidilmesine artık gerek yok.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// IDisposable arayüzünün uygulanması sonucu doldurulması gereken 
        /// Dispose() metodunun görevini kısmen yerine getirecek ve parametre
        /// olarak verilen değere göre hangi kaynaklar üzerinde işlem 
        /// yapacağımıza karar vereceğimiz metodumuz.
        /// </summary>
        /// <param name="disposing">
        /// Managed yada Unmanaged kaynaklarından hangisinde çalışacağımızı 
        /// belirten parametre. False verildiğinde sadece unmanaged kaynaklar 
        /// üzerinde işlem yapılır.
        /// </param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                bgWorker.Dispose();
            }
            applicationInfo = null;
        }
        #endregion

        /// <summary>
        /// Program için bir güncelleme olup olmadığını kontrol eder.
        /// Eğer Bir güncelleme varsa, indirmeyi istediğini soran bir iletişim kutusu görünür.
        /// </summary>
        public void GuncellemeYap(bool guncelleUyariGoster)
        {
            if (!this.bgWorker.IsBusy) { bgWorker.RunWorkerAsync(new object[] { this.applicationInfo, guncelleUyariGoster }); }
        }

        public string GuncellemeAciklamasiGetir()
        {
            System.Threading.Tasks.Task<string> taskDesc = new System.Threading.Tasks.Task<string>(() =>
            {
                AppUpdaterXML xml = AppUpdaterXML.Parse(this.applicationInfo.UpdateXmlLocation, this.applicationInfo.ApplicationID);
                return xml.Description;
            });
            taskDesc.RunSynchronously();
            taskDesc.Wait();
            string desc = taskDesc.Result;
            taskDesc.Dispose();
            this.Dispose();
            return desc;
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            IUpdatable application = (IUpdatable)((e.Argument as object[])[0]);
            bool uyariGoster = (bool)((e.Argument as object[])[1]);
            if (InternetVarmi())
            {
                if (!AppUpdaterXML.ExistsOnServer(application.UpdateXmlLocation)) { e.Cancel = true; }
                else { e.Result = new object[] { AppUpdaterXML.Parse(application.UpdateXmlLocation, application.ApplicationID), uyariGoster }; }
            }
            else
            {
                e.Cancel = true;
                if (uyariGoster)
                {
                    MessageBox.Show("İnternet bağlantısı sağlanamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (!e.Cancelled)
            {
                AppUpdaterXML update = (AppUpdaterXML)(((object[])e.Result)[0]);
                //AppUpdaterXML update = (AppUpdaterXML)e.Result;
                if (update != null)
                {
                    if (update.IsNewerThan(this.applicationInfo.ApplicationAssembly.GetName().Version))
                    {
                        if (new UpdateAcceptForm(this.applicationInfo, update).ShowDialog(this.applicationInfo.Context) == DialogResult.Yes)
                        {
                            this.DownloadUpdate(update);
                        }
                    }
                    else
                    {
                        bool uyariGoster = (bool)(((object[])e.Result)[1]);
                        if (uyariGoster)
                        {
                            MessageBox.Show(this.applicationInfo.Context, string.Format("Son sürüm v{0} kullanıyorsunuz.", this.applicationInfo.ApplicationAssembly.GetName().Version.ToString()), "Güncel Sürüm Yok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            Dispose();
        }

        private void DownloadUpdate(AppUpdaterXML update)
        {
            UpdateDownloadForm form = new UpdateDownloadForm(update.Uri, update.MD5, this.applicationInfo.ApplicationIcon);
            DialogResult result = form.ShowDialog(this.applicationInfo.Context);
            string tempFilePath = form.TempFilePath;
            form.Dispose();
            if (result == DialogResult.OK)
            {
                string currentPath = this.applicationInfo.ApplicationAssembly.Location;
                string newPath = Path.GetDirectoryName(currentPath) + "\\" + update.FileName;
                this.IstatistikYolla(update.StatisticsUri.AbsoluteUri);
                UpdateApplication(tempFilePath, currentPath, newPath, update.LaunchArgs);
                Application.Exit();
            }
            else if (result == DialogResult.Abort)
            {
                MessageBox.Show("Güncelleme işlemi kullanıcı tarafından iptal edildi.", "Güncelleme İptal Edildi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Güncelleme dosyaları karşıdan yüklenirken bir hata oluştu.\nLütfen daha sonra tekrar deneyin.", "Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Internet Olup Olmadığını Kontrol Eder!
        /// </summary>
        /// <returns>true or false</returns>
        private bool InternetVarmi()
        {
            try
            {
                return new System.Net.NetworkInformation.Ping().Send("www.google.com", 1000).Status == System.Net.NetworkInformation.IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void IstatistikYolla(string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                {
                    ((HttpWebResponse)((HttpWebRequest)WebRequest.Create(url)).GetResponse()).Close();
                }
            }
            catch { }
        }

        private void UpdateApplication(string tempFilePath, string currentPath, string newPath, string launchArgs)
        {
            string arguments = "/C Choice /C Y /N /D Y /T 4 & Del /F /Q \"{0}\" & Choice /C Y /N /D Y /T 2 & Move /Y \"{1}\" \"{2}\" & Start \"\" /D \"{3}\" \"{4}\" {5}";
            ProcessStartInfo info = new ProcessStartInfo()
            {
                Arguments = string.Format(arguments, currentPath, tempFilePath, newPath, Path.GetDirectoryName(newPath), Path.GetFileName(newPath), launchArgs),
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                FileName = "cmd.exe"
            };
            Process.Start(info);
        }
    }
}
