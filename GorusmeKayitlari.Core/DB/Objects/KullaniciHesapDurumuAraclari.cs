namespace GorusmeKayitlari.Core.DB.Objects
{
    public static class KullaniciHesapDurumuAraclari
    {
        public static string ToCustomString(this KullaniciHesapDurumu durum)
        {
            switch (durum)
            {
                case KullaniciHesapDurumu.None:
                    return string.Empty;
                case KullaniciHesapDurumu.Aktif:
                    return "Aktif";
                case KullaniciHesapDurumu.KullanimDisi:
                    return "Kullanım Dışı";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// "" = KullaniciHesapDurumu.None
        /// "aktif" = KullaniciHesapDurumu.Aktif
        /// "kullanımdışı" = KullaniciHesapDurumu.KullanimDisi
        /// şeklinde dönüştürülür.
        /// Girilen string türündeki değer küçültülür ve trimlenerek KullaniciHesapDurumu'da karşılayan değer döndürülür
        /// </summary>
        /// <param name="durum">KullaniciHesapDurumu yazısı.</param>
        /// <returns></returns>
        public static KullaniciHesapDurumu ToKullaniciHesabiDurumu(this string durum)
        {
            durum = durum.Trim().ToLower().Replace(" ",string.Empty);
            switch (durum)
            {
                case "":
                    return KullaniciHesapDurumu.None;
                case "none":
                    return KullaniciHesapDurumu.None;
                case "aktif":
                    return KullaniciHesapDurumu.Aktif;
                case "kullanımdışı":
                    return KullaniciHesapDurumu.KullanimDisi;
                case "kullanimdisi":
                    return KullaniciHesapDurumu.KullanimDisi;
                default:
                    return KullaniciHesapDurumu.None;
            }
        }
    }
}
