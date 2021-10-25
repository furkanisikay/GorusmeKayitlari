using System;
using System.Collections.Generic;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public static class DigerYetkilerTools
    {
        public static DigerYetkiler ToDigerYetkiler(this string yetkiadi)
        {
            yetkiadi = yetkiadi.ToLower();
            yetkiadi = yetkiadi.Replace(" ", string.Empty);
            yetkiadi = yetkiadi.Trim();
            switch (yetkiadi)
            {
                case "":
                    return DigerYetkiler.None;
                case "none":
                    return DigerYetkiler.None;
                case "hatirlatmaekle":
                    return DigerYetkiler.HatirlatmaEkle;
                case "hatirlatmaduzenle":
                    return DigerYetkiler.HatirlatmaDuzenle;
                case "hatirlatmagoruntule":
                    return DigerYetkiler.HatirlatmaGoruntule;
                case "hatirlatmasil":
                    return DigerYetkiler.HatirlatmaSil;
                default:
                    return DigerYetkiler.None;
            }
        }
        public static List<DigerYetkiler> TumunuGetir(this DigerYetkiler Yetki)
        {
            List<DigerYetkiler> yetkiler = new List<DigerYetkiler>();
            Array arr = Enum.GetValues(typeof(DigerYetkiler));
            if (arr != null)
            {
                foreach (DigerYetkiler yetki in arr)
                {
                    yetkiler.Add(yetki);
                }
            }
            return yetkiler;
        }
        public static string ToCustomString(this DigerYetkiler yetki)
        {
            switch (yetki)
            {
                case DigerYetkiler.None:
                    return string.Empty;
                case DigerYetkiler.HatirlatmaEkle:
                    return "Hatırlatma Ekle";
                case DigerYetkiler.HatirlatmaDuzenle:
                    return "Hatırlatma Düzenle";
                case DigerYetkiler.HatirlatmaGoruntule:
                    return "Hatırlatma Görüntüle";
                case DigerYetkiler.HatirlatmaSil:
                    return "Hatırlatma Sil";
                default:
                    return string.Empty;
            }
        }
        public static bool IsDigerYetkiler<T>( this T nesne)
        {
            if (typeof(T).IsEnum)
            {
                return nesne is DigerYetkiler;
            }
            else { return false; }
        }
    }
}
