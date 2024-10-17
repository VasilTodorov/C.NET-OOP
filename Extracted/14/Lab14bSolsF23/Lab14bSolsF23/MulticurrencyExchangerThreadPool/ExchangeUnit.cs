using System;
using System.Threading;


namespace ThreadPool
{
    public class ExchangeUnit
    {
        private double amount;
        private string currencyIn;
        private string currencyOut;

        private ManualResetEvent signal;
        private double exAmount;

        public ExchangeUnit(double amount,
            string currencyIn,
            string currencyOut,
            ManualResetEvent signal)
        {
            this.amount = amount;
            this.currencyIn = currencyIn;
            this.currencyOut = currencyOut;

            this.signal = signal;
        }

        public double Amount
        {
            get { return amount; }
        }

        public string CurrencyIn
        {
            get { return currencyIn; }
        }

        public string CurrencyOut
        {
            get { return currencyOut; }
        }

        public double ExAmount
        {
            get { return exAmount; }
        }

        // Wrapper method for use with thread pool
        public void ThreadPoolCallback(Object threadContext)
        {
            exAmount = MulticurrencyExchanger.Convert(exchange: (ExchangeUnit)threadContext);
            signal.Set();
        }
    }

}
