using System;

// 进制转化 补码反码原码 二进制中1的个数
namespace NumberOf1
{
    class Solution
    {
        public int NumberOf1(int n)
        {
            // write code here
            int c = 0;
            while(n != 0)
            {
                n &= n - 1;
                c++;
            }
            return c;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                int n = rnd.Next();
                if(rnd.Next(100) < 50)
                {
                    n = -n;
                }
                if (s.NumberOf1(n) != NumberOf1(n)) return false;
            }
            return true;
        }

        private int NumberOf1(int n)
        {
            uint u = (uint)n;
            int c = 0;
            while(u != 0)
            {
                if((u & 0x1) != 0)
                {
                    c++;
                }
                u >>= 1;
            }
            return c;
        }
    }
}