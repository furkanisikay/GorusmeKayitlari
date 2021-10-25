using System.Security.Cryptography;
using System.IO;
using System.Text;

namespace GorusmeKayitlari.Updater.Classes
{
    /// <summary>
    /// Oluşturulacak Şifreleme Türü.
    /// </summary>
    internal enum HasType { None, MD5, SHA1, SHA512 }
    /// <summary>
    /// Bu sınıf, dosyaların şifrelemek halini hesaplamak için kullanılır.
    /// </summary>
    internal static class Hasher
    {
        /// <summary>
        /// Bir dosyanın hash'ini hesapla.
        /// </summary>
        /// <param name="filePath">Hash'i belirlenecek dosya.</param>
        /// <param name="algo">Hash türü.</param>
        /// <returns>Hesaplanan hash.</returns>
        internal static string HashFile(string filePath, HasType algo)
        {
            switch (algo)
            {
                case HasType.None:
                    return string.Empty;
                case HasType.MD5:
                    return MakeHashString(MD5.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HasType.SHA1:
                    return MakeHashString(SHA1.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                case HasType.SHA512:
                    return MakeHashString(SHA512.Create().ComputeHash(new FileStream(filePath, FileMode.Open)));
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// byte[]'yi string'e dönüştürür.
        /// </summary>
        /// <param name="hash">dönüştürülecek hash</param>
        /// <returns>string türünde hash</returns>
        private static string MakeHashString(byte[] hash)
        {
            StringBuilder s = new StringBuilder(hash.Length * 2);
            foreach (byte b in hash)
            {
                s.Append(b.ToString("X2").ToLower());
            }
            return s.ToString();
        }
    }
}
