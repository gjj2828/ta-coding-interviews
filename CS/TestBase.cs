using System;
using System.Collections.Generic;

abstract class TestBase : ITest
{
    protected int[][][] pts =
    {
        // 0
        //     ____1____
        //    |         |
        //  __2       __3__
        // |         |     |
        // 4_        5    _6
        //   |           |
        //   7           8
        new int[][]
        {
            new int[]{ 1, 2, 4, 7, 3, 5, 6, 8 },
            new int[]{ 4, 7, 2, 1, 5, 3, 8, 6 }
        }
        // 1
        //     ____5____
        //    |         |
        //  __2__     __8__
        // |     |   |     |
        // 1     3_  6_    9
        //         |   |
        //         4   7
        , new int[][]
        {
            new int[]{ 5, 2, 1, 3, 4, 8, 6, 7, 9 },
            new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 }
        }
        // 2
        //     ____5____
        //    |         |
        //  __2         8
        // |
        // 1
        , new int[][]
        {
            new int[]{ 5, 2, 1, 8 },
            new int[]{ 1, 2, 5, 8 }
        }
        // 3
        //     ____9____
        //    |         |
        //  __8__     __7__
        // |     |   |     |
        // 5    _4   6_    2
        //     |       |
        //     1       3
        , new int[][]
        {
            new int[]{ 9, 8, 5, 4, 1, 7, 6, 3, 2 },
            new int[]{ 5, 8, 1, 4, 9, 6, 3, 7, 2 }
        }
        // 4
        //     ____9____
        //    |         |
        //  __8__     __7__
        // |     |   |     |
        // 5    _4   6    _2
        //     |         |
        //     1         3
        , new int[][]
        {
            new int[]{ 9, 8, 5, 4, 1, 7, 6, 2, 3 },
            new int[]{ 5, 8, 1, 4, 9, 6, 7, 3, 2 }
        }
        // 5
        //     ____8____
        //    |         |
        //  __6__     __10_
        // |     |   |     |
        // 5     7   9     11
        , new int[][]
        {
            new int[]{ 8, 6, 5, 7, 10, 9, 11 },
            new int[]{ 5, 6, 7, 8, 9, 10, 11 }
        }
        // 6
        //     ____8____
        //    |         |
        //  __10_     __6__
        // |     |   |     |
        // 11    9   7     5
        , new int[][]
        {
            new int[]{ 8, 10, 11, 9, 6, 7, 5 },
            new int[]{ 11, 10, 9, 8, 7, 6, 5 }
        }
    };

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

    protected TreeNode reConstructBinaryTree(int[][] pt)
    {
        return reConstructBinaryTree(pt[0], pt[1]);
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