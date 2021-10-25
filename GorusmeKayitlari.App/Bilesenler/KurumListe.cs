using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.DB.Methods;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GorusmeKayitlari.App.Bilesenler
{
    public partial class KurumListe : UserControl
    {
        public KurumListe()
        {
            InitializeComponent();
            this.KategoriId = -1;
            GosterimTuru = GosterimTuru.None;
            AltKategorilerDahil = true;
        }

        public KurumListe(int kategoriId)
        {
            InitializeComponent();
            this.KategoriId = kategoriId;
            GosterimTuru = GosterimTuru.Tekli;
            AltKategorilerDahil = true;
        }

        public KurumListe(List<int> KategoriIdler)
        {
            InitializeComponent();
            this.KategoriIdler = KategoriIdler;
            GosterimTuru = GosterimTuru.Coklu;
            AltKategorilerDahil = true;
        }

        public GosterimTuru GosterimTuru { get; set; }
        public int KategoriId { get; set; }
        public List<int> KategoriIdler { get; set; }
        public bool AltKategorilerDahil { get; set; }
        public  Oturum KullaniciOturumu { get; set; }

        private void _KurumlariTemizle()
        {
            Optimizasyon.Delagate(lstKurumlar, () => { lstKurumlar.Items.Clear(); });
        }

        private void _KurumEkle(Kurum kurum)
        {
            DataListViewItem item = new DataListViewItem(kurum);
            Optimizasyon.Delagate(lstKurumlar, () => { lstKurumlar.Items.Add(item); });
        }

        private async System.Threading.Tasks.Task<List<Kurum>> _KurumlariYukle_Alt(int kategoriid)
        {
            List<Kurum> tmp_krmlar = new List<Kurum>();
            List<Kurum> tmp_krm = await Kurumlar.TumunuGetir(new Kategori(kategoriid), App.Instance.ConnManager);
            if (tmp_krm != null && tmp_krm.Count != 0)
            {
                tmp_krmlar.AddRange(tmp_krm);
                if (this.AltKategorilerDahil)
                {
                    List<Kategori> kat = await Kategoriler.UstKategoriIdeGoreTumunuGetir(kategoriid, App.Instance.ConnManager);
                    foreach (Kategori _kategori in kat)
                    {
                        List<Kurum> _tmp_krm = await Kurumlar.TumunuGetir(_kategori, App.Instance.ConnManager);
                        if (_tmp_krm != null && _tmp_krm.Count != 0) { tmp_krmlar.AddRange(_tmp_krm); }
                    }
                }
            }
            return tmp_krmlar;
        }

        Kurum _BosKurumOlustur(string ad)
        {
            return new Kurum(-1, null, ad, null, null, "");
        }

        private async void _KurumlariYukle()
        {
            YukleniyorkenArgs args = new YukleniyorkenArgs();
            KurumlarYuklenirken?.Invoke(null, args);
            _Yukleniyor(true);
            Optimizasyon.Delagate(this, () => { this.UseWaitCursor = true; });
            _KurumlariTemizle();
            if (this.DesignMode)
            {
                args.Data = "design";
            }
            if (args.Cancel)
            {
                _KurumEkle(_BosKurumOlustur("Yükleme işlemi iptal edildi"));
            }
            else
            {
                if (args.Data != null)
                {
                    if ((args.Data as string) == "yetkisiz")
                    {
                        _KurumEkle(_BosKurumOlustur("Kurum görüntüleme yetkiniz bulunmamaktadır"));
                    }
                    else if ((args.Data as string) == "design")
                    {
                        _KurumEkle(_BosKurumOlustur("Tasarım modundasınız"));
                    }
                }
                else
                {
                    List<Kurum> kurumlar = new List<Kurum>();
                    if (GosterimTuru == GosterimTuru.Tekli && KategoriId > 0)
                    {
                        kurumlar = await _KurumlariYukle_Alt(KategoriId);
                    }
                    else if (GosterimTuru == GosterimTuru.Coklu && KategoriIdler != null && KategoriIdler.Count != 0)
                    {
                        foreach (int id in KategoriIdler)
                        {
                            kurumlar.AddRange(await _KurumlariYukle_Alt(id));
                        }
                    }
                    else
                    {
                        //kurumlar = await Kurumlar.TumunuGetir();
                    }
                    if (kurumlar != null && kurumlar.Count != 0)
                    {
                        foreach (Kurum kurum in kurumlar)
                        {
                            _KurumEkle(kurum);
                        }
                    }
                    else
                    {
                        _KurumEkle(_BosKurumOlustur("Kurum Bulunamadı"));
                    }
                }
            }
            _Yukleniyor(false);
            Optimizasyon.Delagate(this, () => { this.UseWaitCursor = false; });
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
        private async void BwKurumYukle_DoWork(object sender, DoWorkEventArgs e)
        {
            _SetDurum("İşlem yürütülüyor...", Color.OrangeRed);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _KurumlariYukle();
            sw.Stop();
            _SetDurum("İşlem " + DigerFonksiyonlar.MillisecondsToTimeString(sw.ElapsedMilliseconds) + " sürede tamamlandı", Color.Green);
            await _ResetDurum();
        }

        private void BwKurumYukle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                bwKurumYukle.RunWorkerAsync();
            }
        }

        /// <summary>
        /// Listedeki Kurumları Silip Belirtilen KategoriId'ye göre tekrardan yükler.
        /// </summary>
        /// <param name="arkaplanda">Kurumları arkplanda yüklenme durumu.</param>
        public void KurumlariYukle()
        {
            if (bwKurumYukle.IsBusy)
            {
                bwKurumYukle.CancelAsync();
            }
            else { bwKurumYukle.RunWorkerAsync(); }

        }
        public void Resetle()
        {
            _KurumlariTemizle();
            _KurumEkle(_BosKurumOlustur("Kurum Bulunamadı"));
        }

        private void LstKurumlar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try { CmsKurumlar_Goruntule_Click(sender, e); }
            catch (Exception ex) { Logger.Log(ex); throw ex; }
        }
        private void LstKurumlar_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try { CmsKurumlar_Goruntule_Click(sender, e); }
                catch (Exception ex) { Logger.Log(ex); }
            }
        }

        private void _Yukleniyor(bool Goster)
        {
            _YukleniyorOrtala();
            Delegates.Visible.Set(yukleniyor1, Goster);
        }

        private void _YukleniyorOrtala()
        {
            Size thissize = Delegates.Size.Get(this);
            Size yukleniyorsize = Delegates.Size.Get(yukleniyor1);
            Delegates.Location.Set(yukleniyor1, new Point((thissize.Width / 2) - (yukleniyorsize.Width / 2), (thissize.Height / 2) - (yukleniyorsize.Height / 2)));
        }

        private void CmsKurumlar_Goruntule_Click(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && GoruntuleTiklandiginde != null && lstKurumlar.SelectedItems != null && lstKurumlar.SelectedItems.Count >= 1)
            {
                List<Kurum> secilenkurumlar = new List<Kurum>();
                foreach (ListViewItem item in lstKurumlar.SelectedItems)
                {
                    secilenkurumlar.Add((Kurum)(((DataListViewItem)item).Data));
                }
                GoruntuleTiklandiginde(sender, secilenkurumlar);
            }
        }

        private void CmsKurumlar_Ekle_Click(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && EkleTiklandiginde != null && lstKurumlar.SelectedItems != null)
            {
                EkleTiklandiginde(sender, e);
            }
        }

        private void CmsKurumlar_Duzenle_Click(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && DuzenleTiklandiginde != null && lstKurumlar.SelectedItems != null && lstKurumlar.SelectedItems.Count == 1)
            {
                DuzenleTiklandiginde(sender, ((Kurum)(((DataListViewItem)(lstKurumlar.SelectedItems[0])).Data)));
            }
        }

        private void CmsKurumlar_Sil_Click(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && SilTiklandiginde != null && lstKurumlar.SelectedItems != null && lstKurumlar.SelectedItems.Count >= 1)
            {
                List<Kurum> secilenkurumlar = new List<Kurum>();
                if (lstKurumlar.SelectedItems.Count == 1)
                {
                    secilenkurumlar.Add(((Kurum)(((DataListViewItem)(lstKurumlar.SelectedItems[0])).Data)));
                }
                else
                {
                    foreach (DataListViewItem item in lstKurumlar.SelectedItems)
                    {
                        secilenkurumlar.Add(((Kurum)item.Data));
                    }
                }
                SilTiklandiginde(sender, secilenkurumlar);
            }
        }

        private void CmsKurumlar_TumunuGoruntule_Click(object sender, EventArgs e)
        {
            if (_ListeBosDegilse() && TumGoruntuleTiklandiginde != null)
            {
                TumGoruntuleTiklandiginde(sender, new Kategori(this.KategoriId));
            }
        }
        private void CmsKurumlar_Opening(object sender, CancelEventArgs e)
        {
            if (_ListeBosDegilse())
            {
                if (lstKurumlar.SelectedItems.Count >= 1)
                {
                    if (lstKurumlar.SelectedItems.Count == 1)
                    {
                        bool gorunum = _YetkiSorgula(NesneYetkileri.KurumGoruntule);
                        cmsKurumlar_Ekle.Visible = _YetkiSorgula(NesneYetkileri.KurumEkle);
                        cmsKurumlar_Duzenle.Visible = _YetkiSorgula(NesneYetkileri.KurumDuzenle);
                        cmsKurumlar_Sil.Visible = _YetkiSorgula(NesneYetkileri.KurumSil);
                        cmsKurumlar_Sil.Text = "Sil";
                        cmsKurumlar_Sil.ToolTipText = "Seçilen kurumu siler.";
                        cmsKurumlar_Goruntule.Visible = gorunum;
                        cmsKurumlar_Goruntule.Text = "Görüntüle";
                        cmsKurumlar_Goruntule.ToolTipText = "Seçilen kuruma ait görüşmeleri görüntüler.";
                        toolStripSeparator2.Visible = gorunum;
                        cmsKurumlar_TumunuGoruntule.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                        toolStripSeparator1.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                    }
                    else
                    {
                        bool gorunum = _YetkiSorgula(NesneYetkileri.KurumGoruntule);
                        cmsKurumlar_Ekle.Visible = gorunum;
                        cmsKurumlar_Duzenle.Visible = false;
                        cmsKurumlar_Sil.Visible = _YetkiSorgula(NesneYetkileri.KurumSil);
                        cmsKurumlar_Sil.Text = "Seçilenleri Sil";
                        cmsKurumlar_Sil.ToolTipText = "Seçilen kurumları siler.";
                        cmsKurumlar_Goruntule.Visible = gorunum;
                        cmsKurumlar_Goruntule.Text = "Seçilenlenleri Görüntüle";
                        cmsKurumlar_Goruntule.ToolTipText = "Sadece seçilen kurumlara ait görüşmeleri görüntüler.";
                        toolStripSeparator2.Visible = gorunum;
                        cmsKurumlar_TumunuGoruntule.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                        toolStripSeparator1.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                    }
                }
                else
                {
                    bool gorunum = _YetkiSorgula(NesneYetkileri.KurumGoruntule);
                    cmsKurumlar_Ekle.Visible = gorunum;
                    cmsKurumlar_Duzenle.Visible = false;
                    cmsKurumlar_Sil.Visible = false;
                    cmsKurumlar_Sil.Text = "Sil";
                    cmsKurumlar_Sil.ToolTipText = "Seçilen kurumu siler.";
                    cmsKurumlar_Goruntule.Visible = false;
                    cmsKurumlar_Goruntule.ToolTipText = "Seçilen kuruma ait görüşmeleri görüntüler.";
                    toolStripSeparator2.Visible = false;
                    cmsKurumlar_TumunuGoruntule.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                    toolStripSeparator1.Visible = (this.GosterimTuru == GosterimTuru.Tekli) && (gorunum);
                }
            }
            else
            {
                cmsKurumlar_Ekle.Visible = _YetkiSorgula(NesneYetkileri.KurumGoruntule);
                cmsKurumlar_Duzenle.Visible = false;
                cmsKurumlar_Sil.Visible = false;
                cmsKurumlar_Sil.Text = "Sil";
                cmsKurumlar_Sil.ToolTipText = "Seçilen kurumu siler.";
                cmsKurumlar_Goruntule.Visible = false;
                cmsKurumlar_Goruntule.ToolTipText = "Seçilen kuruma ait görüşmeleri görüntüler.";
                toolStripSeparator2.Visible = false;
                cmsKurumlar_TumunuGoruntule.Visible = false;
                toolStripSeparator1.Visible = false;
            }
        }

        private bool _YetkiSorgula<T>(T yetki)
        {
            return Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, yetki, KullaniciOturumu, false);
        }

        private bool _ListeBosDegilse()
        {
            return lstKurumlar.Items.Count != 0 && lstKurumlar.Items[0] != null && lstKurumlar.Items[0].Text != "Bulunamadı";
        }


        private void KurumListe_EnabledChanged(object sender, EventArgs e)
        {
            lstKurumlar.Enabled = this.Enabled;
            cmsKurumlar.Enabled = this.Enabled;
        }

        private void KurumListe_Load(object sender, EventArgs e)
        {
            KurumlariYukle();
        }

        private void KurumListe_SizeChanged(object sender, EventArgs e)
        {
            columnHeader1.Width = lstKurumlar.Width - 5;
            if (Delegates.Visible.Get(yukleniyor1))
            {
                _YukleniyorOrtala();
            }
        }


        public event EventHandler<List<Kurum>> GoruntuleTiklandiginde;
        public event EventHandler EkleTiklandiginde;
        public event EventHandler<Kurum> DuzenleTiklandiginde;
        public event EventHandler<List<Kurum>> SilTiklandiginde;
        public event EventHandler<Kategori> TumGoruntuleTiklandiginde;
        public event EventHandler<YukleniyorkenArgs> KurumlarYuklenirken;
    }
}
