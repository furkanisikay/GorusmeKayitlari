using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.DB.Objects
{
    public class YukleniyorkenArgs
    {
        public YukleniyorkenArgs()
        {

        }
        private bool cancel = false;

        public bool Cancel { get => cancel; set => cancel = value; }
        public object Data { get; set; }

    }
}
