using System.Net;

class Program
{
    static void Main(string[] args)
    {
        int n = 0;
        var up = Task.Run(() =>
        {
            for (int i = 0; i < 1000000; i++)
                Interlocked.Increment(ref n);
        });
        for (int i = 0; i < 1000000; i++)
            Interlocked.Decrement(ref n);
        up.Wait();
        Console.WriteLine(n);

    }
    private async Task SomeWebMethod()
    {
        Uri site = new Uri("http://www.illustratedcsharp.com");
        WebClient wc = new WebClient();
        string result = await wc.DownloadStringTaskAsync(site);
    }
    private static void UsingMonitorClass()
    {
        int n = 0;// shared data between main and worker threads
        object _sharedData = new object();
        var up = new Thread(() =>
        {

            for (int i = 0; i < 1000000; i++)
            {
                Monitor.Enter(_sharedData);
                n++; // access to shared data is locked
                Monitor.Exit(_sharedData);
            }
        });
        up.Start();
        for (int i = 0; i < 1000000; i++)
        {
            Monitor.Enter(_sharedData);
            n--; // access to shared data is locked
            Monitor.Exit(_sharedData);
        }
        up.Join();
        Console.WriteLine(n);
    }

    private static void UsingLockOperator()
    {
        int n = 0;// shared data between main and worker threads
        object _sharedData = new object();
        var up = new Thread(() =>
        {

            for (int i = 0; i < 1000000; i++)
                lock (_sharedData)
                {
                    n++;  // access to shared data is locked
                }
        });
        up.Start();
        for (int i = 0; i < 1000000; i++)
            lock (_sharedData)
            {
                n--; // access to shared data is locked
            }
        up.Join();
        Console.WriteLine(n);
    }

    private static void UnSynchronizedAccessToData()
    {
        int n = 0;
        var up = new Thread(() =>
        {

            for (int i = 0; i < 1000000; i++)
                n++;
        });
        up.Start();
        for (int i = 0; i < 1000000; i++)
            n--;
        up.Join();
        Console.WriteLine(n);
    }
}