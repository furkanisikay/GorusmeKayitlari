using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorusmeKayitlari.Core.DB.Methods;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public class KullaniciHesap : IIdliNesne
    {
        #region Constructor
        public static KullaniciHesap Bos
        {
            get { return new KullaniciHesap(-1, new Kullanici(-1), string.Empty, string.Empty,null, null, KullaniciHesapDurumu.None, DateTime.MinValue, DateTime.MinValue, null, string.Empty); }
        }
        public KullaniciHesap(int Id)
        {
            this.id = Id;
            this._Kullanici = Kullanici.Bos;
            this.KullaniciAdi = string.Empty;
            this.Sifre = string.Empty;
            this.NesneYetkileri = null;
            this.DigerYetkiler = null;
            this.Durum = KullaniciHesapDurumu.None;
            this.OlusturulmaTarihi = DateTime.MinValue;
            this.SonDuzenlemeTarihi = DateTime.MinValue;
            this._SonDuzenleyenKullaniciHesabi = KullaniciHesap.Bos;
            this.Aciklama = string.Empty;
        }
        public KullaniciHesap(string KullaniciAdi, string Sifre)
        {
            this.id = -1;
            this._Kullanici = Kullanici.Bos;
            this.KullaniciAdi = KullaniciAdi;
            this.Sifre = Sifre;
            this.NesneYetkileri = null;
            this.DigerYetkiler = null;
            this.Durum =  KullaniciHesapDurumu.None;
            this.OlusturulmaTarihi = DateTime.MinValue;
            this.SonDuzenlemeTarihi = DateTime.MinValue;
            this._SonDuzenleyenKullaniciHesabi = KullaniciHesap.Bos;
            this.Aciklama = string.Empty;
        }
        public KullaniciHesap(int Id, Kullanici Kullanici, string KullaniciAdi, string Sifre, List<NesneYetkileri> NesneYetkileri, List<DigerYetkiler> DigerYetkiler, KullaniciHesapDurumu Durum, DateTime OlusturulmaTarihi, DateTime SonDuzenlemeTarihi, KullaniciHesap SonDuzenleyenKullaniciHesabi, string Aciklama)
        {
            this.id = Id;
            this._Kullanici = Kullanici;
            this.KullaniciAdi = KullaniciAdi;
            this.Sifre = Sifre;
            this.NesneYetkileri = NesneYetkileri;
            this.DigerYetkiler = DigerYetkiler;
            this.Durum = Durum;
            this.OlusturulmaTarihi = OlusturulmaTarihi;
            this.SonDuzenlemeTarihi = SonDuzenlemeTarihi;
            this._SonDuzenleyenKullaniciHesabi = SonDuzenleyenKullaniciHesabi;
            this.Aciklama = Aciklama;
        }
        #endregion

        #region Private Members

        private readonly int id = -1;
        int IIdliNesne.Id { get { return this.id; } }
        private Kullanici _Kullanici { get; set; }
        private KullaniciHesap _SonDuzenleyenKullaniciHesabi { get; set; }
        private bool KullaniciAyarlandi = false;
        private bool SDKulHesabiAyarlandi = false;
        #endregion

        #region Public Members
        /// <summary>
        /// Kullanıcı Hesabı Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Kullanıcı Hesabı Kullanıcısı.
        /// </summary>
        //public Kullanici Kullanici => GetKullanici();    
        /// <summary>
        /// Kullanıcı Hesabının Kullanıcı adı.
        /// </summary>
        public string KullaniciAdi { get; }
        /// <summary>
        /// Kullanıcı Hesabı Şifresi.
        /// </summary>
        public string Sifre { get; }
        /// <summary>
        /// Kullanıcı Hesabının Nesne Yetkileri.
        /// </summary>
        public List<NesneYetkileri> NesneYetkileri { get; }
        /// <summary>
        /// Kullanıcı Hesabının Diğer Yetkileri.
        /// </summary>
        public List<DigerYetkiler> DigerYetkiler { get; }
        /// <summary>
        /// Kullanıcı Hesabı Durumu.
        /// </summary>
        public KullaniciHesapDurumu Durum { get; }
        /// <summary>
        /// Kullanıcı Hesabının oluşturulma tarihi.
        /// </summary>
        public DateTime OlusturulmaTarihi { get; }
        /// <summary>
        /// Kullanıcı Hesabının En Son Düzenlendiği Tarih
        /// </summary>
        public DateTime SonDuzenlemeTarihi { get; }
        /// <summary>
        /// Kullanıcı hesabını en son düzenleyen kullanıcın hesabı.
        /// </summary>
        //private KullaniciHesap _SonDuzenleyenKullaniciHesabi { get { return GetSonDuzKulHesabi(); } }
        /// <summary>
        /// Kullanıcı Hesabı Açıklaması.
        /// </summary>
        public string Aciklama { get; }
        #endregion

        #region Methods
        public Kullanici GetKullanici(ConnectionManager manager)
        {
            if (this._Kullanici?.Id > 0 && !this.KullaniciAyarlandi)
            {
                Optimizasyon.ArkaplandaCalistir(async () => { this._Kullanici = await Kullanicilar.Getir(this._Kullanici.Id, manager); }, true);
            }
            return this._Kullanici;
        }
        public KullaniciHesap GetSonDuzKulHesabi(ConnectionManager manager)
        {
            if (this._SonDuzenleyenKullaniciHesabi?.Id > 0 && !this.SDKulHesabiAyarlandi)
            {
                Optimizasyon.ArkaplandaCalistir(async () =>
                {
                    this._SonDuzenleyenKullaniciHesabi = await KullaniciHesaplar.Getir(this._SonDuzenleyenKullaniciHesabi.Id, manager);
                }, true);
            }
            return this._SonDuzenleyenKullaniciHesabi;
        }
        public void SetKullanici(Kullanici kullanici)
        {
            this._Kullanici = kullanici;
        }
        public bool YetkileriAra<T>(T Yetki)
        {
            if (Yetki.IsDigerYetkiler())
            {
                return this.DigerYetkiler.Contains(Yetki.ToString().ToDigerYetkiler());
            }
            else if (Yetki.IsNesneYetkileri())
            {
                return this.NesneYetkileri.Contains(Yetki.ToString().ToNesneYetkileri());
            }
            else { throw new ArgumentException("Yetki parametresindeki sınıf Enum olmalı."); }
        }
        public override string ToString()
        {
            return this.KullaniciAdi;
        }
        #endregion
    }
}
