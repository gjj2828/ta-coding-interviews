/****************************************************************
 * Project: coding-interviews
 * File: Common.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: Common class.
****************************************************************/

public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x)
    {
        val = x;
    }
}

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

public class RandomListNode
{
    public int label;
    public RandomListNode next, random;
    public RandomListNode(int x)
    {
        this.label = x;
    }
}