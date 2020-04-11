/****************************************************************
 * Project: coding-interviews
 * File: IsBalanced_Solution.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: IsBalanced_Solution algorithm.
****************************************************************/

using System;

namespace IsBalanced_Solution
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
        public bool IsBalanced_Solution(TreeNode pRoot)
        {
            // write code here
            if (pRoot == null) return false;
            int depth;
            return IsBalancedTree(pRoot, out depth);
        }

        private bool IsBalancedTree(TreeNode node, out int depth)
        {
            depth = 0;
            if(node == null) return true;
            int ld;
            if (IsBalancedTree(node.left, out ld) == false) return false;
            int rd;
            if (IsBalancedTree(node.right, out rd) == false) return false;
            if (Math.Abs(rd - ld) > 1) return false;
            depth = Math.Max(ld, rd) + 1;
            return true;
        }

        public int TreeDepth(TreeNode pRoot)
        {
            // write code here
            if (pRoot == null) return 0;
            return 1 + Math.Max(TreeDepth(pRoot.left), TreeDepth(pRoot.right));
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            bool[] results = { false, true, true, true, true, true, true };
            int len = Math.Min(pts.Length, results.Length);
            for(int i = 0; i < len; i++)
            {
                if (s.IsBalanced_Solution(reConstructBinaryTree(pts[i]))
                    != results[i]) return false;
            }
            return true;
        }
    }
}