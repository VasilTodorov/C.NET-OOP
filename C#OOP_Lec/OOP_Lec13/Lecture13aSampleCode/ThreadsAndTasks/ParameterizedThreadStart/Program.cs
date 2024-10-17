class Program
{
    public static void ThreadMethod(object o)
    {
        for (int i = 0; i < (int)o; i++)
        {
            Console.WriteLine("ThreadProc: {0}", i);
            Thread.Sleep(0);
        }
    }
    public static void Main()
    {
        Thread t = new Thread(ThreadMethod);

        t.Start(5);
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(i);
        }

        // t.Join();

    }
}