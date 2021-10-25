using System.Windows.Forms;

namespace GorusmeKayitlari.Core.MsgBox
{
    class MessageBoxResultTools
    {
        public static DialogResult MessageBoxResultToDialogResult(System.Windows.MessageBoxResult result)
        {
            switch (result)
            {
                case System.Windows.MessageBoxResult.None:
                    return DialogResult.None;
                case System.Windows.MessageBoxResult.OK:
                    return DialogResult.OK;
                case System.Windows.MessageBoxResult.Cancel:
                    return DialogResult.Cancel;
                case System.Windows.MessageBoxResult.Yes:
                    return DialogResult.Yes;
                case System.Windows.MessageBoxResult.No:
                    return DialogResult.No;
                default:
                    return DialogResult.None;
            }
        }
    }
}
