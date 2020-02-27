using System;

// 递归 矩形覆盖
namespace rectCover
{
    class Solution
    {
        public int rectCover(int number)
        {
            // write code here
            if (number <= 3) return number;
            return rectCover(number - 1) + rectCover(number - 2);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            for(int i = 1; i <= 10; i++)
            {
                Console.WriteLine("{0}: {1}", i, s.rectCover(i));
            }
            return true;
        }
    }
}