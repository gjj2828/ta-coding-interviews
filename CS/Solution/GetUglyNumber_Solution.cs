/****************************************************************
 * Project: coding-interviews
 * File: GetUglyNumber_Solution.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: GetUglyNumber_Solution algorithm.
****************************************************************/

using System;

// 穷举 丑数
namespace GetUglyNumber_Solution
{
    class Solution
    {
        public int GetUglyNumber_Solution(int index)
        {
            // write code here
            if (index <= 0) return 0;
            int[] nums = new int[index];
            nums[0] = 1;
            int mulNum = 3;
            int[] indexes = new int[] { 0, 0, 0 };
            int[] multiplier = new int[] { 2, 3, 5 };
            int[] values = (int[])multiplier.Clone();
            for (int i = 1; i < index; i++)
            {
                int last = nums[i - 1];
                for(int j = 0; j < mulNum; j++)
                {
                    while(values[j] <= last)
                    {
                        indexes[j]++;
                        values[j] = nums[indexes[j]] * multiplier[j];
                    }
                }
                int min = values[0];
                for(int j = 1; j < mulNum; j++)
                {
                    min = Math.Min(values[j], min);
                }
                nums[i] = min;
            }
            return nums[index - 1];
        }
    }

    class Test : TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] results = { 1, 2, 3, 4, 5, 6, 8, 9, 10 };
            for(int i = 0; i < results.Length; i++)
            {
                if (s.GetUglyNumber_Solution(i + 1) != results[i]) return false;
            }
            return true;
        }
    }
}
