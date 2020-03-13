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

    protected void Print<T>(IEnumerable<T> l)
    {
        foreach(T i in l)
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

    //     ____1____
    //    |         |
    //  __2       __3__
    // |         |     |
    // 4_        5    _6
    //   |           |
    //   7           8
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

    protected TreeNode reConstructBinaryTree(int[] pre, int[] tin)
    {
        // write code here
        if (pre.Length <= 0) return null;
        if (pre.Length != tin.Length) return null;
        int val = pre[0];
        int index = -1;
        for (int i = 0; i < tin.Length; i++)
        {
            if (tin[i] == val)
            {
                index = i;
                break;
            }
        }
        if (index < 0) return null;
        TreeNode node = new TreeNode(val);
        int lcount = index;
        int rcount = tin.Length - index - 1;
        if (lcount > 0)
        {
            //ArraySegment<int> lpre = new ArraySegment<int>(pre, 1, lcount);
            //ArraySegment<int> ltin = new ArraySegment<int>(tin, 0, lcount);
            //node.left = reConstructBinaryTree(lpre.Array, ltin.Array);
            int[] lpre = new int[lcount];
            int[] ltin = new int[lcount];
            Array.Copy(pre, 1, lpre, 0, lcount);
            Array.Copy(tin, 0, ltin, 0, lcount);
            node.left = reConstructBinaryTree(lpre, ltin);
        }
        if (rcount > 0)
        {
            //ArraySegment<int> rpre = new ArraySegment<int>(pre, lcount + 1, rcount);
            //ArraySegment<int> rtin = new ArraySegment<int>(tin, index + 1, rcount);
            //node.right = reConstructBinaryTree(rpre.Array, rtin.Array);
            int[] rpre = new int[rcount];
            int[] rtin = new int[rcount];
            Array.Copy(pre, lcount + 1, rpre, 0, rcount);
            Array.Copy(tin, index + 1, rtin, 0, rcount);
            node.right = reConstructBinaryTree(rpre, rtin);
        }
        return node;
    }

    protected int[][] CreateMatrix(int[] list, int col)
    {
        if (list == null || list.Length <= 0 || col <= 0 || list.Length % col != 0)
            return null;
        int row = list.Length / col;
        int[][] matrix = new int[row][];
        for(int i = 0; i < row; i++)
        {
            matrix[i] = new int[col];
            for(int j = 0; j < col; j++)
            {
                matrix[i][j] = list[i * col + j];
            }
        }
        return matrix;
    }

    protected bool IsEqual(int[] l1, int[] l2)
    {
        if (l1 == null && l2 == null) return true;
        if (l1 == null || l2 == null) return false;
        if (l1.Length != l2.Length) return false;
        int len = Math.Min(l1.Length, l2.Length);
        for(int i = 0; i < len; i++)
        {
            if (l1[i] != l2[i]) return false;
        }
        return true;
    }

    protected int[] ToDigits(int number)
    {
        int len = CalcDigitLen(number);
        if (len <= 0) return null;
        int[] digits = new int[len];
        for (int i = 0; i < len; i++)
        {
            digits[len - i - 1] = number % 10;
            number /= 10;
        }
        return digits;
    }

    protected int CalcDigitLen(int number)
    {
        int len = 0;
        while (number > 0)
        {
            len++;
            number /= 10;
        }
        return len;
    }
}