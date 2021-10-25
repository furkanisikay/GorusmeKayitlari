using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Extensions.Reminder.Class
{
    public class BildirimSesi
    {
        /// <summary>
        /// Yeni bir nesne oluşturur
        /// </summary>
        /// <param name="Aktif">Bildirim Sesi Oynatmanın aktiflik durumu.</param>
        /// <param name="Dosya">Bildirim Sesinin Dosyası.</param>
        public BildirimSesi(bool Aktif, string Dosya)
        {
            this.Aktif = Aktif;
            this.Dosya = Dosya;
        }
        public BildirimSesi()
        {
            this.Aktif = false;
            this.Dosya = string.Empty;
        }
        /// <summary>
        /// Bildirim Sesi Oynatmanın aktiflik durumu.
        /// </summary>
        public bool Aktif { get; set; }
        /// <summary>
        /// Bildirim Sesinin Dosyası.
        /// </summary>
        public string Dosya { get; set; }
    }
}
