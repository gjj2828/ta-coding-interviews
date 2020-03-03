using System;
using System.Collections.Generic;

// 链表 复杂链表的复制
namespace Clone
{
    /*
    public class RandomListNode
    {
        public int label;
        public RandomListNode next, random;
        public RandomListNode (int x)
        {
            this.label = x;
        }
    }*/
    class Solution
    {
        //private Dictionary<RandomListNode, RandomListNode> mMap
        //    = new Dictionary<RandomListNode, RandomListNode>();

        //public RandomListNode Clone(RandomListNode pHead)
        //{
        //    // write code here
        //    if (pHead == null) return null;
        //    if (mMap.ContainsKey(pHead)) return mMap[pHead];
        //    RandomListNode node = new RandomListNode(pHead.label);
        //    mMap[pHead] = node;
        //    node.next = Clone(pHead.next);
        //    node.random = Clone(pHead.random);
        //    return node;
        //}

        public RandomListNode Clone(RandomListNode pHead)
        {
            // write code here
            if (pHead == null) return null;
            RandomListNode p = pHead;
            while(p != null)
            {
                RandomListNode q = p.next;
                p.next = new RandomListNode(p.label);
                p.next.next = q;
                p = q;
            }
            p = pHead;
            while(p != null)
            {
                if(p.random != null)
                {
                    p.next.random = p.random.next;
                }
                p = p.next.next;
            }
            RandomListNode pClone = pHead.next;
            p = pHead;
            while(p.next != null)
            {
                RandomListNode q = p.next;
                p.next = p.next.next;
                p = q;
            }
            return pClone;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Random rnd = new Random();
            int len = 100;
            RandomListNode[] list = new RandomListNode[len];
            HashSet<RandomListNode> set = new HashSet<RandomListNode>();
            RandomListNode head = new RandomListNode(0);
            list[0] = head;
            set.Add(head);
            for(int i = 1; i < len; i++)
            {
                RandomListNode node = new RandomListNode(i);
                list[i] = node;
                set.Add(node);
                list[i - 1].next = node;
            }
            for(int i = 0; i < len; i++)
            {
                if(rnd.Next(100) < 50)
                {
                    list[i].random = list[rnd.Next(len)];
                }
            }
            RandomListNode clone = s.Clone(head);
            RandomListNode p = head;
            RandomListNode cp = clone;
            while(p != null && cp != null)
            {
                if (set.Contains(cp)) return false;
                if (p.label != cp.label) return false;
                if(p.random != null || cp.random != null)
                {
                    if (p.random == null) return false;
                    if (cp.random == null) return false;
                    if (set.Contains(cp.random)) return false;
                    if (p.random.label != cp.random.label) return false;
                }
                p = p.next;
                cp = cp.next;
            }
            if (p != null) return false;
            if (cp != null) return false;
            return true;
        }
    }
}