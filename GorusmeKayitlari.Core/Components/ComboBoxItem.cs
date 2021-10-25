using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.Components
{
    public class ComboboxItem
    {
        public string Yazi { get; set; }
        public object Deger { get; set; }

        public ComboboxItem(string Yazi, object Deger)
        {
            this.Yazi = Yazi;
            this.Deger = Deger;
        }

        public override string ToString()
        {
            return this.Yazi;
        }
    }
}
