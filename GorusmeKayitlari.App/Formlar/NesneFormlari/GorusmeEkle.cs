using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Formlar.NesneFormlari
{
    public partial class GorusmeEkle : Form, IConnMng
    {
        public GorusmeEkle(Oturum oturum)
        {
            InitializeComponent();
            NesneId = -1;
            _EkleForm();
            SetOturums(oturum);
        }

        internal GorusmeEkle(Gorusme gorusme, Oturum oturum)
        {
            InitializeComponent();
            SetOturums(oturum);
            NesneId = (gorusme.Id > 0 ? gorusme.Id : -1);
            _IcerikAyarla(gorusme, "Görüşme Güncelle", Resources.NesneResimleri.Gorusme_Duzenle, IslemButonlariDurumu.Guncelle);
        }

        internal GorusmeEkle(Kurum kurum, Oturum oturum)
        {
            InitializeComponent();
            NesneId = -1;
            SetOturums(oturum);
            _EkleForm();
            Optimizasyon.Delagate(nsKurum, () => { nsKurum.SecilenNesneId = kurum != null ? kurum.Id : -1; });
        }
        internal GorusmeEkle(int Id, Oturum oturum)
        {
            InitializeComponent();
            SetOturums(oturum);
            NesneId = (Id > 0 ? Id : -1);
            Action act = new Action(async () =>
            {
                Gorusme gorusme = await Gorusmeler.Getir(Id, GetConnMgr());
                if (gorusme != null)
                {
                    _IcerikAyarla(gorusme, "Görüşme Güncelle", GorusmeKayitlari.Resources.NesneResimleri.Gorusme_Duzenle, IslemButonlariDurumu.Guncelle);
                }
                else
                {
                    MsgBox.Hata(this, "Görüşme Bulunamadı!");
                }
            });
            act();
        }

        private bool _degisiklikyapildi = false;
        public bool DegisiklikYapildi { get { return _degisiklikyapildi; } }
        public int NesneId { get; }

        public Oturum KulOturumu { get; private set; }
        ConnectionManager IConnMng.ConnManager { get => GetConnMgr(); set => SetConnMgr(value); }

        private void _EkleForm()
        {
            _IcerikAyarla(new Gorusme(-1), "Görüşme Ekle", GorusmeKayitlari.Resources.NesneResimleri.Gorusme_Ekle, IslemButonlariDurumu.Ekle);
        }

        private void _IcerikAyarla(Gorusme gorusme, string baslik, Image resim, IslemButonlariDurumu durum)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(this.pboxResim, () => { this.pboxResim.Image = resim; });
            Optimizasyon.Delagate(this.btnEkleGuncelleSil, () => { this.btnEkleGuncelleSil.Durum = durum; });
            Optimizasyon.Delagate(this.nsKurum, () => { nsKurum.SecilenNesneId = gorusme.Kurum != null ? gorusme.Kurum.Id : -1; });
            Optimizasyon.Delagate(this.nsYetkili, () => { nsYetkili.SecilenNesneId = gorusme.Yetkili != null ? gorusme.Yetkili.Id : -1; });
            Optimizasyon.Delagate(this.nsKullanici, () => { nsKullanici.SecilenNesneId = gorusme.Kullanici != null ? gorusme.Kullanici.Id : -1; });
            Optimizasyon.Delagate(this.dtpTarih, () => { this.dtpTarih.Value = gorusme.Tarih; });
            Optimizasyon.Delagate(this.txtMetin, () => { this.txtMetin.Text = gorusme.Metin; });
        }
        private async Task<Gorusme> _IceriktenYetkiliOlustur()
        {
            cErrProMain.Clear();
            if (nsKurum.SecilenNesneId == -1
                || nsYetkili.SecilenNesneId == -1
                || nsKullanici.SecilenNesneId == -1
                || dtpTarih.Value == null
                || string.IsNullOrEmpty(txtMetin.Text))
            {
                if (nsKurum.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsKurum, "Bu bilgi zorunludur.");
                }
                if (nsYetkili.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsYetkili, "Bu bilgi zorunludur.");
                }
                if (nsKullanici.SecilenNesneId == -1)
                {
                    cErrProMain.SetError(nsKullanici, "Bu bilgi zorunludur.");
                }
                if (dtpTarih.Value == null)
                {
                    cErrProMain.SetError(dtpTarih, "Bu bilgi zorunludur.");
                }
                if (string.IsNullOrEmpty(txtMetin.Text))
                {
                    cErrProMain.SetError(txtMetin, "Bu bilgi zorunludur.");
                }
                return null;
            }
            else
            {
                return new Gorusme(NesneId
                    , await Kurumlar.Getir(nsKurum.SecilenNesneId, GetConnMgr())
                    , await Yetkililer.Getir(nsYetkili.SecilenNesneId, GetConnMgr())
                    , await Kullanicilar.Getir(nsKullanici.SecilenNesneId, GetConnMgr())
                    , dtpTarih.Value
                    , txtMetin.Text);
            }
        }
        private async void BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula((btnEkleGuncelleSil.Durum == IslemButonlariDurumu.Ekle ? NesneYetkileri.GorusmeEkle : NesneYetkileri.GorusmeDuzenle)))
            {
                bool sonuc = false;
                switch (btnEkleGuncelleSil.Durum)
                {
                    case IslemButonlariDurumu.Ekle:
                        sonuc = await Gorusmeler.Ekle(await _IceriktenYetkiliOlustur(), GetConnMgr());
                        break;
                    case IslemButonlariDurumu.Guncelle:
                        sonuc = await Gorusmeler.Guncelle(await _IceriktenYetkiliOlustur(), GetConnMgr());
                        break;
                    default:
                        Logger.Log(new NotSupportedException("Buton durumu Belirtilmemiş![GorusmeEkle]"));
                        break;
                }
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Görüşme", btnEkleGuncelleSil.Durum, sonuc); if (sonuc) { _degisiklikyapildi = true; }
                if (sonuc) { _degisiklikyapildi = true; this.Close(); }
            }
        }

        private async void BtnEkleGuncelleSil_SilTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula(NesneYetkileri.GorusmeSil))
            {
                bool sonuc = await Gorusmeler.Sil(NesneId, GetConnMgr());
                DigerFonksiyonlar.NesneAyarlandiMesajKutusu("Görüşme", btnEkleGuncelleSil.Durum, sonuc);
                if (sonuc)
                {
                    _degisiklikyapildi = true;
                    this.Close();
                }
            }
        }

        private async void NsKurum_NesneSecildiginde(object sender, int e)
        {
            if (e > 0)
            {
                Kurum kurum = await Kurumlar.Getir(e, GetConnMgr());
                if (kurum != null && kurum.Yetkili != null)
                {
                    Optimizasyon.Delagate(nsYetkili, () => { nsYetkili.SecilenNesneId = kurum.Yetkili.Id; });
                }
            }
            else
            {
                Optimizasyon.Delagate(nsYetkili, () => { nsYetkili.SecilenNesneId = -1; });
            }
        }

        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            if (!((sender is Button) && ((sender as Button).Name == nsKurum.NesneSecButton.Name
                || (sender as Button).Name == nsYetkili.NesneSecButton.Name
                || (sender as Button).Name == nsKullanici.NesneSecButton.Name))
                && e.KeyCode == Keys.Enter)
            {
                BtnEkleGuncelleSil_EkleGuncelleTiklandiginda(sender, e);
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void TxtMetin_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Alt == true && e.KeyCode == Keys.Enter)
            {
                Form_KeyUp(sender, e);
            }
        }

        private void GorusmeEkle_Load(object sender, EventArgs e)
        {
            if (!_YetkiSorgula(NesneYetkileri.GorusmeGoruntule))
            {
                this.Close();
            }
        }
        private bool _YetkiSorgula<T>(T Yetki, bool msg = true)
        {
            return Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, Yetki, this.KulOturumu, false);
        }

        public ConnectionManager GetConnMgr()
        {
            return App.Instance.ConnManager;
        }

        public void SetConnMgr(ConnectionManager connmgr)
        {
            throw new NotImplementedException();
        }

        private void SetOturums(Oturum oturum)
        {
            Optimizasyon.Delagate(this,()=> { this.KulOturumu = oturum; });
            Optimizasyon.Delagate(nsKurum,()=> { nsKurum.KulOturumu = oturum; });
            Optimizasyon.Delagate(nsYetkili,()=> { nsYetkili.KulOturumu = oturum; });
            Optimizasyon.Delagate(nsKullanici,()=> { nsKullanici.KulOturumu = oturum; });
        }
    }
}

