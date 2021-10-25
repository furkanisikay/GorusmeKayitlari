using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.App.Formlar
{
    public partial class YetkiliEkle : Form
    {
        public YetkiliEkle(Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = -1;
            _EkleForm();
        }
        internal YetkiliEkle(Yetkili yetkili, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = (yetkili.Id > 0 ? yetkili.Id : -1);
            _IcerikAyarla(yetkili, "Yetkili Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Yetkili_Duzenle, IslemButonlariDurumu.Guncelle);
        }
        internal YetkiliEkle(int Id, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                Yetkili yetkili = await Yetkililer.Getir(Id, App.Instance.ConnManager);
                if (yetkili != null)
                {
                    _IcerikAyarla(yetkili, "Yetkili Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Yetkili_Duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    MsgBox.Hata(this, "Yetkili Bulunamadı!");
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
            _IcerikAyarla(new Yetkili(-1), "Yetkili Ekle", GorusmeKayitlari.Resources.NesneResimleri.Yetkili_Ekle, IslemButonlariDurumu.Ekle);
        }

        private void _IcerikAyarla(Yetkili yetkili, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            Optimizasyon.Delagate(this.txtAd, () => { this.txtAd.Text = yetkili.Ad; });
            Optimizasyon.Delagate(this.txtSoyad, () => { this.txtSoyad.Text = yetkili.Soyad; });
            Optimizasyon.Delagate(this.txtTelefon, () => { this.txtTelefon.Text = yetkili.IletisimBilgileri.Telefon; });
            Optimizasyon.Delagate(this.txtEPosta, () => { this.txtEPosta.Text = yetkili.IletisimBilgileri.Eposta; });
            Optimizasyon.Delagate(this.txtAciklama, () => { this.txtAciklama.Text = yetkili.Aciklama; });
        }
        private Yetkili _IceriktenYetkiliOlustur()
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
                return new Yetkili(NesneId
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
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.YetkiliEkle : NesneYetkileri.YetkiliEkle)))
            {
                bool sonuc = false;
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await Yetkililer.Ekle(_IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await Yetkililer.Guncelle(_IceriktenYetkiliOlustur(), App.Instance.ConnManager);
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![YetkiliEkle]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Yetkili", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc) { _degisiklikyapildi = true; }
            }
        }

        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula( NesneYetkileri.YetkiliSil))
            {
                bool sonuc = await Yetkililer.Sil(NesneId, App.Instance.ConnManager);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Yetkili", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    Optimizasyon.Delagate(this, () => { _EkleForm(); });
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

        private void YetkiliEkle_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.YetkiliGoruntule))
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
