/****************************************************************
 * Project: coding-interviews
 * File: FindGreatestSumOfSubArray.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: FindGreatestSumOfSubArray algorithm.
****************************************************************/

using System;

// 数组 连续子数组的最大和
namespace FindGreatestSumOfSubArray
{
    class Solution
    {
        //public int FindGreatestSumOfSubArray(int[] array)
        //{
        //    // write code here
        //    int max = int.MinValue;

        //    if (array != null)
        //    {
        //        int len = array.Length;
        //        for(int i = 0; i < len; i++)
        //        {
        //            int sum = array[i];
        //            int idx = i;
        //            max = Math.Max(sum, max);
        //            for(int j = i + 1; j < len; j++)
        //            {
        //                if(array[j] > 0)
        //                {
        //                    for(int k = idx + 1; k <= j; k++)
        //                    {
        //                        sum += array[k];
        //                    }
        //                    idx = j;
        //                    max = Math.Max(sum, max);
        //                }
        //            }
        //        }
        //    }

        //    return max;
        //}

        private enum EState
        {
              NONE
            , POS
            , NEG
        }

        public int FindGreatestSumOfSubArray(int[] array)
        {
            // write code here
            int max = int.MinValue;

            if (array != null)
            {
                int len = array.Length;
                EState state = EState.NONE;
                int sum = 0;
                for (int i = 0; i < len; i++)
                {
                    int a = array[i];

                    if(state == EState.POS)
                    {
                        if(a > 0)
                        {
                            sum += a;
                        }
                        else
                        {
                            max = Math.Max(sum, max);
                            sum += a;
                            state = EState.NEG;
                        }
                    }
                    else if(state == EState.NEG)
                    {
                        if(a > 0)
                        {
                            sum = Math.Max(sum, 0);
                            state = EState.POS;
                        }
                        sum += a;
                    }
                    else
                    {
                        if (a > 0)
                        {
                            state = EState.POS;
                            sum = a;
                        }
                        else
                        {
                            max = Math.Max(a, max);
                        }
                    }
                }
                if(state == EState.POS)
                {
                    max = Math.Max(sum, max);
                }
            }

            return max;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] array = { 6, -3, -2, 7, -15, 1, 2, 2 };
            return s.FindGreatestSumOfSubArray(array) == 8;
        }
    }
}