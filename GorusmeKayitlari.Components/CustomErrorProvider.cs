using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core;

namespace GorusmeKayitlari.Components
{
    public partial class CustomErrorProvider : ErrorProvider
    {
        public CustomErrorProvider()
        {
            InitializeComponent();
        }
        int _azaltilacakwidth = 20;
        public int AzaltilacakWidth
        {
            get { return _azaltilacakwidth; }
            set
            {
                if (value > 0) { _azaltilacakwidth = value; }
            }
        }

        [Browsable(false)]
        List<Control> boyutuazatilanctrllar = new List<Control>();

        #region Clear Methodu
        /// <summary>
        /// Error Gösterilmiş olan controllerin Error iconlarını temizleyerek eski boyutuna ve lokasyonuna getirir.
        /// </summary>
#pragma warning disable CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik

        public void Clear()
#pragma warning restore CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        {
            if (boyutuazatilanctrllar != null && boyutuazatilanctrllar.Count != 0)
            {
                foreach (Control ctrl in boyutuazatilanctrllar)
                {
                    ErrorIconAlignment hizalama = base.GetIconAlignment(ctrl);
                    if (hizalama == ErrorIconAlignment.BottomLeft || hizalama == ErrorIconAlignment.MiddleLeft || hizalama == ErrorIconAlignment.TopLeft)
                    {
                        Delegates.Width.Set(ctrl, (Delegates.Width.Get(ctrl) + _azaltilacakwidth));
                        //ctrl.Width = ctrl.Width + _azaltilacakwidth;
                        Point loc = Delegates.Location.Get(ctrl);
                        Point pnt = new System.Drawing.Point(loc.X - _azaltilacakwidth, loc.Y);
                        Delegates.Location.Set(ctrl, pnt);
                    }
                    else
                    {
                        Delegates.Width.Set(ctrl, (Delegates.Width.Get(ctrl) + _azaltilacakwidth));
                        //ctrl.Width = ctrl.Width + _azaltilacakwidth;
                    }
                }
                boyutuazatilanctrllar.Clear();
            }
            base.Clear();
        }
        #endregion

        #region SetError Methodu
#pragma warning disable CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        public void SetError(Control ctrl, string yazi)
#pragma warning restore CS0108 // Üye devralınmış üyeyi gizler; yeni anahtar sözcük eksik
        {
            boyutuazatilanctrllar.Add(ctrl);
            ErrorIconAlignment hizalama = base.GetIconAlignment(ctrl);
            if (hizalama == ErrorIconAlignment.BottomLeft || hizalama == ErrorIconAlignment.MiddleLeft || hizalama == ErrorIconAlignment.TopLeft)
            {
                Delegates.Width.Set(ctrl, (Delegates.Width.Get(ctrl) - _azaltilacakwidth));
                //ctrl.Width = ctrl.Width - _azaltilacakwidth;
                Point loc = Delegates.Location.Get(ctrl);
                Point pnt = new System.Drawing.Point(loc.X + _azaltilacakwidth, loc.Y);
                Delegates.Location.Set(ctrl, pnt);
                //ctrl.Location = new System.Drawing.Point(ctrl.Location.X + _azaltilacakwidth, ctrl.Location.Y);
            }
            else
            {
                //ctrl.Width = ctrl.Width - _azaltilacakwidth;
                Delegates.Width.Set(ctrl, (Delegates.Width.Get(ctrl) - _azaltilacakwidth));
            }
            base.SetError(ctrl, yazi);
        }
        #endregion

        public CustomErrorProvider(IContainer container)
        {
            InitializeComponent();
        }
    }
}
