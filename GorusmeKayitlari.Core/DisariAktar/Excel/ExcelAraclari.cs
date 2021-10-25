using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    public class ExcelAraclari
    {
        public static void _RangeEkle(Worksheet calismasayfa, int satir, int sutun, string yazi, ExcelBlok blokozellikleri)
        {
            Range albaslikblok = (Range)calismasayfa.Cells[satir, sutun];
            albaslikblok.Value2 = yazi;
            if (blokozellikleri != null)
            {
                #region ### Blok Fontunu Ayarlama Kodları ###
                albaslikblok.Font.Bold = blokozellikleri.YaziTipi.Bold;
                albaslikblok.Font.Color = System.Drawing.ColorTranslator.ToOle(blokozellikleri.FontRengi);
                albaslikblok.Font.Italic = blokozellikleri.YaziTipi.Italic;
                albaslikblok.Font.Name = blokozellikleri.YaziTipi.Name;
                albaslikblok.Font.Size = blokozellikleri.YaziTipi.Size;
                albaslikblok.Font.Underline = blokozellikleri.YaziTipi.Underline;
                #endregion
                albaslikblok.HorizontalAlignment = blokozellikleri.YatayHizalama;
                albaslikblok.VerticalAlignment = blokozellikleri.DikeyHizalama;
                albaslikblok.ColumnWidth = blokozellikleri.Genislik;
                albaslikblok.RowHeight = blokozellikleri.Yukseklik;
                albaslikblok.Interior.Color = System.Drawing.ColorTranslator.ToOle(blokozellikleri.ArkaplanRengi);
            }
        }
        public static string _HizalamaDonustur(XlVAlign dikeyhizalama)
        {
            switch (dikeyhizalama)
            {
                case XlVAlign.xlVAlignTop:
                    return "üst";
                case XlVAlign.xlVAlignCenter:
                    return "orta";
                case XlVAlign.xlVAlignBottom:
                    return "alt";
                default:
                    return "alt";
            }
        }
        public static string _HizalamaDonustur(XlHAlign yatayhizalama)
        {
            switch (yatayhizalama)
            {
                case XlHAlign.xlHAlignLeft:
                    return "sol";
                case XlHAlign.xlHAlignCenter:
                    return "orta";
                case XlHAlign.xlHAlignRight:
                    return "sağ";
                default:
                    return "sol";
            }
        }
        public static XlVAlign _DikeyHizalamaDonustur(string hizalamayazisi)
        {
            switch (hizalamayazisi)
            {
                case "üst":
                    return XlVAlign.xlVAlignTop;
                case "orta":
                    return XlVAlign.xlVAlignCenter;
                case "alt":
                    return XlVAlign.xlVAlignBottom;
                default:
                    return XlVAlign.xlVAlignBottom;
            }
        }
        public static XlHAlign _YatayHizalamaDonustur(string hizalamayazisi)
        {
            switch (hizalamayazisi)
            {
                case "sol":
                    return XlHAlign.xlHAlignLeft;
                case "orta":
                    return XlHAlign.xlHAlignCenter;
                case "sağ":
                    return XlHAlign.xlHAlignRight;
                default:
                    return XlHAlign.xlHAlignLeft;
            }
        }
        public static ExcelIcerikTemasi _GetDefaultTheme(System.Windows.Forms.IWin32Window owner)
        {
            string themePath = System.Windows.Forms.Application.StartupPath + "\\ExcelDefaultTema.gk.xml";
            if (File.Exists(themePath))
            {
                string temaadi = string.Empty;
                return ExcelIcerikTemaConverter.XMLToExcelIcerikTema(themePath, out temaadi);
            }
            else
            {
                return new ExcelIcerikTemasi(
                     new ExcelBlok(new System.Drawing.Font("Segoe UI", 16f), System.Drawing.Color.White, System.Drawing.Color.FromArgb(41, 128, 185), 25m, 24m
                    , Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter)
                    , new ExcelBlok(new System.Drawing.Font("Segoe UI", 10f), System.Drawing.Color.Black, System.Drawing.Color.White, 25m, 15m
                    , Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter)
                    , new ExcelBlok(new System.Drawing.Font("Segoe UI", 10f), System.Drawing.Color.White, System.Drawing.Color.FromArgb(52, 152, 219), 25m, 15m
                    , Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter
                    , Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter)
                    );
            }
            
        }
    }
}
