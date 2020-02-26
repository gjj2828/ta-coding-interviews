using System;
using System.Collections;

// 用两个栈实现队列
namespace push_pop
{
    class Solution
    {
        private Stack mStackPush = new Stack();
        private Stack mStackPop = new Stack();

        public void push(int node)
        {
            while(mStackPop.Count > 0)
            {
                mStackPush.Push(mStackPop.Pop());
            }
            mStackPush.Push(node);
        }
        public int pop()
        {
            while(mStackPush.Count > 0)
            {
                mStackPop.Push(mStackPush.Pop());
            }
            return (int)mStackPop.Pop();
        }
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            Queue q = new Queue();
            Random rnd = new Random();
            for(int i = 0; i < 100; i++)
            {
                int num = rnd.Next(1, 10);
                if (rnd.Next(100) < 50)
                {
                    for(int j = 0; j < num; j++)
                    {
                        int node = rnd.Next();
                        q.Enqueue(node);
                        s.push(node);
                    }
                }
                else
                {
                    for(int j = 0; j < num; j++)
                    {
                        if (!PopCheck(q, s)) return false;
                    }
                }
            }
            int remain = q.Count + 10;
            for(int i = 0; i < remain; i++)
            {
                if (!PopCheck(q, s)) return false;
            }
            return true;
        }

        private int Dequeue(Queue q)
        {
            int node;
            try
            {
                node = (int)q.Dequeue();
            }
            catch (InvalidOperationException e)
            {
                _ = e;
                node = -1;
            }
            return node;
        }

        private int pop(Solution s)
        {
            int node;
            try
            {
                node = s.pop();
            }
            catch (InvalidOperationException e)
            {
                _ = e;
                node = -1;
            }
            return node;
        }

        private bool PopCheck(Queue q, Solution s)
        {
            int qnode = Dequeue(q);
            int snode = pop(s);
            return qnode == snode;
        }
    }
}