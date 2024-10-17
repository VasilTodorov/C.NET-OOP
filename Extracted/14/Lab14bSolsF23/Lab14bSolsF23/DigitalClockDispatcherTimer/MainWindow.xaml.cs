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

namespace DigitalClockDispatcherTimer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// DispatcherTimer is the regular timer. It fires its Tick event on the UI thread, 
    /// you can do anything you want with the UI. System.Timers.
    /// Timer is an asynchronous timer, its Elapsed event runs on a thread pool thread. 
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            this.timer.Tick += new EventHandler(this.OnTimedEvent);
            this.timer.Interval = new TimeSpan(0, 0, 1); // 1 second
            this.timer.Start();
        }
        void OnTimedEvent(object? sender, EventArgs e)
        {
            this.digitalClock.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
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
            Environment.Exit(0);
        }
    }
}