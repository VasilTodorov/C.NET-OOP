namespace ThreadTester
{
    internal class Program
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
            Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
            t.Start(5);// pass 5 as a parameter to the delegate
            t.Join();
            Console.WriteLine("End thred");
        }

    }
}
