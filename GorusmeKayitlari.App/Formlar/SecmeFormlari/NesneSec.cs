using GorusmeKayitlari.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Extensions.Logger;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.App.Formlar
{
    public partial class NesneSec : Form
    {
        public NesneSec(NesneTuru Tur, Oturum Oturum)
        {
            InitializeComponent();
            this.Tur = Tur;
            this.KulOturum = Oturum;
            _IcerikYukle(Tur);
        }

        public NesneTuru Tur = NesneTuru.None;
        private int _secilenId = -1;
        public int SecilenNesneId { get { return _secilenId; } }
        public Oturum KulOturum { get; set; }

        #region ### İçerik Ayarlama Kodları ###
        private void _IcerikAyarla(string baslik, Image resim)
        {
            Optimizasyon.Delagate(this, () => { this.Text = baslik; });
            Optimizasyon.Delagate(pboxResim, () => { this.pboxResim.Image = resim; });
        }

        private void _IcerikYukle(NesneTuru Tur)
        {
            switch (Tur)
            {
                case NesneTuru.Yetkili:
                    _IcerikAyarla("Yetkili Seç", GorusmeKayitlari.Resources.NesneResimleri.Yetkili_Sec);
                    break;
                case NesneTuru.Kullanici:
                    _IcerikAyarla("Kullanıcı Seç", GorusmeKayitlari.Resources.NesneResimleri.Kullanıcı_Sec);
                    break;
                case NesneTuru.Kurum:
                    _IcerikAyarla("Kurum Seç", GorusmeKayitlari.Resources.NesneResimleri.Kurum_Sec);
                    break;
                case NesneTuru.Kategori:
                    _IcerikAyarla("Kategori Seç", GorusmeKayitlari.Resources.NesneResimleri.Kategori_Sec);
                    break;
                case NesneTuru.KullaniciHesabi:
                    _IcerikAyarla("Kullanıcı Hesabı Seç", GorusmeKayitlari.Resources.NesneResimleri.hesap_sec);
                    break;
                default:
                    Logger.Log(new NotSupportedException("NesneTuru Belirtilmemiş![NesneSec]"));
                    _IcerikAyarla("", null);
                    break;
            }
        }
        #endregion

        #region ### Nesne Bölümü ###
        private void _NesneleriTemizle()
        {
            Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Clear(); });
        }

        #region ### Nesne Ekleme Bölümü ###
        private void _NesneEkle(Yetkili yetkili)
        {
            if (yetkili != null)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = !string.IsNullOrEmpty(yetkili.Ad) ? yetkili.Ad : "-"
                };
                item.SubItems.Add(!string.IsNullOrEmpty(yetkili.Soyad) ? yetkili.Soyad : "-");
                if (yetkili.IletisimBilgileri != null)
                {
                    item.SubItems.Add(!string.IsNullOrEmpty(yetkili.IletisimBilgileri.Telefon) ? yetkili.IletisimBilgileri.Telefon : "-");
                    item.SubItems.Add(!string.IsNullOrEmpty(yetkili.IletisimBilgileri.Eposta) ? yetkili.IletisimBilgileri.Eposta : "-");
                }
                else
                {
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                item.SubItems.Add(!string.IsNullOrEmpty(yetkili.Aciklama) ? yetkili.Aciklama : "-");
                item.Tag = yetkili.Id;
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Add(item); });
            }
        }
        private void _NesneEkle(Kullanici kullanici)
        {
            if (kullanici != null)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = !string.IsNullOrEmpty(kullanici.Ad) ? kullanici.Ad : "-"
                };
                item.SubItems.Add(!string.IsNullOrEmpty(kullanici.Soyad) ? kullanici.Soyad : "-");
                if (kullanici.IletisimBilgileri != null)
                {
                    item.SubItems.Add(!string.IsNullOrEmpty(kullanici.IletisimBilgileri.Telefon) ? kullanici.IletisimBilgileri.Telefon : "-");
                    item.SubItems.Add(!string.IsNullOrEmpty(kullanici.IletisimBilgileri.Eposta) ? kullanici.IletisimBilgileri.Eposta : "-");
                }
                else
                {
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                item.SubItems.Add(!string.IsNullOrEmpty(kullanici.Aciklama) ? kullanici.Aciklama : "-");
                item.Tag = kullanici.Id;
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Add(item); });
            }
        }
        private void _NesneEkle(Kurum kurum)
        {
            if (kurum != null)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = !string.IsNullOrEmpty(kurum.Ad) ? kurum.Ad : "-"
                };
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(kurum.Yetkili));
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(kurum.Kategori));
                if (kurum.IletisimBilgileri != null)
                {
                    item.SubItems.Add(!string.IsNullOrEmpty(kurum.IletisimBilgileri.Telefon) ? kurum.IletisimBilgileri.Telefon : "-");
                    item.SubItems.Add(!string.IsNullOrEmpty(kurum.IletisimBilgileri.Fax) ? kurum.IletisimBilgileri.Fax : "-");
                    item.SubItems.Add(!string.IsNullOrEmpty(kurum.IletisimBilgileri.Eposta) ? kurum.IletisimBilgileri.Eposta : "-");
                    item.SubItems.Add(!string.IsNullOrEmpty(kurum.IletisimBilgileri.Adres) ? kurum.IletisimBilgileri.Adres : "-");
                }
                else
                {
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                    item.SubItems.Add("-");
                }
                item.SubItems.Add(!string.IsNullOrEmpty(kurum.Aciklama) ? kurum.Aciklama : "-");
                item.Tag = kurum.Id;
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Add(item); });
            }
        }
        private void _NesneEkle(Kategori kategori)
        {
            if (kategori != null)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = !string.IsNullOrEmpty(kategori.Ad) ? kategori.Ad : "-"
                };
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(kategori.UstKategori));
                item.Tag = kategori.Id;
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Add(item); });
            }
        }
        private void _NesneEkle(KullaniciHesap hesap)
        {
            if (hesap != null)
            {
                ListViewItem item = new ListViewItem()
                {
                    Text = DigerFonksiyonlar.EmptyToCizgi(hesap)
                };
                item.SubItems.Add(DigerFonksiyonlar.YaziGizle(hesap.Sifre, '*'));
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(hesap.GetKullanici(App.Instance.ConnManager)));
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(hesap.Durum));
                item.SubItems.Add(DigerFonksiyonlar.EmptyToCizgi(hesap.Aciklama));
                item.Tag = hesap.Id;
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.Add(item); });
            }
        }
        #endregion

        private void _ListedeDonEkle<T>(List<T> liste)
        {
            if (liste != null && liste.Count != 0)
            {
                foreach (T _nesne in liste)
                {
                    if (_nesne is Yetkili) { _NesneEkle(_nesne as Yetkili); }
                    else if (_nesne is Kullanici) { _NesneEkle(_nesne as Kullanici); }
                    else if (_nesne is Kurum) { _NesneEkle(_nesne as Kurum); }
                    else if (_nesne is Kategori) { _NesneEkle(_nesne as Kategori); }
                    else if (_nesne is KullaniciHesap) { _NesneEkle(_nesne as KullaniciHesap); }
                    else { throw new ArgumentException("liste türü bilinmiyor[NesneSec>>_ListedeDonEkle]"); }
                }
            }
        }

        private async void _Nesneleri_Yukle()
        {
            _NesneleriTemizle();
            _KolonlariYukle(this.Tur);
            _BulYukle(this.Tur);
            _AramaDurumu(false);
            switch (Tur)
            {
                case NesneTuru.Yetkili:
                    _ListedeDonEkle(await Yetkililer.TumunuGetir(App.Instance.ConnManager));
                    break;
                case NesneTuru.Kullanici:
                    _ListedeDonEkle(await Kullanicilar.TumunuGetir(App.Instance.ConnManager));
                    break;
                case NesneTuru.Kurum:
                    _ListedeDonEkle(await Kurumlar.TumunuGetir(App.Instance.ConnManager));
                    break;
                case NesneTuru.Kategori:
                    _ListedeDonEkle(await Kategoriler.TumunuGetir(App.Instance.ConnManager));
                    break;
                case NesneTuru.KullaniciHesabi:
                    _ListedeDonEkle(await KullaniciHesaplar.TumunuGetir(App.Instance.ConnManager));
                    break;
                default:
                    NotSupportedException nse = new NotSupportedException("Nesne Türü Belirtilmemiş![NesneSec>>_Nesneleri_Yukle]");
                    Logger.Log(nse);
                    break;
                    throw nse;
            }
            if (lstNesneler.Items.Count == 0)
            {
                switch (this.Tur)
                {
                    case NesneTuru.Yetkili:
                        _NesneEkle(new Yetkili(-1, "Bulunamadı", "", null, ""));
                        break;
                    case NesneTuru.Kullanici:
                        _NesneEkle(new Kullanici(-1, "Bulunamadı", "", null, ""));
                        break;
                    case NesneTuru.Kurum:
                        _NesneEkle(new Kurum(-1, null, "Bulunamadı", null, null, ""));
                        break;
                    case NesneTuru.Kategori:
                        _NesneEkle(new Kategori(-1, null, "Bulunamadı"));
                        break;
                    case NesneTuru.KullaniciHesabi:
                        _NesneEkle(new KullaniciHesap("Bulunamadı", string.Empty));
                        break;
                    default:
                        NotSupportedException nse = new NotSupportedException("Nesne Türü Belirtilmemiş![NesneSec>>_Nesneleri_Yukle]");
                        Logger.Log(nse);
                        break;
                        throw nse;
                }
            }
            Optimizasyon.Delagate(lstNesneler, () =>
            {
                lstNesneler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
            _AramaDurumu(true);
        }

        private void _Nesneleri_Yukle(List<ListViewItem> itemler)
        {
            _NesneleriTemizle();
            _KolonlariYukle(this.Tur);
            _BulYukle(this.Tur);
            _AramaDurumu(false);
            if (itemler != null && itemler.Count > 0)
            {
                Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Items.AddRange(itemler.ToArray()); });
            }
            if (lstNesneler.Items.Count == 0)
            {
                switch (this.Tur)
                {
                    case NesneTuru.Yetkili:
                        _NesneEkle(new Yetkili(-1, "Bulunamadı", "", null, ""));
                        break;
                    case NesneTuru.Kullanici:
                        _NesneEkle(new Kullanici(-1, "Bulunamadı", "", null, ""));
                        break;
                    case NesneTuru.Kurum:
                        _NesneEkle(new Kurum(-1, null, "Bulunamadı", null, null, ""));
                        break;
                    case NesneTuru.Kategori:
                        _NesneEkle(new Kategori(-1, null, "Bulunamadı"));
                        break;
                    case NesneTuru.KullaniciHesabi:
                        _NesneEkle(new KullaniciHesap("Bulunamadı", string.Empty));
                        break;
                    default:
                        NotSupportedException nse = new NotSupportedException("Nesne Türü Belirtilmemiş![NesneSec>>_Nesneleri_Yukle]");
                        Logger.Log(nse);
                        break;
                        throw nse;
                }
            }
            Optimizasyon.Delagate(lstNesneler, () =>
            {
                lstNesneler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            });
            _AramaDurumu(true);
        }

        public void _NesneleriYukle(bool arkaplanda = true)
        {
            if (arkaplanda)
            {
                Optimizasyon.ArkaplandaCalistir(() => { _Nesneleri_Yukle(); });
            }
            else { _Nesneleri_Yukle(); }
        }
        #endregion

        #region ### Kolon Bölümü ###
        private void _KolonlariTemizle()
        {
            Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Columns.Clear(); });
        }

        private void _KolonEkle(string colonAdi)
        {
            Optimizasyon.Delagate(lstNesneler, () => { lstNesneler.Columns.Add(colonAdi); });
        }

        private void _KolonlariYukle(NesneTuru Tur)
        {
            _KolonlariTemizle();
            switch (Tur)
            {
                case NesneTuru.None:
                    break;
                case NesneTuru.Yetkili:
                    _KolonEkle("Ad");
                    _KolonEkle("Soyad");
                    _KolonEkle("Telefon");
                    _KolonEkle("E-Posta");
                    _KolonEkle("Açıklama");
                    break;
                case NesneTuru.Kullanici:
                    _KolonEkle("Ad");
                    _KolonEkle("Soyad");
                    _KolonEkle("Telefon");
                    _KolonEkle("E-Posta");
                    _KolonEkle("Açıklama");
                    break;
                case NesneTuru.Kurum:
                    _KolonEkle("Ad");
                    _KolonEkle("Yetkili");
                    _KolonEkle("Kategori");
                    _KolonEkle("Telefon");
                    _KolonEkle("Fax");
                    _KolonEkle("E-Posta");
                    _KolonEkle("Adres");
                    _KolonEkle("Açıklama");
                    break;
                case NesneTuru.Kategori:
                    _KolonEkle("Ad");
                    _KolonEkle("Üst Kategori");
                    break;
                case NesneTuru.KullaniciHesabi:
                    _KolonEkle("Kullanıcı Adı");
                    _KolonEkle("Şifre");
                    _KolonEkle("Hesap Kullanıcısı");
                    _KolonEkle("Hesap Durumu");
                    _KolonEkle("Açıklama");
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region ### Arama Bölümü ###

        #region ### cmbBul Ayarlama Bölümü ###
        private void _BulTemizle()
        {
            Optimizasyon.Delagate(cmbBul, () => { cmbBul.Items.Clear(); });
        }
        private void _BulEkle(ColumnHeader clm)
        {
            ComboboxItem item = new ComboboxItem(clm.Text, clm);
            Optimizasyon.Delagate(cmbBul, () => { cmbBul.Items.Add(item); });
        }
        private void _BulYukle(NesneTuru Tur)
        {
            int eskindex = -1;
            Optimizasyon.Delagate(cmbBul, () => { eskindex = cmbBul.SelectedIndex; });
            _BulTemizle();
            foreach (ColumnHeader clm in lstNesneler.Columns)
            {
                _BulEkle(clm);
            }
            if (eskindex != -1)
            {
                Optimizasyon.Delagate(cmbBul, () => { cmbBul.SelectedIndex = eskindex; });
            }
            else { Optimizasyon.Delagate(cmbBul, () => { cmbBul.SelectedIndex = 0; }); }
        }
        #endregion

        private void _AramaDurumu(bool Aktif)
        {
            Optimizasyon.Delagate(gboxAra, () => { gboxAra.Enabled = Aktif; });
        }
        private void BtnBul_Click(object sender, EventArgs e)
        {
            if (cmbBul.SelectedItem == null)
            {
                MsgBox.Hata(this, "Lütfen Aranama Yapılacak Bölümü Seçin.");
                return;
            }
            if (!string.IsNullOrEmpty(txtBul.Text) && cmbBul.Items.Count > 0 && cmbBul.SelectedIndex != -1)
            {
                int clmindex = -1;
                try { clmindex = ((cmbBul.SelectedItem as ComboboxItem).Deger as ColumnHeader).DisplayIndex; }
                catch (Exception ex) { Logger.Log(ex); clmindex = -1; }
                if (clmindex != -1)
                {
                    List<ListViewItem> itemler = new List<ListViewItem>();
                    foreach (ListViewItem item in lstNesneler.Items)
                    {
                        if (item.SubItems != null && item.SubItems[clmindex] != null && !string.IsNullOrEmpty(item.SubItems[clmindex].Text))
                        {
                            string yazi = item.SubItems[clmindex].Text;
                            string arananyazi = txtBul.Text;
                            if (!chckBKHDuyarlı.Checked)
                            {
                                yazi = yazi.ToLower();
                                arananyazi = arananyazi.ToLower();
                            }
                            if ((!checkBox1.Checked && yazi.Contains(arananyazi))
                                || (checkBox1.Checked && yazi == arananyazi))
                            {
                                itemler.Add(item);
                            }
                        }
                    }
                    if (itemler.Count > 0)
                    {
                        _Nesneleri_Yukle(itemler);
                    }
                    else
                    {
                        MsgBox.Hata(this, "Üzgünüz, Aradığınız içeriği bulamadık!");
                    }
                }
            }
        }

        #endregion

        private bool _ListeBosDegilse()
        {
            return lstNesneler != null && lstNesneler.Items != null && lstNesneler.Items.Count != 0 && lstNesneler.Items[0] != null && lstNesneler.Items[0].Tag != null && Convert.ToInt32(lstNesneler.Items[0].Tag) != -1;
        }

        private void NesneSec_Load(object sender, EventArgs e)
        {
            if (Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this,
                this.Tur.ToNesneYetkileriGoruntulemeYetki(), KulOturum))
            {
                _NesneleriYukle();
            }
        }


        private void OnaylaIptal1_Onaylandiginde(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && lstNesneler.SelectedItems.Count != 0 && lstNesneler.SelectedItems[0] != null && lstNesneler.SelectedItems[0].Tag != null && Convert.ToInt32(lstNesneler.SelectedItems[0].Tag) != -1)
            {
                _secilenId = Convert.ToInt32(lstNesneler.SelectedItems[0].Tag);
                this.Close();
            }
        }

        private void OnaylaIptal1_IptalEdildiginde(object sender, EventArgs e)
        {
            this._secilenId = -1;
            this.Close();
        }

        private void LstNesneler_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnaylaIptal1_Onaylandiginde(sender, e);
        }

        private void CmsNesneler_YenidenYukle_Click(object sender, EventArgs e)
        {
            this._NesneleriYukle();
        }

        private bool AramaMenusuAcik = false;

        private void CmsNesneler_Arama_Click(object sender, EventArgs e)
        {
            cmsNesneler_Arama.Text = "Arama Menüsünü " + (AramaMenusuAcik ? "Göster" : "Gizle");
            string ttText = "Arama Menüsünü " + (AramaMenusuAcik ? "Gösterir" : "Gizler");
            cmsNesneler_Arama.ToolTipText = ttText + ". (CTRL + F)";
            Image image = AramaMenusuAcik ? GorusmeKayitlari.Resources.DigerResimler.Buyutec : GorusmeKayitlari.Resources.DigerResimler.Buyutec_Carpiisaretli;
            cmsNesneler_Arama.Image = image;
            Delegates.Image.Set(pboxBul, image);
            Optimizasyon.Delagate(pboxBul, ()=> { ttBul.SetToolTip(pboxBul, ttText); });
            Optimizasyon.Delagate(lstNesneler, () =>
            {
                lstNesneler.Size = new Size(lstNesneler.Width, lstNesneler.Height + (AramaMenusuAcik ? 69 : (-1 * 69)));
            });
            AramaMenusuAcik = !AramaMenusuAcik;
        }

        private void pboxBul_Click(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(cmsNesneler, () =>
            {
                CmsNesneler_Arama_Click(sender, e);
            });
        }
    }
}
