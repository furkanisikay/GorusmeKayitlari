using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;
using GorusmeKayitlari.Extensions.Reminder.Class;
using System;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Reminder.UI
{
    public partial class AutoCloseOptions : UserControl, IExtensionUI
    {
        public AutoCloseOptions()
        {
            InitializeComponent();
            this.Text = "Otomatik kapanma ayarları";
            this.OtoKapanma = RegeditBilgisiGetir();
        }
        public OtomatikKapatma OtoKapanma { get; private set; }

        private void ReminderOptions_Load(object sender, EventArgs e)
        {
            Delegates.Checked.Set(chckOtoKapat, OtoKapanma.Aktif);
            tbarOtoKapat.Value = OtoKapanma.Sure;
        }


        private OtomatikKapatma RegeditBilgisiGetir()
        {
            OtomatikKapatma otoKapat = new OtomatikKapatma()
            {
                Aktif = bool.Parse(Regedit.Ayar_Oku("Reminder-Auto-Close", "true", Regedit.rkMain, false)),
                Sure = int.Parse(Regedit.Ayar_Oku("Reminder-Auto-Close-Time", "15", Regedit.rkMain, false))
            };
            return otoKapat;
        }

        #region Otomatik Kapatma 
        private void TextAyarla(int Sure)
        {
            Delegates.Text.Set(lblOtoKapat, string.Format("Hatırlatma penceresi görüntülendikten {0} saniye sonra pencere otomatik kaybolur.", Sure.ToString()));
        }
        private void tbarOtoKapat_ValueChanged(object sender, EventArgs e)
        {
            this.OtoKapanma.Sure = Delegates.Value.Get(tbarOtoKapat);
            TextAyarla(this.OtoKapanma.Sure);
        }

        private void chckOtoKapat_CheckedChanged(object sender, EventArgs e)
        {
            this.OtoKapanma.Aktif = Delegates.Checked.Get(chckOtoKapat);
            Delegates.Enabled.Set(panel1, this.OtoKapanma.Aktif);
        }

        public void AyarlariKaydet()
        {
            Regedit.Ayar_Kaydet("Reminder-Auto-Close", OtoKapanma.Aktif.ToString(), Regedit.rkMain, true, false);
            Regedit.Ayar_Kaydet("Reminder-Auto-Close-Time", OtoKapanma.Sure.ToString(), Regedit.rkMain, true, false);
        }

        #endregion


    }
}
