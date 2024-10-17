using Patterns.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Patterns
{
    /// <summary>
    /// Interaction logic for PipelineWindow.xaml
    /// </summary>
    public partial class PipelineWindow : Window
    {
        //The demo-pipeline
        PipeDemo demo;
        //For generating some artifical work
        Random rand;

        public PipelineWindow()
        {
            InitializeComponent();
            demo = new PipeDemo();
            rand = new Random();
            demo.Log += demo_Log;
        }

        void demo_Log(object sender, LogEventArgs e)
        {
            Log.Items.Add(e);
        }

        private void AddToQueue(object sender, RoutedEventArgs e)
        {
            var time = rand.Next(1000, 15000);
            demo.Push(new WorkItem { WorkTime = time });
        }

        private void StopCurrent(object sender, RoutedEventArgs e)
        {
            demo.CancelCurrent();
        }

        private void StopAll(object sender, RoutedEventArgs e)
        {
            demo.CancelAll();
        }
    }
}
