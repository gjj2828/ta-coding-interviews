/****************************************************************
 * Project: coding-interviews
 * File: Fibonacci.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: Fibonacci algorithm.
****************************************************************/

using System;

// 递归 斐波那契数列
namespace Fibonacci
{
    class Solution
    {
        //public int Fibonacci(int n)
        //{
        //    // write code here
        //    if (n < 2) return n;
        //    return Fibonacci(n - 2) + Fibonacci(n - 1);
        //}

        public int Fibonacci(int n)
        {
            // write code here
            if (n < 2) return n;
            int[] f = new int[n];
            f[0] = 1;
            f[1] = 1;
            for (int i = 2; i < n; i++)
            {
                f[i] = f[i - 2] + f[i - 1];
            }
            return f[n - 1];
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int n = 40;
            int[] f = new int[n];
            for(int i = 0; i < n; i++)
            {
                //Console.WriteLine("{0}: {1}", n, s.Fibonacci(n));
                f[i] = s.Fibonacci(i);
            }
            if (f[0] != 0) return false;
            if (f[1] != 1) return false;
            for(int i = 2; i < n; i++)
            {
                if (f[i] != f[i - 2] + f[i - 1]) return false;
            }
            return true;
        }
    }
}