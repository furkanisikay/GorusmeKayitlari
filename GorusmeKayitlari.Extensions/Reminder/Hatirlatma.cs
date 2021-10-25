using System;
using GorusmeKayitlari.Core.DB.Objects;

namespace GorusmeKayitlari.Extensions.Reminder
{
    public class Hatirlatma : IIdliNesne
    {
        /// <summary>
        /// Boş Hatırlatma nesnesi oluşturur.
        /// </summary>
        public static Hatirlatma Bos { get { return new Hatirlatma(-1, string.Empty, DateTime.Now); } }

        #region Constructor
        /// <summary>
        /// Yeni bir Hatırlatma nesnesi oluşturur.
        /// </summary>
        /// <param name="id">Hatırlatma id'si.</param>
        /// <param name="metin">Hatırlatma metni</param>
        /// <param name="tarih">Hatırlatma tarihi</param>
        public Hatirlatma(int id, string metin, DateTime tarih)
        {
            this.id = id;
            this.Metin = metin;
            this.Tarih = tarih;
        }
        #endregion

        #region Members
        #region Private Members
        private readonly int id = -1;
        int IIdliNesne.Id { get { return this.id; } }
        #endregion
        #region Public Members
        /// <summary>
        /// Hatırlatma Id'si.
        /// </summary>
        public int Id { get { return ((IIdliNesne)this).Id; } }
        /// <summary>
        /// Hatırlatma Metni.
        /// </summary>
        public string Metin = string.Empty;
        /// <summary>
        /// Hatırlatma Tarihi.
        /// </summary>
        public DateTime Tarih = DateTime.Now;
        #endregion
        #endregion
    }
}
