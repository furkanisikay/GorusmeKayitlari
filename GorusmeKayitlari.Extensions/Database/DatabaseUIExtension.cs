using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.Database
{
    class DatabaseUIExtension : IUIExtension
    {
        public Control[] CreateSettingsView()
        {
            return new Control[] { new UI.DBOptions() };
        }

        public void PersistSettings(Control[] settingsView)
        {
            //UI.DBOptions UIoptions = settingsView[0] as UI.DBOptions;
            IExtensionUI dbOpt = settingsView[0] as IExtensionUI;
            dbOpt.AyarlariKaydet();
        }
    }
}
