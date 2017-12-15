using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    public static class Misc
    {
        public static void Swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        public static bool IsPrime(int n)
        {
            if (n <= 1)
                return false;
            else if (n <= 3)
                return true;
            else if (n % 2 == 0 || n % 3 == 0)
                return false;
            for(int i=5; i*i <= n; i+= 6)
            {
                if (n % i == 0 || n % (i + 2) == 0)
                    return true;
            }
            return false;
        }

    }
}
