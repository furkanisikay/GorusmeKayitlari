using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.UI
{
    public class AppManager
    {
        private AppManager()
        {
        }

        private static AppManager instance = new AppManager();

        public static AppManager Instance
        {
            get { return instance; }
        }

        private IApp application;

        public IApp Application
        {
            get { return application; }
        }

        public void Initialize(IApp app)
        {
            this.application = app;
        }
    }
}
