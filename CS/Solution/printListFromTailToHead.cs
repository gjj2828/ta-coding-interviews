using System;
using System.Collections.Generic;

// 链表 从尾到头打印链表
namespace printListFromTailToHead
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
        // 返回从尾到头的列表值序列
        public List<int> printListFromTailToHead(ListNode listNode)
        {
            // write code here
            if (listNode == null) return null;

            //List<int> l = new List<int>();
            //for (ListNode ln = listNode; ln != null; ln = ln.next)
            //{
            //    l.Insert(0, ln.val);
            //}
            //return l;

            List<int> l = new List<int>();
            for (ListNode ln = listNode; ln != null; ln = ln.next)
            {
                l.Add(ln.val);
            }
            int half = l.Count / 2;
            for (int i = 0; i < half; i++)
            {
                int j = l.Count - i - 1;
                l[i] = l[i] + l[j];
                l[j] = l[i] - l[j];
                l[i] = l[i] - l[j];
            }
            return l;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int num = 10;
            Random rnd = new Random();
            List<int> t = new List<int>(num);
            for(int i = 0; i < num; i++)
            {
                t.Add(rnd.Next());
            }
            Print(t);
            ListNode root = new ListNode(t[0]);
            ListNode pre = root;
            for(int i = 1; i < num; i++)
            {
                pre.next = new ListNode(t[i]);
                pre = pre.next;
            }
            List<int> t1 = s.printListFromTailToHead(root);
            for(int i = 0; i < num; i++)
            {
                if(t[i] != t1[num - i - 1])
                {
                    Console.WriteLine("Test fail");
                    return false;
                }
            }
            List<int> t2 = s.printListFromTailToHead(null);
            if(t2 != null && t2.Count > 0)
            {
                Console.WriteLine("Test empty fail");
                return false;
            }
            return true;
        }
    }
}