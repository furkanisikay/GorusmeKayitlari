using GorusmeKayitlari.Core;
using GorusmeKayitlari.Extensions.Reminder;
using GorusmeKayitlari.Extensions.Reminder.Class;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace GorusmeKayitlari.Reminder.Notify
{
    public partial class Notify : Form
    {
        Hatirlatma hatirlatma;
        string TaskName;
        public bool Ertelendi { get; private set; }
        public int ErtelemeSuresi { get; private set; }

        private OtomatikKapatma OtoKapanma { get; set; }
        public Notify(Hatirlatma hatirlatma, string TaskName)
        {
            InitializeComponent();
            this.TaskName = TaskName;
            this.hatirlatma = hatirlatma;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblMetin.Text = hatirlatma.Metin;
            KonumAyarla();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {
            Ertelendi = false;
            Kapat();
        }

        private void KonumAyarla()
        {
            int x = Screen.PrimaryScreen.WorkingArea.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Location = new Point(x, y);
        }
        

        private void Kapat()
        {
            this.Close();
        }

        private void btnDahaSonra_Click(object sender, EventArgs e)
        {
            cmsDahaSonra.Show(MousePosition);
        }

        private void cmsDahaSonra_ItemClicked(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Tag != null)
            {
                ErtelemeSuresi = int.Parse(((ToolStripMenuItem)sender).Tag.ToString());
                Ertelendi = true;
                Kapat();
            }
        }

        int progressedWidth = 0;

        private void tmrKaymaEffct_Tick(object sender, EventArgs e)
        {
            if (progressedWidth == this.Width)
            {
                tmrKaymaEffct.Stop();
                pboxHatirlatma.Visible = true;
                BildirimSesCal();
                OtomatikKapanmaAyarla();
            }
            else
            {
                this.Location = new Point(this.Location.X - 1, this.Location.Y);
                if ((progressedWidth % 25) == 0)
                {
                    pboxHatirlatma.Visible = !pboxHatirlatma.Visible;
                }
                progressedWidth++;
            }
        }

        private void Notify_Shown(object sender, EventArgs e)
        {
            tmrKaymaEffct.Start();
        }
        private void BildirimSesCal()
        {
            BildirimSesi bSesi = new BildirimSesi();
            RegistryKey rk = Regedit.GetMainRegKey();
            bSesi.Aktif = bool.Parse(Regedit.Ayar_Oku("Reminder-Notify-Sound", "false", rk, false));
            if (bSesi.Aktif)
            {
                bSesi.Dosya = Regedit.Ayar_Oku("Reminder-Notify-Sound-File", string.Empty, rk, false);
                if (File.Exists(bSesi.Dosya))
                {
                    using (System.Media.SoundPlayer player = new System.Media.SoundPlayer(bSesi.Dosya))
                    {
                        player.Play();
                    }
                }
            }
        }

        private void OtomatikKapanmaAyarla()
        {
            OtoKapanma = new OtomatikKapatma();
            RegistryKey rk = Regedit.GetMainRegKey();
            OtoKapanma.Aktif = bool.Parse(Regedit.Ayar_Oku("Reminder-Auto-Close", "false", rk, false));
            if (OtoKapanma.Aktif)
            {
                OtoKapanma.Sure = Convert.ToInt32(Regedit.Ayar_Oku("Reminder-Auto-Close-Time", string.Empty, rk, false));
                tmrOtoKapat.Start();
                kapanmayaKalanSure = OtoKapanma.Sure;
            }
        }

        private int kapanmayaKalanSure = 0;
        private void tmrOtoKapat_Tick(object sender, EventArgs e)
        {
            if(kapanmayaKalanSure > 0)
            {
                Delegates.Text.Set(btnTamam,"Tamam(" + kapanmayaKalanSure.ToString() + ")");
                kapanmayaKalanSure--;
            }
            else { this.Ertelendi = true; this.ErtelemeSuresi = 0; Kapat(); }
        }
    }
}
