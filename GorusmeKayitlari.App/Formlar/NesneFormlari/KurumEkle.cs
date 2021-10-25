using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.App.Formlar
{
    public partial class KurumEkle : Form
    {
        public KurumEkle(Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = -1;
            _EkleForm();
        }
        internal KurumEkle(Kurum kurum, Oturum oturum, bool GosterimModu = false)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            this.GosterimModu = GosterimModu;
            NesneId = (kurum.Id > 0 ? kurum.Id : -1);
            _IcerikAyarla(kurum, "Kurum Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kurum_Duzenle, IslemButonlariDurumu.Guncelle);
        }
        internal KurumEkle(int Id, Oturum oturum, bool GosterimModu = false)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            this.GosterimModu = GosterimModu;
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                Kurum kurum = await Kurumlar.Getir(Id, App.Instance.ConnManager);
                if (kurum != null)
                {
                    _IcerikAyarla(kurum, "Kurum Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kurum_Duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    MsgBox.Hata(this, "Kurum Bulunamadı!");
                }
            });
            act();
        }

        private bool _degisiklikyapildi = false;
        public bool DegisiklikYapildi { get { return _degisiklikyapildi; } }
        public int NesneId { get; }
        public Oturum KulOturum { get; }
        public bool GosterimModu { get; private set; }

        private void _EkleForm()
        {
            _IcerikAyarla(new Kurum(-1), "Kurum Ekle", GorusmeKayitlari.Resources.NesneResimleri.Kurum_Ekle, IslemButonlariDurumu.Ekle);
        }
        private void _IcerikAyarla(Kurum kurum, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            Optimizasyon.Delagate(this.txtAd, () => { this.txtAd.Text = kurum.Ad; });
            Optimizasyon.Delagate(this.nsKategori, () => { this.nsKategori.SecilenNesneId = kurum.Kategori != null ? kurum.Kategori.Id : -1; });
            Optimizasyon.Delagate(this.nsYetkili, () => { this.nsYetkili.SecilenNesneId = kurum.Yetkili != null ? kurum.Yetkili.Id : -1; });
            if (kurum.IletisimBilgileri != null)
            {
                Optimizasyon.Delagate(this.txtTelefon, () => { this.txtTelefon.Text = kurum.IletisimBilgileri.Telefon; });
                Optimizasyon.Delagate(this.txtFax, () => { this.txtFax.Text = kurum.IletisimBilgileri.Fax; });
                Optimizasyon.Delagate(this.txtEPosta, () => { this.txtEPosta.Text = kurum.IletisimBilgileri.Eposta; });
                Optimizasyon.Delagate(this.txtAdres, () => { this.txtAdres.Text = kurum.IletisimBilgileri.Adres; });
            }
            Optimizasyon.Delagate(this.txtAciklama, () => { this.txtAciklama.Text = kurum.Aciklama; });
            if (GosterimModu) { SetReadOnly(); }
        }

        private void SetReadOnly()
        {
            Optimizasyon.Delagate(txtAd, () => { txtAd.ReadOnly = true; });
            Optimizasyon.Delagate(nsKategori, () => { nsKategori.NesneSecButton.Enabled = true; });
            Optimizasyon.Delagate(nsYetkili, () => { nsYetkili.NesneSecButton.Enabled = true; });
            Optimizasyon.Delagate(txtTelefon, () => { txtTelefon.ReadOnly = true; });
            Optimizasyon.Delagate(txtFax, () => { txtFax.ReadOnly = true; });
            Optimizasyon.Delagate(txtAdres, () => { txtAdres.ReadOnly = true; });
            Optimizasyon.Delagate(txtEPosta, () => { txtEPosta.ReadOnly = true; });
            Optimizasyon.Delagate(txtAciklama, () => { txtAciklama.ReadOnly = true; });
            Optimizasyon.Delagate(btnEkleGuncelleSil, () => { btnEkleGuncelleSil.Enabled = true; });
        }
        private async Task<Kurum> _IceriktenYetkiliOlustur()
        {
            cErrProMain.Clear();
            if (string.IsNullOrEmpty(txtAd.Text)
                || nsKategori.SecilenNesneId == -1
                || nsYetkili.SecilenNesneId == -1)
            {
                if (string.IsNullOrEmpty(txtAd.Text))
                {
                    cErrProMain.SetError(txtAd, "Bu bilgi zorunludur.");
                }
                if (nsKategori.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsKategori, "Bu bilgi zorunludur.");
                }
                if (nsYetkili.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsYetkili, "Bu bilgi zorunludur.");
                }
                return null;
            }
            else
            {
                return new Kurum(NesneId
                    , await Kategoriler.Getir(nsKategori.SecilenNesneId, App.Instance.ConnManager)
                    , txtAd.Text
                    , await Yetkililer.Getir(nsYetkili.SecilenNesneId, App.Instance.ConnManager)
                    , new IletisimBilgileri(txtTelefon.Text
                    , txtEPosta.Text
                    , txtFax.Text
                    , txtAdres.Text)
                    , txtAciklama.Text);
            }
        }
        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.KurumEkle : NesneYetkileri.KurumDuzenle)))
            {
                bool sonuc = false;
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await Kurumlar.Ekle(await _IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await Kurumlar.Guncelle(await _IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![KurumEkle]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kurum", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc) { _degisiklikyapildi = true; this.Close(); }
            }
        }
        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula(NesneYetkileri.KurumSil))
            {
                bool sonuc = await Kurumlar.Sil(NesneId, App.Instance.ConnManager);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kurum", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    this.Close();
                }
            }
        }
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void KurumEkle_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.KurumGoruntule))
            {
                this.Close();
            }
        }
        private bool _YetkiSorgula<T>(T Yetki, bool msg = true)
        {
            return Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, Yetki, this.KulOturum, false);
        }
    }
}
