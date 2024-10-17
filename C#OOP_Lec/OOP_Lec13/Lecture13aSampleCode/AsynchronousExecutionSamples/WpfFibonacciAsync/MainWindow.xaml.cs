using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace WpfFibonacciAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        async Task<long> StartFibonacciAsync(int n)
        {  //runs on a TPL thread, not the UI thread
            Stopwatch sw = new Stopwatch();
            sw.Start();
            // execute task on the UI thread
            await outputTextBox.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                new Action<int>((int e) =>
                                    outputTextBox.Text += String.Format("Calculating Fibonacci({0})\r\n", e)),
                                n);

            long fibonacciValue = await Task.FromResult<long>(Fibonacci(n)); //not using a TPL thread
            // time completion calculation
            long finishTime = sw.ElapsedMilliseconds;
            // execute task on the UI thread
            await outputTextBox.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                new Action<int, long>((int e, long l) =>
                                    outputTextBox.Text += String.Format("Fibonacci({0}) = {1}", e, l)),
                                n, fibonacciValue);
            await outputTextBox.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                                new Action<long>((e) =>
                                    outputTextBox.Text += String.Format("   Calculation time = {0} ms\r\n", e)),
                                finishTime);
            sw.Reset();
            return finishTime;
        } // end method StartFibonacci
        public long Fibonacci(long n)
        {
            if (n == 0 || n == 1)
                return n;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        } // end method Fibonacci
        /// <summary>
        /// Version  awaiting to obtain sequentially the results of the tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartButton_ClickV1(object sender, RoutedEventArgs e)
        {  // uses 2 async Tasks to compute Fibonacci- sequential execution of Tasks
            startButton.IsEnabled = false;

            outputTextBox.Text = "Starting Task to calculate Fibonacci(40)\r\n";
            // await Task to perform Fibonacci(40) calculation  
            long r1 = await StartFibonacciAsync(40);

            outputTextBox.AppendText("Starting Task to calculate Fibonacci(30)\r\n");
            // create Task to perform Fibonacci(30) calculation  
            long r2 = await StartFibonacciAsync(30);
            // both tasks are ran to completion
            outputTextBox.AppendText(String.Format(
                            "Total calculation time = {0} ms\r\n",
                            Math.Max(r1, r2)));

            startButton.IsEnabled = true;
        }
        /// <summary>
        /// Version  awaiting the two tasks to complete Tasks
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void StartButton_ClickV2(object sender, RoutedEventArgs e)
        {  // uses 4 threads to compute Fibonacci- parallel execution of Tasks
            startButton.IsEnabled = false;
            outputTextBox.Text = "Starting Task to calculate Fibonacci(40)\r\n";

            // create Task to perform Fibonacci(46) calculation in a thread
            Task<long> e1 = Task.Run(() => StartFibonacciAsync(40));

            outputTextBox.AppendText("Starting Task to calculate Fibonacci(30)\r\n");

            // create Task to perform Fibonacci(45) calculation in a thread
            Task<long> e2 = Task.Run(() => StartFibonacciAsync(30));
            // await all the two Tasks to complete
            await Task.WhenAll<long>(e1, e2);

            //display total time for calculations
            outputTextBox.AppendText(String.Format(
               "Total calculation time = {0} ms\r\n",
                Math.Max(e1.Result, e2.Result)));
            startButton.IsEnabled = true;
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            System.Environment.Exit(0);
        }

        /// <summary>
        /// Test when await requires Dispatcher.Invoke in the asynch task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
         
        private async void StartButton_Click(object sender, RoutedEventArgs e)
        {
            var t1 = await M1Async(1);
            var t2 = await M1Async(2); // does not requires Dispatcher.Invoke in M1Async
            outputTextBox.Text += "\n" + t1  + " " + t2 ;

            //await M1Async(1);
            //await M1Async(2); // does not requires Dispatcher.Invoke in M1Async


            //Task<int> t1 = Task.Run(() => M1Async(1));
            //Task<int> t2 = Task.Run(() => M1Async(2));
            //await Task.WhenAll(t1, t2);// requires Dispatcher.Invoke in M1Async
            //outputTextBox.Text += "\n" + t1.Result + " " + t2.Result ; 
        }
        async Task<int> M1Async(int n)
        {
            
            await Task.Delay(10);
            if (outputTextBox.Dispatcher.CheckAccess()) // check if current thread is the UI thread
            {
                 outputTextBox.Text += "\nOn the UI thread..." +
                  string.Format("\nIsThreadPoolThread {0}", outputTextBox.Dispatcher.Thread.IsThreadPoolThread)+
                   string.Format("\nIsBackground {0}", outputTextBox.Dispatcher.Thread.IsBackground)
                   ;
            }
            else
            {
               MessageBox.Show("Not on the UI thread", "Check UI thread access");
            }
            return n;
        }
    }
}
