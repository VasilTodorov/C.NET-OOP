using System;
using System.Threading;


namespace ThreadPool
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //Invoke the MulticurrencyExchanger Init() method on a separate thread 
            MulticurrencyExchanger exchanger = new MulticurrencyExchanger();
            Thread thread = new Thread( exchanger.Init );
            thread.Start();

            ExchangeUnit[] exchanges = new ExchangeUnit[3];
            // One event is used for each ExchangeUnit object
            ManualResetEvent[] signalEvents = new ManualResetEvent[3];
            for (int i = 0; i < 3; i++)
            {
                signalEvents[i] = new ManualResetEvent(false);
            }

            exchanges[0] = new ExchangeUnit(100.00, "USD", "BGN", signalEvents[0]);
            exchanges[1] = new ExchangeUnit(100.00, "EURO", "BGN", signalEvents[1]);
            exchanges[2] = new ExchangeUnit(100.00, "GBP", "BGN", signalEvents[2]);

            // Calculate exchanges for 10 times so that fluctuating exchange rates reflect
            for (int j = 0; j < 10; j++)
            {
                // Launch threads for an ExchangeUnit using ThreadPool
                for (int i = 0; i < 3; i++)
                {
                    System.Threading.ThreadPool.QueueUserWorkItem(exchanges[i].ThreadPoolCallback!, exchanges[i]);
                }

                // Wait for all threads in pool to complete currency conversion
                WaitHandle.WaitAll(signalEvents);

                // Display the results
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine("{0} {1:F2}={2} {3:F2}",
                        exchanges[i].CurrencyIn, exchanges[i].Amount, exchanges[i].CurrencyOut, exchanges[i].ExAmount);
                }

                // Sleep for 1 sec before going to next iteration
                Thread.Sleep(1000);
            }

            // Stop the thread for the MulticurrencyExchanger object
            

            Console.ReadLine();
            Environment.Exit(0);    
        }

    }


}
