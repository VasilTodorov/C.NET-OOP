using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace DigitalClockSystemTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// / DispatcherTimer is the regular timer. It fires its Tick event on the UI thread, 
    /// you can do anything you want with the UI. System.Timers.
    /// Timer is an asynchronous timer, its Elapsed event runs on a thread pool thread.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly System.Timers.Timer timer ;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Timers.Timer(1000);
            // Option 1
            //timer.Elapsed +=   (sender, e) =>   HandleTimer();
            // Option 2
             timer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            timer.Enabled = true;
        }

        private void HandleTimer()
        {
                try
                {  // Write on th UI thread
                    Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                    {
                        this.digitalClock.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                    }));
                }
                catch (TaskCanceledException)
                {
                    Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
                    Environment.Exit(0);
                }
            
        }
        void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // Violates Thread affinity, attempts to access an object owned by another thread
            //System.InvalidOperationException: 'The calling thread cannot access this object because
            //a different thread owns it.'
            // this.digitalClock.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

            try
            {  // Write on th UI thread
                Dispatcher.Invoke(DispatcherPriority.Normal, (Action)(() =>
                {
                    this.digitalClock.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);


                }));
            }
            catch (TaskCanceledException)
            {
                Dispatcher.BeginInvokeShutdown(DispatcherPriority.Normal);
                Environment.Exit(0);
            }
        }
        private void startClick(object sender, RoutedEventArgs e)
        {
            this.timer.Start();
        }

        private void stopClick(object sender, RoutedEventArgs e)
        {
            this.timer.Stop();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            timer.Dispose();
            Environment.Exit(0);
        }
    }
}