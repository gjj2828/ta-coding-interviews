using System;
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

    // first
    //class Solution
    //{
    //    private struct NodeInfo
    //    {
    //        public TreeNode node;
    //        public List<int> path;
    //        public int sum;
    //    }

    //    public List<List<int>> FindPath(TreeNode root, int expectNumber)
    //    {
    //        // write code here
    //        List<List<int>> paths = new List<List<int>>();
    //        Queue queue = new Queue();
    //        if (root != null)
    //        {
    //            NodeInfo info = new NodeInfo();
    //            info.node = root;
    //            info.path = new List<int>();
    //            info.path.Add(root.val);
    //            info.sum = root.val;
    //            queue.Enqueue(info);
    //        }
    //        FindPath(queue, expectNumber, paths);
    //        return paths;
    //    }

    //    private void FindPath(Queue queue, int expectNumber, List<List<int>> paths)
    //    {
    //        if (queue.Count <= 0) return;
    //        NodeInfo info = (NodeInfo)queue.Dequeue();
    //        Enqueue(queue, info.node.left, info);
    //        Enqueue(queue, info.node.right, info);
    //        FindPath(queue, expectNumber, paths);
    //        if (info.sum == expectNumber)
    //        {
    //            paths.Add(info.path);
    //        }
    //    }

    //    private void Enqueue(Queue queue, TreeNode node, NodeInfo parentInfo)
    //    {
    //        if (node == null) return;
    //        NodeInfo info = new NodeInfo();
    //        info.node = node;
    //        info.path = new List<int>(parentInfo.path);
    //        info.path.Add(node.val);
    //        info.sum = parentInfo.sum + node.val;
    //        queue.Enqueue(info);
    //    }
    //}

    //class Test: TestBase
    //{
    //    public override bool Run()
    //    {
    //        //     ____9____
    //        //    |         |
    //        //  __8__     __7__
    //        // |     |   |     |
    //        // 5    _4   6_    2
    //        //     |       |
    //        //     1       3
    //        int[] pre = { 9, 8, 5, 4, 1, 7, 6, 3, 2 };
    //        int[] tin = { 5, 8, 1, 4, 9, 6, 3, 7, 2 };
    //        TreeNode root = reConstructBinaryTree(pre, tin);
    //        int expectNumber = 22;
    //        Solution s = new Solution();
    //        List<List<int>> paths = s.FindPath(root, expectNumber);
    //        int count = paths.Count;
    //        if (count < 3) return false;
    //        for(int i = 0; i < count; i++)
    //        {
    //            List<int> path = paths[i];
    //            int sum = 0;
    //            for(int j = 0; j < path.Count; j++)
    //            {
    //                sum += path[j];
    //            }
    //            if (sum != expectNumber) return false;
    //        }
    //        return true;
    //    }
    //}

    // second
    //class Solution
    //{
    //    private struct NodeInfo
    //    {
    //        public TreeNode node;
    //        public List<int> path;
    //        public int sum;
    //    }

    //    public List<List<int>> FindPath(TreeNode root, int expectNumber)
    //    {
    //        // write code here
    //        List<List<int>> paths = new List<List<int>>();
    //        Queue queue = new Queue();
    //        if (root != null)
    //        {
    //            NodeInfo info = new NodeInfo();
    //            info.node = root;
    //            info.path = new List<int>();
    //            info.path.Add(root.val);
    //            info.sum = root.val;
    //            queue.Enqueue(info);
    //        }
    //        FindPath(queue, expectNumber, paths);
    //        return paths;
    //    }

    //    private void FindPath(Queue queue, int expectNumber, List<List<int>> paths)
    //    {
    //        if (queue.Count <= 0) return;
    //        NodeInfo info = (NodeInfo)queue.Dequeue();
    //        Enqueue(queue, info.node.left, info);
    //        Enqueue(queue, info.node.right, info);
    //        FindPath(queue, expectNumber, paths);
    //        if (info.node.left == null && info.node.right == null
    //            && info.sum == expectNumber)
    //        {
    //            paths.Add(info.path);
    //        }
    //    }

    //    private void Enqueue(Queue queue, TreeNode node, NodeInfo parentInfo)
    //    {
    //        if (node == null) return;
    //        NodeInfo info = new NodeInfo();
    //        info.node = node;
    //        info.path = new List<int>(parentInfo.path);
    //        info.path.Add(node.val);
    //        info.sum = parentInfo.sum + node.val;
    //        queue.Enqueue(info);
    //    }
    //}

    // third
    class Solution
    {
        public List<List<int>> FindPath(TreeNode root, int expectNumber)
        {
            // write code here
            List<List<int>> paths = new List<List<int>>();
            FindPath(root, expectNumber, paths, new List<int>(), 0);
            return paths;
        }

        private void FindPath(TreeNode node, int expectNumber
            , List<List<int>> paths, List<int> path, int sum)
        {
            if (node == null) return;
            path.Add(node.val);
            sum += node.val;
            if (node.left == null && node.right == null)
            {
                if (sum == expectNumber)
                {
                    int len = path.Count;
                    int cnt = paths.Count;
                    int idx;
                    for (idx = 0; idx < cnt; idx++)
                    {
                        if (paths[idx].Count <= len) break;
                    }
                    paths.Insert(idx, new List<int>(path));
                }
            }
            else
            {
                FindPath(node.left, expectNumber, paths, path, sum);
                FindPath(node.right, expectNumber, paths, path, sum);
            }
            path.RemoveAt(path.Count - 1);
        }
    }

    class Test : TestBase
    {
        public override bool Run()
        {
            //TreeNode[] roots =
            //{
            //    // first
            //    //     ____9____
            //    //    |         |
            //    //  __8__     __7__
            //    // |     |   |     |
            //    // 5    _4   6_    2
            //    //     |       |
            //    //     1       3
            //    reConstructBinaryTree(new int[]{ 9, 8, 5, 4, 1, 7, 6, 3, 2 }
            //        , new int[]{ 5, 8, 1, 4, 9, 6, 3, 7, 2 })
            //    // second
            //    //     ____9____
            //    //    |         |
            //    //  __8__     __7__
            //    // |     |   |     |
            //    // 5    _4   6    _2
            //    //     |         |
            //    //     1         3
            //    , reConstructBinaryTree(new int[]{ 9, 8, 5, 4, 1, 7, 6, 2, 3 }
            //        , new int[] { 5, 8, 1, 4, 9, 6, 7, 3, 2 })
            //};
            TreeNode[] roots =
            {
                // first
                reConstructBinaryTree(pts[3])
                // second
                , reConstructBinaryTree(pts[4])
            };
            int expectNumber = 22;
            int[][][] results =
            {
                // first
                new int[][]
                {
                      new int[] {9, 8, 4, 1}
                    , new int[] {9, 8, 5}
                }
                // second
                , new int[][]
                {
                      new int[] {9, 8, 4, 1}
                    , new int[] {9, 8, 5}
                    , new int[] {9, 7, 6}
                }
            };
            Solution s = new Solution();
            int sampleNum = Math.Min(roots.Length, results.Length);
            for(int i = 0; i < sampleNum; i++)
            {
                if (Check(s, roots[i], expectNumber, results[i]) == false) return false;
            }
            return true;
        }

        bool Check(Solution s, TreeNode root, int expectNumber, int[][] results)
        {
            List<List<int>> paths = s.FindPath(root, expectNumber);
            if (paths.Count != results.Length) return false;
            for(int i = 1; i < paths.Count; i++)
            {
                if (paths[i].Count > paths[i - 1].Count) return false;
            }
            foreach(int[] result in results)
            {
                bool found = false;
                foreach(List<int> path in paths)
                {
                    if(IsEqual(path.ToArray(), result))
                    {
                        found = true;
                        break;
                    }
                }
                if (found == false) return false;
            }
            return true;
        }
    }
}