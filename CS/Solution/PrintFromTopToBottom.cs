using System.Collections;
using System.Collections.Generic;

// 队列 树 从上往下打印二叉树
namespace PrintFromTopToBottom
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
        public List<int> PrintFromTopToBottom(TreeNode root)
        {
            // write code here
            if (root == null) return null;
            List<int> ret = new List<int>();
            Queue q = new Queue();
            q.Enqueue(root);
            while(q.Count > 0)
            {
                TreeNode node = (TreeNode)q.Dequeue();
                ret.Add(node.val);
                if (node.left != null) q.Enqueue(node.left);
                if (node.right != null) q.Enqueue(node.right);
            }
            return ret;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            TreeNode root = CreateTreeSample();
            List<int> l = s.PrintFromTopToBottom(root);
            for (int i = 0; i < l.Count; i++)
            {
                if (l[i] != (i + 1)) return false;
            }
            return true;
        }
    }
}