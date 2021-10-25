namespace GorusmeKayitlari.Core.DB.Objects
{
    public static class NesneTuruAraclari
    {
        public static NesneYetkileri ToNesneYetkileriGoruntulemeYetki(this NesneTuru Tur)
        {
            switch (Tur)
            {
                case NesneTuru.None:
                    return NesneYetkileri.None;
                case NesneTuru.Yetkili:
                    return NesneYetkileri.YetkiliGoruntule;
                case NesneTuru.Kullanici:
                    return NesneYetkileri.KullaniciGoruntule;
                case NesneTuru.Kurum:
                    return NesneYetkileri.KurumGoruntule;
                case NesneTuru.Kategori:
                    return NesneYetkileri.KategoriGoruntule;
                case NesneTuru.KullaniciHesabi:
                    return NesneYetkileri.KullaniciHesapGoruntuleme;
                default:
                    return NesneYetkileri.None;
            }
        }
        public static string NesneTuruToString(this NesneTuru tur)
        {
            switch (tur)
            {
                case NesneTuru.None:
                    return string.Empty;
                case NesneTuru.Yetkili:
                    return "Yetkili";
                case NesneTuru.Kullanici:
                    return "Kullanıcı";
                case NesneTuru.Kurum:
                    return "Kurum";
                case NesneTuru.Kategori:
                    return "Kategori";
                case NesneTuru.KullaniciHesabi:
                    return "Kategori";
                default:
                    return string.Empty;
            }
        }
        public static NesneTuru ToNesneTuru(this string tur)
        {
            tur = tur.ToLower().Trim().Replace(" ", string.Empty);
            switch (tur)
            {
                case "":
                    return NesneTuru.None;
                case "none":
                    return NesneTuru.None;
                case "yetkili":
                    return NesneTuru.Yetkili;
                case "kullanıcı":
                    return NesneTuru.Kullanici;
                case "kullanici":
                    return NesneTuru.Kullanici;
                case "kurum":
                    return NesneTuru.Kurum;
                case "kategori":
                    return NesneTuru.Kategori;
                case "kullanicihesabi":
                    return NesneTuru.Kullanici;
                case "kullanıcıhesabı":
                    return NesneTuru.Kullanici;
                default:
                    return NesneTuru.None;
            }
        }
    }
}
