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