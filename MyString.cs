using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    static class Mystring
    {
        public static bool IsStringUnique(string str)
        {
            // commented code is using bit check - assuming only lower case letters a-z is used
            //int checker = 0;
            if (str.Length > 128) 
                return false;
            bool[] hashMap = new bool[128];
            foreach (var c in str)
            {
                //int val = c - 'a';
                //if ((checker & (1 << val)) > 0)
                //    return false;
                //checker |= 1 << val;
                if (hashMap[c])
                    return false;
                hashMap[c] = true;
            }
            return true;
        }

        public static void permutation(string str)
        {
            permutation(str, "");
        }

        private static void permutation(string str, string prefix)
        {
            if (str.Length == 0)
            {
                Console.WriteLine(prefix);
            }
            else
            {
                for (int i = 0; i < str.Length; i++)
                {
                    string rem = str.Substring(0, i) + str.Substring(i + 1);
                    permutation(rem, prefix + str[i]);
                }
            }
        }        
    }
}
