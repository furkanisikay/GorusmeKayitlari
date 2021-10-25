using GorusmeKayitlari.Core;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.App.Bilesenler
{
    public partial class NesneSec : UserControl
    {
        public NesneSec()
        {
            InitializeComponent();
            Tur = NesneTuru.None;
        }
        private int _secilennesneid = -1;
        [Description("Seçilen Nesnenin Id sini döndürür."), Browsable(false)]
        public int SecilenNesneId
        {
            get { return _secilennesneid; }
            set { _secilennesneid = value; Optimizasyon.ArkaplandaCalistir(() => { _IdeGoreIcerikDoldur(_secilennesneid); }); }
        }
        [Description("Seçilecek Nesnenin Türünü Belirtir.")]
        public NesneTuru Tur { get; set; }
        public Button NesneSecButton { get { return this.btnNesneSec; } }
        public TextBox NesneTextBox { get { return this.txtNesne; } }
        public Oturum KulOturumu { get; set; }

        #region ### Nesne Ayarlama Bölümü ###
        private void _NesneAyarla(Yetkili yetkili)
        {
            if (yetkili != null)
            {
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Text = yetkili.ToString(); });
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Tag = yetkili.Id; });
            }
            else
            {
                _NesneAyarla();
            }
        }
        private void _NesneAyarla(Kullanici kullanici)
        {
            if (kullanici != null)
            {
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Text = kullanici.ToString(); });
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Tag = kullanici.Id; });
            }
            else
            {
                _NesneAyarla();
            }
        }
        private void _NesneAyarla(Kurum kurum)
        {

            if (kurum != null)
            {
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Text = kurum.ToString(); });
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Tag = kurum.Id; });
            }
            else
            {
                _NesneAyarla();
            }
        }
        private void _NesneAyarla(Kategori kategori)
        {
            if (kategori != null)
            {
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Text = kategori.ToString(); });
                Optimizasyon.Delagate(txtNesne, () => { txtNesne.Tag = kategori.Id; });
            }
            else
            {
                _NesneAyarla();
            }
        }
        private void _NesneAyarla()
        {
			Optimizasyon.Delagate(this, () => { this._secilennesneid = -1; }); 
            Optimizasyon.Delagate(txtNesne, () => { txtNesne.Text = "(yok)"; });
            Optimizasyon.Delagate(txtNesne, () => { txtNesne.Tag = -1; });
        }
        #endregion

        private async void _IdeGoreIcerikDoldur(int Id)
        {
            NesneSecilirken?.Invoke(null, null);
            if (Id != -1)
            {
                switch (this.Tur)
                {
                    case NesneTuru.Yetkili:
                        _NesneAyarla(await Yetkililer.Getir(Id, App.Instance.ConnManager));
                        break;
                    case NesneTuru.Kullanici:
                        _NesneAyarla(await Kullanicilar.Getir(Id, App.Instance.ConnManager));
                        break;
                    case NesneTuru.Kurum:
                        _NesneAyarla(await Kurumlar.Getir(Id, App.Instance.ConnManager));
                        break;
                    case NesneTuru.Kategori:
                        _NesneAyarla(await Kategoriler.Getir(Id, App.Instance.ConnManager));
                        break;
                    default:
                        _NesneAyarla();
                        break;
                }
            }
            else
            {
                _NesneAyarla();
            }
            NesneSecildiginde?.Invoke(null, Id);
        }

        private void BtnNesneSec_Click(object sender, EventArgs e)
        {
            if (Tur == NesneTuru.Kategori)
            {
                using (Formlar.NesneFormlari.SecmeFormlari.KategoriSec ksForm = new Formlar.NesneFormlari.SecmeFormlari.KategoriSec(this.KulOturumu))
                {
                    try { ksForm.ShowDialog(); }
                    catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Nesne Seçme Formu Görüntülenirken Hata Oluştu!"); }
                    if (ksForm.SecilenNesne != null)
                    {
                        this.SecilenNesneId = ksForm.SecilenNesne.Id;
                    }
                    else { _NesneAyarla(); }
                }
            }
            else
            {
                using (Formlar.NesneSec nsForm = new Formlar.NesneSec(this.Tur, this.KulOturumu))
                {
                    try { nsForm.ShowDialog(); }
                    catch (Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Nesne Seçme Formu Görüntülenirken Hata Oluştu!"); }
                    this.SecilenNesneId = nsForm.SecilenNesneId;
                }
            }
        }
        private void TxtNesne_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.KeyUp != null) { KeyUp(sender, e); }
        }

        private void BtnNesneSec_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.KeyUp != null) { KeyUp(sender, e); }
        }

        public new event KeyEventHandler KeyUp;
        public event EventHandler NesneSecilirken;
        public event EventHandler<int> NesneSecildiginde;
    }
}
