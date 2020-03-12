using System;
using System.Collections.Generic;

// 数组 数字在排序数组中出现的次数
namespace GetNumberOfK
{
    class Solution
    {
        public int GetNumberOfK(int[] data, int k)
        {
            // write code here
            if (data == null) return 0;
            return GetNumberOfK(data, k, 0, data.Length - 1);
        }

        private int GetNumberOfK(int[] data, int k, int begin, int end)
        {
            if (data[begin] > k || data[end] < k) return 0;
            if (data[begin] == k && data[end] == k) return end - begin + 1;
            int mid = (begin + end) / 2;
            return GetNumberOfK(data, k, begin, mid)
                + GetNumberOfK(data, k, mid + 1, end);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            Dictionary<int, int> cnt = new Dictionary<int, int>();
            for(int i = 0; i < 10; i++)
            {
                cnt.Clear();
                int len = 0;
                for (int j = 0; j < 100; j++)
                {
                    int r = rnd.Next(10);
                    cnt[j] = r;
                    len += r;
                }
                if(len > 0)
                {
                    int[] data = new int[len];
                    for(int j = 0, k = 0; j < 100; j++)
                    {
                        int n = cnt[j];
                        for(int l = 0; l < n; l++)
                        {
                            data[k++] = j;
                        }
                    }
                    int r = rnd.Next(100);
                    if (s.GetNumberOfK(data, r) != cnt[r]) return false;
                }
                else
                {
                    if (s.GetNumberOfK(null, rnd.Next(100)) != 0) return false;
                }
            }
            return true;
        }
    }
}