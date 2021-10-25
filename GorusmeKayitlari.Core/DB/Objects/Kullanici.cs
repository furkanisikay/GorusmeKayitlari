namespace GorusmeKayitlari.Core.DB.Objects
{
    public class Kullanici : IIdliNesne
    {
        #region Constructor
        public static Kullanici Bos
        {
            get { return new Kullanici(-1, string.Empty, string.Empty, IletisimBilgileri.Bos, string.Empty); }
        }
        /// <summary>
        /// Yeni bir Kullanıcı nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kullanıcının Id'si.</param>
        /// <param name="Ad">Kullanıcının Adı.</param>
        /// <param name="Soyad">Kullanıcının Soyadı.</param>
        /// <param name="IletisimBilgileri">Kullanıcının İletişim Bilgileri.</param>
        /// <param name="Aciklama">Kullanıcının Açıklaması.</param>
        public Kullanici(int Id, string Ad, string Soyad, IletisimBilgileri IletisimBilgileri, string Aciklama)
        {
            this.id = Id;
            this.Ad = Ad;
            this.Soyad = Soyad;
            this.IletisimBilgileri = IletisimBilgileri;
            this.Aciklama = Aciklama;
        }
        /// <summary>
        /// Yeni bir boş Kullanıcı nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kullanıcının Id'si.</param>
        public Kullanici(int Id)
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
        /// Kullanıcının Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Kullanıcının Adı.
        /// </summary>
        public string Ad { get; }
        /// <summary>
        /// Kullanıcının Soyadı.
        /// </summary>
        public string Soyad { get; }
        /// <summary>
        /// Kullanıcının İletişim Bilgileri.
        /// </summary>
        public IletisimBilgileri IletisimBilgileri { get; }
        /// <summary>
        /// Kullanıcının Açıklaması.
        /// </summary>
        public string Aciklama { get; }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Kullanıcının Adı ve Soyadını Döndürür.
        /// </summary>
        /// <returns>Kullanıcının Adı ve Soyadı</returns>
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
