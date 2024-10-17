using System.Windows;

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool CanSit { get; set; }
        public bool CanStay { get; set; }
        public bool CanFetch { get; set; }
        public MainWindow()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Sit: {0}, Stay: {1}, Fetch: {2}", CanSit, CanStay, CanFetch));
        }

    }
}
