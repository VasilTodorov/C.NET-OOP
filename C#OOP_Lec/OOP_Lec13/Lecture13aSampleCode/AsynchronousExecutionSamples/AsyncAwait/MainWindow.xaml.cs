using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsyncAwait
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

        void RunSequentially(object sender, RoutedEventArgs e)
        {
            //First part
            var original = Button1.Content;
            Button1.Content = "Please wait ...";
            Button1.IsEnabled = false;

            //Simulate some work
            SimulateWork();

            //Last part
            Button1.Content = original;
            Button1.IsEnabled = true;
        }

        void RunAsyncTask(object sender, RoutedEventArgs e)
        {
            //First part
            var original = Button2.Content;
            Button2.Content = "Please wait ...";
            Button2.IsEnabled = false;

            //Simulate some work
            var task = Task.Factory.StartNew(() => SimulateWork());

            task.ContinueWith(t =>
            {
                //Last part
                Button2.Content = original;
                Button2.IsEnabled = true;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        async void RunAsyncAwait(object sender, RoutedEventArgs e)
        {
            //First part
            var original = Button3.Content;
            Button3.Content = "Please wait ...";
            Button3.IsEnabled = false;

            //Simulate some work
            await Task.Run(() => SimulateWork());
            //or even better
            //await SimulateWorkAsync();

            //Last part
            Button3.Content = original;
            Button3.IsEnabled = true;
        }

        void SimulateWork()
        {
            Thread.Sleep(5000);
        }

        async Task SimulateWorkAsync()
        {
            await Task.Run(() => SimulateWork());
        } 
    }
}
