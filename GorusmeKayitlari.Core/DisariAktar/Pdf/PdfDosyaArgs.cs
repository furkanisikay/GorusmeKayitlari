namespace GorusmeKayitlari.Core.DisariAktar.Pdf
{
    public class PdfDosyaArgs
    {
        /// <summary>
        /// Dosyanın kaydedileceği yol.
        /// </summary>
        public string DosyaAdi { get; set; }
        /// <summary>
        /// PDF dosyanın içeriğindeki logonun bulunduğu dizin.
        /// </summary>
        public string LogoDosyaAdi { get; set; }
        /// <summary>
        /// PDF dosyasının içeriğindeki başlık.
        /// </summary>
        public string Baslik { get; set; }
        /// <summary>
        /// PDF dosyasının yazarı.
        /// </summary>
        public string Yazar { get; set; }
        /// <summary>
        /// PDF dosyasında tarihin görüntülenip görüntülenmeyeceği durumu.
        /// </summary>
        public bool TarihGoster { get; set; }
        /// <summary>
        /// PDF dosyası için oluşturulacak, üst bölümdeki kolon sayısını belirtir.
        /// </summary>
        public int BaslikSayisi
        {
            get
            {
                int bloksayisi = 0;
                if (!string.IsNullOrEmpty(LogoDosyaAdi))
                {
                    bloksayisi++;
                }
                if (!string.IsNullOrEmpty(this.Baslik))
                {
                    bloksayisi++;
                }
                if (this.TarihGoster)
                {
                    bloksayisi++;
                }
                return bloksayisi;
            }
        }
        /// <summary>
        /// Yeni bir PDFDosyaArgs nesnesi oluşturur.
        /// </summary>
        /// <param name="DosyaAdi">Dosyanın kaydedileceği yol.</param>
        /// <param name="LogoDosyaAdi">PDF dosyanın içeriğindeki logonun bulunduğu dizin.</param>
        /// <param name="Baslik">PDF dosyasının içeriğindeki başlık.</param>
        /// <param name="Yazar">PDF dosyasının yazarı.</param>
        /// <param name="TarihGoster">PDF dosyasında tarihin görüntülenip görüntülenmeyeceği durumu.</param>
        public PdfDosyaArgs(string DosyaAdi, string LogoDosyaAdi, string Baslik, string Yazar, bool TarihGoster)
        {
            this.DosyaAdi = DosyaAdi;
            this.LogoDosyaAdi = LogoDosyaAdi;
            this.Baslik = Baslik;
            this.Yazar = Yazar;
            this.TarihGoster = TarihGoster;
        }
    }
}
