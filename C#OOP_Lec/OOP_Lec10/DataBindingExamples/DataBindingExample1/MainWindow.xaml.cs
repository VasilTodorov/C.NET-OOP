using System.Windows;

namespace DataBindingExample1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = TxtBox1;
        }
    }
}
