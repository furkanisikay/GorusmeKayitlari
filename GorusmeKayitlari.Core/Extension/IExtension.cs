using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core.Extension
{
    public interface IExtension
    {
        string Name { get; }
        IUIExtension UIExtension { get; }
    }
}
