// 树 二叉树的镜像
namespace Mirror
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
        public TreeNode Mirror(TreeNode root)
        {
            // write code here
            if (root == null) return null;
            TreeNode t = root.left;
            root.left = root.right;
            root.right = t;
            Mirror(root.left);
            Mirror(root.right);
            return root;
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] opre = { 8, 6, 5, 7, 10, 9, 11 };
            int[] otin = { 5, 6, 7, 8, 9, 10, 11 };
            int[] mpre = { 8, 10, 11, 9, 6, 7, 5 };
            int[] mtin = { 11, 10, 9, 8, 7, 6, 5 };
            TreeNode origin = reConstructBinaryTree(opre, otin);
            TreeNode mirror = reConstructBinaryTree(mpre, mtin);
            return IsEqual(s.Mirror(origin), mirror);
        }
    }
}