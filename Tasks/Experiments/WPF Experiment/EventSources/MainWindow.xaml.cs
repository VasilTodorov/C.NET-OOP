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

namespace EventSources
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

        new private void MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(sender is Button button)
            {
                MessageBox.Show("sender = button");
            }
            else if(sender is Label)
            {
                MessageBox.Show("sender = label");
            }
            else if(sender is StackPanel panel)
            {
                MessageBox.Show("sender = StackPanel");
            }
            MessageBox.Show("e.Source=" + e.Source);
        }

        private void StackPanel_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (sender is Button button)
            {
                MessageBox.Show("sender = button");
            }
            else if (sender is Label)
            {
                MessageBox.Show("sender = label");
            }
            else if (sender is StackPanel panel)
            {
                MessageBox.Show("sender = StackPanel");
            }
            MessageBox.Show("e.Source=" + e.Source);
        }
    }
}