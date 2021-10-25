using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari.Extensions.InterviewExporter
{
    public class InterviewExporterUIExtension : IUIExtension
    {
        public Control[] CreateSettingsView()
        {
            return new Control[] { new UI.ExcelExporterOptions() };
        }

        public void PersistSettings(Control[] settingsView)
        {
            //UI.ExcelExporterOptions UIoptions = ((UI.ExcelExporterOptions)settingsView[0]);
        }
    }
}
