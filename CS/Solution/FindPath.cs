using System.Collections;
using System.Collections.Generic;

// 树 二叉树中和为某一值的路径
namespace FindPath
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
        private struct NodeInfo
        {
            public TreeNode node;
            public List<int> path;
            public int sum;
        }

        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            // write code here
            List<List<int>> paths = new List<List<int>>();
            Queue queue = new Queue();
            if (root != null)
            {
                NodeInfo info = new NodeInfo();
                info.node = root;
                info.path = new List<int>();
                info.path.Add(root.val);
                info.sum = root.val;
                queue.Enqueue(info);
            }
            FindPath(queue, expectNumber, paths);
            return paths;
        }

        private void FindPath(Queue queue, int expectNumber, List<List<int>> paths)
        {
            if (queue.Count <= 0) return;
            NodeInfo info = (NodeInfo)queue.Dequeue();
            Enqueue(queue, info.node.left, info);
            Enqueue(queue, info.node.right, info);
            FindPath(queue, expectNumber, paths);
            if(info.sum == expectNumber)
            {
                paths.Add(info.path);
            }
        }

        private void Enqueue(Queue queue, TreeNode node, NodeInfo parentInfo)
        {
            if (node == null) return;
            NodeInfo info = new NodeInfo();
            info.node = node;
            info.path = new List<int>(parentInfo.path);
            info.path.Add(node.val);
            info.sum = parentInfo.sum + node.val;
            queue.Enqueue(info);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            //     ____9____
            //    |         |
            //  __8__     __7__
            // |     |   |     |
            // 5    _4   6_    2
            //     |       |
            //     1       3
            int[] pre = { 9, 8, 5, 4, 1, 7, 6, 3, 2 };
            int[] tin = { 5, 8, 1, 4, 9, 6, 3, 7, 2 };
            TreeNode root = reConstructBinaryTree(pre, tin);
            int expectNumber = 22;
            Solution s = new Solution();
            List<List<int>> paths = s.FindPath(root, expectNumber);
            int count = paths.Count;
            if (count < 3) return false;
            for(int i = 0; i < count; i++)
            {
                List<int> path = paths[i];
                int sum = 0;
                for(int j = 0; j < path.Count; j++)
                {
                    sum += path[j];
                }
                if (sum != expectNumber) return false;
            }
            return true;
        }
    }
}