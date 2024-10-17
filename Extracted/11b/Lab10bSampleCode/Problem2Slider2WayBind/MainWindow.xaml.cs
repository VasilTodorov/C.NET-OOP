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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Problem2Slider2WayBind
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
            {
                ElementName = "SlrDigitalData",
                Path = new PropertyPath("Value"),
                Converter = new SlidderValueConverter(),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
            };
            DataContext = SlrDigitalData;
            TxtBindCScode.SetBinding(TextBox.TextProperty, b);

        }
    }
}
