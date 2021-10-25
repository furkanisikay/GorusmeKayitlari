using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Objects;
using System;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Reminder.Formlar
{
    public partial class HatirlatmaEkle : Form
    {
        #region Members
        /// <summary>
        /// Hatırlatma id'si.
        /// </summary>
        public int NesneId { get; }
        /// <summary>
        /// Kullanıcının Açmış olduğu oturum.
        /// </summary>
        public Oturum KullaniciOturum { get; }
        public Hatirlatma DuzenlenmisHatirlatma { get; private set; }
        private bool _degisiklikyapildi = false;
        public bool DegisiklikYapildi { get { return _degisiklikyapildi; } }
        public bool Silindi { get; private set; }
        private ConnectionManager cmHatirlatma = ConnectionManager.Instance;
        #endregion
        #region Constructor
        /// <summary>
        /// Hatırlatma Ekle formu oluşturur.
        /// </summary>
        /// <param name="KullaniciOturum">Kullanıcının açmış olduğu oturum.</param>
        public HatirlatmaEkle(Oturum KullaniciOturum)
        {
            InitializeComponent();
            this.KullaniciOturum = KullaniciOturum;
            this.NesneId = -1;
            _EkleForm();
        }
        /// <summary>
        /// Belirtilen Hatırlatma nesnesi bilgilerine göre güncelleme formunu açar.
        /// </summary>
        /// <param name="hatirlatma">Güncellenecek bilgileri içeren hatırlatma nesnesi</param>
        /// <param name="KullaniciOturum">Kullanıcının açmış olduğu oturum.</param>
        public HatirlatmaEkle(Hatirlatma hatirlatma, Oturum KullaniciOturum)
        {
            InitializeComponent();
            this.KullaniciOturum = KullaniciOturum;
            this.NesneId = hatirlatma.Id;
            _IcerikAyarla(hatirlatma, IslemButonlariDurumu.Guncelle);
        }
        #endregion
        #region Form Ayarlama Fonksiyonları
        private void _EkleForm()
        {
            _IcerikAyarla(new Hatirlatma(-1, string.Empty, DateTime.Now), IslemButonlariDurumu.Ekle);
        }
        private void _IcerikAyarla(Hatirlatma hatirlatma, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(btnEkleGuncelleSil, () => { btnEkleGuncelleSil.Durum = durum; });
            Delegates.Value.Set(dtpTarih, hatirlatma.Tarih);
            Delegates.Value.Set(dtpSaat, hatirlatma.Tarih);
            Delegates.Text.Set(txtMetin, hatirlatma.Metin);
        }
        private Hatirlatma _IceriktenHatirlatmaOlustur()
        {
            cErrProMain.Clear();
            string metin = Delegates.Text.Get(txtMetin);
            DateTime tarih1 = Delegates.Value.Get(dtpTarih);
            DateTime tarih2 = Delegates.Value.Get(dtpSaat);
            DateTime tarih = new DateTime(tarih1.Year, tarih1.Month, tarih1.Day, tarih2.Hour, tarih2.Minute, tarih2.Second);
            if (string.IsNullOrEmpty(txtMetin.Text) || DateTime.Compare(tarih, DateTime.Now) < 0)
            {
                if (string.IsNullOrEmpty(txtMetin.Text))
                {
                    cErrProMain.SetError(txtMetin, "Bu bilgi zorunludur.");
                }
                if (DateTime.Compare(tarih, DateTime.Now) < 0)
                {
                    cErrProMain.SetError(dtpTarih, "Hatırlatma tarihi şuanki tarihten önce olamaz");
                    cErrProMain.SetError(dtpSaat, "Hatırlatma tarihi şuanki tarihten önce olamaz.");
                }
                return null;
            }
            else
            {
                return new Hatirlatma(this.NesneId, metin, tarih);
            }
        }
        #endregion
        #region HatirlatmaEkle Form Kodları
        private void HatirlatmaEkle_Load(object sender, EventArgs e)
        {
            if (!Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, DigerYetkiler.HatirlatmaGoruntule, KullaniciOturum))
            {
                this.Close();
            }
            Optimizasyon.Delagate(this, () => { this.AcceptButton = btnEkleGuncelleSil.EkleGuncelleButton; });
        }
        private void HatirlatmaEkle_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmHatirlatma?.Dispose();
        }
        #endregion
        #region BtnEkleGuncelleSil Fonksiyonları
        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            IslemButonlariDurumu durum = IslemButonlariDurumu.None;
            Optimizasyon.Delagate(btnEkleGuncelleSil, () => { durum = btnEkleGuncelleSil.Durum; });
            if (Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, (durum == IslemButonlariDurumu.Ekle ? DigerYetkiler.HatirlatmaEkle : DigerYetkiler.HatirlatmaDuzenle), KullaniciOturum)
                )
            {
                Hatirlatma ht = _IceriktenHatirlatmaOlustur();
                bool sonuc = false;
                if (ht != null)
                {
                    switch (durum)
                    {
                        case IslemButonlariDurumu.Ekle:
                            sonuc = await Reminder.Hatirlatmalar.Ekle(ht, cmHatirlatma);
                            break;
                        case IslemButonlariDurumu.Guncelle:
                            DuzenlenmisHatirlatma = ht;
                            sonuc = await Reminder.Hatirlatmalar.Guncelle(ht, cmHatirlatma);
                            break;
                        default:
                            Core.Extensions.Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![HatirlatmaEkle]"));
                            break;
                    }
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Hatırlatma", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc) { _degisiklikyapildi = true; this.Close(); }

            }
        }
        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, DigerYetkiler.HatirlatmaSil, KullaniciOturum))
            {
                bool sonuc = await Reminder.Hatirlatmalar.Sil(NesneId, cmHatirlatma);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Hatırlatma", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    Silindi = true;
                    this.Close();
                }
            }
        }
        #endregion

        private void HatirlatmaEkle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Optimizasyon.ArkaplandaCalistir(() => { btnEkleGuncelleSil.EkleGuncelleButton.PerformClick(); });
            }
            if (e.KeyCode == Keys.Delete && btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Guncelle)
            {
                Optimizasyon.ArkaplandaCalistir(() => { btnEkleGuncelleSil.SilButton.PerformClick(); });
            }
        }
    }
}
