using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.DisariAktar.Excel;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Core.MsgBox;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GorusmeKayitlari.Components.ExcelBilesenleri
{
    [DefaultEvent("BlokDegistiginde")]
    public partial class FontKutusu : UserControl
    {
        #region Constructor
        public FontKutusu()
        {
            InitializeComponent();
            _SetThisAlign(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
            _SetThisAlign(Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter);
        }
        /// <summary>
        /// Blok içeriğini verilen bilgilere oluşturur.
        /// </summary>
        /// <param name="Blok">Blok bilgileri</param>
        public FontKutusu(GorusmeKayitlari.Core.DisariAktar.Excel.ExcelBlok Blok)
        {
            InitializeComponent();
            _SetThisAlign(Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter);
            _SetThisAlign(Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter);
            if (Blok != null)
            {
                _BlokAyarla(Blok, null);
            }
        }
        #endregion

        #region FontKutusu Members
        /// <summary>
        /// Bloğun yazı stili.
        /// </summary>
        public Font YaziFontu { get { return _GetThisFont(); } set { _BlokAyarla(value, _GetThisFontColor(), _GetThisBackColor(), null, _GetThisHAlign(), _GetThisVAlign()); } }
        /// <summary>
        /// Bloğun yazı rengi.
        /// </summary>
        public Color YaziFontRengi { get { return _GetThisFontColor(); } set { _BlokAyarla(_GetThisFont(), value, _GetThisBackColor(), null, _GetThisHAlign(), _GetThisVAlign()); } }
        /// <summary>
        /// Bloğun arkaplan rengi.
        /// </summary>
        public Color YaziArkaplanRengi { get { return _GetThisBackColor(); } set { _BlokAyarla(_GetThisFont(), _GetThisFontColor(), value, null, _GetThisHAlign(), _GetThisVAlign()); } }
        /// <summary>
        /// Bloğun genişliği int türünde.
        /// </summary>
        public decimal BlokGenisligi { get { return _GetThisWidth(); } set { _SetThisWidht(value); } }
        /// <summary>
        /// Bloğun yüksekliği int türünde.
        /// </summary>
        public decimal BlokYuksekligi { get { return _GetThisHeight(); } set { _SetThisHeight(value); } }
        /// <summary>
        /// Bloğun yatay hizalaması.
        /// </summary>
        public Microsoft.Office.Interop.Excel.XlHAlign BlokYatayHizalama { get { return _GetThisHAlign(); } set { _SetThisAlign(value); } }
        /// <summary>
        /// Bloğun dikey hizalaması.
        /// </summary>
        public Microsoft.Office.Interop.Excel.XlVAlign BlokDikeyHizalama { get { return _GetThisVAlign(); } set { _SetThisAlign(value); } }
        #endregion

        #region Methods
        #region ### Event Kodları ###
        private void lblYaziTipi_Click(object sender, EventArgs e)
        {
            using (FontDialog fdForm = new FontDialog())
            {
                try
                {
                    fdForm.Font = lblYaziTipi.Font;
                    fdForm.ShowColor = false;
                    fdForm.ShowDialog(this);
                }
                catch(Exception ex) { Logger.Log(ex); MsgBox.Hata(this, "Yazı Tipi Seçme Penceresi Açılırken Hata Oluştu!"); }
                if (fdForm.Font != null)
                {
                    _BlokAyarla(fdForm.Font, _GetThisFontColor(), _GetThisBackColor(), sender, _GetThisHAlign(), _GetThisVAlign());
                }
            }
        }
        private void rkRenk_RenkDegistiginde(object sender, Color e)
        {
            _BlokAyarla(_GetThisFont(), e, _GetThisBackColor(), sender, _GetThisHAlign(), _GetThisVAlign());
        }
        private void rkArkaplanRengi_RenkDegistiginde(object sender, Color e)
        {
            _BlokAyarla(_GetThisFont(), _GetThisFontColor(), e, sender, _GetThisHAlign(), _GetThisVAlign());
        }
        private void lblYaziTipi_FontChanged(object sender, EventArgs e)
        {
            Optimizasyon.Delagate(lblYaziTipi, () => { ttMain.SetToolTip(lblYaziTipi, string.Format("Yazı Tipi Özellikleri;\nYazı Tipi Adı : {0}\nYazı Tipi Büyüklüğü : {1} \nYazı Altı Çizili : {2}\nYazı Üstü Çizili : {3}\nYazı Eğik : {4}\nYazı Kalın : {5}\n(Değiştirmek için Tıklayın)", lblYaziTipi.Font.Name, lblYaziTipi.Font.Size.ToString(), lblYaziTipi.Font.Underline ? " Evet" : "Hayır", lblYaziTipi.Font.Strikeout ? " Evet" : "Hayır", lblYaziTipi.Font.Italic ? " Evet" : "Hayır", lblYaziTipi.Font.Bold ? " Evet" : "Hayır")); });
        }
        #endregion

        #region ### _BlokAyarla fonksiyonları ###
        private void _BlokAyarla(Font font, Color fontrengi, Color arkaplanrengi, object sender, Microsoft.Office.Interop.Excel.XlHAlign yatayhizalama, Microsoft.Office.Interop.Excel.XlVAlign dikeyhizalama)
        {
            //_BlokAyarlaOutedSize fonksiyonunda yuksekil ve genislik kulannılmadığı için -1 giriyorum.
            ExcelBlok blok = new ExcelBlok(font, fontrengi, arkaplanrengi, -1, -1, yatayhizalama, dikeyhizalama);
            _BlokAyarlaOutedSize(blok, sender);
            if (BlokDegistiginde != null) { BlokDegistiginde(null, _GetthisBlok()); }
        }
        private void _BlokAyarla(ExcelBlok Blok, object sender)
        {
            _BlokAyarlaOutedSize(Blok, sender);
            Delegates.Value.Set(nudGenislik, Blok.Genislik);
            Delegates.Value.Set(nudYukseklik, Blok.Yukseklik);
            if (BlokDegistiginde != null) { BlokDegistiginde(null, _GetthisBlok()); }
        }
        private void _BlokAyarlaOutedSize(ExcelBlok Blok, object sender)
        {
            Delegates.Font.Set(lblYaziTipi, Blok.YaziTipi);
            Delegates.ForeColor.Set(lblYaziTipi, Blok.FontRengi);
            Delegates.BackColor.Set(lblYaziTipi, Blok.ArkaplanRengi);
            if (sender == null || !(sender is RenkKutusu))
            {
                Optimizasyon.Delagate(rkYaziRengi, () => { rkYaziRengi.SecilenRenk = Blok.FontRengi; });
                Optimizasyon.Delagate(rkArkaplanRengi, () => { rkArkaplanRengi.SecilenRenk = Blok.ArkaplanRengi; });
            }
            if (sender == null || !(sender is ComboBox))
            {
                _SetThisAlign(Blok.DikeyHizalama);
                _SetThisAlign(Blok.YatayHizalama);
            }
        }
        #endregion

        #region ### Get Set Kodları ###
        private void _SetThisAlign(Microsoft.Office.Interop.Excel.XlHAlign yatayhizalama)
        {
            int index = 0;
            try
            {
                switch (yatayhizalama)
                {
                    case Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter:
                        index = 1;
                        break;
                    case Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft:
                        index = 0;
                        break;
                    case Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight:
                        index = 2;
                        break;
                    default:
                        index = 0;
                        break;
                }
            }
            catch (Exception ex) { Logger.Log(ex); index = 0; }
            Delegates.SelectedIndex.Set(cmbHorizontalAlign, index);
        }
        private void _SetThisAlign(Microsoft.Office.Interop.Excel.XlVAlign dikeyhizalama)
        {
            int index = 0;
            try
            {
                switch (dikeyhizalama)
                {
                    case Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom:
                        index = 2;
                        break;
                    case Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter:
                        index = 1;
                        break;
                    case Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop:
                        index = 0;
                        break;
                    default:
                        index = 0;
                        break;
                }
            }
            catch (Exception ex) { Logger.Log(ex); index = 0; }
            Delegates.SelectedIndex.Set(cmbVerticalAlign,index);
        }
        /// <summary>
        /// Bloğun yatay hizalamasını döndürür.
        /// </summary>
        /// <returns>Microsoft.Office.Interop.Excel.XlHAlign</returns>
        public Microsoft.Office.Interop.Excel.XlHAlign _GetThisHAlign()
        {
            try
            {
                int index = _GetComboBoxIndex(cmbHorizontalAlign);
                switch (index)
                {
                    case 0:
                        return Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                    case 1:
                        return Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                    case 2:
                        return Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                    default:
                        return Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft; }
        }
        /// <summary>
        /// Bloğun dikey hizalamasını döndürür.
        /// </summary>
        /// <returns>Microsoft.Office.Interop.Excel.XlVAlign</returns>
        public Microsoft.Office.Interop.Excel.XlVAlign _GetThisVAlign()
        {
            try
            {
                int index = _GetComboBoxIndex(cmbVerticalAlign);
                switch (index)
                {
                    case 0:
                        return Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignTop;
                    case 1:
                        return Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                    case 2:
                        return Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                    default:
                        return Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom;
                }
            }
            catch (Exception ex) { Logger.Log(ex); return Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignBottom; }
        }
        private int _GetComboBoxIndex(ComboBox cmb)
        {
            return Delegates.SelectedIndex.Get(cmb);
        }
        /// <summary>
        /// Bloğun içeriğini ExcelBlok türünde döndürür.
        /// </summary>
        /// <returns>ExcelBlok</returns>
        public ExcelBlok _GetthisBlok()
        {
            try
            {
                return new ExcelBlok(_GetThisFont(), _GetThisFontColor(), _GetThisBackColor(), _GetThisWidth(), _GetThisHeight(), _GetThisHAlign(), _GetThisVAlign());
            }
            catch (Exception ex) { Logger.Log(ex); return null; }
        }
        private Font _GetThisFont()
        {
            return Delegates.Font.Get(lblYaziTipi);
        }
        private Color _GetThisFontColor()
        {
            return Delegates.ForeColor.Get(lblYaziTipi);
        }
        private Color _GetThisBackColor()
        {
            return Delegates.BackColor.Get(lblYaziTipi);
        }
        /// <summary>
        /// Bloğun genişliğini double türünde döndürür.
        /// </summary>
        /// <returns>double</returns>
        public decimal _GetThisWidth()
        {
            try { return Convert.ToDecimal(Delegates.Value.Get(nudGenislik)); }
            catch (Exception ex) { Logger.Log(ex); return 0m; }
        }
        /// <summary>
        /// Bloğun yüksekliğini double türünde döndürür.
        /// </summary>
        /// <returns>double</returns>
        public decimal _GetThisHeight()
        {
            try { return Convert.ToDecimal(Delegates.Value.Get(nudGenislik)); }
            catch (Exception ex) { Logger.Log(ex); return 0m; }
        }
        ///// <summary>
        ///// Bloğun genişliğini int türünde döndürür.
        ///// </summary>
        ///// <returns>int</returns>
        //public int _GetThisWidthint()
        //{
        //    return Convert.ToInt32(Delegates.Value.Get(nudGenislik));
        //}
        ///// <summary>
        ///// Bloğun yüksekliğini int türünde döndürür.
        ///// </summary>
        ///// <returns>int</returns>
        //public int _GetThisHeightint()
        //{
        //    return Convert.ToInt32(Delegates.Value.Get(nudYukseklik));
        //}
        private void _SetThisWidht(decimal genislik)
        {
            Delegates.Value.Set(nudGenislik, genislik);
        }
        private void _SetThisHeight(decimal yukseklik)
        {
            Delegates.Value.Set(nudYukseklik, yukseklik);
        }
        /// <summary>
        /// Blok içeriğini ayarlar,
        /// boyut değerlerini excel formatına çevirmeden kaydeder.
        /// </summary>
        /// <param name="blok">Blok bilgileri.</param>
        public void _SetThis(ExcelBlok blok)
        {
            _BlokAyarla(blok, null);
        }
        #endregion
        #endregion

        #region Events
        [Category("Action"),Description("Blok içeriği değiştiğinde tetiklenir.")]
        public event EventHandler<ExcelBlok> BlokDegistiginde;
        #endregion
        
    }
}
