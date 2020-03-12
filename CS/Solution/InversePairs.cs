using System;

// 数组 数组中的逆序对
namespace InversePairs
{
    class Solution
    {
        public int InversePairs(int[] data)
        {
            // write code here
            if (data == null || data.Length < 2) return 0;
            int[] buf1 = (int[])data.Clone();
            int[] buf2 = (int[])data.Clone();
            return Count(buf1, buf2, 0, data.Length - 1);
        }

        private int Count(int[] buf1, int[] buf2, int begin, int end)
        {
            if (begin >= end) return 0;

            int mid = (begin + end) / 2;
            int cl = Count(buf2, buf1, begin, mid);
            int cr = Count(buf2, buf1, mid + 1, end);

            int il = mid;
            int ir = end;
            int i1 = end;
            int cnt = 0;
            int m = 1000000007;
            while (il >= begin && ir > mid)
            {
                if(buf2[ir] < buf2[il])
                {
                    cnt += (ir - mid);
                    cnt %= m;
                    buf1[i1--] = buf2[il--];
                }
                else
                {
                    buf1[i1--] = buf2[ir--];
                }
            }
            while(ir > mid)
            {
                buf1[i1--] = buf2[ir--];
            }
            while(il >= begin)
            {
                buf1[i1--] = buf2[il--];
            }

            return (cnt + ((cl + cr) % m)) % m;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            //int len = 200000;
            int len = 10000;
            int[] data = new int[len];
            for(int i = 0; i < len; i++)
            {
                data[i] = i;
            }
            for(int i = 0; i < len; i++)
            {
                int r = rnd.Next(len - i);
                data[i] += data[r];
                data[r] = data[i] - data[r];
                data[i] -= data[r];
            }
            if (s.InversePairs(data) != InversePairs(data)) return false;
            return true;
        }

        private int InversePairs(int[] data)
        {
            if (data == null) return 0;
            int cnt = 0;
            int m = 1000000007;
            for (int i = 0; i < data.Length; i++)
            {
                int v = data[i];
                for(int j = i + 1; j < data.Length; j++)
                {
                    if(data[j] < v)
                    {
                        cnt++;
                        if(cnt == m)
                        {
                            cnt = 0;
                        }
                    }
                }
            }
            return cnt;
        }
    }
}