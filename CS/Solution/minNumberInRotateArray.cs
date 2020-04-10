using System;

// 查找 旋转数组的最小数字
namespace minNumberInRotateArray
{
    class Solution
    {
        public int minNumberInRotateArray(int[] rotateArray)
        {
            // write code here
            if (rotateArray == null || rotateArray.Length <= 0) return 0;
            return minNumberInRotateArray(rotateArray, 0, rotateArray.Length - 1);
        }

        private int minNumberInRotateArray(int[] rotateArray, int begin, int end)
        {
            // write code here
            if (rotateArray[begin] < rotateArray[end]) return rotateArray[begin];
            if (end - begin < 2) return rotateArray[end];
            int center = (begin + end) / 2;
            if (rotateArray[center] > rotateArray[end])
                return minNumberInRotateArray(rotateArray, center + 1, end);
            if (rotateArray[center] < rotateArray[begin])
                return minNumberInRotateArray(rotateArray, begin + 1, center);
            return Math.Min(minNumberInRotateArray(rotateArray, begin + 1, center - 1)
                , minNumberInRotateArray(rotateArray, center + 1, end - 1));
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[][] q = { new int[] { 3, 4, 5, 1, 2 }
                , new int[] { 2, 4, 5, 1, 2 }
                , new int[] { 2, 4, 5, 1, 2, 2, 2, 2, 2 }
                , new int[] { 2, 2, 2, 2, 2, 1, 2, 2, 2 }
                , new int[] { 1, 1, 1 } };
            int[] a = { 1, 1, 1, 1, 1 };
            int num = Math.Min(q.Length, a.Length);
            for(int i = 0; i < num; i++)
            {
                if (s.minNumberInRotateArray(q[i]) != a[i]) return false;
            }
            return true;
        }
    }
}