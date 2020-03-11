using System;
using System.Text;

// 字符串 第一个只出现一次的字符
namespace FirstNotRepeatingChar
{
    class Solution
    {
        public int FirstNotRepeatingChar(string str)
        {
            // write code here
            if (str == null || str.Length <= 0) return -1;

            int letterNum = 26;
            int lowerBegin = 0;
            int upperBegin = lowerBegin + letterNum;
            int letterNumAll = letterNum * 2;
            int[] cnt = new int[letterNumAll];
            int[] pos = new int[letterNumAll];

            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                int idx = -1;
                if(c >= 'a' && c <= 'z')
                {
                    idx = c - 'a' + lowerBegin;
                }
                else if(c >= 'A' && c <= 'Z')
                {
                    idx = c - 'A' + upperBegin;
                }
                if(idx >= 0)
                {
                    cnt[idx]++;
                    pos[idx] = i;
                }
            }

            int minPos = -1;
            for(int i = 0; i < letterNumAll; i++)
            {
                if(cnt[i] == 1)
                {
                    if(minPos < 0 || pos[i] < minPos)
                    {
                        minPos = pos[i];
                    }
                }
            }

            return minPos;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            for(int i = 0; i < 50; i++)
            {
                string rndStr = GenRndStr(rnd);
                if (s.FirstNotRepeatingChar(rndStr) != FirstNotRepeatingChar(rndStr))
                    return false;
            }
            return true;
        }

        private string GenRndStr(Random rnd)
        {
            StringBuilder sb = new StringBuilder();
            int len = rnd.Next(100001);
            for(int i = 0; i < len; i++)
            {
                int r = rnd.Next(56);
                char c;
                if(r < 26)
                {
                    c = (char)('a' + r);
                }
                else
                {
                    c = (char)('A' + r);
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        private int FirstNotRepeatingChar(string str)
        {
            if (str == null) return -1;
            for(int i = 0; i < str.Length; i++)
            {
                char c = str[i];
                bool found = false;
                for(int j = 0; j < str.Length; j++)
                {
                    if (i == j) continue;
                    if(str[j] == c)
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false) return i;
            }
            return -1;
        }
    }
}