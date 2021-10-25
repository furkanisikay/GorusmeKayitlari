using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    public class ExcelDosyaArgs
    {
        /// <summary>
        /// Dosyanın kaydedileceği yol.
        /// </summary>
        public string DosyaAdi { get; set; }
        /// <summary>
        /// Dosyanın XlFileFormat türündeki kaydetme formatı.
        /// </summary>
        public XlFileFormat DosyaFormati { get; set; }
        /// <summary>
        /// Dosya açılırken sorulacak şifre.
        /// </summary>
        public string DosyaAcmaSifresi { get; set; }
        /// <summary>
        /// Dosya içeriği değiştirilirken sorulacak şifre.
        /// </summary>
        public string DosyaYazmaSifresi { get; set; }
        /// <summary>
        /// Dosya içeriğindeki görüşmelerin dosyaya aktarılma teması.
        /// </summary>
        public ExcelIcerikTemasi Tema { get; set; }
        /// <summary>
        /// Yeni Bir ExcelDosyaArgs nesnesi oluşturur.
        /// </summary>
        /// <param name="DosyaAdi">Dosyanın kaydedileceği yol.</param>
        /// <param name="DosyaFormati">Dosyanın XlFileFormat türündeki kaydetme formatı.</param>
        /// <param name="DosyaAcmaSifresi">Dosya açılırken sorulacak şifre.</param>
        /// <param name="DosyaYazmaSifresi">Dosya içeriği değiştirilirken sorulacak şifre.</param>
        /// <param name="Tema">Dosya içeriğindeki görüşmelerin dosyaya aktarılma teması.</param>
        public ExcelDosyaArgs(string DosyaAdi, XlFileFormat DosyaFormati, string DosyaAcmaSifresi, string DosyaYazmaSifresi, ExcelIcerikTemasi Tema)
        {
            this.DosyaAdi = DosyaAdi;
            this.DosyaFormati = DosyaFormati;
            this.DosyaAcmaSifresi = DosyaAcmaSifresi;
            this.DosyaYazmaSifresi = DosyaYazmaSifresi;
            this.Tema = Tema;
        }
    }
}
