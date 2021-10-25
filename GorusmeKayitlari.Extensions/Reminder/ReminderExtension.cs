using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GorusmeKayitlari.Core.Extension;

namespace GorusmeKayitlari.Extensions.Reminder
{
    public class ReminderExtension : IExtension, IInitializable
    {
        #region IExtension Members
        public string Name
        {
            get
            {
                return "Hatırlatıcı";
            }
        }

        public IUIExtension UIExtension
        {
            get
            {
                return new ReminderUIExtension();
            }
        }
        #endregion

        #region IInitializable Members

        public HatirlatmaTask hTask { get; private set; }
        public void Init()
        {
            hTask = new HatirlatmaTask();
            hTask.TaskleriYenidenYukle(true);
        }
        #endregion

    }
}
