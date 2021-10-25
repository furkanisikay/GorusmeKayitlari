using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Logger
{
    class LoggerUIExtension : IUIExtension
    {
        public Control[] CreateSettingsView()
        {
            return new Control[] { new UI.LoggerOptions() };
        }

        public void PersistSettings(Control[] settingsView)
        {
            UI.LoggerOptions UIoptions = ((UI.LoggerOptions)settingsView[0]);
            ((IExtensionUI)UIoptions).AyarlariKaydet();
        }
    }
}
