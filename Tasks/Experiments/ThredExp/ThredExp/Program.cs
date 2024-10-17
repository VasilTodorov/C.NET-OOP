namespace ThredExp
{
    namespace MultiThreading
    {
        public static class CreateThread
        {
            public static void ThreadMethod()
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("ThreadProc: {0}", i);
                    Thread.Sleep(0);
                }
            }
            public static void Main()
            {
                Thread t = new Thread(new ThreadStart(ThreadMethod));
                t.Name = "Test";
                //t.IsBackground = true;
                t.Start();
                for (int i = 0; i < 4; i++)
                {
                    Console.WriteLine("Main thread: Do some work." + t.Name);
                    Thread.Sleep(0);
                }
                t.Join(); // wait for ThreadMethod to end
                Console.WriteLine("End of main thread");
            }
        }
    }
}
