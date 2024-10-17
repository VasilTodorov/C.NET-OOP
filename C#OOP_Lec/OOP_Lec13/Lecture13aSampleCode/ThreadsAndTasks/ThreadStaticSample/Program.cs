  class Program
{
    [ThreadStatic]
    public static int field;
    public static void Main()
    {
        new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                field++;
                Console.WriteLine("Thread A: {0}", field);
            }
        }).Start();
        new Thread(() =>
        {
            for (int x = 0; x < 10; x++)
            {
                field++;
                Console.WriteLine("Thread B:{0}", field);
            }
        }).Start();
        Console.ReadKey();
    }
}