using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
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

namespace Patterns
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SyncOverAsync : Window
    {
        public SyncOverAsync()
        {
            InitializeComponent();
        }

        public async Task<string> ReadUrlAsync(string url)
        {
            var request = WebRequest.Create(url);

            using (var response = await request.GetResponseAsync().ConfigureAwait(false))
            using (var stream = new StreamReader(response.GetResponseStream()))
                return stream.ReadToEnd();
        }

        void AsyncOverSyncInvoke(object sender, RoutedEventArgs e)
        {
            Output.Text = string.Empty;
            ButtonSync.IsEnabled = false;

            //var task = ReadUrlAsync("http://www.google.com");
            //task.Wait();
            //var response = task.Result;

            //or just:
            var response = ReadUrlAsync("http://www.google.com").Result;

            Output.Text = response;
            ButtonSync.IsEnabled = true;
        }

        async void AsyncInvoke(object sender, RoutedEventArgs e)
        {
            Output.Text = string.Empty;
            ButtonSync.IsEnabled = false;

            string response = await ReadUrlAsync("http://www.bing.com");

            Output.Text = response;
            ButtonSync.IsEnabled = true;
        }
    }
}
