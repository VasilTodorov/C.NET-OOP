namespace ThreadPoolEperiment
{
    using System;
    using System.Threading;

    // class ThreadTester demonstrates basic threading concepts
    class ThreadTester
    {
        static void Main(string[] args)
        {
            // Create an array of ManualResetEvents for asynch thread pool execution.
            ManualResetEvent[] _events;
            // pick random sleep time between 0 and 5 seconds
            Random random = new Random();

            // Create and name each thread. Use MessagePrinter's
            // Print method as argument to ThreadStart delegate.
            ManualResetEvent e1 = new ManualResetEvent(false);
            MessagePrinter printer1 = new MessagePrinter(e1);
            ThreadPool.QueueUserWorkItem(printer1.Print, random.Next(5001));

            ManualResetEvent e2 = new ManualResetEvent(false);
            MessagePrinter printer2 = new MessagePrinter(e2);
            ThreadPool.QueueUserWorkItem(printer2.Print, random.Next(5001));

            ManualResetEvent e3 = new ManualResetEvent(false);
            MessagePrinter printer3 = new MessagePrinter(e3);
            ThreadPool.QueueUserWorkItem(printer3.Print, random.Next(5001));



            _events = new ManualResetEvent[] { e1, e2, e3 };
            Console.WriteLine("Threads started\n");
            WaitHandle.WaitAll(_events);// wait all threads to complete
            Console.WriteLine("Threads done\n");
        }

        class MessagePrinter
        {

            private static int count = 1;
            private readonly int id;// unique id fo reach thread
            private ManualResetEvent _event;
            // constructor to initialize a MessagePrinter object
            public MessagePrinter(ManualResetEvent _event)
            {
                id = count++;
                this._event = _event;
            }

            public void Print(object sleepTime)
            {
                // obtain reference to currently executing thread
                Thread current = Thread.CurrentThread;
                current.Name = "Thread No. " + id;
                // put thread to sleep for sleepTime amount of time
                Console.WriteLine("Thread {0} going to sleep for {1} milliseconds",
                current.Name, sleepTime);
                Thread.Sleep((int)sleepTime); // sleep for sleepTime milliseconds

                // print thread name
                Console.WriteLine("Thread {0} done sleeping", current.Name);
                _event.Set(); // signal the end of the thread

            } // end method Print

            public void PrintF()
            {
                int sleepTime = 500;
                // obtain reference to currently executing thread
                Thread current = Thread.CurrentThread;
                current.Name = "Thread No. " + id;
                // put thread to sleep for sleepTime amount of time
                Console.WriteLine("Thread {0} going to sleep for {1} milliseconds",
                current.Name, sleepTime);
                Thread.Sleep((int)sleepTime); // sleep for sleepTime milliseconds

                // print thread name
                Console.WriteLine("Thread {0} done sleeping", current.Name);
                _event.Set(); // signal the end of the thread

            } // end method Print
        } // end class MessagePrinter
    }
}