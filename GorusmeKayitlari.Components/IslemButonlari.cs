using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace GorusmeKayitlari.Components
{
    [DefaultEvent("EkleGuncelleTiklandiginda")]
    public partial class IslemButonlari : UserControl
    {
        public IslemButonlari()
        {
            InitializeComponent();
        }
        [Description("Ekle/Güncelle Butonuna Tıklandığında Gerçekleşir."),Category("Action")]
        public event EventHandler EkleGuncelleTiklandiginda;
        [Description("Sil Butonuna Tıklandığında Gerçekleşir."), Category("Action")]
        public event EventHandler SilTiklandiginda;
        private IslemButonlariDurumu _durum = IslemButonlariDurumu.Guncelle;
        public IslemButonlariDurumu Durum
        {
            get { return _durum; }
            set
            {
                _durum = value;
                _DurumaGoreİcerikDegistir(_durum);
            }
        }
        public IButtonControl EkleGuncelleButton { get { return btnEkleGuncelle; } }
        public IButtonControl SilButton { get { return btnSil; } }

        private void _DurumaGoreİcerikDegistir(IslemButonlariDurumu Durum)
        {
            switch (Durum)
            {
                case IslemButonlariDurumu.Ekle:
                    _IcerigiEkleyeGoreAyarla();
                    break;
                case IslemButonlariDurumu.Guncelle:
                    _IcerigiGuncelleyeGoreAyarla();
                    break;
                default:
                    break;
            }
        }
        private void _IcerigiEkleyeGoreAyarla()
        {
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.ColumnStyles.Clear(); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F)); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.Controls.Clear(); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.Controls.Add(this.btnEkleGuncelle, 0, 0); });
            Optimizasyon.Delagate(btnEkleGuncelle, () => { btnEkleGuncelle.Text = "Ekle"; });
            Optimizasyon.Delagate(btnSil, () => { btnSil.Visible = false; });
        }
        private void _IcerigiGuncelleyeGoreAyarla()
        {
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.ColumnStyles.Clear(); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33F)); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 66.67F)); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.Controls.Clear(); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.Controls.Add(this.btnSil, 0, 0); });
            Optimizasyon.Delagate(tlpMain, () => { this.tlpMain.Controls.Add(this.btnEkleGuncelle, 1, 0); });
            Optimizasyon.Delagate(btnEkleGuncelle, () => { btnEkleGuncelle.Text = "Güncelle"; });
            Optimizasyon.Delagate(btnSil, () => { btnSil.Visible = true; });
        }
        private void btnEkleGuncelle_Click(object sender, EventArgs e)
        {
            if(EkleGuncelleTiklandiginda != null) { EkleGuncelleTiklandiginda(sender, e); }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (SilTiklandiginda != null) { SilTiklandiginda(sender, e); }
        }

    }
}
