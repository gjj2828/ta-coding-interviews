using System;
using System.Text;

// 字符串 替换空格
namespace replaceSpace
{
    class Solution
    {
        public string replaceSpace(string str)
        {
            // write code here
            //char[] se = new char[] { ' ' };
            //string[] strs = str.Split(new char[] { ' ' });
            //return string.Join("%20", strs);

            //return str.Replace(" ", "%20");

            //StringBuilder sb = new StringBuilder();
            //int start = 0;
            //while(start < str.Length)
            //{
            //    int pos = str.IndexOf(' ', start);
            //    if(pos < 0)
            //    {
            //        sb.Append(str.Substring(start));
            //        break;
            //    }
            //    else
            //    {
            //        if(pos > start)
            //        {
            //            sb.Append(str.Substring(start, pos - start));
            //        }
            //        sb.Append("%20");
            //        start = pos + 1;
            //    }
            //}
            //return sb.ToString();

            char[] chars = str.ToCharArray();
            int spaceNum = 0;
            for(int i = 0; i < chars.Length; i++)
            {
                if(chars[i] == ' ')
                {
                    spaceNum++;
                }
            }
            char[] des = new char[chars.Length + spaceNum * 2];
            for (int i = 0, j = 0; i < chars.Length; i++)
            {
                if(chars[i] == ' ')
                {
                    des[j++] = '%';
                    des[j++] = '2';
                    des[j++] = '0';
                }
                else
                {
                    des[j++] = chars[i];
                }
            }
            return new string(des);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            string[] q = { "We Are Happy", "We  Are  Happy", "We Are Happy  " };
            string[] a = { "We%20Are%20Happy", "We%20%20Are%20%20Happy", "We%20Are%20Happy%20%20" };
            int num = Math.Min(q.Length, a.Length);
            for(int i = 0; i < num; i++)
            {
                if(s.replaceSpace(q[i]).Equals(a[i]))
                {
                    Console.WriteLine("Test pass: {0}", q[i]);
                }
                else
                {
                    Console.WriteLine("Test fail: {0}", q[i]);
                    return false;
                }
            }
            return true;
        }
    }
}