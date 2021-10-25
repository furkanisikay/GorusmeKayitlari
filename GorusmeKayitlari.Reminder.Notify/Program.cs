using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Extensions.Reminder;
using Microsoft.Win32.TaskScheduler;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Reminder.Notify
{
    static class Program
    {
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            try
            {
                if (args.Length > 0)
                {
                    cmHatirlatmalar = ConnectionManager.Instance;
                    _MainProcesses(args, out NotifyProgramArgs arg);//argümanlara göre hatırlatma değşkenleri ayarlanıyor
                    if (arg.firstRun)
                    {
                        Process.Start(Application.ExecutablePath, "/htID:" + arg.Id + " /taskname:\"" + arg.taskName + "\"");
                        Application.Exit();
                    }
                    else
                    {
                        NotifyGoster(arg);
                    }

                }
            }
            catch (Exception ex) { Core.Extensions.Logger.Log(ex); }
            finally { Application.Exit(); }
        }

        private static void NotifyGoster(NotifyProgramArgs arg)
        {
            if (arg.ht != null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Notify frmNotify = new Notify(arg.ht, arg.taskName);
                _StopMainFormInScheduler(arg.Id);
                frmNotify.ShowDialog();
                if (frmNotify.Ertelendi) { HatirlatmaErtele(frmNotify.ErtelemeSuresi, arg.ht); }
                else { HatirlatmayiSil(arg); }
                frmNotify.Dispose();
            }
        }

        static ConnectionManager cmHatirlatmalar;

        private static void _MainProcesses(string[] args, out NotifyProgramArgs arg)
        {
            NotifyProgramArgs tArg = new NotifyProgramArgs();
            System.Threading.Tasks.Task task = System.Threading.Tasks.Task.Run(async () =>
            {
                tArg = await HatirlatmaGetir(args);
            });
            task.Wait();
            arg = tArg;
        }

        private static void _StopMainFormInScheduler(int htId)
        {
            using (TaskService tss = new TaskService())
            {
                TaskFolder tFolder = Hatirlatmalar.GetTaskFolder(tss);
                string taskPath = string.Format("{0}\\Hatirlatma({1})", tFolder, htId);
                Microsoft.Win32.TaskScheduler.Task task = tss.GetTask(taskPath);
                task.Stop();
            }
        }

        public static async void HatirlatmaErtele(int ErtelemeSuresi, Hatirlatma ht)
        {
            try
            {
                ht.Tarih = ht.Tarih.AddSeconds(ErtelemeSuresi);
                await Hatirlatmalar.Guncelle(ht, cmHatirlatmalar);
                Hatirlatmalar.HatirlatmayiTasklerdeGuncelle(ht, HatirlatmaTask.NotifyPath);
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); Logger.Log(ex); }
        }
        /// <summary>
        /// Hatırlatmayı veritabanı ve TaskScheduler den siler
        /// </summary>
        /// <param name="arg">Gelerekli olan argümanlar(id,taskName)</param>
        public static async void HatirlatmayiSil(NotifyProgramArgs arg)
        {
            try
            {
                using (TaskService ts = new TaskService())
                {
                    TaskFolder folder = Hatirlatmalar.GetTaskFolder(ts);
                    Microsoft.Win32.TaskScheduler.Task tsk = ts.GetTask(folder + "\\" + arg.taskName);
                    if (tsk != null && folder != null)
                    {
                        try { folder.DeleteTask(arg.taskName, true); }
                        catch { }
                    }
                }
                await Hatirlatmalar.Sil(arg.Id, cmHatirlatmalar);
            }
            catch (Exception ex) { MessageBox.Show(ex.StackTrace); Logger.Log(ex); }
        }

        private static async Task<NotifyProgramArgs> HatirlatmaGetir(string[] Args)
        {
            int htid = -1;
            string isim = string.Empty;
            bool firstrun = false;
            foreach (string arg in Args)
            {
                if (arg.StartsWith("/htID:")) { htid = int.Parse(arg.Remove(0, "/htID:".Length)); }
                if (arg.StartsWith("/taskname:")) { isim = arg.Remove(0, "/taskname:".Length); }
                if (arg == "/FirstRun") { firstrun = true; }
            }
            Hatirlatma ht = firstrun ? null : await Hatirlatmalar.Getir(htid, cmHatirlatmalar);

            return new NotifyProgramArgs(htid, isim, ht, firstrun);
        }

    }

}
