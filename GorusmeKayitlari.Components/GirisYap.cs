using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core.DB.Objects;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DB.Methods;
using GorusmeKayitlari.Core.DB;

namespace GorusmeKayitlari.Components
{
    public partial class GirisYap : UserControl, IDisposable
    {
        #region Constructor
        public GirisYap()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Events
        public event EventHandler<KullaniciHesap> OturumAcilacaginda;
        #endregion

        #region Private Members
        private ConnectionManager manager = ConnectionManager.Instance;
        #endregion

        #region Private Methods
        private void GirisYapForm_SizeChanged(object sender, EventArgs e)
        {
            Core.DigerFonksiyonlar.PanelOrtalama(pnlControls, this.Width, this.Height);
        }

        private void BtnGirisYap_Click(object sender, EventArgs e)
        {
            Wait(true, "Bilgiler Kontrol Ediliyor");
            Delegates.Enabled.Set(pnlControls, false);
            _GirisYap();
            //Optimizasyon.ArkaplandaCalistir(() => { _GirisYap(); }, true);
        }

        private void _GirisYap()
        {
            string KulAd = Delegates.Text.Get(txtKulAd);
            string Sifre = Delegates.Text.Get(txtSifre);
            bwGiris.RunWorkerAsync(new KullaniciHesap(KulAd, Sifre));
            epMain.Clear();
        }

        private void Bwkul_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            KullaniciHesap kulhesap = (KullaniciHesap)(e.Result);
            if (kulhesap == null)
            {
                epMain.SetError(txtKulAd, "Kullanıcı adı veya şifre yanlış.");
                epMain.SetError(txtSifre, "Kullanıcı adı veya şifre yanlış.");
            }
            else if (kulhesap?.Durum == KullaniciHesapDurumu.KullanimDisi || kulhesap?.Durum == KullaniciHesapDurumu.None)
            {
                epMain.SetError(txtKulAd, "Bu hesap kullanım dışıdır.");
            }
            else
            {
                OturumAcilacaginda(sender, kulhesap);
            }
            Delegates.Enabled.Set(pnlControls, true);
            Wait(false, "Yükleniyor");
        }

        private async void Bwkul_DoWork(object sender, DoWorkEventArgs e)
        {
            KullaniciHesap kulhesap = (KullaniciHesap)(e.Argument);
            e.Result = await KullaniciHesaplar.Bul(kulhesap, manager);
        }

        private void Wait(bool Value, string Text)
        {
            Delegates.Size.Set(yukleniyor1, Delegates.Size.Get(pnlControls));
            Size thisSize = Delegates.Size.Get(this);
            DigerFonksiyonlar.PanelOrtalama(yukleniyor1, thisSize.Width, thisSize.Height);
            Optimizasyon.Delagate(yukleniyor1, () => { yukleniyor1.Yazi = Text; });
            Delegates.Visible.Set(yukleniyor1, Value);
        }

        private void GirisYap_Load(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(this, () => { txtKulAd.Focus(); });
        }
        #endregion
        
        private void txtSifre_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Optimizasyon.ArkaplandaCalistir(() => { Optimizasyon.Delagate(btnGirisYap, () => { btnGirisYap.PerformClick(); }); });
            }
        }

        private void txtKulAd_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                Optimizasyon.ArkaplandaCalistir(() => { Optimizasyon.Delagate(txtSifre, () => { txtSifre.Focus(); }); });
            }
        }
    }
}
