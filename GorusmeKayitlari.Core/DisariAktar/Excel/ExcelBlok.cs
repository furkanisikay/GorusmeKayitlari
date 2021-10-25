using Microsoft.Office.Interop.Excel;
using System.ComponentModel;
using System.Drawing;

namespace GorusmeKayitlari.Core.DisariAktar.Excel
{
    public class ExcelBlok
    {
        /// <summary>
        /// Blok yazının yazı tipi.
        /// </summary>
        public System.Drawing.Font YaziTipi { get; set; }
        /// <summary>
        /// Blok yazısının yazı tipi rengi.
        /// </summary>
        public Color FontRengi { get; set; }
        /// <summary>
        /// Blok yazısının arkaplan rengi.
        /// </summary>
        public Color ArkaplanRengi { get; set; }
        /// <summary>
        /// Blok genişliği.
        /// </summary>
        [DefaultValue(10)]
        public decimal Genislik { get; set; }
        /// <summary>
        /// Blok yüksekliği.
        /// </summary>
        [DefaultValue(15)]
        public decimal Yukseklik { get; set; }
        /// <summary>
        /// Bloğun Yatay Hizalaması.
        /// </summary>
        public XlHAlign YatayHizalama { get; set; }
        /// <summary>
        /// Bloğun Dikey Hizalaması.
        /// </summary>
        public XlVAlign DikeyHizalama { get; set; }
        public ExcelBlok(System.Drawing.Font YaziTipi, Color FontRengi, Color ArkaplanRengi, decimal Genislik, decimal Yukseklik, XlHAlign YatayHizalama, XlVAlign DikeyHizalama)
        {
            this.YaziTipi = YaziTipi;
            this.FontRengi = FontRengi;
            this.ArkaplanRengi = ArkaplanRengi;
            this.Genislik = Genislik;
            this.Yukseklik = Yukseklik;
            this.YatayHizalama = YatayHizalama;
            this.DikeyHizalama = DikeyHizalama;
        }
    }
}
