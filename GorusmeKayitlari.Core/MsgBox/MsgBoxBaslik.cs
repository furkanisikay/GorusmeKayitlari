namespace GorusmeKayitlari.Core.MsgBox
{
    public enum MsgBoxBaslik { None, Hata, Dikkat, Soru, Bilgi }
    public class MsgBoxBaslikAraclari
    {
        public static string BaslikGetir(MsgBoxBaslik baslik)
        {
            switch (baslik)
            {
                case MsgBoxBaslik.Hata:
                    return "Hata";
                case MsgBoxBaslik.Dikkat:
                    return "Dikkat";
                case MsgBoxBaslik.Soru:
                    return "Soru";
                case MsgBoxBaslik.Bilgi:
                    return "Bilgi";
                default:
                    return "";
            }
        }
    }
}
