using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace SequentialAwaits
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderAsync();
            Console.ReadLine();
        }

        static async void OrderAsync()
        {
            var stopwatch = Stopwatch.StartNew();

            await Task.Run(() => Thread.Sleep(2000)) 
                .ContinueWith(task => ShowCompletion("Burger", stopwatch.Elapsed));
            await Task.Run(() => Thread.Sleep(1000))
                .ContinueWith(task => ShowCompletion("Fries", stopwatch.Elapsed));
            await Task.Run(() => Thread.Sleep(100))
                .ContinueWith(task => ShowCompletion("Drink", stopwatch.Elapsed));


            ShowCompletion("Order", stopwatch.Elapsed);

            stopwatch.Stop();
        }

        static void ShowCompletion(string name, TimeSpan time)
        {
            Console.WriteLine($"{name} completed after {time}");
        }

    }
}
