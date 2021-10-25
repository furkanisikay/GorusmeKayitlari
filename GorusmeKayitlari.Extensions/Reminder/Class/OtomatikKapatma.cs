namespace GorusmeKayitlari.Extensions.Reminder.Class
{
    public class OtomatikKapatma
    {
        /// <summary>
        /// Yeni bir OtomatikKapanma nesnesi oluşturur.
        /// </summary>
        /// <param name="Aktif">Otomatik Kapatmanın aktiflik durumu.</param>
        /// <param name="Sure">Otomatik kapanmadan önce beklenecek süre.</param>
        public OtomatikKapatma(bool Aktif, int Sure)
        {
            this.Aktif = Aktif;
            this.Sure = Sure;
        }
        public OtomatikKapatma()
        {
            this.Aktif = false;
            this.Sure = -1;
        }
        /// <summary>
        /// Otomatik Kapatmanın aktiflik durumu.
        /// </summary>
        public bool Aktif { get; set; }
        /// <summary>
        /// Otomatik kapanmadan önce beklenecek süre.
        /// </summary>
        public int Sure { get; set; }
    }
}
