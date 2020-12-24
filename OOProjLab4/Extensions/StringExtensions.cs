using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extensions
{
    public static class StringExtensions
    {
        public static String Peglaj(this String s)
        {
            if (s == "")
                return "";
            char[] charArray = s.ToCharArray();
            charArray[0] = Char.ToUpper(charArray[0]);
            for (int i = 1; i < charArray.Length; i++)
                charArray[i] = char.ToLower(charArray[i]);
            String str = new String(charArray);
            return str;
        }
    }
}
