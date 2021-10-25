using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public class TumunuGetirArgs
    {
        public TumunuGetirArgs(List<Kurum> KurumListesi, List<Yetkili> YetkiliListesi, List<Kullanici> KullaniciListesi, DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            this.KurumListesi = KurumListesi;
            this.YetkiliListesi = YetkiliListesi;
            this.KullaniciListesi = KullaniciListesi;
            this.BaslangicTarihi = BaslangicTarihi;
            this.BitisTarihi = BitisTarihi;
        }
        public List<Kurum> KurumListesi { get; }
        public List<Yetkili> YetkiliListesi { get; }
        public List<Kullanici> KullaniciListesi { get; }
        public DateTime BaslangicTarihi { get; }
        public DateTime BitisTarihi { get; }
    }
}
