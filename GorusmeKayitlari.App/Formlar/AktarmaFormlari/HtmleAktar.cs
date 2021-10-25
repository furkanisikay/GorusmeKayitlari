using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DisariAktar;
using GorusmeKayitlari.Core.DisariAktar.Html;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Extensions.Logger;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.Components.ExporterForms
{
    public partial class HtmleAktar : Form
    {
        public HtmleAktar()
        {
            InitializeComponent();
            this.lstGorusmeler = null;
            CheckForIllegalCrossThreadCalls = false;
        }
        public HtmleAktar(ListView lstGorusmeler)
        {
            InitializeComponent();
            this.lstGorusmeler = lstGorusmeler;
            CheckForIllegalCrossThreadCalls = false;
        }

        public ListView lstGorusmeler { get; }

        private void btnGozat_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".html";
            sfd.Filter = "Görüşme Kayıtları Web Dökümü | *.html";
            sfd.Title = "Dosyanın Kaydedileceği Dizini Seçin.";
            sfd.OverwritePrompt = true;
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            DialogResult drCevap = DialogResult.Cancel;
            while (drCevap == DialogResult.Cancel)
            {
                drCevap = sfd.ShowDialog();
                if (drCevap == DialogResult.Cancel && 
                    MsgBox.Hata(this, "Dosya Seçilmedi!", MessageBoxButtons.RetryCancel) != DialogResult.Retry)
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
            if (!string.IsNullOrEmpty(_GetControlText(txtPath)))
            {
                BackgroundWorker bg = new BackgroundWorker();
                bg.DoWork += new DoWorkEventHandler(Bg_DoWork);
                bg.RunWorkerAsync();
            }
            else
            {
                MsgBox.Hata(this, "Dosya Seçilmedi");
            }
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
                    try { System.Diagnostics.Process.Start(_GetControlText(txtPath)); }
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
            bool _sonuc = Gorusmeler.HtmleAktar(new GorusmeAktar(this.lstGorusmeler,
                    new HtmlDosyaArgs(_GetControlText(txtPath))));
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
