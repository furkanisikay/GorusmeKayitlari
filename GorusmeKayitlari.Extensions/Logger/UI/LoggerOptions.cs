using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Logger.UI
{
    public partial class LoggerOptions : UserControl,IExtensionUI
    {
        public LoggerOptions()
        {
            InitializeComponent();
            this.Text = "Hata kaydedici ayarları";
            MainLoad();
        }
        public string HataKaydiDizini { get { return txtDizin.Text; } }

        private void MainLoad()
        {
            string LoggerPath = Regedit.Ayar_Oku("Logger-Path", Application.StartupPath, Regedit.rkMain);
            if (string.IsNullOrEmpty(LoggerPath))
            {
                txtDizin.Text = Application.StartupPath + "\\logs";
            }
            else { txtDizin.Text = LoggerPath; }
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.Description = "Hata kayıtlarının kaydedileceği dizini seçin.";
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            fbd.ShowNewFolderButton = true;
            if(fbd.ShowDialog() == DialogResult.OK)
            {
                txtDizin.Text = fbd.SelectedPath;
            }
        }

        public void AyarlariKaydet()
        {
            Regedit.Ayar_Kaydet("Logger-Path", HataKaydiDizini, Regedit.rkMain, true, false);
        }
    }
}
