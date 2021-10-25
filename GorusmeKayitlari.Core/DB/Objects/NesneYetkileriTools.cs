using System;
using System.Collections.Generic;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public static class NesneYetkileriTools
    {
        public static NesneYetkileri ToNesneYetkileri(this string yetkiadi)
        {
            yetkiadi = yetkiadi.ToLower();
            yetkiadi = yetkiadi.Replace(" ", string.Empty);
            yetkiadi = yetkiadi.Trim();
            switch (yetkiadi)
            {
                case "":
                    return NesneYetkileri.None;
                case "none":
                    return NesneYetkileri.None;
                case "kategorigörüntüle":
                    return NesneYetkileri.KategoriGoruntule;
                case "kategorigoruntule":
                    return NesneYetkileri.KategoriGoruntule;
                case "kategoriekle":
                    return NesneYetkileri.KategoriEkle;
                case "kategoridüzenle":
                    return NesneYetkileri.KategoriDuzenle;
                case "kategoriduzenle":
                    return NesneYetkileri.KategoriDuzenle;
                case "kategorisil":
                    return NesneYetkileri.KategoriSil;
                case "kurumgörüntüle":
                    return NesneYetkileri.KurumGoruntule;
                case "kurumgoruntule":
                    return NesneYetkileri.KurumGoruntule;
                case "kurumekle":
                    return NesneYetkileri.KurumEkle;
                case "kurumdüzenle":
                    return NesneYetkileri.KurumDuzenle;
                case "kurumduzenle":
                    return NesneYetkileri.KurumDuzenle;
                case "kurumsil":
                    return NesneYetkileri.KurumSil;
                case "kullanıcıgörüntüle":
                    return NesneYetkileri.KullaniciGoruntule;
                case "kullanicigoruntule":
                    return NesneYetkileri.KullaniciGoruntule;
                case "kullanıcıekle":
                    return NesneYetkileri.KullaniciEkle;
                case "kullaniciekle":
                    return NesneYetkileri.KullaniciEkle;
                case "kullanıcıdüzenle":
                    return NesneYetkileri.KullaniciDuzenle;
                case "kullaniciduzenle":
                    return NesneYetkileri.KullaniciDuzenle;
                case "kullanıcısil":
                    return NesneYetkileri.KullaniciSil;
                case "kullanicisil":
                    return NesneYetkileri.KullaniciSil;
                case "yetkiligörüntüle":
                    return NesneYetkileri.YetkiliGoruntule;
                case "yetkiligoruntule":
                    return NesneYetkileri.YetkiliGoruntule;
                case "yetkiliekle":
                    return NesneYetkileri.YetkiliEkle;
                case "yetkilidüzenle":
                    return NesneYetkileri.YetkiliDuzenle;
                case "yetkiliduzenle":
                    return NesneYetkileri.YetkiliDuzenle;
                case "yetkilisil":
                    return NesneYetkileri.YetkiliSil;
                case "görüşmegörüntüle":
                    return NesneYetkileri.GorusmeGoruntule;
                case "gorusmegoruntule":
                    return NesneYetkileri.GorusmeGoruntule;
                case "görüşmeekle":
                    return NesneYetkileri.GorusmeEkle;
                case "gorusmeekle":
                    return NesneYetkileri.GorusmeEkle;
                case "görüşmedüzenle":
                    return NesneYetkileri.GorusmeDuzenle;
                case "gorusmeduzenle":
                    return NesneYetkileri.GorusmeDuzenle;
                case "görüşmesil":
                    return NesneYetkileri.GorusmeSil;
                case "gorusmesil":
                    return NesneYetkileri.GorusmeSil;
                case "kullanıcıhesapekleme":
                    return NesneYetkileri.KullaniciHesapEkleme;
                case "kullanicihesapekleme":
                    return NesneYetkileri.KullaniciHesapEkleme;
                case "kullanıcıhesapdüzenleme":
                    return NesneYetkileri.KullaniciHesapDuzenleme;
                case "kullanicihesapduzenleme":
                    return NesneYetkileri.KullaniciHesapDuzenleme;
                case "kullanıcıhesapsilme":
                    return NesneYetkileri.KullaniciHesapSilme;
                case "kullanicihesapsilme":
                    return NesneYetkileri.KullaniciHesapSilme;
                case "kullanıcıhesapgörüntüleme":
                    return NesneYetkileri.KullaniciHesapGoruntuleme;
                case "kullanicihesapgoruntuleme":
                    return NesneYetkileri.KullaniciHesapGoruntuleme;
                default:
                    return NesneYetkileri.None;
            }
        }
        public static string ToCustomString(this NesneYetkileri yetki)
        {
            switch (yetki)
            {
                case NesneYetkileri.None:
                    return string.Empty;
                case NesneYetkileri.KategoriGoruntule:
                    return "Kategori Görüntüle";
                case NesneYetkileri.KategoriEkle:
                    return "Kategori Ekle";
                case NesneYetkileri.KategoriDuzenle:
                    return "Kategori Düzenle";
                case NesneYetkileri.KategoriSil:
                    return "Kategori Sil";
                case NesneYetkileri.KurumGoruntule:
                    return "Kurum Görüntüle";
                case NesneYetkileri.KurumEkle:
                    return "Kurum Ekle";
                case NesneYetkileri.KurumDuzenle:
                    return "Kurum Düzenle";
                case NesneYetkileri.KurumSil:
                    return "Kurum Sil";
                case NesneYetkileri.KullaniciGoruntule:
                    return "Kullanıcı Görüntüle";
                case NesneYetkileri.KullaniciEkle:
                    return "Kullanıcı Ekle";
                case NesneYetkileri.KullaniciDuzenle:
                    return "Kullanıcı Düzenle";
                case NesneYetkileri.KullaniciSil:
                    return "Kullanıcı Sil";
                case NesneYetkileri.YetkiliGoruntule:
                    return "Yetkili Görüntüle";
                case NesneYetkileri.YetkiliEkle:
                    return "Yetkili Ekle";
                case NesneYetkileri.YetkiliDuzenle:
                    return "Yetkili Düzenle";
                case NesneYetkileri.YetkiliSil:
                    return "Yetkili Sil";
                case NesneYetkileri.GorusmeGoruntule:
                    return "Görüşme Görüntüle";
                case NesneYetkileri.GorusmeEkle:
                    return "Görüşme Ekle";
                case NesneYetkileri.GorusmeDuzenle:
                    return "Görüşme Düzenle";
                case NesneYetkileri.GorusmeSil:
                    return "Görüşme Sil";
                case NesneYetkileri.KullaniciHesapEkleme:
                    return "Kullanıcı Hesap Ekleme";
                case NesneYetkileri.KullaniciHesapDuzenleme:
                    return "Kullanıcı Hesap Düzenleme";
                case NesneYetkileri.KullaniciHesapSilme:
                    return "Kullanıcı Hesap Silme";
                case NesneYetkileri.KullaniciHesapGoruntuleme:
                    return "Kullanıcı Hesap Görüntüleme";
                default:
                    return string.Empty;
            }
        }
        public static List<NesneYetkileri> TumunuGetir(this NesneYetkileri Yetki)
        {
            List<NesneYetkileri> nesneler = new List<NesneYetkileri>();
            Array arr = Enum.GetValues(typeof(NesneYetkileri));
            if (arr != null)
            {
                foreach (NesneYetkileri yetki in arr)
                {
                    nesneler.Add(yetki);
                }
            }
            return nesneler;
        }
        public static string ToCustomString(this NesneYetkileri yetki, bool convertable)
        {
            if (convertable)
            {
                return Enum.GetName(typeof(NesneYetkileri), yetki);
            }
            else { return yetki.ToString(); }
        }
        public static bool IsNesneYetkileri<T>(this T nesne)
        {
            if (typeof(T).IsEnum)
            {
                return nesne is NesneYetkileri;
            }
            else { return false; }
        }
    }
}
