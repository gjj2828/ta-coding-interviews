// 链表 合并两个排序的链表
namespace Merge
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
        public ListNode Merge(ListNode pHead1, ListNode pHead2)
        {
            // write code here
            if (pHead1 == null) return pHead2;
            if (pHead2 == null) return pHead1;

            ListNode head;
            ListNode p1 = pHead1;
            ListNode p2 = pHead2;
            if(p1.val > p2.val)
            {
                head = p2;
                p2 = p2.next;
            }
            else
            {
                head = p1;
                p1 = p1.next;
            }
            ListNode p = head;

            while (p1 != null && p2 != null)
            {
                if (p1.val > p2.val)
                {
                    p.next = p2;
                    p2 = p2.next;
                }
                else
                {
                    p.next = p1;
                    p1 = p1.next;
                }
                p = p.next;
            }
            if(p1 == null)
            {
                p.next = p2;
            }
            else if(p2 == null)
            {
                p.next = p1;
            }
            return head;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] a1 = { 1, 3, 5, 7, 9 };
            int[] a2 = { 2, 4, 6, 8, 10 };
            ListNode l1 = CreateList(a1);
            ListNode l2 = CreateList(a2);
            ListNode lm = s.Merge(l1, l2);
            ListNode p = lm;
            for(int i = 1; i <= 10; i++)
            {
                if (p.val != i) return false;
                p = p.next;
            }
            if (p != null) return false;
            return true;
        }
    }
}