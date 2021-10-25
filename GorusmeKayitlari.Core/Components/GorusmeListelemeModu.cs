namespace GorusmeKayitlari.Core.Components
{
    public enum GorusmeListelemeModu { None, KurumaGore, KategoriyeGore, KarisikKurumlaraGore }
    public class GorusmeListelemeModuAraclari
    {
        public static GorusmeListelemeModu Parse(string yazi)
        {
            switch (yazi.ToLower().Trim())
            {
                case "":
                    return GorusmeListelemeModu.None;
                case "kurumagore":
                    return GorusmeListelemeModu.KurumaGore;
                case "kategoriyegore":
                    return GorusmeListelemeModu.KategoriyeGore;
                case "karisik":
                    return GorusmeListelemeModu.KarisikKurumlaraGore;
                case "karisikkurumlaragore":
                    return GorusmeListelemeModu.KarisikKurumlaraGore;
                default:
                    return GorusmeListelemeModu.None;
            }
        }
    }
}
