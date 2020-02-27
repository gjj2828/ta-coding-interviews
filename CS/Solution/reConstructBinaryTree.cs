using System;

// 树 重建二叉树
namespace reConstructBinaryTree
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int x)
        {
            val = x;
        }
    }
    class Solution
    {
        //public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        //{
        //    // write code here
        //    if (pre.Length != tin.Length) return null;
        //    return reConstructBinaryTree(pre, tin, 0, 0, pre.Length);
        //}

        //private TreeNode reConstructBinaryTree(int[] pre, int[] tin, int ppos, int tpos, int length)
        //{
        //    if (length <= 0) return null;
        //    TreeNode node = new TreeNode(pre[ppos]);
        //    int llen;
        //    for (llen = 0; llen < length; llen++)
        //    {
        //        if (tin[tpos + llen] == node.val) break;
        //    }
        //    int rlen = length - 1 - llen;
        //    node.left = reConstructBinaryTree(pre, tin, ppos + 1, tpos, llen);
        //    node.right = reConstructBinaryTree(pre, tin, ppos + 1 + llen, tpos + llen + 1, rlen);
        //    return node;
        //}

        public TreeNode reConstructBinaryTree(int[] pre, int[] tin)
        {
            // write code here
            if (pre.Length <= 0) return null;
            if (pre.Length != tin.Length) return null;
            int val = pre[0];
            int index = -1;
            for(int i  = 0; i < tin.Length; i++)
            {
                if(tin[i] == val)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0) return null;
            TreeNode node = new TreeNode(val);
            int lcount = index;
            int rcount = tin.Length - index - 1;
            if(lcount > 0)
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
            if(rcount > 0)
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
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int num = 8;
            TreeNode[] nodes = new TreeNode[8];
            for(int i = 0; i < num; i++)
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
            int[] pre = new int[] { 1, 2, 4, 7, 3, 5, 6, 8 };
            int[] tin = new int[] { 4, 7, 2, 1, 5, 3, 8, 6 };
            return IsEqual(s.reConstructBinaryTree(pre, tin), nodes[0]);
        }

        private bool IsEqual(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null && n2 != null || n1 != null && n2 == null) return false;
            if (n1.val != n2.val) return false;
            return IsEqual(n1.left, n2.left) && IsEqual(n1.right, n2.right);
        }
    }
}