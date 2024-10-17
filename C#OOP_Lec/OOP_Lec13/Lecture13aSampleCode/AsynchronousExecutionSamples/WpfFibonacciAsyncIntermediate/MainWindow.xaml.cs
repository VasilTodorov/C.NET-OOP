using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfFibonacciAsyncIntermediate
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// When you use Dispatcher.BeginInvoke it means that it schedules the given action for execution in the UI thread
    /// at a later point in time, and then returns control to allow the current thread to continue executing. 
    /// Invoke blocks the caller until the scheduled action finishes.
    /// When you use BeginInvoke your loop is going to run super fast since BeginInvoke returns right away.
    /// This means that you're adding lot and lots of actions to the message queue. 
    /// You're adding them much faster than they can actually be processed.This means that there's a long time
    /// between when you schedule a message and when it actually gets a chance to be run.
    /// If you use Dispatcher.Invoke instead then it prevents the loop from "getting ahead of itself" 
    /// and having multiple scheduled events, which ensures that the value that it's writing is always the "current" value.
    /// Additionally, by forcing each iteration of the loop to wait for the message to be run it makes
    /// the loop a lot less "tight", so it can't run as quickly in general.
    /// If you want to use BeginInvoke the first thing you really need to do is slow down your loop. 
    /// If you want it to update the text every second, or ever 10ms, or whatever, 
    /// then you can use Thread.Sleep or an expensive CPU- bound calculation as in this example
    /// to wait the appropriate amount of time.
    /// </summary>
    public partial class MainWindow : Window
    {
        private Stopwatch sw = new Stopwatch();
        public MainWindow()
        {
            InitializeComponent();
        }
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            // initialize variables

            int maxFibNumber = int.Parse(txtInput.Text);
            if (maxFibNumber < 1)
            {
                outputTextBox.Text += "Wrong input. Enter a number greater than 0.";
                return;
            }
            startButton.IsEnabled = false;
            pbStatus.Value = pbStatus.Minimum;
            pbStatus.Maximum = 100;
            // await the execution of the asynchronous Task
            await ComputeFibonacciNumbersAsync(maxFibNumber);
            // the Task ran to completion
            startButton.IsEnabled = true;
            sw.Reset();
        }
        private async Task ComputeFibonacciNumbersAsync(int maximum)
        {
            long fn = 0;
            sw.Start();
            //Start computing the Fibonacci numbers
            for (int i = 0; i <= maximum; i++)
            {
                long k;
                k = (long)i;
                // BeginInvoke is async unlike Invoke
                outputTextBox.Text += String.Format("Calculating Fibonacci({0}) ...\r\n", i);

                fn = await Task.Run<long>(()=>Fibonacci(k));// wrap in a Task the execution of Fibonacci() 
                
                outputTextBox.Text += String.Format("Fibonacci({0}) = {1}\r\n", i, fn);
                pbStatus.Value = (i * 100) / maximum;//Note:pbStatusTextBlock is bound to pbStatus.Value
            }
            outputTextBox.Text += String.Format("Total execution time: {0} [ms] \r\n", sw.ElapsedMilliseconds);
            sw.Reset();
        }
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1)
            {
                return n;
            }
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        } // end method Fibonacci

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
