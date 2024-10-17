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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void SyncOverAsyncClicked(object sender, RoutedEventArgs e)
        {
            (new SyncOverAsync()).Show();
        }

        void AsyncEventClicked(object sender, RoutedEventArgs e)
        {
            (new AsyncEvent()).Show();
        }

        void AsyncModelClicked(object sender, RoutedEventArgs e)
        {
            (new AsyncModel()).Show();
        }

        void AsyncPipelineClicked(object sender, RoutedEventArgs e)
        {
            (new PipelineWindow()).Show();
        }
    }
}
