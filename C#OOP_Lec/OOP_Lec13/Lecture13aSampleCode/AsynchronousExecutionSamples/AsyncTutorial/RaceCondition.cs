using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTutorial
{
    static class RaceCondition
    {
        public static void Sample()
        {
            Measure(RaceConditionSerial);
            Measure(RaceConditionProblem);
            Measure(RaceConditionLock);
            Measure(RaceConditionInterlocked);
            Measure(RaceConditionSynchronized);
            Measure(RaceConditionConcurrent);
        }

        static void Measure(Action f)
        {
            Console.WriteLine("Measuring ...");
            var sw = Stopwatch.StartNew();
            f();
            sw.Stop();
            Console.WriteLine("Total time: {0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine();
        }

        static void Print(string kind, int max, int count)
        {
            Console.WriteLine("{0,9} op. in {3} resulted in {1} race-conditions ({2:00.0}%) ...",
                max, max - count == 0 ? "zero" : "some", (max - count) / (max * 0.01), kind);
        }

        static void RaceConditionSerial()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                var count = 0;
                max *= 10;

                for (int m = 0; m < max; m++)
                    count++;

                Print("serial", max, count);
            }
        }

        static void RaceConditionProblem()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                var count = 0;
                max *= 10;
                Parallel.For(0, max, m => count++);
                Print("parallel", max, count);
            }
        }

        static void RaceConditionLock()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                var lockObj = new object();
                var count = 0;
                max *= 10;

                Parallel.For(0, max, m =>
                {
                    lock (lockObj)
                    {
                        count++;
                    }
                });

                Print("(lock) parallel", max, count);
            }
        }

        static void RaceConditionInterlocked()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                var count = 0;
                max *= 10;

                Parallel.For(0, max, m => Interlocked.Increment(ref count));
                Print("(interlocked) parallel", max, count);
            }
        }

        static void RaceConditionSynchronized()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                max *= 10;
                var sm = new SyncMethod();
                Parallel.For(0, max, m => sm.Increment());
                Print("(synchronized) parallel", max, sm.Count);
            }
        }

        static void RaceConditionConcurrent()
        {
            var max = 1;

            for (int i = 0; i < 8; i++)
            {
                var lockObj = new object();
                int count = 0;
                max *= 10;
                Parallel.For(0, max, () => 0, (m, state, local) => local + 1, local =>
                {
                    lock (lockObj)
                    {
                        count += local;
                    }
                });

                Print("(concurrent) parallel", max, count);
            }
        }
    }
}
