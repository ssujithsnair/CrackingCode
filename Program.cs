using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrackingCode.TopologicalSort;
namespace CrackingCode
{
    struct TestS
    {
        public int i;
        public int j;
        public TestS(int a, int b)
        {
            j = 0;
            i = 1;
        }

    }
    class Program 
    {
        static void Main(string[] args)
        {
            TestS t;
            Mystring.Test();
            //Mystring.permutation("abcd");
            //var unique = Mystring.IsStringUnique("ASDFdpqrsujk");
            int[] arr = new[] { 5, 3, 1, 2, 3 };
            //int[] arr = new[] { 9,1,0,4,8,7};
            //Sort.SortPeakValley(arr);
            //Graph.Test();
            //BMTest.Test1();
            //TopologicalSort.TopologicalSort.Test();
        }
    }
}
