using System.Collections.Generic;

// 数组 顺时针打印矩阵
namespace printMatrix
{
    class Solution
    {
        public List<int> printMatrix(int[][] matrix)
        {
            // write code here
            if (matrix == null || matrix.Length <= 0 || matrix[0].Length <= 0)
                return null;
            int row = matrix.Length;
            int col = matrix[0].Length;
            int[] limits = { 0, col - 1, row - 1 , 0 };
            int[] pos = { 0, 0 };
            int stage = 0;
            List<int> result = new List<int>(row * col);
            int ori = 0;
            int dir = -1;
            while (true)
            {
                result.Add(matrix[pos[0]][pos[1]]);
                if(pos[ori] == limits[stage])
                {
                    limits[stage] -= dir;
                    stage = (stage + 1) % 4;
                    ori = stage % 2;
                    dir = 2 * (((stage + 1) / 2) % 2) - 1;
                    if (pos[ori] * dir >= limits[stage] * dir) break;
                }
                pos[ori] += dir;
            }
            return result;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] list = new int[16];
            for(int i = 0; i < list.Length; i++)
            {
                list[i] = i + 1;
            }
            int[][] matrix = CreateMatrix(list, 4);
            if (!IsEqual(s.printMatrix(matrix).ToArray()
                , new int[] { 1, 2, 3, 4, 8, 12, 16, 15, 14, 13, 9, 5, 6, 7, 11, 10 }))
                return false;
            return true;
        }
    }
}