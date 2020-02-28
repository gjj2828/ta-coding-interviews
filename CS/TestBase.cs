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

    protected bool IsEqual(TreeNode n1, TreeNode n2)
    {
        if (n1 == null && n2 == null) return true;
        if (n1 == null && n2 != null || n1 != null && n2 == null) return false;
        if (n1.val != n2.val) return false;
        return IsEqual(n1.left, n2.left) && IsEqual(n1.right, n2.right);
    }

    protected TreeNode CreateTreeSample()
    {
        int num = 8;
        TreeNode[] nodes = new TreeNode[8];
        for (int i = 0; i < num; i++)
        {
            nodes[i] = new TreeNode(i + 1);
        }
        nodes[0].left = nodes[1];
        nodes[0].right = nodes[2];
        nodes[1].left = nodes[3];
        nodes[2].left = nodes[4];
        nodes[2].right = nodes[5];
        nodes[3].right = nodes[6];
        nodes[5].left = nodes[7];
        return nodes[0];
    }
}