using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using GorusmeKayitlari.Core.Extensions;

namespace GorusmeKayitlari.Core
{
    public static class Crypt
    {
        //bit power : 3176 
        private const string pass = "cK4^BCgTea!/JKh1mOIbRK$OKTvMW!/|4P3vfD6wp&5hkxuAxaRXD6gF08fw$EXEd-&-GCDT#U*ljyzpEwDhKVIgCVbv1OAuXAZ1@K%9hvC&wd0RQ/WlMcxMGfmdI0B$mZZ0e9N4@/QRRCTfNAw7hOG_abWgHyle%MAElm|0VoYeBZ50FP/NC5C$^cisMGNhKoKnZMfgxZ_vJ2X8m*5$efXnDfnzrEk8#WiB5D9RpeZeN0XBwsZ5gcmUxAhjJaJwoDKqgVehtUD!0reoQ8YhSne2*WFZqC/geKjS@La31LVcXDXRQ6seP!AEfNf5CORWaVc!qE%X29zSrZkLh*ic-Gbuv1v8%ENEV|FygjQ6tve&968!F6A-t$-nkaLSMuAbAfW_/VXEOY-Sjuuf$WJ_kSF&TXP2U4QTDsZIFiKrXrOkxXUdnQDVR^CA9KM5FFV6dSRfEBY$ZgE/^FdN6CCUia!fspp#x%WCaw9eFPL^bvU7xWW@kdGLAh$@J7L&L1uV";


        private static byte[] SifreCoz(byte[] SifreliVeri, byte[] Key, byte[] IV)
        {
            MemoryStream memoryStream = new MemoryStream();
            Rijndael key = Rijndael.Create();
            key.Key = Key;
            key.IV = IV;
            CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateDecryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(SifreliVeri, 0, (int)SifreliVeri.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }

        private static byte[] Sifrele(byte[] SifresizVeri, byte[] Key, byte[] IV)
        {
            MemoryStream memoryStream = new MemoryStream();
            Rijndael key = Rijndael.Create();
            key.Key = Key;
            key.IV = IV;
            CryptoStream cryptoStream = new CryptoStream(memoryStream, key.CreateEncryptor(), CryptoStreamMode.Write);
            cryptoStream.Write(SifresizVeri, 0, (int)SifresizVeri.Length);
            cryptoStream.Close();
            return memoryStream.ToArray();
        }

        public static string TextSifreCoz(string text)
        {
            byte[] numArray = Convert.FromBase64String(text);
            PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(pass, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
            byte[] numArray1 = Crypt.SifreCoz(numArray, passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
            return Encoding.Unicode.GetString(numArray1);
        }

        public static string TextSifrele(string sifrelenecekMetin)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(sifrelenecekMetin);
            PasswordDeriveBytes passwordDeriveByte = new PasswordDeriveBytes(pass, new byte[] { 73, 118, 97, 110, 32, 77, 101, 100, 118, 101, 100, 101, 118 });
            byte[] numArray = Crypt.Sifrele(bytes, passwordDeriveByte.GetBytes(32), passwordDeriveByte.GetBytes(16));
            return Convert.ToBase64String(numArray);
        }

        public static string Sifre_Coz(string sifreli_yazi)
        {
            string str;
            try
            {
                byte[] numArray = Convert.FromBase64String(sifreli_yazi);
                str = Encoding.UTF8.GetString(numArray);
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                str = sifreli_yazi;
            }
            return str;
        }

        public static string Sifrele_(string yazi)
        {
            try { return Convert.ToBase64String(Encoding.UTF8.GetBytes(yazi)); }
            catch { return yazi; }
        }
    }
}
