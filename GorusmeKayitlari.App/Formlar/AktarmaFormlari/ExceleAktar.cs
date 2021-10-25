using GorusmeKayitlari.App.AktarmaFormlari;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.DisariAktar;
using GorusmeKayitlari.Core.DisariAktar.Excel;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Extensions.Logger;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.Components.ExporterForms
{
    public partial class ExceleAktar : Form
    {
        public ExceleAktar()
        {
            InitializeComponent();
            this.lstGorusmeler = null;
            CheckForIllegalCrossThreadCalls = false;
        }
        public ExceleAktar(ListView lstGorusmeler)
        {
            InitializeComponent();
            this.lstGorusmeler = lstGorusmeler;
            _SetThisTheme(ExcelAraclari._GetDefaultTheme(this));
            CheckForIllegalCrossThreadCalls = false;
        }

        public ListView lstGorusmeler { get; }

        private void chckAcmaSifresi_CheckedChanged(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(txtAcmaSifresi, () => { txtAcmaSifresi.UseSystemPasswordChar = !_IsChecked(chckAcmaSifresi); });
            Optimizasyon.Delagate(chckAcmaSifresi, () => { ttMain.SetToolTip(chckAcmaSifresi, "Dosya Açma Şifresini " + (_IsChecked(chckAcmaSifresi) ? "Gizler" : "Görünür Yapar.")); });
        }

        private void chckYazmaSifresi_CheckedChanged(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(txtYazmaSifresi, () => { txtYazmaSifresi.UseSystemPasswordChar = !_IsChecked(chckYazmaSifresi); });
            Optimizasyon.Delagate(chckYazmaSifresi, () => { ttMain.SetToolTip(chckYazmaSifresi, "Dosya Yazma Şifresini " + (_IsChecked(chckYazmaSifresi) ? "Gizler" : "Görünür Yapar.") + ""); });
        }

        private void btnTemaDegistir_Click(object sender, EventArgs e)
        {
            using (ExcelAktarTema eatForm = new ExcelAktarTema(_GetThisTheme(), _GetThisThemeName()))
            {
                try
                {
                    eatForm.ShowDialog();
                    _SetThisTheme(eatForm.Tema);
                    _SetControlText(txtIcerikTemasi, eatForm.Tema == ExcelAraclari._GetDefaultTheme(this) ? "(Varsayılan)" : string.IsNullOrEmpty(eatForm.TemaAdi) ? "(isimsiz)" : eatForm.TemaAdi);
                }
                catch (Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Excel Tema Değiştime Penceresi Açılırken Hata Oluştu!"); }
            }
        }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xlsx";
            sfd.Filter = "Görüşme Kayıtları Excel Dökümü | *.xlsx";
            sfd.Title = "Dosyanın Kaydedileceği Dizini Seçin.";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.OverwritePrompt = true;
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
            _SetControlText(txtPath, sfd.FileName);
            sfd.Dispose();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (Gereksinimler.GetExcel())
            {
                if (!string.IsNullOrEmpty(_GetControlText(txtPath)))
                {
                    BackgroundWorker bg = new BackgroundWorker();
                    bg.DoWork += new DoWorkEventHandler(Bg_DoWork);
                    bg.RunWorkerAsync();
                }
                else
                {
                    MsgBox.Hata(this, "Dosya Seçilmedi ");
                }
            }
            else { MsgBox.Hata(this, "Devam edebilmek için 'Microsoft Excel' programını kurmalısınız."); }
        }

        private void Bg_DoWork(object sender, DoWorkEventArgs e)
        {
            _Yukleniyor(true);
            string sure = string.Empty;
            bool sonuc = _Kaydet(out sure);
            _Yukleniyor(false);
            if (sonuc)
            {
                if (MsgBox.Bilgi(this, "Aktarım " + sure + "'de Tamamlandı!\nAktarım Dosyası Çalıştırılsın mı?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo() { Arguments = "/c start " + _GetControlText(txtPath) + "", FileName = "cmd.exe", CreateNoWindow = true, WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden });
                    }
                    catch (Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Dosya Açılırken Bir Oluştu!"); }
                }
            }
            else
            {
                MsgBox.Hata(this, "Görüşmeler Aktarılırken Bir Oluştu!");
            }
            _SetControlText(txtPath, "");
        }

        private bool _Kaydet(out string sure)
        {
            System.Diagnostics.Stopwatch kronometre = new System.Diagnostics.Stopwatch();
            kronometre.Start();
            bool _sonuc = Gorusmeler.ExceleAktar(new GorusmeAktar(this.lstGorusmeler,
                new ExcelDosyaArgs(_GetControlText(txtPath), Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, _GetControlText(txtAcmaSifresi), _GetControlText(txtYazmaSifresi), _GetThisTheme())));
            kronometre.Stop();
            string _sure = DigerFonksiyonlar.MillisecondsToTimeString(kronometre.ElapsedMilliseconds);
            sure = _sure;
            return _sonuc;
        }

        private void _Yukleniyor(bool Goster)
        {
            Delegates.Location.Set(yukleniyor1, new Point(12, (Goster ? 0 : Delegates.Width.Get(this) + 10)));
            Delegates.Visible.Set(yukleniyor1, Goster);
            Delegates.Enabled.Set(btnKaydet, !Goster);
            Delegates.Enabled.Set(gBoxIcerik, !Goster);
        }


        private string _GetThisThemeName()
        {
            string ad = Delegates.Text.Get(txtIcerikTemasi);
            if (ad == "(Varsayılan)" || ad == "(isimsiz)") { ad = string.Empty; }
            return ad;
        }
        private bool _IsChecked(CheckBox chck)
        {
            bool secili = false;
            try { Optimizasyon.Delagate(chck, () => { secili = chck.Checked; }); }
            catch (Exception ex) { Logger.Log(ex); secili = false; }
            return secili;
        }
        private void _SetThisTheme(ExcelIcerikTemasi Tema)
        {
            Delegates.Tag.Set(txtIcerikTemasi, Tema);
        }
        private ExcelIcerikTemasi _GetThisTheme()
        {
            ExcelIcerikTemasi tema = ExcelAraclari._GetDefaultTheme(this);
            try { tema = Delegates.Tag.Get(txtIcerikTemasi) as ExcelIcerikTemasi; }
            catch (Exception ex) { Logger.Log(ex); tema = ExcelAraclari._GetDefaultTheme(this); }
            return tema;
        }


        private string _GetControlText(Control ctrl)
        {
            return Delegates.Text.Get(ctrl);
        }
        private void _SetControlText(Control ctrl, string yazi)
        {
            Delegates.Text.Set(ctrl, yazi);
        }
    }
}
