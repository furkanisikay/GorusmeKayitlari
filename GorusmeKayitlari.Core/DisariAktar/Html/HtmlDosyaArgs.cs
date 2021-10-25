namespace GorusmeKayitlari.Core.DisariAktar.Html
{
    public class HtmlDosyaArgs
    {
        /// <summary>
        /// Dosyanın kaydedileceği yol.
        /// </summary>
        public string DosyaAdi { get; set; }
        public HtmlDosyaArgs(string DosyaAdi)
        {
            this.DosyaAdi = DosyaAdi;
        }
    }
}
