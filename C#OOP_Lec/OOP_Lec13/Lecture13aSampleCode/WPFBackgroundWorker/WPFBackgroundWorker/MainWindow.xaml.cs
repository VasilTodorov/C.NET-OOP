using System;
using System.Windows;
using System.ComponentModel;


namespace WPFBackgroundWorker
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

        private void BtnDoSynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            int max = 10000;
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            int result = 0;
            for (int i = 0; i < max; i++)
            {
                if (i % 42 == 0)
                {
                    lbResults.Items.Add(i);
                    result++;
                }
                System.Threading.Thread.Sleep(1);
                pbCalculationProgress.Value = Convert.ToInt32(((double)i / max) * 100);
            }
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + result);
        }

        private void BtnDoAsynchronousCalculation_Click(object sender, RoutedEventArgs e)
        {
            pbCalculationProgress.Value = 0;
            lbResults.Items.Clear();

            BackgroundWorker worker = new ()
            {
                WorkerReportsProgress = true
            };
            worker.DoWork += Worker_DoWork!;
            worker.ProgressChanged += Worker_ProgressChanged!;
            worker.RunWorkerCompleted += Worker_RunWorkerCompleted!;
            worker.RunWorkerAsync(10000);
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            int max = (int)e.Argument!;
            int result = 0;
            for (int i = 0; i < max; i++)
            {
                int progressPercentage = Convert.ToInt32(((double)i / max) * 100);
                if (i % 42 == 0)
                {
                    result++;
                    (sender as BackgroundWorker)?.ReportProgress(progressPercentage, i);
                }
                else
                    (sender as BackgroundWorker)?.ReportProgress(progressPercentage);
                System.Threading.Thread.Sleep(1);

            }
            e.Result = result;
        }

        void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbCalculationProgress.Value = e.ProgressPercentage;
            if (e.UserState != null)
                lbResults.Items.Add(e.UserState);
        }

        void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Numbers between 0 and 10000 divisible by 7: " + e.Result);
        }

    }
}

