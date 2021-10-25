using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Methods;
using System.Drawing;
using System.Threading.Tasks;
using System.Diagnostics;

namespace GorusmeKayitlari.App.Bilesenler
{
    [DefaultEvent("KurumSecildiginde")]
    public partial class Liste : UserControl
    {
        #region Constructor
        public Liste()
        {
            InitializeComponent();
        }
        #endregion

        #region Members
        private Kategori _secilennesne = null;
        internal Kategori SecilenNesne { get { return _secilennesne; } }
        public  Oturum KulOturumu { get; set; }
        #endregion

        #region Public Events
        public event EventHandler<TreeViewEventArgs> KurumSecildiginde;
        public event EventHandler<KurumListelemeModuArgs> KurumIsaretlendiginde;
        public event EventHandler<Kategori> EkleTiklandiginda;
        public event EventHandler<Kategori> DuzenleTiklandiginda;
        public event EventHandler<Kategori> SilTiklandiginda;
        public event EventHandler YenileTiklandiginda;
        public event EventHandler<KurumListelemeModuArgs> KurumGosterimModuDegistiginde;
        public event EventHandler<YukleniyorkenArgs> KategorilerYuklenirken;
        #endregion

        #region Methods

        #region Private Methods
        private void _NodelerdeDonEkle(ref List<DataTreeNode> nodeler, ref List<DataTreeNode> altnodeler)
        {
            List<DataTreeNode> tempnodeler = nodeler;
            List<DataTreeNode> tempaltnodeler = altnodeler;
            for (int i = 0; i < nodeler.Count; i++)
            {
                DataTreeNode _ustnode = nodeler[i];
                for (int ialt = 0; ialt < altnodeler.Count; ialt++)
                {
                    try
                    {
                        DataTreeNode _altnode = altnodeler[ialt];
                        _Node_Ekle(_ustnode, _altnode, ref tempaltnodeler, ialt);
                    }
                    catch (Exception ex) { Logger.Log(ex); }
                }
            }
            if (tempaltnodeler.Count > 0)
            {
                _NodelerdeDonEkle(ref tempnodeler, ref tempaltnodeler);
            }
        }

        private void _Node_Ekle(DataTreeNode _ustnode, DataTreeNode _altnode, ref List<DataTreeNode> altnodeler, int altnodeler_indexi)
        {
            if (((Kategori)_ustnode.Data).Id == ((Kategori)_altnode.Data).UstKategori.Id)
            {
                _ustnode.Nodes.Add(_altnode);
                altnodeler.RemoveAt(altnodeler_indexi);
            }
            else
            {
                foreach (DataTreeNode _ustnode_alt in _ustnode.Nodes)
                {
                    _Node_Ekle(_ustnode_alt, _altnode, ref altnodeler, altnodeler_indexi);
                }
            }
        }

        private void _KategorileriEkle(List<DataTreeNode> nodeler)
        {
            Optimizasyon.Delagate(tvKategoriler, () => { tvKategoriler.Nodes.AddRange(nodeler.ToArray()); });
        }

        private void _KategorileriTemizle()
        {
            Optimizasyon.Delagate(tvKategoriler, () => { tvKategoriler.Nodes.Clear(); });
        }

        void _BosKategoriEkle(string ad)
        {
            _KategorileriEkle(new List<DataTreeNode>(new DataTreeNode[] { _BosNodeOlustur(ad) }));
        }

        DataTreeNode _BosNodeOlustur(string ad)
        {
            return new DataTreeNode(new Kategori(-1, new Kategori(0, null, "(yok)"), ad));
        }

        private async void _KategorileriYukle()
        {
            YukleniyorkenArgs args = new YukleniyorkenArgs();
            KategorilerYuklenirken?.Invoke(null, args);
            _Yukleniyor(true);
            _KategorileriTemizle();
            _Yukleniyor_Ayarla("Kategoriler Alınıyor...", 10);
            if (this.DesignMode)
            {
                args.Data = "design";
            }
            if (args.Cancel)
            {
                _BosKategoriEkle("Yükleme işlemi iptal edildi");
            }
            else
            {
                if (args.Data != null)
                {
                    if ((args.Data as string) == "yetkisiz")
                    {
                        _BosKategoriEkle("Kategori görüntüleme yetkiniz bulunmamaktadır");
                    }
                    else if ((args.Data as string) == "design")
                    {
                        _BosKategoriEkle("Tasarım modundasınız");
                    }
                }
                else
                {
                    List<Kategori> kategoriler = await Kategoriler.TumunuGetir(App.Instance.ConnManager);
                    List<DataTreeNode> nodeler = new List<DataTreeNode>();
                    if (kategoriler != null && kategoriler.Count != 0)
                    {
                        List<DataTreeNode> altnodeler = new List<DataTreeNode>();
                        foreach (Kategori kategori in kategoriler)
                        {
                            if (kategori.UstKategori != null && kategori.UstKategori.Id != kategori.Id)//kategorinin üstkategorisi kendisi ise eklenmemesi için
                            {
                                if (kategori.UstKategori?.Id != -1)
                                {
                                    if (kategori.UstKategori?.Id == 0)
                                    {
                                        nodeler.Add(new DataTreeNode(kategori));
                                    }
                                    else
                                    {
                                        altnodeler.Add(new DataTreeNode(kategori));
                                    }
                                }
                            }
                        }
                        _Yukleniyor_Ayarla("Alt Kategoriler Yerleştiriliyor...", 60);
                        _NodelerdeDonEkle(ref nodeler, ref altnodeler);
                    }
                    else { nodeler.Add(_BosNodeOlustur("Kategori Bulunamadı")); }
                    _Yukleniyor_Ayarla("Tüm Kategoriler Ekleniyor...", 80);
                    _KategorileriEkle(nodeler);
                }
            }
            _Yukleniyor_Ayarla("Yüklendi!", 100);
            _Yukleniyor(false);
        }
        
        private async void BwKategoriYukle_DoWork(object sender, DoWorkEventArgs e)
        {
            _SetDurum("İşlem yürütülüyor...", Color.OrangeRed);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            _KategorileriYukle();
            sw.Stop();
            _SetDurum("İşlem " + DigerFonksiyonlar.MillisecondsToTimeString(sw.ElapsedMilliseconds) + " sürede tamamlandı", Color.Green);
            await _ResetDurum();
        }

        private void BwKategoriYukle_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                bwKategoriYukle.RunWorkerAsync();
            }
        }

        private void _Yukleniyor_Ayarla(string yazi, int yuzde)
        {
            yukleniyor1.SetThis(yazi, yuzde); 
        }

        private void _Yukleniyor(bool Goster)
        {
            Delegates.BackColor.Set(yukleniyor1, Delegates.BackColor.Get(tvKategoriler));
            Delegates.Visible.Set(yukleniyor1, Goster);
        }

        private bool _ListeBosDegilse()
        {
            try
            {
                return tvKategoriler != null && tvKategoriler.Nodes.Count != 0 && tvKategoriler.Nodes[0] != null && ((tvKategoriler.Nodes[0] as DataTreeNode).Data as Kategori).Id != -1;
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        private Kategori _SecilenIlkveTekKategoriyiGetir()
        {
            try
            {
                if (_ListeBosDegilse() && tvKategoriler.SelectedNode != null && ((tvKategoriler.SelectedNode as DataTreeNode).Data as Kategori).Id != -1)
                {
                    return (tvKategoriler.SelectedNode as DataTreeNode).Data as Kategori;
                }
                else { return null; }
            }
            catch (Exception ex) { Logger.Log(ex); return null; }
        }

        private List<Kategori> _IsaretlenenKategoriler(TreeNodeCollection nodeler)
        {
            try
            {
                List<Kategori> kategoriler = new List<Kategori>();
                foreach (TreeNode item in nodeler)
                {
                    if (item.Checked && ((item as DataTreeNode).Data as Kategori).Id != -1)
                    {
                        kategoriler.Add((item as DataTreeNode).Data as Kategori);
                    }
                    if (item.Nodes.Count > 0)
                    {
                        kategoriler.AddRange(_IsaretlenenKategoriler(item.Nodes).ToArray());
                    }
                }
                return kategoriler;
            }
            catch (Exception ex) { Logger.Log(ex); return null; }
        }

        private void _KurumIsaretlendiEventUygula(object sender, EventHandler<KurumListelemeModuArgs> eventhandler)
        {
            if (eventhandler != null)
            {
                KurumListelemeModu mod = cmsKat_GostMod_Tekli.Checked ? KurumListelemeModu.Tekli : KurumListelemeModu.OzelSecim;
                List<Kategori> kategoriler = new List<Kategori>();
                bool altktgrdahil = cmsKat_GostMod_AltKatDahil.Checked;
                if (_ListeBosDegilse())
                {
                    kategoriler = _IsaretlenenKategoriler(tvKategoriler.Nodes);
                }
                eventhandler(sender, new KurumListelemeModuArgs(mod, altktgrdahil, kategoriler));
            }
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
        #endregion

        #region Public Methods
        public void KategorileriYukle(/*bool arkaplanda = true*/)
        {
            if (bwKategoriYukle.IsBusy)
            {
                bwKategoriYukle.CancelAsync();
            }
            else { bwKategoriYukle.RunWorkerAsync(); }
        }
        public void Resetle()
        {
            _KategorileriTemizle();
            cmsKat_GostMod_Tekli.Checked = true;
            cmsKat_GostMod_AltKatDahil.Checked = true;
            _BosKategoriEkle("Kurum Bulunamadı");
        }
        #endregion

        #endregion

        #region Private Control-Events
        private void Liste_Load(object sender, EventArgs e)
        {
            KategorileriYukle();
        }

        private void TvKategoriler_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //try { this._secilennesne = (Kategori)(((DataTreeNode)tvKategoriler.SelectedNode).Data); }
            //catch (Exception ex) { Logger.Log(ex); this._secilennesne = null; }
            //if (KurumSecildiginde != null) { KurumSecildiginde(sender, e); }
        }

        private void TvKategoriler_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvKategoriler.SelectedNode != null)
            {
                try { this._secilennesne = (Kategori)(((DataTreeNode)tvKategoriler.SelectedNode).Data); }
                catch { this._secilennesne = null; }
            }
            if (cmsKat_GostMod_Tekli.Checked && KurumSecildiginde != null)
            {
                KurumSecildiginde(sender, e);
            }
        }

        private void TvKategoriler_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (cmsKat_GostMod_IsaretliKat.Checked)
            {
                _KurumIsaretlendiEventUygula(sender, KurumIsaretlendiginde);
            }
        }

        private void CmsKategoriler_Yenile_Click(object sender, EventArgs e)
        {
            YenileTiklandiginda?.Invoke(sender, e);
        }

        private void CmsKategoriler_Ekle_Click(object sender, EventArgs e)
        {
            EkleTiklandiginda?.Invoke(sender, _SecilenIlkveTekKategoriyiGetir());
        }

        private void CmsKategoriler_Duzenle_Click(object sender, EventArgs e)
        {
            DuzenleTiklandiginda?.Invoke(sender, _SecilenIlkveTekKategoriyiGetir());
        }

        private void CmsKategoriler_Sil_Click(object sender, EventArgs e)
        {
            SilTiklandiginda?.Invoke(sender, _SecilenIlkveTekKategoriyiGetir());
        }

        private void CmsKategoriler_Opening(object sender, CancelEventArgs e)
        {
            if (_ListeBosDegilse() && tvKategoriler.SelectedNode != null && ((tvKategoriler.SelectedNode as DataTreeNode).Data as Kategori).Id != -1)
            {
                cmsKategoriler_Ekle.Visible = _YetkiSorgula(NesneYetkileri.KategoriEkle);
                cmsKategoriler_Duzenle.Visible = _YetkiSorgula(NesneYetkileri.KategoriDuzenle);
                cmsKategoriler_Sil.Visible = _YetkiSorgula(NesneYetkileri.KategoriSil);
                bool gorunum = _YetkiSorgula(NesneYetkileri.KategoriGoruntule);
                toolStripSeparator1.Visible = gorunum;
                cmsKategoriler_Yenile.Visible = gorunum;
            }
            else
            {
                cmsKategoriler_Ekle.Visible = _YetkiSorgula(NesneYetkileri.KategoriEkle);
                cmsKategoriler_Duzenle.Visible = false;
                cmsKategoriler_Sil.Visible = false;
                bool gorunum = _YetkiSorgula(NesneYetkileri.KategoriGoruntule);
                toolStripSeparator1.Visible = gorunum;
                cmsKategoriler_Yenile.Visible = gorunum;
            }
        }

        private bool _YetkiSorgula<T>(T Yetki)
        {
            return Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, Yetki, this.KulOturumu, false);
        }
        #endregion

        bool KurumlarYuklendiUygulandi = false;
        private void CmsKat_GostModes_CheckedChanged(object sender, EventArgs e)
        {
            if (((ToolStripMenuItem)sender).Name == "cmsKat_GostMod_Tekli")
            {
                if (cmsKat_GostMod_Tekli.Checked == cmsKat_GostMod_IsaretliKat.Checked)//iki event arasında kısır döngüye girmemesi için
                {
                    cmsKat_GostMod_IsaretliKat.Checked = !cmsKat_GostMod_Tekli.Checked;
                }
            }
            else if (((ToolStripMenuItem)sender).Name == "cmsKat_GostMod_IsaretliKat")
            {
                if (cmsKat_GostMod_IsaretliKat.Checked == cmsKat_GostMod_Tekli.Checked)//iki event arasında kısır döngüye girmemesi için
                {
                    cmsKat_GostMod_Tekli.Checked = !cmsKat_GostMod_IsaretliKat.Checked;
                }
            }
            if (KurumlarYuklendiUygulandi)
            {
                KurumlarYuklendiUygulandi = false;
            }
            else
            {
                tvKategoriler.CheckBoxes = cmsKat_GostMod_IsaretliKat.Checked;
                btnIsaretleriTemizle.Visible = cmsKat_GostMod_IsaretliKat.Checked;
                _KurumIsaretlendiEventUygula(sender, KurumGosterimModuDegistiginde);
            }
        }

        private void CmsKat_GostMod_AltKatDahil_CheckedChanged(object sender, EventArgs e)
        {
            _KurumIsaretlendiEventUygula(sender, KurumGosterimModuDegistiginde);
        }

        private void BtnIsaretleriTemizle_Click(object sender, EventArgs e)
        {
            foreach (TreeNode node in tvKategoriler.Nodes)
            {
                node.Checked = false;
            }
        }
    }
}
