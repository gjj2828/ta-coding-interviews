using System;

// 链表 链表中倒数第k个结点
namespace FindKthToTail
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
        public ListNode FindKthToTail(ListNode head, int k)
        {
            // write code here
            if (k <= 0) return null;
            ListNode p = head;
            for(int i = 0; i < k; i++)
            {
                if (p == null) return null;
                p = p.next;
            }
            ListNode q = head;
            while (p != null)
            {
                q = q.next;
                p = p.next;
            }
            return q;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                int len = rnd.Next(100);
                ListNode head = null;
                if (len > 0)
                {
                    head = new ListNode(0);
                    ListNode p = head;
                    for(int j = 1; j < len; j++)
                    {
                        p.next = new ListNode(j);
                        p = p.next;
                    }
                }
                int k = rnd.Next(100);
                Check(len, k, s.FindKthToTail(head, k));
            }
            Check(0, 1, s.FindKthToTail(null, 1));
            Check(1, 0, s.FindKthToTail(new ListNode(0), 1));
            return true;
        }

        private bool Check(int len, int k, ListNode result)
        {
            if ((len == 0 || k == 0 || k > len) && result != null) return false;
            if (result == null || (result.val != (len - k))) return false;
            return true;
        }
    }
}