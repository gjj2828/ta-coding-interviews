using System;
using System.Collections.Generic;

abstract class TestBase: ITest
{
    public abstract bool Run();

    protected void Print(int[][] array)
    {
        for(int i = 0; i < array.Length; i++)
        {
            int[] row = array[i];
            for(int j = 0; j < row.Length; j++)
            {
                Console.Write("{0}\t", array[i][j]);
            }
            Console.WriteLine();
        }
    }

    protected void Print(IEnumerable<int> l)
    {
        foreach(int i in l)
        {
            Console.Write("{0}\t", i);
        }
        Console.WriteLine();
    }

    protected void Print(ListNode head)
    {
        ListNode p = head;
        while (p != null)
        {
            Console.Write("{0}\t", p.val);
            p = p.next;
        }
        Console.WriteLine();
    }

    protected ListNode CreateList(int[] l)
    {
        if (l == null || l.Length <= 0) return null;
        ListNode head = new ListNode(l[0]);
        ListNode p = head;
        for(int i = 1; i < l.Length; i++)
        {
            p.next = new ListNode(l[i]);
            p = p.next;
        }
        return head;
    }
}