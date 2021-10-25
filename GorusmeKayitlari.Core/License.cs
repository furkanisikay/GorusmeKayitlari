using GorusmeKayitlari.Core.Extensions;
using System;
using System.Management;

namespace GorusmeKayitlari.Core
{

    public static class License
    {
        public static string Get(string license)
        {
            string durum = "";
            durum = Crypt.Sifre_Coz(license);
            durum = Crypt.Sifrele_(durum);
            durum = Crypt.TextSifrele(durum);
            durum = Crypt.Sifrele_(durum);
            return durum;
        }

        public static bool Check(string lisans)
        {
            bool durum_ = false;
            string license = lisans;
            license = Crypt.Sifre_Coz(license);
            license = Crypt.TextSifreCoz(license);
            license = Crypt.Sifre_Coz(license);
            durum_ = license.Trim() == (HWID() + CPUID().Trim()) ? true : false;
            return durum_;
        }

        static string CPUID()
        {
            try
            {
                string id = string.Empty;
                ManagementClass managClass = new ManagementClass("win32_processor");
                ManagementObjectCollection managCollec = managClass.GetInstances();

                foreach (ManagementObject managObj in managCollec)
                {
                    id = managObj.Properties["processorID"].Value.ToString();
                    break;
                }
                return id;
            }
            catch (Exception ex) { Logger.Log(ex); return string.Empty; }
        }

        static string HWID()
        {
            try
            {
                string id = string.Empty;
                var mbs = new ManagementObjectSearcher("Select ProcessorId From Win32_processor");
                ManagementObjectCollection mbsList = mbs.Get();
                foreach (ManagementObject mo in mbsList)
                {
                    id = mo["ProcessorId"].ToString();
                    break;
                }
                return id;
            }
            catch (Exception ex) { Logger.Log(ex); return string.Empty; }
        }
    }
}
