using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Grouping a:\n");
            Product.GroupByCategoryCountDescending();
            Console.WriteLine("\nGrouping b:\n");
            Product.GroupByQtrAndProductPriceAvg();
            Console.WriteLine("\nGrouping c:\n");
            Product.GroupByQtrCategoryWeeklySum();
            Console.WriteLine("\nGrouping d:\n");
            Product.GroupByQtrCategoryAndProducts();
            Console.WriteLine("\nGrouping e:\n");
            Product.GroupByQtrMinMaxPrice();

        }
    }
}
