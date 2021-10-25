using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Extensions.Logger;
using System;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.App.Formlar
{
    public partial class KullaniciEkle : Form
    {
        public KullaniciEkle(Oturum oturum)
        {
            InitializeComponent();
            NesneId = -1;
            this.KulOturum = oturum;
            _EkleForm();
        }
        internal KullaniciEkle(Kullanici kullanici, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = (kullanici.Id > 0 ? kullanici.Id : -1);
            _IcerikAyarla(kullanici, "Kullanıcı Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kullanici_Duzenle, IslemButonlariDurumu.Guncelle);
        }

        internal KullaniciEkle(int Id)
        {
            InitializeComponent();
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                Kullanici kullanici = await Kullanicilar.Getir(Id, App.Instance.ConnManager);
                if (kullanici != null)
                {
                    _IcerikAyarla(kullanici, "Kullanıcı Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kullanici_Duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    MsgBox.Hata(this, "Kullanıcı Bulunamadı!");
                }
            });
            act();
        }
        private bool _degisiklikyapildi = false;
        public bool DegisiklikYapildi { get { return _degisiklikyapildi; } }
        public int NesneId { get; }
        public Oturum KulOturum { get; }
        private void _EkleForm()
        {
            _IcerikAyarla(new Kullanici(-1), "Kullanıcı Ekle", GorusmeKayitlari.Resources.NesneResimleri.Kullanici_Ekle, IslemButonlariDurumu.Ekle);
        }

        private void _IcerikAyarla(Kullanici kullanici, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            Optimizasyon.Delagate(this.txtAd, () => { this.txtAd.Text = kullanici.Ad; });
            Optimizasyon.Delagate(this.txtSoyad, () => { this.txtSoyad.Text = kullanici.Soyad; });
            Optimizasyon.Delagate(this.txtTelefon, () => { this.txtTelefon.Text = kullanici.IletisimBilgileri.Telefon; });
            Optimizasyon.Delagate(this.txtEPosta, () => { this.txtEPosta.Text = kullanici.IletisimBilgileri.Eposta; });
            Optimizasyon.Delagate(this.txtAciklama, () => { this.txtAciklama.Text = kullanici.Aciklama; });
        }
        private Kullanici _IceriktenYetkiliOlustur()
        {
            cErrProMain.Clear();
            if (string.IsNullOrEmpty(txtAd.Text)
                || string.IsNullOrEmpty(txtSoyad.Text))
            {
                if (string.IsNullOrEmpty(txtAd.Text))
                {
                    cErrProMain.SetError(txtAd, "Bu bilgi zorunludur.");
                }
                if (string.IsNullOrEmpty(txtSoyad.Text))
                {
                    cErrProMain.SetError(txtSoyad, "Bu bilgi zorunludur.");
                }
                return null;
            }
            else
            {
                return new Kullanici(NesneId
                    , txtAd.Text
                    , txtSoyad.Text
                    , new IletisimBilgileri(txtTelefon.Text
                    , txtEPosta.Text
                    , ""
                    , "")
                    , txtAciklama.Text);
            }
        }

        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.KullaniciEkle : NesneYetkileri.KullaniciDuzenle)))
            {
                bool sonuc = false;
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await Kullanicilar.Ekle(_IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await Kullanicilar.Guncelle(_IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![KullaniciEkle]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kullanıcı", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc) { _degisiklikyapildi = true; this.Close(); }
            }
        }

        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula( NesneYetkileri.KullaniciSil))
            {
                bool sonuc = await
                Kullanicilar.Sil(NesneId, App.Instance.ConnManager);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kullanıcı", btnEkleGuncelleSil.Durum, sonuc);
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

        private void KullaniciEkle_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.KullaniciGoruntule))
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
