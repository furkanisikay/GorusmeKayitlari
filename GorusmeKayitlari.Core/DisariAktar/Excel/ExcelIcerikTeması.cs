using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    public class ExcelIcerikTemasi
    {
        /// <summary>
        /// İçerikteki Başlıkların Blok Türünden Özellikleri.
        /// </summary>
        public ExcelBlok BaslikBloklari { get; set; }
        /// <summary>
        /// İçerikteki Görüşmelerin Birincil Bloklarının Özellikleri.
        /// </summary>
        public ExcelBlok BirincilBlok { get; set; }
        /// <summary>
        /// İçerikteki Görüşmelerin İkincil Bloklarının Özellikleri.
        /// </summary>
        public ExcelBlok IkincilBlok { get; set; }
        public ExcelIcerikTemasi( ExcelBlok BaslikBloklari, ExcelBlok BirincilBlok, ExcelBlok IkincilBlok)
        {
            this.BaslikBloklari = BaslikBloklari;
            this.BirincilBlok = BirincilBlok;
            this.IkincilBlok = IkincilBlok;
        }
        public ExcelIcerikTemasi ParseXML(string path)
        {
            string temaadi = string.Empty;
            return ParseXML(path, out temaadi);
        }
        public ExcelIcerikTemasi ParseXML(string path,out string temaadi)
        {
            return Core.DisariAktar.Excel.ExcelIcerikTemaConverter.XMLToExcelIcerikTema(path, out temaadi);
        }
    }
}
