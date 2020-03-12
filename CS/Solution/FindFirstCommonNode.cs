using System;

// 链表 两个链表的第一个公共结点
namespace FindFirstCommonNode
{
    /*
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode (int x)
        {
            val = x;
        }
    }*/
    class Solution
    {
        public ListNode FindFirstCommonNode(ListNode pHead1, ListNode pHead2)
        {
            // write code here
            int cnt = 0;
            ListNode p1 = pHead1;
            while(p1 != null)
            {
                cnt++;
                p1 = p1.next;
            }
            ListNode p2 = pHead2;
            while(p2 != null)
            {
                cnt--;
                p2 = p2.next;
            }
            if(cnt > 0)
            {
                p1 = pHead1;
                p2 = pHead2;
            }
            else
            {
                p1 = pHead2;
                p2 = pHead1;
                cnt = -cnt;
            }
            for(int i = 0; i < cnt; i++)
            {
                p1 = p1.next;
            }
            while(p1 != null && p2 != null)
            {
                if (p1 == p2) return p1;
                p1 = p1.next;
                p2 = p2.next;
            }
            return null;
        }
    }

    class Test: TestBase
    {
        private int mIdCnt = 0;

        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            int lenMax = 10;
            for(int i = 0; i < 10; i++)
            {
                int len1 = rnd.Next(lenMax);
                ListNode h1 = GenList(len1);
                ListNode h2 = GenList(rnd.Next(lenMax / 2));
                if(h1 == null || h2 == null)
                {
                    if (s.FindFirstCommonNode(h1, h2) != null) return false;
                }
                else
                {
                    int c = rnd.Next(len1 + 1);
                    ListNode cn = h1;
                    for(int j = 0; j < c; j++)
                    {
                        cn = cn.next;
                    }
                    ListNode p = h2;
                    while(p.next != null)
                    {
                        p = p.next;
                    }
                    p.next = cn;
                    if (s.FindFirstCommonNode(h1, h2) != cn) return false;
                }
            }
            return true;
        }

        private ListNode GenList(int cnt)
        {
            if (cnt <= 0) return null;
            ListNode head = new ListNode(mIdCnt++);
            ListNode p = head;
            for(int i = 1; i < cnt; i++)
            {
                p.next = new ListNode(mIdCnt++);
                p = p.next;
            }
            return head;
        }
    }
}