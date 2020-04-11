/****************************************************************
 * Project: coding-interviews
 * File: HasSubtree.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: HasSubtree algorithm.
****************************************************************/

// 二叉树 树的子结构
namespace HasSubtree
{
    /*
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x)
        {
            val = x;
        }
    }*/

    class Solution
    {
        public bool HasSubtree(TreeNode pRoot1, TreeNode pRoot2)
        {
            // write code here
            if (pRoot1 == null || pRoot2 == null) return false;
            if (IsEqual(pRoot1, pRoot2)) return true;
            return HasSubtree(pRoot1.left, pRoot2) || HasSubtree(pRoot1.right, pRoot2);
        }

        private bool IsEqual(TreeNode n1, TreeNode n2)
        {
            if (n1 == null && n2 == null) return true;
            if (n1 == null && n2 != null || n1 != null && n2 == null) return false;
            if (n1.val != n2.val) return false;
            return IsEqual(n1.left, n2.left) && IsEqual(n1.right, n2.right);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            TreeNode root = CreateTreeSample();
            TreeNode p = root;
            while(p != null)
            {
                if (s.HasSubtree(root, p) == false) return false;
                p = p.left;
            }
            if (s.HasSubtree(root, null) == true) return false;
            if (s.HasSubtree(null, root) == true) return false;
            if (s.HasSubtree(null, null) == true) return false;
            if (s.HasSubtree(root.left, root.right) == true) return false;
            return true;
        }
    }
}