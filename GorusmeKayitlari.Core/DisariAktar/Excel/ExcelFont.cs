using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    class ExcelFont : Microsoft.Office.Interop.Excel.Font
    {
        public Application Application { get; }

        public dynamic Background { get; set; }

        public dynamic Bold { get; set; }

        public dynamic Color { get; set; }

        public dynamic ColorIndex { get; set; }

        public XlCreator Creator { get; set; }
        public dynamic FontStyle { get; set; }

        public dynamic Italic { get; set; }

        public dynamic Name { get; set; }

        public dynamic OutlineFont { get; set; }

        public dynamic Parent { get; set; }

        public dynamic Shadow { get; set; }

        public dynamic Size { get; set; }

        public dynamic Strikethrough { get; set; }

        public dynamic Subscript { get; set; }

        public dynamic Superscript { get; set; }

        public dynamic ThemeColor { get; set; }

        public XlThemeFont ThemeFont { get; set; }

        public dynamic TintAndShade { get; set; }

        public dynamic Underline { get; set; }
        public ExcelFont(Application Application, dynamic Background, dynamic Bold, dynamic Color, dynamic ColorIndex, XlCreator Creator, dynamic FontStyle, dynamic Italic, dynamic Name, dynamic OutlineFont, dynamic Parent, dynamic Shadow, dynamic Size, dynamic Strikethrough, dynamic Subscript, dynamic Superscript, dynamic ThemeColor, XlThemeFont ThemeFont, dynamic TintAndShade, dynamic Underline)
        {
            this.Application = Application;
            this.Background = Background;
            this.Bold = Bold;
            this.Color = Color;
            this.ColorIndex = ColorIndex;
            this.Creator = Creator;
            this.FontStyle = FontStyle;
            this.Italic = Italic;
            this.Name = Name;
            this.OutlineFont = OutlineFont;
            this.Parent = Parent;
            this.Shadow = Shadow;
            this.Size = Size;
            this.Strikethrough = Strikethrough;
            this.Subscript = Subscript;
            this.Superscript = Superscript;
            this.ThemeColor = ThemeColor;
            this.ThemeFont = ThemeFont;
            this.TintAndShade = TintAndShade;
            this.Underline = Underline;
        }
    }
}
