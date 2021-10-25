using System;
using GorusmeKayitlari.Core.DB.Objects;

namespace GorusmeKayitlari.Core
{
    public class Oturum
    {
        #region Members
        private KullaniciHesap _OturumAcilanHesap;
        public KullaniciHesap OturumAcilanHesap
        {
            get { return this._OturumAcilanHesap; ; }
            set { _OturumAcilanHesap = value; }
        }
        public bool OturumAcildi => _OturumAcilanHesap != null;
        #endregion
        #region Constructor
        public Oturum()
        {
            _OturumAcilanHesap = null;
        }
        #endregion
        #region Destructor
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        #endregion
        #region Events
        public event EventHandler<KullaniciHesap> OturumAcildiginda;
        public event EventHandler OturumKapatildiginda;
        #endregion
        #region Methods
        public void OturumAc(KullaniciHesap hesap)
        {
            OturumAcilanHesap = hesap;
            OturumAcildiginda?.Invoke(null, hesap);
        }

        public void OturumKapat()
        {
            OturumAcilanHesap = null;
            OturumKapatildiginda?.Invoke(null, new EventArgs());
        }
        #endregion
    }
}
