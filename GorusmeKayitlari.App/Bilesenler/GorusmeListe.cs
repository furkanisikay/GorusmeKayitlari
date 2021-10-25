using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Components.ExporterForms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;

namespace GorusmeKayitlari.App.Bilesenler
{
    public partial class GorusmeListe : UserControl
    {
        #region Constructor
        public GorusmeListe()
        {
            InitializeComponent();
            //_cmbKullanicilar_Yukle(); # tasarlama ekranında eklenenlerde  sorun çıkarmaması için #
            this.Mod = GorusmeListelemeModu.None;
        }
        /// <summary>
        /// Belirtilen Kurumun Id'sine göre görüşmeleri listeler.
        /// </summary>
        /// <param name="Kurum">Listelenecek Görüşmelerin Kurum'u.</param>
        public GorusmeListe(Kurum Kurum)
        {
            InitializeComponent();
            this.Kurum = Kurum;
            _cmbKullanicilar_Yukle();
            this.Mod = GorusmeListelemeModu.KurumaGore;
        }
        /// <summary>
        /// Belirtilen Kategorideki ve Alt kategorilerindeki kurumların görüşmelerini listeler.
        /// </summary>
        /// <param name="Kategori">Ana Kategori.</param>
        public GorusmeListe(Kategori Kategori)
        {
            InitializeComponent();
            this.Kategori = Kategori;
            _cmbKullanicilar_Yukle();
            this.Mod = GorusmeListelemeModu.KategoriyeGore;
        }
        /// <summary>
        /// Listedeki kurum idlerine göre görüşmeleri listeler.
        /// </summary>
        /// <param name="Kurumlar">Listelenecek Kurumların id listesi.</param>
        public GorusmeListe(List<Kurum> Kurumlar)
        {
            InitializeComponent();
            this.KurumListesi = Kurumlar;
            _cmbKullanicilar_Yukle();
            this.Mod = GorusmeListelemeModu.KarisikKurumlaraGore;
        }
        #endregion

        # region GorusmeListe Members
        /// <summary>
        /// Sadece belirtilen kuruma göre görüşmeleri listeler.
        /// </summary>
        public Kurum Kurum { get { return new Kurum(this.kurumId); } set { _ModAyarla(value); } }
        /// <summary>
        /// Sadece belirtilen kategoriye göre görüşmeleri listeler.
        /// </summary>
        public Kategori Kategori { get { return new Kategori(this.kategoriId); } set { _ModAyarla(value); } }
        /// <summary>
        /// Sadece belirtilen listedeki kurum idlerine göre görüşmeleri listeler.
        /// </summary>
        public List<Kurum> KurumListesi { get { return kurumlar; } set { _ModAyarla(value); } }
        private int kurumId = -1;
        private int kategoriId = -1;
        private List<Kurum> kurumlar = null;
        private GorusmeListelemeModu Mod = GorusmeListelemeModu.None;

        public ConnectionManager CmGorusmeler { get; set; }
        #endregion

        #region Events
        public event EventHandler EkleTiklandiginda;
        public event EventHandler<Gorusme> DuzenleTiklandiginda;
        public event EventHandler<List<Gorusme>> SilTiklandiginda;
        public event EventHandler<List<Gorusme>> GizleTiklandiginda;
        #endregion

        #region Methods
        #region ### _ModAyarla fonksiyonları ###
        private void _ModAyarla(Kurum kurum)
        {
            this.kurumId = kurum.Id;
            this.kategoriId = -1;
            this.kurumlar = null;
            this.Mod = GorusmeListelemeModu.KurumaGore;
        }
        private void _ModAyarla(Kategori kategori)
        {
            this.kategoriId = kategori.Id;
            this.kurumId = -1;
            this.kurumlar = null;
            this.Mod = GorusmeListelemeModu.KategoriyeGore;
        }
        private void _ModAyarla(List<Kurum> KurumIdler)
        {
            this.kurumlar = KurumIdler;
            this.kurumId = -1;
            this.kategoriId = -1;
            this.Mod = GorusmeListelemeModu.KarisikKurumlaraGore;
        }
        #endregion

        #region ### Grup Yükleme Kodları ###
        private void _GruplariTemizle()
        {
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.Groups.Clear(); });
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.ShowGroups = false; });
        }
        private void _GrupEkle(Kurum kurum)
        {
            ListViewGroup grup = new ListViewGroup();
            grup.Header = kurum.ToString();
            grup.Tag = kurum;
            grup.Name = "_lstGorusmeler_" + kurum.Id.ToString();
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.Groups.Add(grup); });
        }
        private void _GruplariYukle(List<Kurum> kurumlar)
        {
            _GruplariTemizle();
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.ShowGroups = true; });
            if (kurumlar != null)
            {
                foreach (Kurum kurum in kurumlar)
                {
                    _GrupEkle(kurum);
                }
            }
        }
        private ListViewGroup _GrupBul(Kurum kurum)
        {
            ListViewGroup grup = null;
            if (lstGorusmeler.Groups.Count != 0 && kurum != null)
            {
                for (int i = 0; i < lstGorusmeler.Groups.Count; i++)
                {
                    grup = lstGorusmeler.Groups[i];
                    if (grup.Header == kurum.ToString() && grup.Tag != null && grup.Name == "_lstGorusmeler_" + kurum.Id.ToString())
                    {
                        return lstGorusmeler.Groups[i];
                    }
                }
                grup = null;
            }
            else
            {
                grup = null;
            }
            return grup;
        }
        #endregion

        #region ### Görüşme Yükleme Kodları ###
        private void _KolonlariBoyutlandir()
        {
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent); });
        }
        private void _GorusmeleriTemizle()
        {
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.Items.Clear(); });
        }
        private void _GorusmeEkle(Gorusme gorusme)
        {
            ListViewItem item = new ListViewItem();
            #region # item içeriğini ayarlama bölümü  #
            for (int i = 0; i < lstGorusmeler.Columns.Count - 1; i++)
            {
                item.SubItems.Add("-");
            }
            item.SubItems[clmTarih.DisplayIndex].Text = !string.IsNullOrEmpty(gorusme.Tarih.ToShortDateString()) ? gorusme.Tarih.ToShortDateString() : "-";
            item.SubItems[clmMetin.DisplayIndex].Text = !string.IsNullOrEmpty(gorusme.Metin) ? gorusme.Metin : "-";
            item.SubItems[clmKullanici.DisplayIndex].Text = DigerFonksiyonlar.EmptyToCizgi(gorusme.Kullanici);
            item.SubItems[clmYetkili.DisplayIndex].Text = DigerFonksiyonlar.EmptyToCizgi(gorusme.Yetkili);
            item.SubItems[clmKurum.DisplayIndex].Text = DigerFonksiyonlar.EmptyToCizgi(gorusme.Kurum);
            item.ToolTipText = gorusme.Metin;
            item.Tag = gorusme;
            item.Name = "_lstGorusmeler_" + gorusme.Id.ToString();
            if (this.Mod == GorusmeListelemeModu.KategoriyeGore || this.Mod == GorusmeListelemeModu.KarisikKurumlaraGore)
            {
                item.Group = _GrupBul(gorusme.Kurum);
            }
            #endregion
            Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.Items.Add(item); });
        }
        private async void _GorusmeleriYukle()
        {
            List<List<object>> KveYIdleri = await _KurumveYetkiliIdleriGetir();
            List<Gorusme> gorusmeler = await _GorusmeleriGetir(KveYIdleri);
            if (gorusmeler != null && gorusmeler.Count != 0 && KveYIdleri != null && KveYIdleri[0] != null)
            {
                _GruplariYukle(_ListConvert<Kurum>(KveYIdleri[0]));
                foreach (Gorusme gorusme in gorusmeler)
                {
                    _GorusmeEkle(gorusme);
                }
            }
            if ((lstGorusmeler.Items.Count == 0 || this.Mod == GorusmeListelemeModu.KurumaGore)
                || ((this.Mod == GorusmeListelemeModu.KategoriyeGore || this.Mod == GorusmeListelemeModu.KarisikKurumlaraGore) && lstGorusmeler.Items.Count == 1))
            {
                _GruplariTemizle();
            }
            if (lstGorusmeler.Items.Count == 0)
            {
                _GorusmeEkle(new Gorusme(-1, new Kurum(-1), new Yetkili(-1), new Kullanici(-1), DateTime.Now, "Bulunamadı"));
            }
        }

        #region ### Görüşmeleri Getirme Bölümü ###
        #region ### KurumIdleri Ayarlama Bölümü ###
        private async Task<List<List<object>>> _KurumveYetkiliIdleriGetir()
        {
            switch (Mod)
            {
                case GorusmeListelemeModu.KurumaGore:
                    if (this.kurumId > -1) { return await _KurumaGoreKurumveYetkiliIDleriGetir(new Kurum(this.kurumId)); }
                    else { return null; }
                case GorusmeListelemeModu.KategoriyeGore:
                    if (this.kategoriId > -1) { return await _KategoriyeGoreKurumveYetkiliIDleriGetir(new Kategori(this.kategoriId)); }
                    else { return null; }
                case GorusmeListelemeModu.KarisikKurumlaraGore:
                    return _IdlereGoreKurumveYetkiliIDleriGetir(this.KurumListesi);
                default:
                    return null;
            }
        }
        private async Task<List<List<object>>> _KurumaGoreKurumveYetkiliIDleriGetir(Kurum kurum)
        {
            if (kurum != null && kurum.Id > -1 && CmGorusmeler != null)
            {
                Kurum tmpKurum = await Kurumlar.Getir(kurum.Id, CmGorusmeler);
                if (tmpKurum != null)
                {
                    return _ListeOlustur(_ListeOlustur((object)tmpKurum), _ListeOlustur((object)tmpKurum.Yetkili));
                }
                else { return null; }
            }
            else { return null; }
        }
        private async Task<List<List<object>>> _KategoriyeGoreKurumveYetkiliIDleriGetir(Kategori kategori)
        {
            if (CmGorusmeler != null)
            {
                List<Kurum> kategoridekiKurumlar = await Kurumlar.AltKategorilereGoreTumunuGetir(kategori, CmGorusmeler);
                if (kategoridekiKurumlar != null)
                {
                    List<object> kurumlar = new List<object>();
                    List<object> yetkililer = new List<object>();
                    foreach (Kurum kurum in kategoridekiKurumlar)
                    {
                        if (kurum.Yetkili.Id > 0)
                        {
                            kurumlar.Add(kurum);
                            yetkililer.Add(kurum.Yetkili);
                        }
                    }
                    List<List<object>> listeler = new List<List<object>>
                {
                    kurumlar,
                    yetkililer
                };
                    return listeler;
                }
                else { return null; }
            }
            else { return null; }
        }
        private List<List<object>> _IdlereGoreKurumveYetkiliIDleriGetir(List<Kurum> Kurumlar)
        {
            if (Kurumlar != null && Kurumlar.Count != 0)
            {
                List<object> kurumlar = new List<object>();
                List<object> yetkililer = new List<object>();
                foreach (Kurum kurum in Kurumlar)
                {
                    if (kurum != null && kurum.Yetkili != null)
                    {
                        kurumlar.Add(kurum);
                        yetkililer.Add(kurum.Yetkili);
                    }

                }
                return _ListeOlustur(kurumlar, yetkililer);
            }
            else { return null; }
        }
        #endregion
        private List<T> _ListConvert<T>(List<object> nesneler) where T : class
        {
            if (nesneler != null && nesneler.Count != 0)
            {
                List<T> converteds = new List<T>();
                foreach (object item in nesneler)
                {
                    converteds.Add(item as T);
                }
                return converteds;
            }
            else { return null; }
        }
        private async Task<List<Gorusme>> _GorusmeleriGetir(List<List<object>> KurumveYetkiliIdleri)
        {
            List<Gorusme> gorusmeler = new List<Gorusme>();
            List<List<object>> kurumveyetkiliidler = KurumveYetkiliIdleri;
            if (kurumveyetkiliidler != null && kurumveyetkiliidler.Count == 2
                && kurumveyetkiliidler[0] != null && kurumveyetkiliidler[0].Count != 0
                && kurumveyetkiliidler[1] != null && kurumveyetkiliidler[1].Count != 0
                && CmGorusmeler != null )
            {
                TumunuGetirArgs args = new TumunuGetirArgs(
                    _ListConvert<Kurum>(kurumveyetkiliidler[0])
                    , _ListConvert<Yetkili>(kurumveyetkiliidler[1])
                    , _KullanicilariOlustur()
                    , tarihFiltreleme1._BaslangicTarihiOlustur()
                    , tarihFiltreleme1._BitisTarihiOlustur());
                gorusmeler = await Gorusmeler.TumunuGetir(args, CmGorusmeler);
            }
            else { return null; }
            return gorusmeler;
        }
        #endregion
        /// <summary>
        /// Görüşme Listesini Yeniden Yükler.
        /// </summary>
        /// <param name="arkaplanda">Yükleme  işlemi arkplanda ise true,değilse false</param>
        public void GorusmeleriYukle(bool arkaplanda = true)
        {
            Action islemler = new Action(async() => 
            {
                _SetDurum("Görüşmeler yükleniyor...", Color.OrangeRed);
                Stopwatch sw = new Stopwatch();
                sw.Start();
                _Yukleniyor(true);
                _AktarmaButonlariniAyarla(false);
                _GorusmeleriTemizle();
                _GorusmeleriYukle();
                _KolonlariBoyutlandir();
                _AktarmaButonlariniAyarla(_ListeBosDegilse());
                _Yukleniyor(false);
                sw.Stop();
                _SetDurum("İşlem " + DigerFonksiyonlar.MillisecondsToTimeString(sw.ElapsedMilliseconds) + " sürede tamamlandı", Color.Green);
                await _ResetDurum();
            });
            if (arkaplanda)
            {
                Optimizasyon.ArkaplandaCalistir(() => { islemler(); });
            }
            else { islemler(); }
        }
        #endregion

        #region ### İçerik Oluşturma Bölümü ###

        private List<T> _ListeOlustur<T>(params T[] Yetkililer)
        {
            List<T> nesneler = new List<T>();
            try
            {
                foreach (T nesne in Yetkililer)
                {
                    nesneler.Add(nesne);
                }
            }
            catch (Exception ex) { Logger.Log(ex); nesneler = null; }
            return nesneler;
        }
        private List<Kullanici> _KullanicilariOlustur()
        {
            List<Kullanici> kullanicilar = new List<Kullanici>();
            if (cmbKullanicilar.Items.Count > 0)
            {
                for (int i = 0; i < cmbKullanicilar.Items.Count; i++)
                {
                    if (cmbKullanicilar.GetItemChecked(i) && (cmbKullanicilar.Items[i] as Kullanici) != null && ((cmbKullanicilar.Items[i] as Kullanici).Id != -1)) { kullanicilar.Add(cmbKullanicilar.Items[i] as Kullanici); }
                }
            }
            else
            {
                kullanicilar = new List<Kullanici>();
            }
            return kullanicilar;
        }
        #endregion

        #region ### Diğer Kodlar ###
        private bool _ListeBosDegilse()
        {
            bool deger = false;
            Optimizasyon.Delagate(lstGorusmeler, () => { deger = lstGorusmeler != null && lstGorusmeler.Items != null && lstGorusmeler.Items.Count != 0 && _IsNotBulunamadi(lstGorusmeler.Items[0]); });
            return deger;
        }

        /// <summary>
        /// ListViewItem bir nesnenin 'Bulunamadi' ListViewItem'i olup olmadığını denetler.
        /// </summary>
        /// <param name="item">Denetlenecek ListViewItem türündeki nesne.</param>
        /// <returns>bool</returns>
        private bool _IsNotBulunamadi(ListViewItem item)
        {
            return item != null
                && item.Tag != null
                && item.Tag is Gorusme
                && (item.Tag as Gorusme).Id > 0
                && !string.IsNullOrEmpty(item.Name)
                && item.Name.StartsWith("_lstGorusmeler_")
                && item.Name.Remove(0, "_lstGorusmeler_".Length) != "-1";
        }
        private ListViewItem _SecilenIlkveTekItemiGetir()
        {
            if (_ListeBosDegilse() && lstGorusmeler.SelectedItems != null && lstGorusmeler.SelectedItems.Count != 0 && lstGorusmeler.SelectedItems[0] != null && lstGorusmeler.SelectedItems[0].Tag != null && lstGorusmeler.SelectedItems[0].Tag is Gorusme)
            {
                return lstGorusmeler.SelectedItems[0];
            }
            else { return null; }
        }
        private List<ListViewItem> _SecilenItemleriGetir()
        {
            if (_ListeBosDegilse() && lstGorusmeler.SelectedItems != null && lstGorusmeler.SelectedItems.Count >= 1)
            {
                List<ListViewItem> itemler = new List<ListViewItem>();
                foreach (ListViewItem item in lstGorusmeler.SelectedItems)
                {
                    if (_IsNotBulunamadi(item))
                    {
                        itemler.Add(item);
                    }
                }
                return itemler;
            }
            else { return null; }
        }
 
 
        private void _Yukleniyor(bool goster)
        {
            Optimizasyon.Delagate(tarihFiltreleme1, () => { tarihFiltreleme1.FiltrelemeAktif = !goster; });
            Delegates.Enabled.Set(btnKullaniciFiltrele, !goster);
            _YukleniyorOrtala();
            Delegates.Visible.Set(yukleniyor1, goster);
        }
        private void _YukleniyorOrtala()
        {
            Size lstgorusmelersize = Delegates.Size.Get(lstGorusmeler);
            Size yukleniyorsize = Delegates.Size.Get(yukleniyor1);
            Delegates.Location.Set(yukleniyor1, new Point((lstgorusmelersize.Width / 2) - (yukleniyorsize.Width / 2), (lstgorusmelersize.Height / 2) - (yukleniyorsize.Height / 2)));
        }
        private void _AktarmaButonlariniAyarla(bool Aktif)
        {
            Delegates.Enabled.Set(btnExceleAktar, Aktif);
            Delegates.Enabled.Set(btnHtmleAktar, Aktif);
            Delegates.Enabled.Set(btnPdfeAktar, Aktif);
        }

        private void _SetDurum(string yazi, Color renk)
        {
            Optimizasyon.Delagate(ssMain, () =>
            {
                lblDurum.Text = string.Format("Durum : {0}", yazi);
                lblDurum.ForeColor = renk;
            });
        }
        private async Task _ResetDurum()
        {
            await Task.Delay(3000);
            Optimizasyon.Delagate(ssMain, () =>
             {
                 if (lblDurum.ForeColor == Color.Green)
                 {
                     _SetDurum("İşlem bekleniyor", Color.DodgerBlue);
                 }
             });
        }

        /// <summary>
        /// Belirtilen listedeki görüşmeleri listeden temizler.
        /// </summary>
        /// <param name="gorusmeler">gizlenecek görüşmelerin listesi.</param>
        public void GorusmeleriGizle(List<Gorusme> gorusmeler)
        {
            if (gorusmeler != null && gorusmeler.Count != 0)
            {
                foreach (Gorusme gorusme in gorusmeler)
                {
                    foreach (ListViewItem item in lstGorusmeler.Items)
                    {
                        try
                        {
                            if (item.Tag != null && item.Tag as Gorusme == gorusme)
                            {
                                Optimizasyon.Delagate(lstGorusmeler, () => { lstGorusmeler.Items.RemoveAt(item.Index); });
                                break;
                            }
                        }
                        catch (Exception ex) { Logger.Log(ex); }
                    }
                }
            }
        }
        #endregion

        #region ### Kullanicilari Ayarlama Bölümü ###
        private void _cmbKullanicilar_Temizle()
        {
            Optimizasyon.Delagate(cmbKullanicilar, () => { cmbKullanicilar.Items.Clear(); });
        }
        private void _cmbKullanicilar_Ekle(Kullanici kullanici)
        {
            if (kullanici != null)
            {
                Optimizasyon.Delagate(cmbKullanicilar, () =>
                {
                    int index = cmbKullanicilar.Items.Add(kullanici);
                    cmbKullanicilar.SetItemChecked(index, true);
                });

            }
        }
        private void _cmbKullanicilar_Ekle(string yazi = "Bulunamadı")
        {
            Optimizasyon.Delagate(cmbKullanicilar, () =>
            {
                int index = cmbKullanicilar.Items.Add(yazi);
                cmbKullanicilar.SetItemChecked(index, true);
            });
        }
        private async void _cmbKullanicilar_Yukle()
        {
            _cmbKullanicilar_Temizle();
            if (this.DesignMode || DigerFonksiyonlar.IsDesingMode())
            {
                _cmbKullanicilar_Ekle("Tasarım Modunda Kullanıcılar Yüklenemez");//Visual Studio'nun donup kapanmaması için
            }
            else
            {
                List<Kullanici> kullanicilar = await Kullanicilar.TumunuGetir(CmGorusmeler);
                if (kullanicilar != null && kullanicilar.Count != 0)
                {
                    foreach (Kullanici kullanici in kullanicilar)
                    {
                        _cmbKullanicilar_Ekle(kullanici);
                    }
                }
                else
                {
                    _cmbKullanicilar_Ekle();
                }
            }
        }

        #endregion

        #region Aktarma Butonları Kodları

        private void BtnExceleAktar_Click(object sender, EventArgs e)
        {
            using (ExceleAktar eaForm = new ExceleAktar(this.lstGorusmeler))
            {
                try { eaForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Excel'e Aktarma Penceresi Açılırken Hata Oluştu!"); }
            }
        }

        private void BtnPdfeAktar_Click(object sender, EventArgs e)
        {
            using (PdfeAktar paForm = new PdfeAktar(this.lstGorusmeler))
            {
                try { paForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "PDF'e Aktarma Penceresi Açılırken Hata Oluştu!"); }
            }
        }

        private void BtnHtmleAktar_Click(object sender, EventArgs e)
        {
            using (HtmleAktar haForm = new HtmleAktar(this.lstGorusmeler))
            {
                try { haForm.ShowDialog(); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Html'e Aktarma Penceresi Açılırken Hata Oluştu!"); }
            }
        }

        #endregion

        #region Diğer Control Eventleri

        private void BtnFiltrele_Click(object sender, TarihFiltreleEventArgs e)
        {
            this.GorusmeleriYukle();
        }

        private void BtnKullaniciFiltrele_Click(object sender, EventArgs e)
        {
            this.GorusmeleriYukle();
        }

        private void CmsKullanicilarFiltrele_Yenile_Click(object sender, EventArgs e)
        {
            Optimizasyon.ArkaplandaCalistir(() => { _cmbKullanicilar_Yukle(); });
        }
        
        #endregion

        #region LstGorusmeler Event Kodları
        private void LstGorusmeler_SizeChanged(object sender, EventArgs e)
        {
            _YukleniyorOrtala();
        }

        private void LstGorusmeler_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ListViewItem item = _SecilenIlkveTekItemiGetir();
                if (item != null)
                {
                    try { CmsGorusmeler_Duzenle_Click(sender, e); }
                    catch (Exception ex) { Logger.Log(ex); }
                }
                else
                {
                    try { CmsGorusmeler_Ekle_Click(sender, e); }
                    catch (Exception ex) { Logger.Log(ex); }
                }
            }
        }

        private void LstGorusmeler_DoubleClick(object sender, EventArgs e)
        {
            Optimizasyon.ArkaplandaCalistir(() => { Optimizasyon.Delagate((Control)sender, () => { CmsGorusmeler_Duzenle_Click(sender, e); }); });
        }
        #endregion

        #region ### cmsGorusmeler Event Kodları ###

        private void CmsGorusmeler_Opening(object sender, CancelEventArgs e)
        {
            if (_ListeBosDegilse())
            {
                if (lstGorusmeler.SelectedItems.Count >= 1)
                {
                    if (lstGorusmeler.SelectedItems.Count == 1)
                    {
                        cmsGorusmeler_Ekle.Visible = true;
                        cmsGorusmeler_Duzenle.Visible = true;
                        cmsGorusmeler_Sil.Visible = true;
                        cmsGorusmeler_Sil.Text = "Sil";
                        cmsGorusmeler_Gizle.Visible = true;
                        cmsGorusmeler_Gizle.Text = "Gizle";
                    }
                    else
                    {
                        cmsGorusmeler_Ekle.Visible = true;
                        cmsGorusmeler_Duzenle.Visible = false;
                        cmsGorusmeler_Sil.Visible = true;
                        cmsGorusmeler_Sil.Text = "Seçilenleri Sil";
                        cmsGorusmeler_Gizle.Visible = true;
                        cmsGorusmeler_Gizle.Text = "Seçilenleri Gizle";
                    }
                }
                else
                {
                    cmsGorusmeler_Ekle.Visible = true;
                    cmsGorusmeler_Duzenle.Visible = false;
                    cmsGorusmeler_Sil.Visible = false;
                    cmsGorusmeler_Sil.Text = "Sil";
                    cmsGorusmeler_Gizle.Visible = false;
                    cmsGorusmeler_Gizle.Text = "Gizle";
                }
            }
            else
            {
                cmsGorusmeler_Ekle.Visible = true;
                cmsGorusmeler_Duzenle.Visible = false;
                cmsGorusmeler_Sil.Visible = false;
                cmsGorusmeler_Sil.Text = "Sil";
                cmsGorusmeler_Gizle.Visible = false;
                cmsGorusmeler_Gizle.Text = "Gizle";
            }
        }

        private void CmsGorusmeler_Ekle_Click(object sender, EventArgs e)
        {
            if (EkleTiklandiginda != null)
            {
                try { EkleTiklandiginda(sender, null); }
                catch (Exception ex) { Logger.Log(ex); }
            }
        }

        private void CmsGorusmeler_Duzenle_Click(object sender, EventArgs e)
        {
            if (DuzenleTiklandiginda != null)
            {
                ListViewItem item = _SecilenIlkveTekItemiGetir();
                if (item != null)
                {
                    try { DuzenleTiklandiginda(sender, item.Tag as Gorusme); }
                    catch (Exception ex) { Logger.Log(ex); }
                }
            }
        }

        private void CmsGorusmeler_Sil_Click(object sender, EventArgs e)
        {
            if (SilTiklandiginda != null)
            {
                List<ListViewItem> itemler = _SecilenItemleriGetir();
                if (itemler != null && itemler.Count != 0)
                {
                    List<Gorusme> secilenGorusmeler = new List<Gorusme>();
                    foreach (ListViewItem item in itemler)
                    {
                        try { secilenGorusmeler.Add(item.Tag as Gorusme); }
                        catch (Exception ex) { Logger.Log(ex); }
                    }
                    try { SilTiklandiginda(sender, secilenGorusmeler); }
                    catch (Exception ex) { Logger.Log(ex); }
                }
            }
        }

        private void CmsGorusmeler_Gizle_Click(object sender, EventArgs e)
        {
            if (GizleTiklandiginda != null)
            {
                List<ListViewItem> itemler = _SecilenItemleriGetir();
                if (itemler != null && itemler.Count != 0)
                {
                    List<Gorusme> secilenGorusmeler = new List<Gorusme>();
                    foreach (ListViewItem item in itemler)
                    {
                        try { secilenGorusmeler.Add(item.Tag as Gorusme); }
                        catch (Exception ex) { Logger.Log(ex); }
                    }
                    try { GizleTiklandiginda(sender, secilenGorusmeler); }
                    catch (Exception ex) { Logger.Log(ex); }
                }
            }
        }

        #endregion

        #endregion

        private void GorusmeListe_Load(object sender, EventArgs e)
        {
            _cmbKullanicilar_Yukle();
        }
    }
}
