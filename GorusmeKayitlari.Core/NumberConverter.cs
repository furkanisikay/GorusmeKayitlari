using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorusmeKayitlari.Core
{
    public class NumberConverter
    {
        public static ulong BinaryToDecimal(string binarytext)
        {
            //10010000
            List<char> karakterler = new List<char>(binarytext.ToArray());
            ulong toplamsayi = 0;
            for (int i = 0, j = karakterler.Count -1; i < karakterler.Count; i++, j--)
            {
                toplamsayi += Convert.ToUInt64(int.Parse((karakterler[i]).ToString()) * Convert.ToInt32(Math.Pow(2, j)));
            }
            return toplamsayi;
        }
        public static string DecimalToBinary(ulong decimalnumber)
        {
            //288
            ulong tmpnumber = decimalnumber;
            string binarystring = string.Empty;
            while (tmpnumber > 0)
            {
                binarystring += tmpnumber % 2;
                tmpnumber /= 2;
            }
            char[] charArray = binarystring.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}
