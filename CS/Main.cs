using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Test<Find.Test>();
        Test<replaceSpace.Test>();
        Test<printListFromTailToHead.Test>();
        Test<reConstructBinaryTree.Test>();
        Test<push_pop.Test>();
        Test<minNumberInRotateArray.Test>();
        Test<Fibonacci.Test>();
        Test<jumpFloor.Test>();
        Test<jumpFloorII.Test>();
        Test<rectCover.Test>();
        Test<NumberOf1.Test>();
        Test<Power.Test>();
        Test<reOrderArray.Test>();
        Test<FindKthToTail.Test>();
        Test<ReverseList.Test>();
        Test<Merge.Test>();
        Test<HasSubtree.Test>();
        Test<Mirror.Test>();
        Test<printMatrix.Test>();
        Test<push_pop_top_min.Test>();
        Test<IsPopOrder.Test>();
        Test<PrintFromTopToBottom.Test>();
        Test<VerifySquenceOfBST.Test>();
        Test<FindPath.Test>();
        Test<Clone.Test>();
        Test<Convert.Test>();
        Test<Permutation.Test>();
        Test<MoreThanHalfNum_Solution.Test>();
        Test<GetLeastNumbers_Solution.Test>();
        Test<FindGreatestSumOfSubArray.Test>();
        Test<NumberOf1Between1AndN_Solution.Test>();
        Test<PrintMinNumber.Test>();
        Test<GetUglyNumber_Solution.Test>();
        Test<FirstNotRepeatingChar.Test>();
        Test<InversePairs.Test>();
    }

    private static void Test<T>() where T: ITest, new()
    {
        string taskName = "Test " + typeof(T).Namespace;
        Console.WriteLine("**** Begin {0} ****", taskName);
        T t = new T();
        if(t.Run())
        {
            Console.WriteLine(taskName + " Pass");
        }
        else
        {
            Console.WriteLine(taskName + " Fail");
        }
        Console.WriteLine("**** End {0} ****", taskName);
    }
}