using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Components;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core.Extensions;
using System;
using System.Windows.Forms;

namespace GorusmeKayitlari.App.Formlar.NesneFormlari.SecmeFormlari
{
    public partial class KategoriSec : Form
    {
        public KategoriSec(Oturum Oturum)
        {
            InitializeComponent();
            this.KulOturum = Oturum;
        }

        private Kategori _secilennesne = null;
        internal Kategori SecilenNesne { get { return _secilennesne; } }
        public Oturum KulOturum { get; }

        private void btnIptalOnayla_Onaylandiginde(object sender, EventArgs e)
        {
            try
            {
                this._secilennesne = liste1.SecilenNesne;
            }
            catch (Exception ex) { Logger.Log(ex); this._secilennesne = null; }
            finally
            {
                this.Close();
            }
        }

        private void btnIptalOnayla_IptalEdildiginde(object sender, EventArgs e)
        {
            try { this._secilennesne = null; }
            catch (Exception ex) { Logger.Log(ex); this._secilennesne = null; }
            finally { this.Close(); }
        }

        private void KategoriSec_Load(object sender, EventArgs e)
        {
            if (!Core.YetkiSistemi.Methods._OturumVeYetkiSorgula(this, NesneYetkileri.KategoriGoruntule, KulOturum))
            {
                this.Close();
            }
            //Optimizasyon.ArkaplandaCalistir(() => { liste1._KategorileriYukle(); });
        }

        private void liste1_KurumSecildiginde(object sender, TreeViewEventArgs e)
        {
            btnIptalOnayla_Onaylandiginde(sender, e);
        }
    }
}
