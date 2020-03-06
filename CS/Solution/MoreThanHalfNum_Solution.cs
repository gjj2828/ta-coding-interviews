// 数组 数组中出现次数超过一半的数字
namespace MoreThanHalfNum_Solution
{
    class Solution
    {
        public int MoreThanHalfNum_Solution(int[] numbers)
        {
            // write code here
            if (numbers == null) return 0;
            int len = numbers.Length;
            if (len <= 0) return 0;
            int cnt = 1;
            int num = numbers[0];
            for(int i = 1; i < len; i++)
            {
                if(cnt > 0)
                {
                    if(numbers[i] == num)
                    {
                        cnt++;
                    }
                    else
                    {
                        cnt--;
                    }
                }
                else
                {
                    num = numbers[i];
                    cnt = 1;
                }
            }
            if (cnt <= 0) return 0;
            cnt = 0;
            for(int i = 0; i < len; i++)
            {
                if(numbers[i] == num)
                {
                    cnt++;
                }
            }
            if (cnt > len / 2) return num;
            return 0;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] numbers = { 1, 2, 3, 2, 2, 2, 5, 4, 2 };
            return s.MoreThanHalfNum_Solution(numbers) == 2;
        }
    }
}