using System;
using System.Collections;

// 栈 栈的压入、弹出序列
namespace IsPopOrder
{
    class Solution
    {
        //public bool IsPopOrder(int[] pushV, int[] popV)
        //{
        //    // write code heres
        //    if (pushV == null && popV == null) return true;
        //    if (pushV == null || popV == null) return false;
        //    if (pushV.Length != popV.Length) return false;
        //    return IsPopOrder(pushV, popV, 0, 0, Math.Min(pushV.Length, popV.Length));
        //}

        //private bool IsPopOrder(int[] pushV, int[] popV, int pushStart
        //    , int popStart, int len)
        //{
        //    if (len <= 0) return true;
        //    if (len == 1) return pushV[pushStart] == popV[popStart];
        //    int pushStop = pushStart + len;
        //    int pop_in_push;
        //    for(pop_in_push = pushStart; pop_in_push < pushStop; pop_in_push++)
        //    {
        //        if (pushV[pop_in_push] == popV[popStart]) break;
        //    }
        //    if (pop_in_push >= pushStop) return false;
        //    int len1 = pop_in_push - pushStart;
        //    int len2 = len - len1 - 1;
        //    int pushStart1 = pushStart;
        //    int pushStart2 = pop_in_push + 1;
        //    int popStart1 = popStart + len2 + 1;
        //    int popStart2 = popStart + 1;
        //    return IsPopOrder(pushV, popV, pushStart1, popStart1, len1)
        //        && IsPopOrder(pushV, popV, pushStart2, popStart2, len2);
        //}

        public bool IsPopOrder(int[] pushV, int[] popV)
        {
            // write code heres
            if (pushV == null && popV == null) return true;
            if (pushV == null || popV == null) return false;
            if (pushV.Length != popV.Length) return false;
            return IsPopOrder(pushV, popV, 0, 0, Math.Min(pushV.Length, popV.Length));
        }

        private bool IsPopOrder(int[] pushV, int[] popV, int pushStart
            , int popStart, int len)
        {
            if (len <= 0) return true;
            if (len == 1) return pushV[pushStart] == popV[popStart];
            int popStop = popStart + len;
            int push_in_pop;
            for (push_in_pop = popStart; push_in_pop < popStop; push_in_pop++)
            {
                if (popV[push_in_pop] == pushV[pushStart]) break;
            }
            if (push_in_pop >= popStop) return false;
            int len1 = push_in_pop - popStart;
            int len2 = len - len1 - 1;
            int pushStart1 = pushStart + 1;
            int pushStart2 = pushStart + len1 + 1;
            int popStart1 = popStart;
            int popStart2 = push_in_pop + 1;
            return IsPopOrder(pushV, popV, pushStart1, popStart1, len1)
                && IsPopOrder(pushV, popV, pushStart2, popStart2, len2);
        }

        //public bool IsPopOrder(int[] pushV, int[] popV)
        //{
        //    // write code heres
        //    if (pushV == null && popV == null) return true;
        //    if (pushV == null || popV == null) return false;
        //    if (pushV.Length != popV.Length) return false;

        //    Stack s = new Stack();
        //    int len = Math.Min(pushV.Length, popV.Length);
        //    for (int i = 0, j = 0; i < len && j < len; i++)
        //    {
        //        if (pushV[i] == popV[j])
        //        {
        //            for (j++; j < len && s.Count > 0; j++)
        //            {
        //                if (popV[j] != (int)s.Peek()) break;
        //                s.Pop();
        //            }
        //        }
        //        else
        //        {
        //            s.Push(pushV[i]);
        //        }
        //    }
        //    return s.Count == 0;
        //}
    }

    class Test: TestBase
    {
        public override bool Run()
        {
            Solution s = new Solution();
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5 }
                , new int[] { 4, 5, 3, 2, 1 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5 }
                , new int[] { 4, 3, 5, 2, 1 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5 }
                , new int[] { 4, 3, 5, 1, 2 }) == true) return false;
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
                , new int[] { 4, 6, 8, 7, 5, 3, 2, 1 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
                , new int[] { 4, 6, 7, 8, 5, 3, 2, 1 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }
                , new int[] { 4, 5, 3, 6, 2, 7, 1, 8 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2 }
                , new int[] { 1, 2 }) == false) return false;
            if (s.IsPopOrder(new int[] { 1, 2 }
                , new int[] { 2, 1 }) == false) return false;
            return true;
        }
    }
}