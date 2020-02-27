using System;

// 查找 数组 二维数组中的查找
namespace Find
{
    class Solution
    {
        public bool Find(int target, int[][] array)
        {
            // write code here
            int r = array.Length - 1;
            int c = 0;
            while(r >= 0)
            {
                int[] row = array[r];
                if(c < row.Length)
                {
                    if (target == row[c]) return true;
                    _ = target > row[c] ? c++ : r--;
                }
                else
                {
                    r--;
                }
            }

            return false;
        }
    }

    class Test: TestBase
    {
        private const int mRowNum = 10;
        private const int mColNum = 10;

        private int[][] mArray = new int[mRowNum][];
        private Random mRnd = new Random();

        public Test()
        {
            for(int i = 0; i < mRowNum; i++)
            {
                mArray[i] = new int[mColNum];
            }
        }

        public override bool Run()
        {
            Solution s = new Solution();
            for(int i = 0; i < mRowNum; i++)
            {
                for(int j = 0; j < mColNum; j++)
                {
                    Rand(i, j);
                }
            }
            Print(mArray);
            int max = mArray[mRowNum - 1][mColNum - 1] + 10;
        
            for (int i = 0; i < max; i++)
            {
                bool bFound = false;
                for(int r = 0; r < mRowNum; r++)
                {
                    for(int c = 0; c < mColNum; c++)
                    {
                        if(mArray[r][c] == i)
                        {
                            bFound = true;
                            break;
                        }
                    }
                    if (bFound) break;
                }
                if(s.Find(i, mArray) == bFound)
                {
                    if(i == 0)
                    {
                        Console.Write("Test pass:");
                    }
                    Console.Write(" {0}", i);
                }
                else
                {
                    if(i > 0)
                    {
                        Console.WriteLine();
                    }
                    Console.Write("Test fail: ");
                    if(bFound)
                    {
                        Console.Write("Should find ");
                    }
                    else
                    {
                        Console.Write("Should not find ");
                    }
                    Console.WriteLine(i);
                    return false;
                }
            }
            Console.WriteLine();
            return true;
        }

        private void Rand(int row, int col)
        {
            int b = 0;
            b = row > 0 ? Math.Max(mArray[row - 1][col], b) : b;
            b = col > 0 ? Math.Max(mArray[row][col - 1], b) : b;
            mArray[row][col] = b + mRnd.Next(10) + 2;
        }
    }
}