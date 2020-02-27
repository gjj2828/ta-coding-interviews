using System;

// 数组 调整数组顺序使奇数位于偶数前面
namespace reOrderArray
{
    class Solution
    {
        public int[] reOrderArray(int[] array)
        {
            // write code here
            if(array != null)
            {
                int lastOdd = 0;
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    if(!IsEven(array[i]))
                    {
                        lastOdd = i;
                        break;
                    }
                }
                int firstOdd = lastOdd;
                FindFirstOdd(array, ref firstOdd);
                while (firstOdd > 0)
                {
                    int curEven = array[firstOdd - 1];
                    Array.Copy(array, firstOdd, array, firstOdd - 1, lastOdd - firstOdd + 1);
                    array[lastOdd] = curEven;
                    firstOdd--;
                    lastOdd--;
                    FindFirstOdd(array, ref firstOdd);
                }
            }
            return array;
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }

        private void FindFirstOdd(int[] array, ref int firstOdd)
        {
            for (int i = firstOdd - 1; i >= 0; i--)
            {
                if (IsEven(array[i])) break;
                firstOdd = i;
            }
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            int len = 100;
            int[] array = new int[len];
            int[] arrayCheck = new int[len];
            for(int i = 0; i < 10; i++)
            {
                for(int j = 0; j < len; j++)
                {
                    array[j] = rnd.Next();
                    arrayCheck[j] = array[j];
                }
                s.reOrderArray(array);
                int index = 0;
                for(int j = 0; j < len; j++)
                {
                    if(!IsEven(arrayCheck[j]))
                    {
                        if (arrayCheck[j] != array[index]) return false;
                        index++;
                    }
                }
                for (int j = 0; j < len; j++)
                {
                    if (IsEven(arrayCheck[j]))
                    {
                        if (arrayCheck[j] != array[index]) return false;
                        index++;
                    }
                }
            }
            return true;
        }

        private bool IsEven(int n)
        {
            return n % 2 == 0;
        }
    }
}