using System.Windows.Forms;

namespace GorusmeKayitlari.Core.Extension
{
    public interface IUIExtension
    {
        Control[] CreateSettingsView();
        void PersistSettings(Control[] settingsView);
    }
}
