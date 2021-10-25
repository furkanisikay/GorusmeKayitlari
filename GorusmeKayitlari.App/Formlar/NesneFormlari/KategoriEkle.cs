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
    public partial class KategoriEkle : Form
    {
        public KategoriEkle(Oturum oturum)
        {
            InitializeComponent();
            NesneId = -1;
            this.KulOturum = oturum;
            Optimizasyon.Delagate(nsUstKategori,()=> { nsUstKategori.KulOturumu = this.KulOturum; });
            _EkleForm();
        }

        internal KategoriEkle(Kategori kategori, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            Optimizasyon.Delagate(nsUstKategori, () => { nsUstKategori.KulOturumu = this.KulOturum; });
            NesneId = (kategori.Id > 0 ? kategori.Id : -1);
            _IcerikAyarla(kategori, "Kategori Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kategori_Duzenle, IslemButonlariDurumu.Guncelle);
        }
        /// <summary>
        /// Belirtilen Id'ye Göre Kategoriyi Düzenler.
        /// </summary>
        /// <param name="Id">Düzenlenecek Kategori Id'si</param>
        internal KategoriEkle(int Id)
        {
            InitializeComponent();
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                Kategori kategori = await Kategoriler.Getir(Id, App.Instance.ConnManager);
                if (kategori != null)
                {
                    _IcerikAyarla(kategori, "Kategori Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Kategori_Duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    Optimizasyon.Delagate(this, () => { MsgBox.Hata(this, "Kategori Bulunamadı!"); });
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
            _IcerikAyarla(new Kategori(-1, new Kategori(-1, null, "(yok)"), ""), "Kategori Ekle", GorusmeKayitlari.Resources.NesneResimleri.Kategori_Ekle, IslemButonlariDurumu.Ekle);
        }

        private void _IcerikAyarla(Kategori kategori, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            Optimizasyon.Delagate(nsUstKategori, () => { nsUstKategori.SecilenNesneId = kategori.UstKategori.Id; });
            Optimizasyon.Delagate(this.txtIsim, () => { this.txtIsim.Text = kategori.Ad; });
        }

        private Kategori _IceriktenKategoriOlustur()
        {
            cErrProMain.Clear();
            if (string.IsNullOrEmpty(txtIsim.Text))
            {
                if (string.IsNullOrEmpty(txtIsim.Text))
                {
                    cErrProMain.SetError(txtIsim, "Bu bilgi zorunludur.");
                }
                return null;
            }
            else
            {
                return new Kategori(NesneId
                    , new Kategori(nsUstKategori.SecilenNesneId > 0 ? nsUstKategori.SecilenNesneId : 0)
                    , txtIsim.Text);
            }
        }

        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.KategoriEkle : NesneYetkileri.KategoriDuzenle)))
            {
                bool sonuc = false;
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await Kategoriler.Ekle(_IceriktenKategoriOlustur(), App.Instance.ConnManager);
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await Kategoriler.Guncelle(_IceriktenKategoriOlustur(), App.Instance.ConnManager);
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![KategoriEkle]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kategori", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc) { _degisiklikyapildi = true; this.Close(); }
            }
        }


        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula(NesneYetkileri.KategoriSil))
            {
                bool sonuc = await Kategoriler.Sil(NesneId, App.Instance.ConnManager);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kategori", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Belirtilen UstKategori Nesnesinin Id'sine Göre UstKategoriyi Ayarlar.
        /// </summary>
        /// <param name="ustkategori"></param>
        public void _UstKategoriAyarla(Kategori ustkategori)
        {
            Optimizasyon.Delagate(nsUstKategori, () => { nsUstKategori.SecilenNesneId = ustkategori.Id; });
        }

        private void NesneSec1_NesneSecildiginde(object sender, int e)
        {
            if (NesneId != -1 && e == NesneId)
            {
                Optimizasyon.Delagate(this, () => { MsgBox.Hata(this, "Kategorinin üstkategorisi kendisi olamaz."); });
                Optimizasyon.Delagate(nsUstKategori, () => { nsUstKategori.SecilenNesneId = -1; });
            }
        }

        private void KategoriEkle_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void KategoriEkle_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
        }

        private void KategoriEkle_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.KategoriGoruntule))
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
