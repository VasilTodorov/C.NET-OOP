public static class Program
{
    private static void SimpleTask()
    { // Start a task  in a worker thread
        Task t = Task.Run(() =>
        {
            for (int x = 0; x < 100; x++)
            {
                Console.Write('*');
            }
        });
        t.Wait();// Join Task with main thread, waits Task to complete
        Console.WriteLine("\nEnd of task");
    }// SimpleTask();
    private static void TaskReturnResult()
    { // Start a task returning value in a worker thread
        Task<int> t = Task.Run(() =>
        {
            return 42;
        });
        Console.WriteLine(t.Result); // Displays 42
    }

    /*
     * 
     * 

        SimpleTask();
        TaskReturnResult();
        RunContinuation();
        RunThreadTactory();
        RunConditionalContinuation();
     * 
     */
    private static void RunThreadTactory()
    {
        //initialize and Start mytask and assign
        //a unit of work in the body of lambda exp
        Task mytask = Task.Factory.StartNew(new Action(MyMethod));
        mytask.Wait(); //Wait until mytask finish its job
                       //It's the part of Main Method
        Console.WriteLine("Hello From Main Thread");
    }
    private static void RunContinuation()
    {
        var t = Task.Run(() =>
        { // t is of type Task<int> by inference
            return 42;
        }).ContinueWith((i) =>
        {
            return i.Result * 2;
        });
        Console.WriteLine(t.Result); // Displays 84
    }
    private static void RunConditionalContinuation()
    {
        Task<int> t = Task.Run<int>(() =>
        {
            return 42;
        });
        t.ContinueWith((i) =>
        {
            Console.WriteLine("Canceled");
        }, TaskContinuationOptions.OnlyOnCanceled);
        t.ContinueWith((i) =>
        {
            Console.WriteLine("Faulted");
        }, TaskContinuationOptions.OnlyOnFaulted);
        var completedTask = t.ContinueWith((i) =>
        {
            Console.WriteLine("Completed: Result is {0}", i.Result);
        }, TaskContinuationOptions.OnlyOnRanToCompletion);
        completedTask.Wait();
    }
    private static void StartNewTResult()
    {
        Task<int> myTask = Task.Factory.StartNew<int>(FuncMethod);
        Console.WriteLine("Hello from Main Thread");
        //Wait the main thread until myTask is finished
        //and returns the value from myTask operation (myMethod)
        int i = myTask.Result;
        Console.WriteLine("myTask has a return value = {0}", i);
        Console.WriteLine("Bye From Main Thread");
    }
    private static void WaitAllTasks()
    {
        Task[] tasks = new Task[3];
        tasks[0] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("1");
            return 1;
        });
        tasks[1] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("2");
            return 2;
        });
        tasks[2] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("3");
            return 3;
        }
        );
        Task.WaitAll(tasks);
    }
    public static void Main()
    {
        Task[] tasks = new Task[3];
        tasks[0] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("1");
            return 1;
        });
        tasks[1] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("2");
            return 2;
        });
        tasks[2] = Task.Run(() =>
        {
            Thread.Sleep(1000);
            Console.WriteLine("3");
            return 3;
        }
        );
        Task.WaitAll(tasks);
    }
    private static int FuncMethod()
    {
        Console.WriteLine("Hello from myTask<int>");
        Thread.Sleep(1000);
        return 10;
    }
    private static void MyMethod()
    {
        Console.WriteLine("Hello From My Task");
        for (int i = 0; i < 10; i++)
        {
            Console.Write("{0} ", i);
        }
        Console.WriteLine();
        Console.WriteLine("Bye From My Task");
    }
}