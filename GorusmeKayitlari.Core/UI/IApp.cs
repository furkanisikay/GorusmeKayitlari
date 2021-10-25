using GorusmeKayitlari.Core.Extension;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GorusmeKayitlari.Core.UI
{
    public interface IApp : IDisposable
    {
        Form MainForm { get; }

        NotifyIcon NotifyIcon { get; }

        List<IExtension> Extensions { get; }

        IExtension GetExtensionByType(Type type);

        void Start(object[] args);
    }
}
