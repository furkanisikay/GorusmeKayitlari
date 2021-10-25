using System.Windows;
using System.Windows.Forms;

namespace GorusmeKayitlari.Core.MsgBox
{
    public enum MsgBoxTuru { None, Hata, Dikkat, Soru, Bilgi };
    public static class MsgBoxTuruAraclari
    {
        public static MessageBoxIcon ToMessageBoxIcon(MsgBoxTuru Tur)
        {
            switch (Tur)
            {
                case MsgBoxTuru.None:
                    return MessageBoxIcon.None;
                case MsgBoxTuru.Hata:
                    return MessageBoxIcon.Error;
                case MsgBoxTuru.Dikkat:
                    return MessageBoxIcon.Warning;
                case MsgBoxTuru.Soru:
                    return MessageBoxIcon.Question;
                case MsgBoxTuru.Bilgi:
                    return MessageBoxIcon.Information;
                default:
                    return MessageBoxIcon.None;
            }
        }
        public static MessageBoxImage ToMessageBoxImage(MsgBoxTuru Tur)
        {
            switch (Tur)
            {
                case MsgBoxTuru.None:
                    return MessageBoxImage.None;
                case MsgBoxTuru.Hata:
                    return MessageBoxImage.Error;
                case MsgBoxTuru.Dikkat:
                    return MessageBoxImage.Warning;
                case MsgBoxTuru.Soru:
                    return MessageBoxImage.Question;
                case MsgBoxTuru.Bilgi:
                    return MessageBoxImage.Information;
                default:
                    return MessageBoxImage.None;
            }
        }
        public static MsgBoxBaslik ToMsgBoxBaslik(MsgBoxTuru Tur)
        {
            switch (Tur)
            {
                case MsgBoxTuru.None:
                    return MsgBoxBaslik.None;
                case MsgBoxTuru.Hata:
                    return MsgBoxBaslik.Hata;
                case MsgBoxTuru.Dikkat:
                    return MsgBoxBaslik.Dikkat;
                case MsgBoxTuru.Soru:
                    return MsgBoxBaslik.Soru;
                case MsgBoxTuru.Bilgi:
                    return MsgBoxBaslik.Bilgi;
                default:
                    return MsgBoxBaslik.None;
            }
        }
    }
}
