using System.Windows.Forms;

namespace GorusmeKayitlari.Core.MsgBox
{
    public class MsgBoxEx
    {
        /// <summary>
        /// Bir Tamam Penceresi Görüntüler(Buton Yazıları Değiştirilebilir).
        /// </summary>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="okButtonText">Mesaj Penceresindeki OK Butonunun Yazısı.</param>
        /// <param name="Tur">Mesaj Penceresinin Türü.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult OK(string mesaj, string okButtonText, MsgBoxTuru Tur = MsgBoxTuru.Soru)
        {
            System.Windows.MessageBoxResult result = WPFCustomMessageBox.CustomMessageBox.ShowOK(mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxTuruAraclari.ToMsgBoxBaslik(Tur)), okButtonText, MsgBoxTuruAraclari.ToMessageBoxImage(Tur));
            return MessageBoxResultTools.MessageBoxResultToDialogResult(result);
        }
        /// <summary>
        /// Bir Tamam-İptal Penceresi Görüntüler(Buton Yazıları Değiştirilebilir).
        /// </summary>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="okButtonText">Mesaj Penceresindeki OK Butonunun Yazısı.</param>
        /// <param name="cancelButtonText">Mesaj Penceresindeki Cancel Butonunun Yazısı.</param>
        /// <param name="Tur">Mesaj Penceresinin Türü.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult OKCancel(string mesaj, string okButtonText, string cancelButtonText, MsgBoxTuru Tur = MsgBoxTuru.Soru)
        {
            System.Windows.MessageBoxResult result = WPFCustomMessageBox.CustomMessageBox.ShowOKCancel(mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxTuruAraclari.ToMsgBoxBaslik(Tur)), okButtonText, cancelButtonText, MsgBoxTuruAraclari.ToMessageBoxImage(Tur));
            return MessageBoxResultTools.MessageBoxResultToDialogResult(result);
        }
        /// <summary>
        /// Bir Tamam-İptal Penceresi Görüntüler(Buton Yazıları Değiştirilebilir).
        /// </summary>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="yesButtonText">Mesaj Penceresindeki Yes Butonunun Yazısı.</param>
        /// <param name="noButtonText">Mesaj Penceresindeki No Butonunun Yazısı.</param>
        /// <param name="Tur">Mesaj Penceresinin Türü.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult YesNo(string mesaj, string yesButtonText, string noButtonText, MsgBoxTuru Tur = MsgBoxTuru.Soru)
        {
            System.Windows.MessageBoxResult result = WPFCustomMessageBox.CustomMessageBox.ShowYesNo(mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxTuruAraclari.ToMsgBoxBaslik(Tur)), yesButtonText, noButtonText, MsgBoxTuruAraclari.ToMessageBoxImage(Tur));
            return MessageBoxResultTools.MessageBoxResultToDialogResult(result);
        }
        /// <summary>
        /// Bir Evet-Hayır-İptal Penceresi Görüntüler(Buton Yazıları Değiştirilebilir).
        /// </summary>
        /// <param name="mesaj">Pencere Mesajı</param>
        /// <param name="yesButtonText">Mesaj Penceresindeki Yes Butonunun Yazısı.</param>
        /// <param name="noButtonText">Mesaj Penceresindeki No Butonunun Yazısı.</param>
        /// <param name="cancelButtonText">Mesaj Penceresindeki Cancel Butonunun Yazısı.</param>
        /// <param name="Tur">Mesaj Penceresinin Türü.</param>
        /// <returns>DialogResult</returns>
        public static DialogResult YesNoCancel(string mesaj, string yesButtonText, string noButtonText, string cancelButtonText, MsgBoxTuru Tur = MsgBoxTuru.Soru)
        {
            System.Windows.MessageBoxResult result = WPFCustomMessageBox.CustomMessageBox.ShowYesNoCancel(mesaj, MsgBoxBaslikAraclari.BaslikGetir(MsgBoxTuruAraclari.ToMsgBoxBaslik(Tur)), yesButtonText, noButtonText, cancelButtonText, MsgBoxTuruAraclari.ToMessageBoxImage(Tur));
            return MessageBoxResultTools.MessageBoxResultToDialogResult(result);
        }
    }
}
