namespace GorusmeKayitlari.Core.Components
{
    public enum IslemButonlariDurumu { None, Ekle, Guncelle }
    public static class IslemButonlariDurumuAraclari
    {
        public static IslemButonlariDurumu Parse(string yazi)
        {
            switch (yazi)
            {
                case "Ekle":
                    return IslemButonlariDurumu.Ekle;
                case "Guncelle":
                    return IslemButonlariDurumu.Guncelle;
                default:
                    return IslemButonlariDurumu.None;
            }
        }
        public static string ToString(IslemButonlariDurumu durum)
        {
            switch (durum)
            {
                case IslemButonlariDurumu.Ekle:
                    return "Ekle";
                case IslemButonlariDurumu.Guncelle:
                    return "Guncelle";
                default:
                    return "";
            }
        }
    }
}
