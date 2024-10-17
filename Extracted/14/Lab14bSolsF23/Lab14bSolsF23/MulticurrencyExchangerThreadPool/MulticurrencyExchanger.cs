using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;

namespace ThreadPool
{

    public class MulticurrencyExchanger
    {
        private static readonly List<ConversionInfo> conversions;

        static MulticurrencyExchanger()
        {
            // The conversion factors
            conversions = new List<ConversionInfo>();
            conversions.Add(new ConversionInfo("USD", "BGN", 1.69));
            conversions.Add(new ConversionInfo("EURO", "BGN", 1.95));
            conversions.Add(new ConversionInfo("GBP", "BGN", 2.19));
        }

        private Random random = new Random();

        public void Init()
        {
            Action<ConversionInfo> action = UpdateConversionFactors;

            // Loop infinitely
            while (true)
            {
                int waitTime = random.Next(1000, 5000 );
                Thread.Sleep(waitTime);
 
                lock (conversions)
                {
                    // Apply method UpdateConversionFactors(ConversionInfo info)
                    // on each element of the conversion list
                    MulticurrencyExchanger.conversions.ForEach (action);
                }
            }
        }

        // Wrapper method to apply updated conversion rates 
       public  void UpdateConversionFactors(ConversionInfo info)
        {
            int percentage = random.Next(-5, 5);
            info.conversionFactor = info.conversionFactor * (1 + (double)percentage / 100.0);
        }

        // Service method to do a conversion on an ExchangeUnit 
        // in a thread from the ThreadPool
        public static double Convert(ExchangeUnit exchange)
        {
            lock (conversions)
            {
                foreach (ConversionInfo info in conversions)
                {  // Find current converson rate and
                   // apply it to ExchangeUnit exchange
                    if (info.currencyIn.Equals(exchange.CurrencyIn) &&
                        info.currencyOut.Equals(exchange.CurrencyOut))
                    {
                        return exchange.Amount * info.conversionFactor;
                    }
                }
            }
            return -1;// No conversion rates defined for
                      // exchange.CurrencyIn and exchange.CurrencyOut
        }
    }

 

}
