using GorusmeKayitlari.Core.Extensions;
using System;
using GorusmeKayitlari.Core.DB.Objects;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GorusmeKayitlari.Core.DB
{
    public static class Tools
    {
        /// <summary>
        /// Görüşme Kayıtları projesinde kullanılacak bağlantılar için bağlantı yazısnın oluşturup döndürür.
        /// </summary>
        /// <param name="rkMain">Program.cs de bulunana ana regedit anahtar keyi.</param>
        /// <returns></returns>
        public static string BaglYazisiniGetir(Microsoft.Win32.RegistryKey rkMain)
        {
            try
            {
                System.Data.OleDb.OleDbConnectionStringBuilder builder = new System.Data.OleDb.OleDbConnectionStringBuilder()
                {
                    Provider = "Microsoft.ACE.OLEDB.12.0"
                };
                string databasefile = string.Format("{0}\\{1}", Regedit.Ayar_Oku("Database-Path", "", rkMain, false), Regedit.Ayar_Oku("Database-File-Name", "", rkMain, false));
                if (System.IO.File.Exists(databasefile))
                {
                    builder.DataSource = databasefile;
                    return builder.ToString();
                }
                else
                {
                    return "";
                }
            }
            catch (Exception ex)
            {
                Logger.Log(ex);
                return "";
            }
        }

        public static ulong YetkiHesapla<T>(List<T> nesneler) where T : struct, IConvertible
        {
            Type genericType = typeof(T);
            if (genericType.IsEnum)
            {
                if(nesneler.Count == 0) { return 0; }
                int toplamuzunluk = Enum.GetNames(genericType).Length;
                string yetkiyazisi = string.Empty.PadLeft(toplamuzunluk, '0');
                char[] karakterler = yetkiyazisi.ToCharArray();
                foreach (T nesne in nesneler)
                {
                    int yetkisirasi = Enum.GetValues(genericType).Cast<T>().ToList<T>().IndexOf(nesne);
                    karakterler[yetkisirasi] = '1';
                }
                yetkiyazisi = new string(karakterler);
                return NumberConverter.BinaryToDecimal(yetkiyazisi);
            }
            else { throw new ArgumentException("Generic Tür Enum Olmalı."); }
        }

        public static List<T> YetkiHesapla<T>(ulong yetkitoplamlari) where T : struct, IConvertible
        {
            Type genericType = typeof(T);
            if (genericType.IsEnum)
            {
                if (yetkitoplamlari == 0) { return new List<T>(); }
                int toplamuzunluk = Enum.GetNames(genericType).Length;
                List<T> yetkiler = new List<T>();
                string yetkiler_ = NumberConverter.DecimalToBinary(yetkitoplamlari);
                yetkiler_ = yetkiler_.PadLeft(toplamuzunluk, '0');
                List<char> yetkilistesi = new List<char>(yetkiler_.ToArray());
                for (int i = 0; i < yetkilistesi.Count; i++)
                {
                    if (Convert.ToBoolean(int.Parse((yetkilistesi[i]).ToString())))
                    {
                        yetkiler.Add((T)(Enum.ToObject(typeof(T), i)));
                        //yetkiler.Add((Yetkiler)i);
                    }
                }
                return yetkiler;
            }
            else
            {
                throw new ArgumentException("Generic Tür Enum Olmalı.");
            }
        }
    }
}
