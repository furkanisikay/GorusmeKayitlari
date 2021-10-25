using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.MsgBox;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    [DefaultEvent("RenkDegistiginde")]
    public partial class RenkKutusu : UserControl
    {
        public RenkKutusu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Renk kutusunu belirtilen renkte oluşturur.
        /// </summary>
        /// <param name="renk">Ayarlanacak renk</param>
        public RenkKutusu(Color renk)
        {
            InitializeComponent();
            _RenkAyarla(renk);
        }

        #region # BackColor Kodları #
        private Color tmpBackColor = Color.White;
        #pragma warning disable CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
        [Browsable(false)]
        public Color BackColor { get { return _GetBackColor(); } set { tmpBackColor = value; } }
#pragma warning restore CS0114 // Üye devralınmış üyeyi gizler; geçersiz kılma anahtar sözcüğü eksik
        #endregion

        /// <summary>
        /// Seçilen rengi döndürür.
        /// </summary>
        public Color SecilenRenk { get { return _GetSelectedColor(); } set { _RenkAyarla(value); } }

        #region ### Eventler ###
        private void pBoxRenk_Click(object sender, EventArgs e)
        {
            using (ColorDialog cdForm = new ColorDialog())
            {
                try { cdForm.ShowDialog(this); }
                catch (InvalidOperationException ex) { Logger.Log(ex); MsgBox.Hata(this, "Renk Seçme Penceresi Açılırken Hata Oluştu!"); }
                if (cdForm.Color != null)
                {
                    _RenkAyarla(cdForm.Color);
                }
            }
        }
        private void pBoxRenk_BackColorChanged(object sender, EventArgs e)
        {
            if (RenkDegistiginde != null) { RenkDegistiginde(sender, _GetSelectedColor()); }
        }
        #endregion

        #region ### Fonksiyonlar ###
        private void _RenkAyarla(Color renk)
        {
            _BackColorAyarla(pBoxRenk, renk);
            _BackColorAyarla(this, renk == Color.Black ? Color.White : Color.Black);
        }

        private void _BackColorAyarla(Control ctrl, Color renk)
        {
            Delegates.BackColor.Set(ctrl, renk);
        }
        private Color _GetSelectedColor()
        {
            return Delegates.BackColor.Get(pBoxRenk);
        }

        private Color _GetBackColor()
        {
            return _GetSelectedColor() == Color.Black ? Color.White : Color.Black;
        }
        #endregion

        [Category("Action"), Description("Seçilen renk değiştiğinde tetiklenir.")]
        public event EventHandler<Color> RenkDegistiginde;
    }
}
