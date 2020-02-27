using System;

// 链表 反转链表
namespace ReverseList
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode (int x)
        {
            val = x;
        }
    }
    class Solution
    {
        public ListNode ReverseList(ListNode pHead)
        {
            // write code here
            if (pHead == null) return null;
            if (pHead.next == null) return pHead;
            ListNode rHead = ReverseList(pHead.next);
            pHead.next.next = pHead;
            pHead.next = null;
            return rHead;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            ListNode head = new ListNode(0);
            head.next = new ListNode(1);
            head.next.next = new ListNode(2);
            head.next.next.next = new ListNode(3);
            Print(head);
            Print(s.ReverseList(head));
            for(int i = 0; i < 10; i++)
            {
                if (!Check(s, i)) return false;
            }
            return true;
        }

        private void Print(ListNode head)
        {
            ListNode p = head;
            while(p != null)
            {
                Console.Write("{0}\t", p.val);
                p = p.next;
            }
            Console.WriteLine();
        }

        private bool Check(Solution s, int len)
        {
            if(len > 0)
            {
                ListNode head = new ListNode(0);
                ListNode p = head;
                for(int i = 1; i < len; i++)
                {
                    p.next = new ListNode(i);
                    p = p.next;
                }
                ListNode q = s.ReverseList(head);
                for(int i = len - 1; i >= 0; i--)
                {
                    if (q.val != i) return false;
                    q = q.next;
                }
                if (q != null) return false;
            }
            else
            {
                if (s.ReverseList(null) != null) return false;
            }
            return true;
        }
    }
}