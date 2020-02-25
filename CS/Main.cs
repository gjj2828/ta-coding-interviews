using System;

class MainClass
{
    public static void Main(string[] args)
    {
        Test<Find.Test>();
    }

    private static void Test<T>() where T: ITest, new()
    {
        string taskName = "Test " + typeof(T).Namespace;
        Console.WriteLine("Begin " + taskName);
        T t = new T();
        if(t.Run())
        {
            Console.WriteLine(taskName + " Pass");
        }
        else
        {
            Console.WriteLine(taskName + " Fail");
        }
        Console.WriteLine("End " + taskName);
    }
}