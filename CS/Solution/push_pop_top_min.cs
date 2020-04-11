/****************************************************************
 * Project: coding-interviews
 * File: push_pop_top_min.cs
 * Create Date: 2020/02/01
 * Author: Gao Jiongjiong
 * Descript: push_pop_top_min algorithm.
****************************************************************/

using System;
using System.Collections;

// 栈 包含min函数的栈
namespace push_pop_top_min
{
    class Solution
    {
        private Stack mStack = new Stack();
        private Stack mStackMin = new Stack();

        public void push(int node)
        {
            mStack.Push(node);
            if(mStackMin.Count <= 0 || node <= (int)mStackMin.Peek())
            {
                mStackMin.Push(node);
            }
        }
        public void pop()
        {
            int node = (int)mStack.Pop();
            if(node == (int)mStackMin.Peek())
            {
                mStackMin.Pop();
            }
        }
        public int top()
        {
            return (int)mStack.Peek();
        }
        public int min()
        {
            return (int)mStackMin.Peek();
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Stack stack = new Stack();
            Random rnd = new Random();
            for(int i = 0; i < 1000; i++)
            {
                if(stack.Count < 10)
                {
                    int node = rnd.Next();
                    s.push(node);
                    stack.Push(node);
                }
                else
                {
                    int r = rnd.Next();
                    if(r < 25)
                    {
                        int node = rnd.Next();
                        s.push(node);
                        stack.Push(node);
                    }
                    else if(r < 50)
                    {
                        s.pop();
                        stack.Pop();
                    }
                    else if(r < 75)
                    {
                        if (s.top() != (int)stack.Peek()) return false;
                    }
                    else
                    {
                        if (s.min() != Min(stack)) return false;
                    }
                }
            }
            while(stack.Count > 0)
            {
                if (s.top() != (int)stack.Peek()) return false;
                if (s.min() != Min(stack)) return false;
                s.pop();
                stack.Pop();
            }
            return true;
        }

        private int Min(Stack s)
        {
            int min = int.MaxValue;
            foreach(int i in s)
            {
                if(i < min)
                {
                    min = i;
                }
            }
            return min;
        }
    }
}