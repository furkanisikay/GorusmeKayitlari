using GorusmeKayitlari.Core.Extensions;
using Microsoft.Win32;
using System;
using System.Threading;

namespace GorusmeKayitlari.Core
{
    public static class Regedit
    {
        public static Microsoft.Win32.RegistryKey rkMain = null;

        public static void RegKaydet(string reg_adi, object deger, RegistryKey rkey, bool kaydetmeyi_bekle = false)
        {
            Thread thread = new Thread(() =>
            {
                try { rkey.SetValue(reg_adi, deger); }
                catch (Exception ex) { Logger.Log(ex); }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            thread.Start();
            if (kaydetmeyi_bekle)
            {
                thread.Join();
            }
        }
        public static void Ayar_Kaydet(string ayar_adi, string deger, RegistryKey rkey, bool kaydetmeyi_bekle = false, bool Sifreli = true)
        {
            string name = (Sifreli ? Crypt.Sifrele_(ayar_adi) : ayar_adi);
            string value = (Sifreli ? Crypt.Sifrele_(deger) : deger);
            RegKaydet(name, value, rkey, kaydetmeyi_bekle);
        }

        public static object RegOku(string reg_adi, object bulunmazsa, RegistryKey rkey)
        {
            object str1 = bulunmazsa;
            Thread thread = new Thread(() =>
            {
                try { str1 = rkey.GetValue(reg_adi, bulunmazsa).ToString(); }
                catch { str1 = bulunmazsa; }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            thread.Start();
            thread.Join();
            return str1;
        }
        public static string Ayar_Oku(string ayar_adi, string bulunmazsa, RegistryKey rkey, bool Sifreli = true)
        {
            string name = (Sifreli ? Crypt.Sifrele_(ayar_adi) : ayar_adi);
            string value = RegOku(ayar_adi, bulunmazsa, rkey).ToString();
            return  (Sifreli ? Crypt.Sifre_Coz(value) : value);
        }

        public static bool Ayar_Sil(string ayar_adi, RegistryKey rkey = null, bool Sifreli = true)
        {
            bool flag = false;
            Thread thread = new Thread(() =>
            {
                try
                {
                    rkey.DeleteValue((Sifreli ? Crypt.Sifrele_(ayar_adi) : ayar_adi));
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            thread.Start();
            thread.Join();
            return flag;
        }

        public static RegistryKey GetMainRegKey()
        {
            try
            {
                return Regedit.Hatasiz_key_getir(Microsoft.Win32.Registry.CurrentUser, @"SOFTWARE\NoviceHacker\GorusmeKayitlari");
            }
            catch (System.Exception ex)
            {
                Extensions.Logger.Log(ex);
                return null;
            }
        }

        #region ### hatasiz key getirme fonksiyonu ###
        public static RegistryKey Hatasiz_key_getir(RegistryKey anakey, string yol)
        {
            RegistryKey registryKey2 = null;
            Thread thread = new Thread(() =>
            {
                RegistryKey registryKey = anakey;
                RegistryKey registryKey1 = anakey;
                string str = yol;
                while (str != "")
                {
                    try
                    {
                        registryKey = registryKey.OpenSubKey(Regedit.ilk_dizin_getir(str), true) ?? registryKey1.CreateSubKey(Regedit.ilk_dizin_getir(str), RegistryKeyPermissionCheck.ReadWriteSubTree);
                        registryKey1 = registryKey;
                        str = Regedit.yeni_dizin_Getir(str);
                    }
                    catch
                    {
                        registryKey = registryKey1.CreateSubKey(Regedit.ilk_dizin_getir(str), RegistryKeyPermissionCheck.ReadWriteSubTree);
                        registryKey1 = registryKey;
                        str = Regedit.yeni_dizin_Getir(str);
                    }
                }
                registryKey2 = registryKey;
            })
            {
                IsBackground = true,
                Priority = ThreadPriority.Highest
            };
            thread.Start();
            thread.Join();
            return registryKey2;
        }

        private static string ilk_dizin_getir(string fulldizin)
        {
            string str;
            if (string.IsNullOrEmpty(fulldizin))
            {
                str = "";
            }
            else
            {
                str = (!fulldizin.Contains("\\") ? fulldizin : fulldizin.Substring(0, fulldizin.IndexOf("\\")));
            }
            return str;
        }

        private static string yeni_dizin_Getir(string fulldizin)
        {
            string str = fulldizin;
            if (!string.IsNullOrEmpty(fulldizin))
            {
                if (!str.Contains("\\"))
                {
                    string str1 = Regedit.ilk_dizin_getir(str);
                    str = (fulldizin == str1 ? "" : str.Substring(str1.Length));
                }
                else
                {
                    str = str.Substring(Regedit.ilk_dizin_getir(str).Length + 1);
                }
            }
            return str;
        }
        #endregion
    }
}
