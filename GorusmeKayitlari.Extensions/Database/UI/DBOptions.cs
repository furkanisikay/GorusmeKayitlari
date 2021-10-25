using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;
using System;
using System.IO;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Database.UI
{
    public partial class DBOptions : UserControl, IExtensionUI
    {
        #region Constructor
        public DBOptions()
        {
            InitializeComponent();
            this.Text = "Veritabanı ayarları";
            MainLoad();
        }
        #endregion

        #region DBOptions Members
        public string DBFileName { get; private set; }
        public string DBFolder { get; private set; }

        public void AyarlariKaydet()
        {
            Regedit.Ayar_Kaydet("Database-Path", DBFolder, Regedit.rkMain, true, false);
            Regedit.Ayar_Kaydet("Database-File-Name", DBFileName, Regedit.rkMain, true, false);
        }
        #endregion

        #region Methods
        private void btnGozat_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Lütfen veritabanı dosyanızı seçin.";
            ofd.Filter = "Veritabanı Dosyaları|*.accdb";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Multiselect = false;
            DialogResult drSonuc = DialogResult.Cancel;
            while (drSonuc == DialogResult.Cancel)
            {
                drSonuc = ofd.ShowDialog();
                if (drSonuc == DialogResult.Cancel && MessageBox.Show(this, "Hata", "Dosya Seçilmedi!", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
                {
                    return;
                }
            }
            if (!string.IsNullOrEmpty(ofd.FileName) && File.Exists(ofd.FileName))
            {
                SetText(Path.GetFileName(ofd.FileName), Path.GetDirectoryName(ofd.FileName));
            }
        }
        #endregion

        private void MainLoad()
        {
            SetText(Regedit.Ayar_Oku("Database-File-Name", "", Regedit.rkMain, false), Regedit.Ayar_Oku("Database-Path", "", Regedit.rkMain, false));
        }

        private void SetText(string DBFileName, string DBFolder)
        {
            this.DBFileName = DBFileName;
            this.DBFolder = DBFolder;
            Delegates.Text.Set(txtDBFolder, DBFileName);
            Delegates.Text.Set(txtDBAd, DBFolder);
        }
    }
}
