namespace GorusmeKayitlari.Core.DB.Objects
{
    public class Kategori : IIdliNesne
    {
        #region Constructor
        public static Kategori Bos { get { return new Kategori(-1, Kategori.Bos, string.Empty); } }
        /// <summary>
        /// Yeni bir Kategori nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kategorinin Id'si.</param>
        /// <param name="UstKategori">Kategorinin Üst Kategorisi.</param>
        /// <param name="Ad">Kategorinin Adı.</param>
        public Kategori(int Id, Kategori UstKategori, string Ad)
        {
            this.id = Id;
            this.UstKategori = UstKategori;
            this.Ad = Ad;
        }
        /// <summary>
        /// Yeni bir boş Kategori nesnesi oluşturur.
        /// </summary>
        /// <param name="Id">Kategorinin Id'si.</param>
        /// <param name="UstKategori">Kategorinin Üst Kategorisi.</param>
        /// <param name="Ad">Kategorinin Adı.</param>
        public Kategori(int Id)
        {
            this.id = Id;
            this.UstKategori = null;
            this.Ad = string.Empty;
        }
        #endregion

        #region Members
        #region Private Members
        private readonly int id = -1;
        int IIdliNesne.Id { get { return this.id; } }
        #endregion

        #region Public Members
        /// <summary>
        /// Kategorinin Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Kategorinin Üst Kategorisi.
        /// </summary>
        public Kategori UstKategori { get; set; }
        /// <summary>
        /// Kategorinin Adı.
        /// </summary>
        public string Ad { get; set; }
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Kategorinin Adının Döndürür.
        /// </summary>
        /// <returns>Kategori Adı</returns>
        public override string ToString() // <------ DataTreeNode sınıfında temel constructora gönderilecek ToString() işte burası.
        {
            return string.IsNullOrEmpty(this.Ad) ? string.Empty : this.Ad;
        }
        #endregion	
    }
}
