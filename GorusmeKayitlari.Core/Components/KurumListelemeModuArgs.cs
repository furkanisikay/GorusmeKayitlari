using GorusmeKayitlari.Core.DB.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.Components
{
    public class KurumListelemeModuArgs
    {
        public KurumListelemeModuArgs(KurumListelemeModu Mod, bool altKategorilerDahil, List<Kategori> SecilenKategoriler)
        {
            this.Mod = Mod;
            this.altKategorilerDahil = altKategorilerDahil;
            this.SecilenKategoriler = SecilenKategoriler;
        }
        public KurumListelemeModu Mod { get; }
        public List<Kategori> SecilenKategoriler { get; }
        public bool altKategorilerDahil { get; }
    }
}
