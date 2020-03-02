// 栈 树 二叉搜索树的后序遍历序列
namespace VerifySquenceOfBST
{
    class Solution
    {
        public bool VerifySquenceOfBST(int[] sequence)
        {
            // write code here
            if (sequence == null || sequence.Length <= 0) return false;
            return VerifySquenceOfBST(sequence, 0, sequence.Length);
        }

        private bool VerifySquenceOfBST(int[] sequence, int start, int len)
        {
            if (len < 4) return true;
            int root = sequence[len - 1];
            int i;
            for(i = 0; i < len - 1; i++)
            {
                if (sequence[i] == root) return false;
                if (sequence[i] > root) break;
            }
            for(; i < len - 1; i++)
            {
                if (sequence[i] <= root) return false;
            }
            int start1 = start;
            int len1 = i - start;
            int start2 = i;
            int len2 = len - 1 - i;
            return VerifySquenceOfBST(sequence, start1, len1)
                && VerifySquenceOfBST(sequence, start2, len2);
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            int[] seq1 = { 1, 4, 3, 2, 7, 6, 9, 8, 5 };
            int[] seq2 = { 1, 2, 8, 5 };
            int[] seq3 = { 1, 8, 2, 5 };
            if (s.VerifySquenceOfBST(seq1) == false) return false;
            if (s.VerifySquenceOfBST(seq2) == false) return false;
            if (s.VerifySquenceOfBST(seq3) == true) return false;
            return true;
        }
    }
}