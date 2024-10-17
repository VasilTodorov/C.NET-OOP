using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace DataBindingExample2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Binding b = new Binding
            { // Initialze the same attributes as in XAML
                ElementName = "TxtBox1",
                Path = new PropertyPath("Text")
                
            };
            b.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            TxtBox3.SetBinding(TextBox.TextProperty, b);
        }
    }
}
