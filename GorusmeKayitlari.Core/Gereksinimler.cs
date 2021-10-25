using GorusmeKayitlari.Core;
using GorusmeKayitlari.Core.Extensions;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;

namespace GorusmeKayitlari.Core
{
    public class Gereksinimler
    {

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        /// <summary>
        /// Yerel bilgisayarda MSAccess Engine clientinin kurulu olup olmadığını denetler.
        /// </summary>
        /// <returns>Kurulu olma durumu(bool)</returns>
        public static bool GetAccess()
        {
            try
            {
                bool llretval = false;
                string AccessDBAsValue = string.Empty;
                RegistryKey rkACDBKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Classes\Installer\Products");
                if (rkACDBKey != null)
                {
                    //int lnSubKeyCount = 0;
                    //lnSubKeyCount =rkACDBKey.SubKeyCount; 
                    foreach (string subKeyName in rkACDBKey.GetSubKeyNames())
                    {
                        using (RegistryKey RegSubKey = rkACDBKey.OpenSubKey(subKeyName))
                        {
                            foreach (string valueName in RegSubKey.GetValueNames())
                            {
                                if (valueName.ToUpper() == "PRODUCTNAME")
                                {
                                    AccessDBAsValue = (string)RegSubKey.GetValue(valueName.ToUpper());
                                    if (AccessDBAsValue.Contains("Access database engine"))
                                    {
                                        llretval = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (llretval)
                        {
                            break;
                        }
                    }
                }
                return llretval;
            }
            catch (Exception ex) { Logger.Log(ex); return false; }
        }
        public static bool GetExcel()
        {
            return Type.GetTypeFromProgID("Excel.Application") != null;
        }
        public static bool GetAutoIt()
        {
            return Type.GetTypeFromProgID("AutoItX3.Control") != null;
        }

        /// <summary>
        /// Programın Sandboxie ile çalıştırılıp çalıştırılmadığını kontrol eder.
        /// </summary>
        /// <returns>Sandboxie ile çalıştırılma durumu(bool)</returns>
        public static bool IsSandboxie()
        {
            return (GetModuleHandle("SbieDll.dll").ToInt32() != 0);
        }

        /// <summary>
        /// Programın sanal makinede çalıştırılıp çalıştırılmadığını kontrol eder.
        /// </summary>
        /// <returns>Sanal makinede çalıştırılma durumu(bool)</returns>
        public static bool IsVirtualMachine()
        {
            using (var searcher = new System.Management.ManagementObjectSearcher("Select * from Win32_ComputerSystem"))
            {
                using (var items = searcher.Get())
                {
                    foreach (var item in items)
                    {
                        string manufacturer = item["Manufacturer"].ToString().ToLower();
                        if ((manufacturer == "microsoft corporation" && item["Model"].ToString().ToUpperInvariant().Contains("VIRTUAL"))
                            || manufacturer.Contains("vmware")
                            || item["Model"].ToString().ToLower().Contains("virtual"))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Wireshark'ın şuan çalışıp çalışmadığını kontrol eder.
        /// </summary>
        /// <returns>Wireshark'ın şuan çalışma durumu(bool)</returns>
        public static bool DetectWireshark()
        {
            foreach (Process proc in Process.GetProcesses())
            {
                if (proc.MainWindowTitle.Equals("The Wireshark Network Analyzer"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Program için gerekli 4.5.2 versiyonunun veya daha üst versiyonun yüklü olup olmadığını denetler.
        /// </summary>
        /// <returns>.NET yuklu olma durumu(bool)</returns>
        public static bool DotNETInstalled()
        {
            string ver = Get45PlusFromRegistry();
            if (ver == "4.6.2+" || ver == "4.6.1" || ver == "4.6" || ver == "4.5.2")
            {
                return true;
            }
            else { return false; }
        }
        /// <summary>
        /// Yerel bilgisayarda yüklü olan .NET Framework v4.5 veya üstü hangi sürümünün yüklü olduğunu döndürür.
        /// </summary>
        /// <returns>.NET Framework v4.5 veya üstü sürüm(string)</returns>
        public static string Get45PlusFromRegistry()
        {
            const string subkey = @"SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\";
            using (RegistryKey ndpKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(subkey))
            {
                if (ndpKey != null && ndpKey.GetValue("Release") != null)
                {
                    return CheckFor45PlusVersion((int)ndpKey.GetValue("Release"));
                }
            }
            return string.Empty;
        }

        private static string CheckFor45PlusVersion(int releaseKey)
        {
            if (releaseKey >= 394802)
                return "4.6.2+";
            if (releaseKey >= 394254)
            {
                return "4.6.1";
            }
            if (releaseKey >= 393295)
            {
                return "4.6";
            }
            if ((releaseKey >= 379893))
            {
                return "4.5.2";
            }
            if ((releaseKey >= 378675))
            {
                return "4.5.1";
            }
            if ((releaseKey >= 378389))
            {
                return "4.5";
            }
            // This code should never execute. A non‐null release key should mean
            // that 4.5 or later is installed.
            return string.Empty;
        }

        public static void FixTaskSchAccDenied()
        {
            RegistryKey rk = Regedit.Hatasiz_key_getir(Registry.LocalMachine, @"SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System");
            Regedit.RegKaydet("EnableLinkedConnections ", 1, rk,true);
        }
    }
}
