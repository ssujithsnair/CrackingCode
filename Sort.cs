using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingCode
{
    public static class Sort
    {
        public static void SortPeakValley(int[] arr)
        {
            Array.Sort(arr);
            Array.Reverse(arr);
            for (int i = 1; i < arr.Length; i += 2)
                Misc.Swap(arr, i - 1, i);
        }
    }
}
