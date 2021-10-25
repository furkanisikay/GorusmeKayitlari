using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Reminder
{
    public class ReminderUIExtension : IUIExtension
    {
        public Control[] CreateSettingsView()
        {
            return new Control[] { new UI.AutoCloseOptions() , new UI.NotifySoundOpt()};
        }

        public void PersistSettings(Control[] settingsView)
        {
            foreach (IExtensionUI uI in settingsView)
            {
                if(uI != null) { uI.AyarlariKaydet(); }
            }
           }
    }
}
