/****************************************************************
 * Project: coding-interviews
 * File: NumberOf1Between1AndN_Solution.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: NumberOf1Between1AndN_Solution algorithm.
****************************************************************/

using System;

// 查找 数学 整数中1出现的次数（从1到n整数中1出现的次数）
namespace NumberOf1Between1AndN_Solution
{
    class Solution
    {
        //public int NumberOf1Between1AndN_Solution(int n)
        //{
        //    // write code here
        //    if (n <= 0) return 0;
        //    int d = 1;
        //    int cnt = 0;
        //    while(n >= d)
        //    {
        //        int dc = n / d;
        //        cnt += dc / 10 * d;
        //        int dn = dc % 10;
        //        int dm = n % d;
        //        if(dn > 1)
        //        {
        //            cnt += d;
        //        }
        //        else if(dn == 1)
        //        {
        //            cnt += dm + 1;
        //        }
        //        d *= 10;
        //    }
        //    return cnt;
        //}

        public int NumberOf1Between1AndN_Solution(int n)
        {
            // write code here
            if (n <= 0) return 0;
            int d = 1;
            int cnt = 0;
            while(n >= d)
            {
                int nd = d * 10;
                int r1 = n % nd;
                cnt += (n - r1) / 10;
                int r2 = r1 % d;
                int dn = r1 / d;
                if (dn > 1)
                {
                    cnt += d;
                }
                else if (dn == 1)
                {
                    cnt += r2 + 1;
                }
                d = nd;
            }
            return cnt;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(1));
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(9));
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(13));
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(90));
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(91));
            //Console.WriteLine(s.NumberOf1Between1AndN_Solution(99));
            //Console.WriteLine(NumberOf1Between1AndN_Solution(1 << 24));
            Random rnd = new Random();
            int max = 1 << 16;
            for(int i = 0; i < 100; i++)
            {
                int n = rnd.Next(max);
                if(s.NumberOf1Between1AndN_Solution(n) != NumberOf1Between1AndN_Solution(n))
                {
                    Console.WriteLine("Test {0} fail!", n);
                    return false;
                }
            }
            return true;
        }

        private int NumberOf1Between1AndN_Solution(int n)
        {
            if (n <= 0) return 0;
            int cnt = 0;
            for(int i = 1; i <= n; i++)
            {
                cnt += NumberOf1(i);
            }
            return cnt;
        }

        private int NumberOf1(int n)
        {
            int cnt = 0;
            while(n > 0)
            {
                int m = n % 10;
                if(m == 1)
                {
                    cnt++;
                }
                n /= 10;
            }
            return cnt;
        }
    }
}