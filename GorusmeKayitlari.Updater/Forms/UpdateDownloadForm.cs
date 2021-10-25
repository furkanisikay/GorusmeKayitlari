using GorusmeKayitlari.Updater.Classes;
using Microsoft.WindowsAPICodePack.Taskbar;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace GorusmeKayitlari.Updater.Forms
{
    /// <summary>
    /// Güncelleştirmeyi karşıdan yükleyen form
    /// </summary>
    internal partial class UpdateDownloadForm : Form
    {
        /// <summary>
        /// Güncellemeyi indirmek için web istemcisi
        /// </summary>
        private WebClient webClient;
        /// <summary>
        /// Dosyayı hash'leme iş parçacığı
        /// </summary>
        private BackgroundWorker bgWorker;
        /// <summary>
        /// İndirmek için geçici bir dosya adı.
        /// </summary>
        private string tempFile;
        /// <summary>
        /// İndirilecek dosyanın MD5 hash'i.
        /// </summary>
        private string md5;
        /// <summary>
        /// Kalan süreyi hesaplamak için.
        /// </summary>
        private Stopwatch swDownload;
        /// <summary>
        /// Başlat çubuğundaki program simgesi üzerinde progressbar kullanmak için.
        /// </summary>
        private TaskbarManager taskbarPrgBar;
        /// <summary>
        /// İndirilen dosyanın geçici dosya yolunu alır.
        /// </summary>
        internal string TempFilePath { get { return this.tempFile; } }
        /// <summary>
        /// Yeni bir UpdateDownloadForm oluşturur.
        /// </summary>
        /// <param name="location"></param>
        /// <param name="md5"></param>
        /// <param name="programIcon"></param>

        internal UpdateDownloadForm(Uri location, string md5, Icon programIcon)
        {
            InitializeComponent();

            if (programIcon != null) { this.Icon = programIcon; }
            this.tempFile = Path.GetTempFileName();
            this.md5 = md5;

            this.webClient = new WebClient();
            this.webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(WebClient_DownloadProgressChanged);
            this.webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(WebClient_DownloadFileCompleted);

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(BgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(BgWorker_RunWorkerCompleted);

            this.lblProgress.Text = "İndirme başlıyor...";
            this.lblDownSpeed.Text = "İndirme Hızı: ∞";
            this.lblRemaTime.Text = "Kalan Süre: -";

            this.taskbarPrgBar = TaskbarManager.Instance;
            this.taskbarPrgBar.SetProgressState(TaskbarProgressBarState.Normal);

            this.swDownload = new Stopwatch();
            this.swDownload.Start();

            try { webClient.DownloadFileAsync(location, this.tempFile); }
            catch { this.DialogResult = DialogResult.No; this.Close(); }
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.taskbarPrgBar.SetProgressValue(e.ProgressPercentage, 100);
            this.progressBar.Value = e.ProgressPercentage;
            this.lblProgress.Text = string.Format((e.TotalBytesToReceive == (long)-1 ? "{1} indirildi." : "{0} / {1} indirildi."), FormatBytes(e.TotalBytesToReceive, 1, true), FormatBytes(e.BytesReceived, 1, true));
            this.lblDownSpeed.Text = string.Format("İndirme Hızı: {0}", CalcDownSpeed(e.BytesReceived / this.swDownload.Elapsed.TotalSeconds));
            this.lblRemaTime.Text = string.Format("Kalan Süre: {0}", CalcRemainingTime((e.BytesReceived / this.swDownload.Elapsed.TotalSeconds), (e.TotalBytesToReceive - e.BytesReceived)));
        }

        private string FormatBytes(long bytes, int decimalPlaces, bool showByteType)
        {
            double newBytes = bytes;
            string formatString = "{0";
            string[] byteTypes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            int typerow = 0;

            while (newBytes > 1023)
            {
                newBytes /= 1024d;
                typerow++;
            }

            if (decimalPlaces > 0) { formatString += ":0."; }
            for (int i = 0; i < decimalPlaces; i++)
            {
                formatString += "0";
            }
            formatString += "}";

            if (showByteType) { formatString += " " + byteTypes[typerow]; }

            return string.Format(formatString, newBytes);
        }
        private static string CalcDownSpeed(double Speed)
        {
            byte sira = 0;
            double hiz = Speed;
            string[] byteTypes = { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
            while (hiz > 1023)
            {
                sira++;
                hiz /= 1024d;
            }
            return string.Format("{0} {1}/sn", hiz.ToString("0.00"), byteTypes[sira]);
        }
        private static string CalcRemainingTime(double Speed, double kalan_boyut)
        {
            double sure_sn = kalan_boyut / Speed;
            byte dk = 0;
            byte saat = 0;

            while (sure_sn > 59)
            {
                dk++;
                sure_sn /= 60d;
                if (dk > 59)
                {
                    saat++;
                    dk /= 60;
                }
            }

            return string.Format("{2}{1}{0}"
                    , (sure_sn > 0 ? sure_sn.ToString("0.0") + " sn" : string.Empty)
                    , (dk > 0 ? dk.ToString() + " dk " : string.Empty)
                    , (saat > 0 ? saat.ToString() + " saat " : string.Empty));
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                this.DialogResult = DialogResult.No;
                this.Close();
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            else
            {
                lblProgress.Text = "İndirme Doğrulanıyor...";
                progressBar.Style = ProgressBarStyle.Marquee;
                bgWorker.RunWorkerAsync(new string[] { this.tempFile, this.md5 });
            }
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            string file = ((string[])e.Argument)[0];
            string updateMd5 = ((string[])e.Argument)[1];

            if (Hasher.HashFile(file, HasType.MD5) != updateMd5)
            {
                e.Result = DialogResult.No;
            }
            else { e.Result = DialogResult.OK; }
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.DialogResult = (DialogResult)e.Result;
        }

        private void UpdateDownloadForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (webClient.IsBusy)
            {
                webClient.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
            if (bgWorker.IsBusy)
            {
                bgWorker.CancelAsync();
                this.DialogResult = DialogResult.Abort;
            }
            this.taskbarPrgBar.SetProgressState(TaskbarProgressBarState.NoProgress);
        }
    }
}
