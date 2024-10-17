using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPool
{
    public class ConversionInfo
    {
        internal string currencyIn;
        internal string currencyOut;
        internal double conversionFactor;

        internal ConversionInfo(string currencyIn, string currencyOut, double conversionFactor)
        {
            this.currencyIn = currencyIn;
            this.currencyOut = currencyOut;
            this.conversionFactor = conversionFactor;
        }
    }
}
