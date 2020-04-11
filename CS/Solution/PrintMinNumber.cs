/****************************************************************
 * Project: coding-interviews
 * File: PrintMinNumber.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: PrintMinNumber algorithm.
****************************************************************/

using System;
using System.Collections.Generic;
using System.Text;

// 数组 把数组排成最小的数
namespace PrintMinNumber
{
    class Solution
    {
        public string PrintMinNumber(int[] numbers)
        {
            // write code here
            if (numbers == null || numbers.Length <= 0) return null;
            int[][] digitsArray = new int[numbers.Length][];
            for(int i = 0; i < numbers.Length; i++)
            {
                int[] digits = ToDigits(numbers[i]);
                if (digits == null) return null;
                digitsArray[i] = digits;
            }
            StringBuilder sb = new StringBuilder();
            for(int len = digitsArray.Length; len > 0; len--)
            {
                int min = 0;
                for(int i = 1; i < len; i++)
                {
                    min = Compare(digitsArray, min, i);
                }
                sb.Append(numbers[min]);
                Swap(numbers, digitsArray, min, len - 1);
            }
            return sb.ToString();
        }

        private int[] ToDigits(int number)
        {
            int len = CalcDigitLen(number);
            if (len <= 0) return null;
            int[] digits = new int[len];
            for(int i = 0; i < len; i++)
            {
                digits[len - i - 1] = number % 10;
                number /= 10;
            }
            return digits;
        }

        private int CalcDigitLen(int number)
        {
            int len = 0;
            while(number > 0)
            {
                len++;
                number /= 10;
            }
            return len;
        }

        private int Compare(int[][] digitsArray, int a, int b)
        {
            int[] aa = digitsArray[a];
            int[] ba = digitsArray[b];
            int alen = aa.Length;
            int blen = ba.Length;
            int len = alen + blen;
            for(int i = 0; i < len; i++)
            {
                int ad = i < alen ? aa[i] : ba[i - alen];
                int bd = i < blen ? ba[i] : aa[i - blen];
                if (ad < bd) return a;
                if (bd < ad) return b;
            }
            return a;
        }

        private void Swap(int[] numbers, int[][] digitsArray, int a, int b)
        {
            if (a == b) return;
            numbers[a] += numbers[b];
            numbers[b] = numbers[a] - numbers[b];
            numbers[a] -= numbers[b];
            int[] digits = digitsArray[a];
            digitsArray[a] = digitsArray[b];
            digitsArray[b] = digits;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            for (int i = 0; i < 100; i++)
            {
                int len = rnd.Next(1, 100);
                int[] numbers = new int[len];
                for (int j = 0; j < len; j++)
                {
                    numbers[j] = rnd.Next(1, 1000);
                }
                string s1 = s.PrintMinNumber(numbers);
                string s2 = PrintMinNumber(numbers);
                if (s1.Equals(s2) == false)
                {
                    Console.WriteLine("Test the following array fail:");
                    Print(numbers);
                    Console.WriteLine("MinNumber should be: {0}", s2);
                    Console.WriteLine("But the result is: {0}", s1);
                    return false;
                }
            }
            return true;
        }

        class Join
        {
            List<int> numbers;
            int[][] dsa;
            int len;

            internal Join(int[][] dsa)
            {
                numbers = new List<int>();
                this.dsa = (int[][])dsa.Clone();
                len = dsa.Length;
            }

            internal Join(List<int> numbers, int[][] dsa, int len, int idx)
            {
                this.numbers = new List<int>(numbers);
                this.dsa = (int[][])dsa.Clone();
                this.len = len - 1;
                this.numbers.AddRange(this.dsa[idx]);
                Swap(idx, this.len);
            }

            internal List<Join> Prepare(int n)
            {
                if (n < numbers.Count) return null;
                List<Join> l1 = new List<Join>();
                int min = 9;
                for(int i = 0; i < len; i++)
                {
                    min = Math.Min(dsa[i][0], min);
                }
                for(int i = 0; i < len; i++)
                {
                    if(dsa[i][0] == min)
                    {
                        l1.Add(new Join(numbers, dsa, len, i));
                    }
                }
                return l1;
            }

            internal int Get(int n)
            {
                return numbers[n];
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                foreach(int i in numbers)
                {
                    sb.Append(i);
                }
                return sb.ToString();
            }

            private void Swap(int i, int j)
            {
                if (i == j) return;
                int[] ds = dsa[i];
                dsa[i] = dsa[j];
                dsa[j] = ds;
            }
        }

        private string PrintMinNumber(int[] numbers)
        {
            if (numbers == null || numbers.Length <= 0) return null;
            int[][] dsa = new int[numbers.Length][];
            int dlen = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                int[] ds = ToDigits(numbers[i]);
                if (ds == null) return null;
                dsa[i] = ds;
                dlen += ds.Length;
            }
            List<Join> l1 = new List<Join>();
            List<Join> l2 = new List<Join>();
            l1.Add(new Join(dsa));
            for(int i = 0; i < dlen; i++)
            {
                l2.Clear();
                foreach(Join j in l1)
                {
                    List<Join> l = j.Prepare(i);
                    if(l == null)
                    {
                        l2.Add(j);
                    }
                    else
                    {
                        l2.AddRange(l);
                    }
                }
                int min = 9;
                foreach(Join j in l2)
                {
                    min = Math.Min(j.Get(i), min);
                }
                l1.Clear();
                foreach(Join j in l2)
                {
                    if(j.Get(i) == min)
                    {
                        l1.Add(j);
                    }
                }
            }

            return l1[0].ToString();
        }
    }
}