using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;

namespace GorusmeKayitlari.App.Formlar.DigerFormlar
{
    public partial class KullaniciHesapEkle : Form
    {
        public KullaniciHesapEkle(Oturum oturum)
        {
            InitializeComponent();
            NesneId = -1;
            this.KulOturum = oturum;
            _EkleForm();
        }
        public KullaniciHesapEkle(KullaniciHesap hesap, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = (hesap.Id > 0 ? hesap.Id : -1);
            _IcerikAyarla(hesap, "Kullanıcı Hesap Güncelle", Resources.NesneResimleri.hesap_duzenle, IslemButonlariDurumu.Guncelle);
        }
        public KullaniciHesapEkle(int Id, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                KullaniciHesap hesap = await KullaniciHesaplar.Getir(Id, App.Instance.ConnManager);
                if (hesap != null)
                {
                    _IcerikAyarla(hesap, "Kullanıcı Hesap Güncelle", GorusmeKayitlari.Resources.NesneResimleri.hesap_duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    MsgBox.Hata(this, "Kullanıcı Hesap Bulunamadı!");
                }
            });
            act();
        }

        private bool _degisiklikyapildi = false;
        public bool DegisiklikYapildi => _degisiklikyapildi;
        private bool _Silindi = false;
        public bool Silindi => _Silindi;
        public int NesneId { get; }
        public Oturum KulOturum { get; }

        private KullaniciHesap _Hesap { get; set; }
        public KullaniciHesap Hesap => _Hesap;

        private void _EkleForm()
        {
            _IcerikAyarla(KullaniciHesap.Bos, "Kullanıcı Hesap Ekle", GorusmeKayitlari.Resources.NesneResimleri.hesap_ekle, IslemButonlariDurumu.Ekle);
        }
        private void _IcerikAyarla(KullaniciHesap hesap, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            this._Hesap = hesap;
            Delegates.Text.Set(this, baslik);
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            SetKullanici(hesap.GetKullanici(App.Instance.ConnManager));
            SetKullaniciAd(hesap.KullaniciAdi);
            SetSifre(hesap.Sifre);
            HesapDurumlariniAyarla();
            SetHesapDurum(hesap.Durum);
            SetYetkiler(hesap.NesneYetkileri);
            SetYetkiler(hesap.DigerYetkiler);
            SetOlusturulmaTarihi(hesap.OlusturulmaTarihi);
            SetSonDuzenlemeTarihi(hesap.SonDuzenlemeTarihi);
            SetSonDuzenleyenKullanici(hesap.GetSonDuzKulHesabi(App.Instance.ConnManager));
            SetAciklama(hesap.Aciklama);
        }
        private void KullaniciHesapAyarlari_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.KullaniciHesapGoruntuleme))
            {
                this.Close();
            }
        }

        void HesapDurumlariniAyarla()
        {
            List<string> durumlar = new List<string>();
            string[] enumlar = Enum.GetNames(typeof(KullaniciHesapDurumu));
            foreach (string enm in enumlar)
            {
                string yazi = enm.ToKullaniciHesabiDurumu().ToCustomString();
                if (!string.IsNullOrEmpty(yazi))
                {
                    durumlar.Add(yazi);
                }
            }
            Optimizasyon.Delagate(cmbHesapDurum, () =>
            {
                cmbHesapDurum.Items.AddRange(durumlar.ToArray());
                if (cmbHesapDurum.Items.Count != 0)
                {
                    cmbHesapDurum.SelectedIndex = 0;
                }
            });
        }

        #region Set Fonksiyonları
        private void SetKullaniciAd(string kullaniciadi)
        {
            Delegates.Text.Set(txtKullaniciAd, kullaniciadi);
        }
        private void SetSifre(string sifre)
        {
            Delegates.Text.Set(txtSifre, sifre);
        }
        private void SetKullanici(Kullanici kullanici)
        {
            if (kullanici != null)
            {
                Optimizasyon.Delagate(nsKullanici, () => { nsKullanici.SecilenNesneId = kullanici.Id; });
            }
        }
        private void SetYetkiler<T>(List<T> yetkiler)
        {
            Optimizasyon.Delagate(yYetkiler, () => { yYetkiler.YetkiEkle(yetkiler); });
        }
        private void SetHesapDurum(KullaniciHesapDurumu durum)
        {
            Optimizasyon.Delagate(yYetkiler, () =>
            {
                foreach (object obj in cmbHesapDurum.Items)
                {
                    if (obj.ToString() == durum.ToCustomString())
                    {
                        cmbHesapDurum.SelectedItem = obj;
                    }
                }
            });
        }
        private void SetOlusturulmaTarihi(DateTime tarih)
        {
            Delegates.Text.Set(lblOlTarihi, tarih.ToShortDateString() + " " + tarih.ToLongTimeString());
            Delegates.Tag.Set(lblOlTarihi, tarih);
        }
        private void SetSonDuzenlemeTarihi(DateTime tarih)
        {
            Delegates.Text.Set(lblSonDuzTarihi, tarih.ToShortDateString() + " " + tarih.ToLongTimeString());
            Delegates.Tag.Set(lblSonDuzTarihi, tarih);
        }
        private void SetSonDuzenleyenKullanici(KullaniciHesap hesap)
        {
            Delegates.Text.Set(lblSonDuzKullanici, hesap?.ToString());
            Delegates.Tag.Set(lblSonDuzKullanici, hesap);
        }
        private void SetAciklama(string aciklama)
        {
            Delegates.Text.Set(txtAciklama, aciklama);
        }
        #endregion

        #region IcerikGet fonksiyonları ve _IcerikOlustur fonksiyonu 
        private string GetKullaniciAd()
        {
            return Delegates.Text.Get(txtKullaniciAd);
        }
        private string GetSifre()
        {
            return Delegates.Text.Get(txtSifre);
        }
        private async Task<Kullanici> GetKullanici()
        {
            return await Kullanicilar.Getir(nsKullanici.SecilenNesneId, App.Instance.ConnManager);
        }
        private List<NesneYetkileri> GetNesneYetkileri()
        {
            List<NesneYetkileri> nyetkiler = new List<NesneYetkileri>();
            Optimizasyon.Delagate(yYetkiler, () => { nyetkiler = yYetkiler.NesneYetkileri; });
            return nyetkiler;
        }
        private List<DigerYetkiler> GetDigerYetkiler()
        {
            List<DigerYetkiler> dyetkiler = new List<DigerYetkiler>();
            Optimizasyon.Delagate(yYetkiler, () => { dyetkiler = yYetkiler.DigerYetkiler; });
            return dyetkiler;
        }
        private KullaniciHesapDurumu GetHesapDurum()
        {
            return Delegates.Text.Get(cmbHesapDurum).ToKullaniciHesabiDurumu();
        }
        private DateTime GetOlusturulmaTarihi()
        {
            if (btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle)
            {
                return DateTime.Now;
            }
            else
            {
                return (DateTime)(Delegates.Tag.Get(lblOlTarihi));
            }
        }
        private DateTime GetSonDuzenlemeTarihi()
        {
            return DateTime.Now;
            //return (DateTime)(Delegates.Tag.Get(lblSonDuzTarihi));
        }
        private KullaniciHesap GetSonDuzenleyenKullanici()
        {
            return this.KulOturum.OturumAcilanHesap;
            //return (KullaniciHesap)(Delegates.Tag.Get(lblSonDuzKullanici));
        }
        private string GetAciklama()
        {
            return Delegates.Text.Get(txtAciklama);
        }

        private async Task<KullaniciHesap> _IceriktenKullaniciHesapOlustur()
        {
            cErrProMain.Clear();
            bool kullaniciadiuygunmu = (this._Hesap.KullaniciAdi != GetKullaniciAd() && !(await KullaniciHesaplar.KullaniciAdiMusaitmi(GetKullaniciAd(), App.Instance.ConnManager)));
            if (nsKullanici.SecilenNesneId == -1
                || string.IsNullOrEmpty(txtKullaniciAd.Text)
                || kullaniciadiuygunmu)
            {
                if (nsKullanici.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsKullanici, "Bu bilgi zorunludur.");
                }
                if (string.IsNullOrEmpty(txtKullaniciAd.Text))
                {
                    cErrProMain.SetError(txtKullaniciAd, "Bu bilgi zorunludur.");
                }
                if (kullaniciadiuygunmu)
                {
                    cErrProMain.SetError(txtKullaniciAd, "Belirtilen kullanıcı adı zaten kullanılıyor.\nLütfen farklı bir kullanıcı adı yazarak tekrar deneyin.");
                }
                return null;
            }
            else
            {
                return new KullaniciHesap(NesneId
                    , await GetKullanici()
                    , GetKullaniciAd()
                    , GetSifre()
                    , GetNesneYetkileri()
                    , GetDigerYetkiler()
                    , GetHesapDurum()
                    , GetOlusturulmaTarihi()
                    , GetSonDuzenlemeTarihi()
                    , GetSonDuzenleyenKullanici()
                    , GetAciklama());
            }
        }
        #endregion

        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.KullaniciHesapEkleme : NesneYetkileri.KullaniciHesapDuzenleme)))
            {
                bool sonuc = false;
                KullaniciHesap hesap = await _IceriktenKullaniciHesapOlustur();
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await KullaniciHesaplar.Ekle(hesap, App.Instance.ConnManager);
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await KullaniciHesaplar.Guncelle(hesap, App.Instance.ConnManager);
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![KullaniciHesapAyarlari]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kullanıcı Hesap", btnEkleGuncelleSil.Durum, sonuc); if (sonuc) { _degisiklikyapildi = true; }
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    this._Hesap = hesap;
                    this.Close();
                }
            }
        }

        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula(NesneYetkileri.KullaniciHesapSilme))
            {
                bool sonuc = await KullaniciHesaplar.Sil(NesneId, App.Instance.ConnManager);
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Kullanıcı Hesap", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    _Silindi = true;
                    this.Close();
                }
            }
        }

        private void KullaniciHesapAyarlari_KeyUp(object sender, KeyEventArgs e)
        {
            if (!((sender is Button) && ((sender as Button).Name == nsKullanici.NesneSecButton.Name))
                && e.KeyCode == Keys.Enter)
            {
                BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
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
