using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.Components
{
    public class TarihFiltreleEventArgs : EventArgs
    {
        public TarihFiltreleEventArgs(DateTime BaslangicTarihi, DateTime BitisTarihi)
        {
            this.BaslangicTarihi = BaslangicTarihi;
            this.BitisTarihi = BitisTarihi;
        }
        public DateTime BaslangicTarihi { get; }
        public DateTime BitisTarihi { get; }
    }
}
