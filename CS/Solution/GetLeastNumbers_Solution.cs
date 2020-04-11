/****************************************************************
 * Project: coding-interviews
 * File: GetLeastNumbers_Solution.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: GetLeastNumbers_Solution algorithm.
****************************************************************/

using System.Collections.Generic;

// 数组 高级算法 最小的K个数
namespace GetLeastNumbers_Solution
{
    class Solution
    {
        public List<int> GetLeastNumbers_Solution(int[] input, int k)
        {
            // write code here
            if (input == null || k <= 0) return null;
            int len = input.Length;
            if (len <= 0) return null;

            for(int i = len / 2  - 1; i >= 0; i--)
            {
                AdjustHeap(input, i, len);
            }

            List<int> list = new List<int>();
            while(true)
            {
                list.Add(input[0]);
                len--;
                if (list.Count >= k || len <= 0) break;
                input[0] = input[len];
                AdjustHeap(input, 0, len);
            }

            return list;
        }

        //private void AdjustHeap(int[] input, int node, int len)
        //{
        //    int halfLen = len / 2;
        //    while(node < halfLen)
        //    {
        //        int leftChild = node * 2 + 1;
        //        int rightChild = leftChild + 1;
        //        int minChild;
        //        if(rightChild < len && input[rightChild] < input[leftChild])
        //        {
        //            minChild = rightChild;
        //        }
        //        else
        //        {
        //            minChild = leftChild;
        //        }

        //        if (input[node] <= input[minChild]) break;

        //        input[node] += input[minChild];
        //        input[minChild] = input[node] - input[minChild];
        //        input[node] -= input[minChild];
        //        node = minChild;
        //    }
        //}

        private void AdjustHeap(int[] input, int node, int len)
        {
            if (node >= len / 2) return;

            int leftChild = node * 2 + 1;
            int rightChild = leftChild + 1;
            int minChild;
            if (rightChild < len && input[rightChild] < input[leftChild])
            {
                minChild = rightChild;
            }
            else
            {
                minChild = leftChild;
            }

            if (input[minChild] < input[node])
            {
                input[node] += input[minChild];
                input[minChild] = input[node] - input[minChild];
                input[node] -= input[minChild];
                AdjustHeap(input, minChild, len);
            }
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] input = { 4, 5, 1, 6, 2, 7, 3, 8 };
            int k = 4;
            List<int> list = s.GetLeastNumbers_Solution(input, k);
            if (list == null || list.Count != k) return false;
            for(int i = 0; i < k; i++)
            {
                if (list[i] != i + 1) return false;
            }
            return true;
        }
    }
}