using System.Diagnostics;

namespace ConstrainSatisfaction
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Queens a = new Queens(10007);

            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();

            //a.Solve();

            //stopWatch.Stop();
            //TimeSpan ts = stopWatch.Elapsed;
            //Console.WriteLine(ts);

            ReadInfoTest();
        }

        static void ReadInfoTest()
        {
            int n;
            int.TryParse(Console.ReadLine(),out n);
            Queens test = new Queens(n);
            if(n <= 100)
            {
                test.Solve();
                Console.WriteLine(test);
            }
            else 
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start();

                test.Solve();

                stopWatch.Stop();
                TimeSpan ts = stopWatch.Elapsed;
                
                Console.WriteLine($"{((ts.Milliseconds)/1000.0):F2}");
            }
        }
    }
}