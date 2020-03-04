using System;
using System.Collections.Generic;

// 链表 树 二叉搜索树与双向链表
namespace Convert
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
        public TreeNode Convert(TreeNode pRootOfTree)
        {
            // write code here
            TreeNode min = null, max = null;
            Convert(pRootOfTree, ref min, ref max);
            return min;
        }

        private void Convert(TreeNode node, ref TreeNode min, ref TreeNode max)
        {
            if (node == null) return;

            min = node;
            max = node;
            TreeNode lmax = null, rmin = null;
            Convert(node.left, ref min, ref lmax);
            if(lmax != null)
            {
                node.left = lmax;
                lmax.right = node;
            }
            Convert(node.right, ref rmin, ref max);
            if(rmin != null)
            {
                node.right = rmin;
                rmin.left = node;
            }
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] pre = { 5, 2, 1, 3, 4, 8, 6, 7, 9 };
            int[] tin = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            TreeNode root = reConstructBinaryTree(pre, tin);
            TreeNode head = s.Convert(root);
            TreeNode[] roots =
            {
                //     ____5____
                //    |         |
                //  __2__     __8__
                // |     |   |     |
                // 1     3_  6_    9
                //         |   |
                //         4   7
                reConstructBinaryTree(new int[]{ 5, 2, 1, 3, 4, 8, 6, 7, 9 }
                    , new int[]{ 1, 2, 3, 4, 5, 6, 7, 8, 9 })
                //     ____5____
                //    |         |
                //  __2         8
                // |
                // 1
                , reConstructBinaryTree(new int[]{ 5, 2, 1, 8 }
                    , new int[]{ 1, 2, 5, 8 })
            };
            int[][] results =
            {
                  new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }
                , new int[] { 1, 2, 5, 8 }
            };
            int sampleNum = Math.Min(roots.Length, results.Length);
            for(int i = 0; i < sampleNum; i++)
            {
                if (Check(s, roots[i], results[i]) == false) return false;
            }
            return true;
        }

        private bool Check(Solution s, TreeNode root, int[] result)
        {
            Dictionary<int, TreeNode> map = new Dictionary<int, TreeNode>();
            Traverse(root, map);

            TreeNode head = s.Convert(root);

            TreeNode p = head;

            int len = result.Length;
            for (int i = 0; i < len; i++, p = p.right)
            {
                if (p == null) return false;
                if (p != map[result[i]]) return false;
                if(i > 0)
                {
                    if (p.left != map[result[i - 1]]) return false;
                }
                else
                {
                    if (p.left != null) return false;
                }
                if(i < len - 1)
                {
                    if (p.right != map[result[i + 1]]) return false;
                }
                else
                {
                    if (p.right != null) return false;
                }
            }

            return true;
        }

        private void Traverse(TreeNode root, Dictionary<int, TreeNode> map)
        {
            if (root == null) return;

            map[root.val] = root;
            Traverse(root.left, map);
            Traverse(root.right, map);
        }
    }
}