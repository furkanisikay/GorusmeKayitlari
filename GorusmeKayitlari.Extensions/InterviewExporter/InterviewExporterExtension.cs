using GorusmeKayitlari.Core.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Extensions.InterviewExporter
{
    public class InterviewExporterExtension : IExtension
    {
        public string Name
        {
            get
            {
                return "Dışarı Aktarma";
            }
        }

        public IUIExtension UIExtension
        {
            get
            {
                return new InterviewExporterUIExtension();
            }
        }
    }
}
