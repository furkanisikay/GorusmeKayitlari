namespace GorusmeKayitlari.Core.DB.Objects
{
    public class Kurum : IIdliNesne
    {
        #region Constructor
        public static Kurum Bos { get { return new Kurum(-1, Kategori.Bos, string.Empty, Yetkili.Bos, IletisimBilgileri.Bos, string.Empty); } }
        /// <summary>
        /// Yeni bir Kurum nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kurumun Id'si.</param>
        /// <param name="Kategori">Kurumun Kategorisi.</param>
        /// <param name="Ad">Kurumun Adı.</param>
        /// <param name="Yetkili">Kurumun Yetkilisi.</param>
        /// <param name="IletisimBilgileri">Kurumun Iletişim Bilgileri.</param>
        /// <param name="Aciklama">Kurumun Açıklaması.</param>
        public Kurum(int Id, Kategori Kategori, string Ad, Yetkili Yetkili, IletisimBilgileri IletisimBilgileri, string Aciklama)
        {
            this.id = Id;
            this.Kategori = Kategori;
            this.Ad = Ad;
            this.Yetkili = Yetkili;
            this.IletisimBilgileri = IletisimBilgileri;
            this.Aciklama = Aciklama;
        }
        /// <summary>
        /// Yeni boş bir Kurum nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kurumun Id'si.</param>
        public Kurum(int Id)
        {
            this.id = Id;
            this.Kategori = new Kategori(-1);
            this.Ad = string.Empty;
            this.Yetkili = new Yetkili(-1);
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
        /// Kurumun Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Kurumun Kategorisi.
        /// </summary>
        public Kategori Kategori { get; set; }
        /// <summary>
        /// Kurumun Adı.
        /// </summary>
        public string Ad { get; }
        /// <summary>
        /// Kurumun Yetkilisi.
        /// </summary>
        public Yetkili Yetkili { get; set; }
        /// <summary>
        /// Kurumun İletişim Bilgileri.
        /// </summary>
        public IletisimBilgileri IletisimBilgileri { get; }
        /// <summary>
        /// Kurumun Açıklaması.
        /// </summary>
        public string Aciklama { get; }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Kurumun Adının Döndürür.
        /// </summary>
        /// <returns>Kurumun Adı</returns>
        public override string ToString()
        {
            return string.IsNullOrEmpty(this.Ad) ? string.Empty : this.Ad;
        }
        #endregion	
    }
}
