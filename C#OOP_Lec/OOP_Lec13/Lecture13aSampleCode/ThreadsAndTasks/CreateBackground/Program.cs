public static class CreateBackground
{
    public static void ThreadMethod()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("ThreadProc: { 0}", i);
            Thread.Sleep(1000);
        }
    }
    public static void Main()
    {
        Thread t = new Thread(ThreadMethod)
        {
            IsBackground = true
        };
        t.Start();
        Console.WriteLine("End of main thread");
    }
}