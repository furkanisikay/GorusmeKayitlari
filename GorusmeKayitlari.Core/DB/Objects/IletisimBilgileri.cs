using System;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public class IletisimBilgileri
    {
        #region Constructor
        public static IletisimBilgileri Bos
        {
            get { return new IletisimBilgileri(string.Empty, string.Empty, string.Empty, string.Empty); }
        }
        public IletisimBilgileri(string Telefon, string Eposta, string Fax, string Adres)
        {
            this.Telefon = Telefon;
            this.Fax = Fax;
            this.Eposta = Eposta;
            this.Adres = Adres;
        }
        #endregion

        #region Public Members
        public string Telefon { get; }
        public string Fax { get; }
        public string Eposta { get; }
        public string Adres { get; }
        #endregion
    }
}
