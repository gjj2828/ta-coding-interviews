/****************************************************************
 * Project: coding-interviews
 * File: TreeDepth.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: TreeDepth algorithm.
****************************************************************/

using System;

// 树 二叉树的深度
namespace TreeDepth
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
            if (s.TreeDepth(CreateTreeSample()) != 4) return false;
            return true;
        }
    }
}