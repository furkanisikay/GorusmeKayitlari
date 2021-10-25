namespace GorusmeKayitlari.Core.DB.Objects
{
    public class Yetkili : IIdliNesne
    {
        #region Constructor
        public static Yetkili Bos
        {
            get { return new Yetkili(-1, string.Empty, string.Empty, IletisimBilgileri.Bos, string.Empty); }
        }
        /// <summary>
        /// Yeni bir Yetkili nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Yetkili Id'si.</param>
        /// <param name="Ad">Yetkili Adı.</param>
        /// <param name="Soyad">Yetkili Soyadı.</param>
        /// <param name="IletisimBilgileri">Yetkili İletişim Bilgileri.</param>
        /// <param name="Aciklama">Yetkili Açıklaması.</param>
        public Yetkili(int Id, string Ad, string Soyad, IletisimBilgileri IletisimBilgileri, string Aciklama)
        {
            this.id = Id;
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.IletisimBilgileri = IletisimBilgileri;
            this.Aciklama = Aciklama;
        }

        /// <summary>
        /// Yeni bir boş Yetkili nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Yetkili Id'si.</param>
        public Yetkili(int Id)
        {
            this.id = Id;
            this.Ad = string.Empty;
            this.Soyad = string.Empty;
            this.IletisimBilgileri = IletisimBilgileri.Bos;
            this.Aciklama = string.Empty;
        }
        #endregion

        #region Members
        #region Private Members
        private readonly int id = -1;
        int IIdliNesne.Id { get { return this.id; } }
        #endregion

        #region Public Members
        /// <summary>
        /// Yetkilinin Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Yetkilinin Adı.
        /// </summary>
        public string Ad { get; }
        /// <summary>
        /// Yetkilinin Soyadı.
        /// </summary>
        public string Soyad { get; }
        /// <summary>
        /// Yetkilinin İletişim Bilgileri.
        /// </summary>
        public IletisimBilgileri IletisimBilgileri { get; }
        /// <summary>
        /// Yetkilinin Açıklaması.
        /// </summary>
        public string Aciklama { get; }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Yetkilinin Adı ve Soyadını Döndürür.
        /// </summary>
        /// <returns>Yetkilinin Adı ve Soyadı</returns>
        public override string ToString() // <------ DataTreeNode sınıfında temel constructora gönderilecek ToString() işte burası.
        {
            if (!string.IsNullOrEmpty(this.Ad) && !string.IsNullOrEmpty(this.Soyad))
            {
                return this.Ad + " " + this.Soyad;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
