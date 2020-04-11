/****************************************************************
 * Project: coding-interviews
 * File: Permutation.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: Permutation algorithm.
****************************************************************/

using System;
using System.Collections.Generic;

// 字符串 动态规划 递归 字符串的排列
namespace Permutation
{
    class Solution
    {
        public List<string> Permutation(string str)
        {
            // write code here
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            List<string> list = new List<string>();
            Permutation(chars, 0, list);
            return list;
        }

        private void Permutation(char[] chars, int pos, List<string> list)
        {
            if (pos > chars.Length - 1) return;
            if(pos == chars.Length - 1)
            {
                list.Add(new string(chars));
            }
            else
            {
                char c = chars[pos];
                Permutation(chars, pos + 1, list);
                for (int i = pos + 1; i < chars.Length; i++)
                {
                    if (chars[i] == c) continue;
                    chars[pos] = chars[i];
                    chars[i] = c;
                    c = chars[pos];
                    Permutation(chars, pos + 1, list);
                }
                for(int i = pos; i < chars.Length - 1; i++)
                {
                    chars[i] = chars[i + 1];
                }
                chars[chars.Length - 1] = c;
            }
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            int strLenMax = 9;
            for(int i = 0; i < 10; i++)
            {
                int strLen = rnd.Next(strLenMax + 1);
                char[] chars = new char[strLen];
                for(int j = 0; j < strLen; j++)
                {
                    char a;
                    if (rnd.Next(100) < 50)
                    {
                        a = 'a';
                    }
                    else
                    {
                        a = 'A';
                    }
                    chars[j] = (char)(a + rnd.Next(26));
                }
                if(Check(s, chars))
                {
                    Console.WriteLine("Pass");
                }
                else
                {
                    Console.WriteLine("Fail");
                    return false;
                }
            }
            return true;
        }

        private int Factorial(int n)
        {
            if (n <= 0) return 0;
            int ret = 1;
            for(int i = 2; i <= n; i++)
            {
                ret *= i;
            }
            return ret;
        }

        private bool Check(Solution s, char[] chars)
        {
            string str = new string(chars);
            Console.Write("Check {0}: ", str);
            List<string> list = s.Permutation(str);
            Array.Sort(chars);
            int sameLen = 1;
            char c = ' ';
            int strLen = chars.Length;
            int cntMax = Factorial(strLen);
            int cnt = cntMax;
            for (int j = 0; j < strLen; j++)
            {
                if (chars[j] == c)
                {
                    sameLen++;
                }
                else
                {
                    cnt /= Factorial(sameLen);
                    c = chars[j];
                    sameLen = 1;
                }
            }
            cnt /= Factorial(sameLen);
            if (cnt != list.Count) return false;
            string sortedStr = new string(chars);
            foreach(string result in list)
            {
                char[] cs = result.ToCharArray();
                Array.Sort(cs);
                if (!sortedStr.Equals(new string(cs))) return false;
            }
            for(int i = 1; i < cnt; i++)
            {
                if (string.CompareOrdinal(list[i], list[i - 1]) <= 0) return false;
            }
            return true;
        }
    }
}