using System.ComponentModel;
using System.Windows;
using System.Windows.Media;

namespace WPFBackgroundworkerWithEvents
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker worker = null;
        public MainWindow()
        {
            InitializeComponent();
            worker = new BackgroundWorker
            {
                WorkerSupportsCancellation = true,
                WorkerReportsProgress = true
            };
            worker.DoWork += Worker_DoWork;
            worker.ProgressChanged += Worker_ProgressChanged;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            worker.RunWorkerAsync();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            worker.CancelAsync();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i <= 100; i++)
            {
                if (worker.CancellationPending == true)
                {
                    e.Cancel = true;
                    return;
                }
                worker.ReportProgress(i);
                System.Threading.Thread.Sleep(250);
            }
            e.Result = 42;
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = "Working... (" + e.ProgressPercentage + "%)";
            pbRunning.Value = e.ProgressPercentage;
        }

        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblStatus.Foreground = Brushes.Red;
                lblStatus.Text = "Cancelled by user...";
            }
            else
            {
                lblStatus.Foreground = Brushes.Green;
                lblStatus.Text = "Done... Calc result: " + e.Result;
            }
        }


    }
}
