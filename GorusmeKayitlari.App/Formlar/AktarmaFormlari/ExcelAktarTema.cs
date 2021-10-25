using GorusmeKayitlari.Components.ExcelBilesenleri;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DisariAktar.Excel;
using System;
using System.IO;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using GorusmeKayitlari.Extensions.Logger;
using System.Drawing;
using GorusmeKayitlari.Core.MsgBox;
using System.Threading;

namespace GorusmeKayitlari.App.AktarmaFormlari
{
    public partial class ExcelAktarTema : Form
    {
        #region Constructors
        public ExcelAktarTema()
        {
            InitializeComponent();
            _SetThisTheme(ExcelAraclari._GetDefaultTheme(this));
        }
        public ExcelAktarTema(ExcelIcerikTemasi Tema, string temaadi)
        {
            InitializeComponent();
            if (Tema != null)
            {
                _SetThisTheme(Tema);
                _SetThemeName(temaadi);
            }
            else
            {
                _SetThisTheme(ExcelAraclari._GetDefaultTheme(this));
                _SetThemeName("(Varsayılan)");
            }
        }
        #endregion

        #region ExcelAktarTema Members
        public ExcelIcerikTemasi tema = null;
        public ExcelIcerikTemasi Tema { get { return tema; } }
        public string TemaAdi { get { return _GetThemeName(); } set { _SetThemeName(value); } }
        #endregion

        #region Control Events

        private void btnIceriAktar_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".gk.xml";
            ofd.Filter = "Görüşme Kayıtları Excel Tema Dosyası | *.gk.xml";
            ofd.SupportMultiDottedExtensions = true;
            ofd.Title = "Dosyanın Kaydedildiği Dizini Seçin.";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult drCevap = DialogResult.Cancel;
            while (drCevap == DialogResult.Cancel)
            {
                drCevap = ofd.ShowDialog();
                if (drCevap == DialogResult.Cancel && MsgBox.Hata(this, "Dosya Seçilmedi!", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
                {
                    ofd.Dispose();
                    return;
                }
            }
            if (!string.IsNullOrEmpty(ofd.FileName) && File.Exists(ofd.FileName))
            {
                string temaadi = string.Empty;
                ExcelIcerikTemasi tema = ExcelIcerikTemaConverter.XMLToExcelIcerikTema(ofd.FileName,out temaadi);
                if (tema != null)
                {
                    _SetThisTheme(tema);
                    _SetThemeName(temaadi);
                    MsgBox.Bilgi(this, "Tema Başarıyla Yüklendi!");
                }
                else
                {
                    MsgBox.Hata(this, "Tema Yüklenirken Hata Oluştu!");
                }
            }
            else
            {
                MsgBox.Hata(this, "Dosya Seçilmedi veya Seçilen Dosya Bulunamadı!");
            }
            ofd.Dispose();
        }
        private void btnDisariAktar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTemaAdi.Text)) { MsgBox.Hata(this, "Lütfen bir tema adı girin."); }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".gk.xml";
            sfd.Filter = "Görüşme Kayıtları Excel Tema Dosyası | *.gk.xml";
            sfd.SupportMultiDottedExtensions = true;
            sfd.Title = "Dosyanın Kaydedileceği Dizini Seçin.";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = txtTemaAdi.Text;
            DialogResult drCevap = DialogResult.Cancel;
            while (drCevap == DialogResult.Cancel)
            {
                drCevap = sfd.ShowDialog();
                if (drCevap == DialogResult.Cancel && MsgBox.Hata(this, "Dosya Seçilmedi!", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
                {
                    sfd.Dispose();
                    return;
                }
            }
            if (!string.IsNullOrEmpty(sfd.FileName) && !File.Exists(sfd.FileName))
            {
                if (ExcelIcerikTemaConverter._ExcelIcerikTemaToXML(sfd.FileName, _GetThemeName(), _GetThisTheme()))
                {
                    MsgBox.Bilgi(this, "Tema Kaydedildi!");
                }
                else
                {
                    MsgBox.Hata(this, "Tema Kaydedilemedi!");
                }
            }
            else
            {
                MsgBox.Hata(this, "Dosya Seçilmedi veya Seçilen Dosya Adında Dosya Mevcut!");
            }
            sfd.Dispose();
        }
        private void btnGeriDon_Click(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(this, () => { this.tema = _GetThisTheme(); });
            this.Close();
        }
        #endregion

        #region Methods
        private ExcelIcerikTemasi _GetThisTheme()
        {
            ExcelIcerikTemasi tmp = null;
            Optimizasyon.Delagate(excelTema1,() => { tmp = excelTema1._GetThisTheme(); });
            return tmp;
        }
        private void _SetThisTheme(ExcelIcerikTemasi Tema)
        {
            Optimizasyon.Delagate(excelTema1, () => { excelTema1._SetThisTheme(Tema); });
        }
        private string _GetThemeName()
        {
            return Delegates.Text.Get(txtTemaAdi);
        }
        private void _SetThemeName(string ad)
        {
            Delegates.Text.Set(txtTemaAdi,ad);
        }
        #endregion
    }
}
