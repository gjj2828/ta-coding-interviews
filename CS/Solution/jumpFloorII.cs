using System;

// 贪心 变态跳台阶
namespace jumpFloorII
{
    class Solution
    {
        public int jumpFloorII(int number)
        {
            // write code here
            if (number < 3) return number;
            int n = 1;
            for(int i = 0; i < number; i++)
            {
                n += jumpFloorII(i);
            }
            return n;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            for(int i = 1; i < 10; i++)
            {
                if (s.jumpFloorII(i) != 1 << (i - 1)) return false;
            }
            return true;
        }
    }
}