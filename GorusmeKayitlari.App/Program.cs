using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extensions;
using GorusmeKayitlari.Extensions.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GorusmeKayitlari
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            App.App.Instance.Start(args);
        }

        static void DetectSnippet()
        {
            Msg(Gereksinimler.DotNETInstalled(), ".NET Framework", "kurulu");
            Msg(Gereksinimler.DotNETInstalled(), ".NET Framework", Gereksinimler.Get45PlusFromRegistry());
            Msg(Gereksinimler.GetAutoIt(), "AutoIt", "kurulu");
            Msg(Gereksinimler.GetExcel(), "MSExcel", "kurulu");
            Msg(Gereksinimler.GetAccess(), "MSAccess Engine", "kurulu");
            Msg(Gereksinimler.IsSandboxie(), "Sandboxie", "aktif");
            Msg(Gereksinimler.IsVirtualMachine(), "Virtual Machine", "aktif");
        }

        static void Msg(bool sonuc, string ad, string durum)
        {
            MessageBox.Show(ad + " " + (sonuc ? durum : durum + " değil."), "NoviceHacker®", MessageBoxButtons.OK, (sonuc ? MessageBoxIcon.Information : MessageBoxIcon.Error));
        }
    }
}
