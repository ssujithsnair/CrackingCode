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

        private static void Permute(char[] carr, int l)
        {
            if (l == carr.Length)
                Console.WriteLine(carr);

            for (int i = l; i < carr.Length; i++)
            {
                Swap(carr, l, i);
                Permute(carr, l + 1);
                Swap(carr, l, i);
            }
        }

        private static void Swap(char[] carr, int i, int j)
        {
            char c = carr[i];
            carr[i] = carr[j];
            carr[j] = c;
        }

        public static void permute(string str)
        {
            //permutation(str, "");
            Permute(str.ToCharArray(), 0);
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

        private static void PaliandromicPermutation()
        {
            //https://leetcode.com/articles/palindrome-permutation-ii/
            // Find if it can be paliandrome - Odd count <=1.
            // Find the odd character
            // Get an array with half the characters - each character is repeated half the total count (from dictionary)
            // When l=length (above), do str + odd character + str.reverse
            // avoid duplicate by check (s[1] != s[l] || i==l) before permutate
        }

        private static void Reverse(char[] str, int start, int end)
        {
            while (start < end)
            {
                char temp = str[start];
                str[start++] = str[end];
                str[end--] = temp;
            }
        }

        private static void ReverseWords(string s)
        {
            char[] arr = s.ToCharArray();
            int start = 0;
            int i=0;
            for (; i < s.Length; i++)
            {
                if (arr[i] == ' ')
                {
                    Reverse(arr, start, i-1);
                    start = i + 1;
                }
            }
            Reverse(arr, start, i - 1);
            Console.Write("After reverse each word  ");
            Console.WriteLine(arr);

            Reverse(arr, 0, s.Length - 1);
            Console.Write("After reversing above  ");
            Console.WriteLine(arr);
        }
        private static int count = 0;
        private static int FindSubSequenceLength(string text, string pattern)
        {
            var i = 0;
            foreach (var s in text)
            {
                count++;
                if (s == pattern[i] && ++i == pattern.Length)
                    break;
            }
            return i;
        }
        private static string FindLongestSubsequence(string[] values, string pattern)
        {
            string result = null;
            int max = 0;
            foreach (var val in values)
            {
                int len = FindSubSequenceLength(pattern, val);
                if (len > max)
                {
                    max = len;
                    result = val;
                }
            }
            Console.WriteLine("Word = {0}, Total runtime = {1}", result ?? string.Empty, count);
            return result;
        }
        
        private static string FindLongestSubsequence1(string[] values, string pattern)
        {
            StringBuilder result = new StringBuilder();
            int i = 0;
            for(; i < values.Length-1; i++)
            {
                result.Append(values[i]);
                result.Append(' ');
            }
            result.Append(values[i]);
            int maxstart=0, maxend=0, max=0, start=-1;
            i = 0; int index = 0;
            while (i < result.Length)
            {
                if (result[i]  == ' ')
                {
                    if ((i - start) > max)
                    {
                        max = i - start;
                        maxstart = start;
                        maxend = i;
                        start = -1;
                        index = 0;
                    }
                    i++;
                    continue;
                }
                if (result[i] == pattern[index])
                {
                    if (start == -1)
                        start = i;
                    index++;
                }
                i++;
                if (index == pattern.Length)
                {
                    while (i < result.Length && result[i] != ' ')
                        i++;
                }
            }
            return result.ToString();
        }
        private static void stringSplosion(string str)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < str.Length; i++)
            {
                result.Append(str.Substring(0, i + 1));
            }
            Console.WriteLine(result);
        }

        private static void Decode()
        {
            /*
             *  Input : str[] = "1[b]" Output : b
                Input : str[] = "2[ab]" Output : abab
                Input : str[] = "2[a2[b]]" Output : abbabb
                Input : str[] = "3[b2[ca]]" Output : bcacabcacabcaca
             */
            string s = "3[b2[ca]]";
            Stack<int> iStack = new Stack<int>();
            Stack<char> cStack = new Stack<char>();
            for(int i=0; i<s.Length;i++)
            {
                int count = 0;
                if (char.IsDigit(s[i]))
                {
                    while (char.IsDigit(s[i]))
                    {
                        count = count * 10 + s[i] - '0';
                        i++;
                    }
                    i--;
                    iStack.Push(count);
                }
                else if (s[i] == ']')
                {
                    string temp = "";
                    while (cStack.Count >0 && cStack.Peek() != '[')
                    {
                        temp = cStack.Pop() + temp;
                    }
                    if (cStack.Count > 0 && cStack.Peek() == '[')
                        cStack.Pop();

                    count = iStack.Pop();
                    temp = string.Concat(Enumerable.Repeat(temp, count));
                    foreach (char c in temp)
                        cStack.Push(c);
                }
                else if (s[i] == '[')
                {
                    if (i == 0 || !char.IsDigit(s[i - 1]))
                        iStack.Push(1);
                    cStack.Push(s[i]);
                }
                else
                    cStack.Push(s[i]);
            }
            string result = "";
            while (cStack.Count > 0)
            {
                result = cStack.Pop() + result;
            }
            Console.WriteLine(result);
        }
        public static void Test()
        {
            //Decode();
            //stringSplosion("Code");
            //FindLongestSubsequence(new string[] { "able", "ale", "apple", "bale", "kangaroo" }, "abppplee"); 
            FindLongestSubsequence1(new string[] { "able", "ale", "apple", "bale", "kangaroo" }, "abppplee");
            //ReverseWords("geeks quiz practice code");
        }
        //https://www.geeksforgeeks.org/decode-string-recursively-encoded-count-followed-substring/
    }
}
