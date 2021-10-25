using System;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public class Gorusme : IIdliNesne
    {
        #region Constructor
        public static Gorusme Bos { get { return new Gorusme(-1, Kurum.Bos, Yetkili.Bos, Kullanici.Bos, DateTime.MinValue, string.Empty); } }
        /// <summary>
        /// Yeni bir Gorusme nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Görüşme Id'si</param>
        /// <param name="Kurum">Görüşme yapılan Kurum</param>
        /// <param name="Yetkili">Görüşme yapılan Yetkili</param>
        /// <param name="Kullanici">Görüşen Kullanıcı</param>
        /// <param name="Tarih">Görüşme Tarihi</param>
        /// <param name="Metin">Görüşme Metni</param>
        /// <returns>Gorusme</returns>
        public Gorusme(int Id, Kurum Kurum, Yetkili Yetkili, Kullanici Kullanici, DateTime Tarih, string Metin)
        {
            this.id = Id;
            this.Kurum = Kurum;
            this.Yetkili = Yetkili;
            this.Kullanici = Kullanici;
            this.Tarih = Tarih;
            this.Metin = Metin;
        }

        /// <summary>
        /// Yeni bir boş Gorusme nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Görüşme Id'si</param>
        /// <returns>Gorusme</returns>
        public Gorusme(int Id)
        {
            this.id = Id;
            this.Kurum = new Kurum(-1);
            this.Yetkili = new Yetkili(-1);
            this.Kullanici = new Kullanici(-1);
            this.Tarih = DateTime.Now;
            this.Metin = string.Empty;
        }
        #endregion

        #region Members
        #region Private Members
        private readonly int id = -1;
        int IIdliNesne.Id { get { return this.id; } }
        #endregion

        #region Public Members
        /// <summary>
        /// Görüşme Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Görüşme Yapılan Kurusm.
        /// </summary>
        public Kurum Kurum { get; set; }
        /// <summary>
        /// Görüşme Yapılan Kurumun Yetkilisi.
        /// </summary>
        public Yetkili Yetkili { get; set; }
        /// <summary>
        /// Görüşmeyi Yapan Kullanıcı.
        /// </summary>
        public Kullanici Kullanici { get; set; }
        /// <summary>
        /// Görüşme Tarihi.
        /// </summary>
        public DateTime Tarih { get; set; }
        /// <summary>
        /// Görüşme Metni.
        /// </summary>
        public string Metin { get; set; }
        #endregion
        #endregion
    }
}
