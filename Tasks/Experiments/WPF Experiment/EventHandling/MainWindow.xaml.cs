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

namespace EventHandling
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

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            if(sender is Button)
            {
                var button = (Button)sender;
                MessageBox.Show(button.Content.ToString());
            }
            else if(sender is StackPanel)
            {
                //var button = ((StackPanel)sender).Children[0] as Button;
                //MessageBox.Show(button?.Content.ToString() ?? "Sorry Again");
                var button2 = e.Source as Button;
                MessageBox.Show(button2?.Content.ToString()+"   2");
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            MessageBox.Show(button.Content.ToString() + "   1");
        }
    }
}