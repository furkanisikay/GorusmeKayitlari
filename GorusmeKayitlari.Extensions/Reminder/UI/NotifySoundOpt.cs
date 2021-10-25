using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Extensions.Reminder.Class;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Reminder.UI
{
    public partial class NotifySoundOpt : UserControl,IExtensionUI
    {
        public NotifySoundOpt()
        {
            InitializeComponent();
            this.Text = "Bildirim sesi ayarları";
            this.BildSesi = RegeditBilgisiGetir();
        }
        
        public BildirimSesi BildSesi { get; private set; }

        private BildirimSesi RegeditBilgisiGetir()
        {
            BildirimSesi bSesi = new BildirimSesi
            {
                Aktif = bool.Parse(Regedit.Ayar_Oku("Reminder-Notify-Sound", "false", Regedit.rkMain, false)),
                Dosya = Regedit.Ayar_Oku("Reminder-Notify-Sound-File", string.Empty, Regedit.rkMain, false)
            };
            return bSesi;
        }

        private void chckNotfSound_CheckedChanged(object sender, EventArgs e)
        {
            if (BildSesi != null)
            {
                this.BildSesi.Aktif = Delegates.Checked.Get(chckNotfSound);
                Delegates.Enabled.Set(panel1, this.BildSesi.Aktif);
            }
        }

        private void btnNotSoundGozat_SecilenDosyaDegistiginde(object sender, string e)
        {
            BildSesi.Dosya = e;
            Delegates.Text.Set(txtNotSound, e);
        }

        private void NotifySoundOpt_Load(object sender, EventArgs e)
        {
            Delegates.Checked.Set(chckNotfSound, BildSesi.Aktif);
            Delegates.Text.Set(txtNotSound, BildSesi.Dosya);
        }

        public void AyarlariKaydet()
        {
            Regedit.Ayar_Kaydet("Reminder-Notify-Sound", BildSesi.Aktif.ToString(), Regedit.rkMain, true, false);
            Regedit.Ayar_Kaydet("Reminder-Notify-Sound-File", BildSesi.Dosya.ToString(), Regedit.rkMain, true, false);
        }
    }
}
