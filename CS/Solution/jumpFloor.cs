/****************************************************************
 * Project: coding-interviews
 * File: jumpFloor.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: jumpFloor algorithm.
****************************************************************/

using System;

// 递归 跳台阶
namespace jumpFloor
{
    class Solution
    {
        public int jumpFloor(int number)
        {
            // write code here
            if (number < 3) return number;
            return jumpFloor(number - 1) + jumpFloor(number - 2);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            for(int i = 1; i < 10; i++)
            {
                Console.WriteLine("{0}: {1}", i, s.jumpFloor(i));
            }
            return true;
        }
    }
}