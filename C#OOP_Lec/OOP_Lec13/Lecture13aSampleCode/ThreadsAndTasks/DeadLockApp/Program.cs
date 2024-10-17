class Program
{
    //used as lock objects
    private static readonly object thislockA = new object();
    private static readonly object thislockB = new object();
    static void Main()
    {
        Task tsk1 = Task.Run(() =>
        {
            lock (thislockA)
            {
                Console.WriteLine("thislockA of tsk1");
                lock (thislockB)
                {
                    Console.WriteLine("thislockB of tsk2");
                    Thread.Sleep(100);
                }
            }
        });
        Task tsk2 = Task.Run(() =>
        {
            lock (thislockB)
            {
                Console.WriteLine("thislockB of tsk2");
                lock (thislockA)
                {
                    Console.WriteLine("thislockA of tsk2");
                    Thread.Sleep(100);
                }
            }
        });
        Task[] allTasks = { tsk1, tsk2 };
        Task.WaitAll(allTasks); // Wait for all tasks
        Console.WriteLine("Program executed succussfully");
    }
}