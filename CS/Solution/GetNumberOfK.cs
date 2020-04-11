/****************************************************************
 * Project: coding-interviews
 * File: GetNumberOfK.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: GetNumberOfK algorithm.
****************************************************************/

using System;
using System.Collections.Generic;

// 数组 数字在排序数组中出现的次数
namespace GetNumberOfK
{
    class Solution
    {
        // 方法一：递归返回数量
        //public int GetNumberOfK(int[] data, int k)
        //{
        //    // write code here
        //    if (data == null) return 0;
        //    return GetNumberOfK(data, k, 0, data.Length - 1);
        //}

        //private int GetNumberOfK(int[] data, int k, int begin, int end)
        //{
        //    if (data[begin] > k || data[end] < k) return 0;
        //    if (data[begin] == k && data[end] == k) return end - begin + 1;
        //    int mid = (begin + end) / 2;
        //    return GetNumberOfK(data, k, begin, mid)
        //        + GetNumberOfK(data, k, mid + 1, end);
        //}

        // 方法二：循环找出首尾
        //public int GetNumberOfK(int[] data, int k)
        //{
        //    // write code here
        //    if (data == null) return 0;
        //    if (data[0] > k || data[data.Length - 1] < k) return 0;

        //    // first
        //    int first = -1;
        //    if(data[0] == k)
        //    {
        //        first = 0;
        //    }
        //    else
        //    {
        //        int left = 0, right = data.Length - 1;
        //        while (true)
        //        {
        //            int mid = (left + right) / 2;
        //            if (data[mid] >= k)
        //            {
        //                right = mid;
        //            }
        //            else
        //            {
        //                left = mid + 1;
        //                if (data[left] > k) break;
        //                if (data[left] == k)
        //                {
        //                    first = left;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    if (first < 0) return 0;

        //    // last
        //    int last;
        //    if(data[data.Length - 1] == k)
        //    {
        //        last = data.Length - 1;
        //    }
        //    else
        //    {
        //        int left = first, right = data.Length - 1;
        //        while (true)
        //        {
        //            int mid = (left + right + 1) / 2;
        //            if (data[mid] <= k)
        //            {
        //                left = mid;
        //            }
        //            else
        //            {
        //                right = mid - 1;
        //                if (data[right] == k)
        //                {
        //                    last = right;
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    return last - first + 1;
        //}

        // 方法三：递归返回首尾
        public int GetNumberOfK(int[] data, int k)
        {
            // write code here
            if (data == null) return 0;
            int first = GetFirstOfK(data, k, 0, data.Length - 1);
            if (first < 0) return 0;
            return GetLastOfK(data, k, first, data.Length - 1) - first + 1;
        }

        private int GetFirstOfK(int[] data, int k, int begin, int end)
        {
            if (begin > end) return -1;
            int mid = (begin + end) / 2;
            if (data[mid] < k) return GetFirstOfK(data, k, mid + 1, end);
            if (data[mid] == k && (mid == 0 || data[mid - 1] < k)) return mid;
            return GetFirstOfK(data, k, begin, mid - 1);
        }

        private int GetLastOfK(int[] data, int k, int begin, int end)
        {
            int mid = (begin + end) / 2;
            if (data[mid] > k) return GetLastOfK(data, k, begin, mid - 1);
            if (data[mid] == k && (mid == data.Length - 1 || data[mid + 1] > k))
                return mid;
            return GetLastOfK(data, k, mid + 1, end);
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