using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Formlar.NesneFormlari
{
    public partial class KurumGoster : Form
    {

        #region Public Members
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
        public Oturum KulOturum { get; }
        public ConnectionManager ConnManager
        {
            get { return this._ConnManager; }
            set
            {
                this._ConnManager = value;
                try { glGorusmeler.CmGorusmeler = value; }
                catch { Optimizasyon.Delagate(glGorusmeler, () => { glGorusmeler.CmGorusmeler = value; }); }
            }
        }
        #endregion

        #region Private Members
        private int kurumId = -1;
        private int kategoriId = -1;
        private List<Kurum> kurumlar = null;
        private GorusmeListelemeModu Mod = GorusmeListelemeModu.None;
        private ConnectionManager _ConnManager = null;
        #endregion


        #region Constructors
        public KurumGoster()
        {
            InitializeComponent();
            this.Mod = GorusmeListelemeModu.None;
        }
        /// <summary>
        /// Belirtilen Kurumun Id'sine göre görüşmeleri listeler.
        /// </summary>
        /// <param name="Kurum">Listelenecek Görüşmelerin Kurum'u.</param>
        /// <param name="cm">Görüşmeleri listelemek için gerekli ConnectionManager.</param>
        /// <param name="oturum">Görüşmeleri listelemek için gerekli izinleri barındıran Oturum.</param>
        public KurumGoster(Kurum Kurum, ConnectionManager cm, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            this.Kurum = Kurum;
            this.ConnManager = cm;
            Task taskforthisText = new Task(async () =>
            {
                Kurum kurum = await Kurumlar.Getir(Kurum.Id, ConnManager);
                Delegates.Text.Set(this, string.Format("'{0}' kurumuna ait görüşmeler", Kurum.ToString()));
                Optimizasyon.Delagate(this, () => { this.Kurum = kurum; });
            });
            taskforthisText.RunSynchronously();
            this.Mod = GorusmeListelemeModu.KurumaGore;
            Delegates.Visible.Set(btnKrmBilGstr, true); 
        }
        /// <summary>
        /// Belirtilen Kategorideki ve Alt kategorilerindeki kurumların görüşmelerini listeler.
        /// </summary>
        /// <param name="Kategori">Ana Kategori.</param>
        /// <param name="cm">Görüşmeleri listelemek için gerekli ConnectionManager.</param>
        /// <param name="oturum">Görüşmeleri listelemek için gerekli izinleri barındıran Oturum.</param>
        public KurumGoster(Kategori Kategori, ConnectionManager cm, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            this.ConnManager = cm;
            this.Kategori = Kategori;
            Task taskforthisText = new Task(async () =>
            {
                Kategori kategori = await Kategoriler.Getir(Kategori.Id, ConnManager);
                Delegates.Text.Set(this, string.Format("'{0}' kategorisindeki ve alt kategorilerindeki kurumlara ait görüşmeler", kategori.ToString()));
                Optimizasyon.Delagate(this, () => { this.Kategori = kategori; });
            });
            taskforthisText.RunSynchronously();
            this.Mod = GorusmeListelemeModu.KategoriyeGore;
        }
        /// <summary>
        /// Listedeki kurum idlerine göre görüşmeleri listeler.
        /// </summary>
        /// <param name="Kurumlar">Listelenecek Kurumların id listesi.</param>
        /// <param name="cm">Görüşmeleri listelemek için gerekli ConnectionManager.</param>
        /// <param name="oturum">Görüşmeleri listelemek için gerekli izinleri barındıran Oturum.</param>
        public KurumGoster(List<Kurum> Kurumlar, ConnectionManager cm, Oturum oturum)
        {
            InitializeComponent();
            this.KulOturum = oturum;
            this.ConnManager = cm;
            this.KurumListesi = Kurumlar;
            Task taskforthisText = new Task(() =>
           {
               Delegates.Text.Set(this, string.Format("'{0}' adlı kurumlara ait görüşmeler", _BaslikOlustur(Kurumlar)));
           });
            taskforthisText.RunSynchronously();
            this.Mod = GorusmeListelemeModu.KarisikKurumlaraGore;
        }
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
        private string _BaslikOlustur(List<Kurum> kurumlar)
        {
            if (kurumlar != null && kurumlar.Count != 0)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Kurum kurum in kurumlar)
                {
                    sb.Append(kurum.ToString());
                    sb.Append(", ");
                }
                sb.Remove(sb.Length - ", ".Length, ", ".Length);
                return sb.ToString();
            }
            else { return string.Empty; }
        }
        private bool _YetkiSorgula<T>(T Yetki, bool msg = true)
        {
            return Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, Yetki, this.KulOturum, false);
        }
        private void KurumGoster_Load(object sender, EventArgs e)
        {
            switch (this.Mod)
            {
                case GorusmeListelemeModu.KurumaGore:
                    glGorusmeler.Kurum = this.Kurum;
                    break;
                case GorusmeListelemeModu.KategoriyeGore:
                    glGorusmeler.Kategori = this.Kategori;
                    break;
                case GorusmeListelemeModu.KarisikKurumlaraGore:
                    glGorusmeler.KurumListesi = this.KurumListesi;
                    break;
                default:
                    Logger.Log(new NotSupportedException("Mod Belirtilmemiş![KurumGoster]"));
                    break;
            }
            if (_YetkiSorgula(NesneYetkileri.GorusmeGoruntule))
            {
                glGorusmeler.GorusmeleriYukle();
            }
        }

        #region GlGorusmeler Methods
        private void GlGorusmeler_EkleTiklandiginda(object sender, EventArgs e)
        {
            if (_YetkiSorgula(NesneYetkileri.GorusmeEkle))
            {
                using (GorusmeEkle geForm = new GorusmeEkle(this.Kurum, this.KulOturum))
                {
                    try { geForm.ShowDialog(); }
                    catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Görüşme Ekleme Formu Açılırken Hata Oluştu!"); }
                    if (geForm.DegisiklikYapildi)
                    {
                        glGorusmeler.GorusmeleriYukle();
                    }
                }
            }
        }
        private void GlGorusmeler_DuzenleTiklandiginda(object sender, Gorusme e)
        {
            if (_YetkiSorgula(NesneYetkileri.GorusmeDuzenle))
            {
                using (GorusmeEkle geForm = new GorusmeEkle(e, KulOturum))
                {
                    try { geForm.ShowDialog(); }
                    catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Görüşme Güncelleme Formu Açılırken Hata Oluştu!"); }
                    if (geForm.DegisiklikYapildi)
                    {
                        glGorusmeler.GorusmeleriYukle();
                    }
                }
            }
        }
        private void GlGorusmeler_GizleTiklandiginda(object sender, List<Gorusme> e)
        {
            if (e != null && e.Count >= 1)
            {
                glGorusmeler.GorusmeleriGizle(e);
            }

        }
        private async void GlGorusmeler_SilTiklandiginda(object sender, List<Gorusme> e)
        {
            if (e != null && e.Count >= 1)
            {
                if (_YetkiSorgula(NesneYetkileri.GorusmeSil))
                {
                    if (MsgBox.Soru(this, "Seçilen Görüşme" + (e.Count == 1 ? "yi" : "leri") + " Silmek istediğinize Eminmisiniz?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        foreach (Gorusme gorusme in e)
                        {
                            if (!(await Gorusmeler.Sil(gorusme.Id, ConnManager)))
                            {
                                MsgBox.Hata(this, "\'" + gorusme.Id + "\' idli görüşme silinemedi!");
                            }
                        }
                    }
                }
            }
        }

        #endregion

        #endregion

        private void btnKrmBilGstr_Click(object sender, EventArgs e)
        {
            if (kurumId != -1 && this.KulOturum != null)
            {
                using (KurumEkle keForm = new KurumEkle(kurumId, KulOturum, true))
                {
                    keForm.ShowDialog();
                }
            }
        }
    }
}
