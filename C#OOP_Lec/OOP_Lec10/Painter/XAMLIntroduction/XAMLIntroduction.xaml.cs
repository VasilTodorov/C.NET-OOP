using System;
using System.Collections.Generic;
using System.Linq;
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

namespace XAMLIntroduction
{
    /// <summary>
    /// Interaction logic for XAMLIntroductionWindow.xaml
    /// </summary>
    public partial class XAMLEventSetter : Window
    {
        public XAMLEventSetter()
        {
            InitializeComponent();
        }



        void b1SetColor(object sender, RoutedEventArgs e)
        {
            Button b = e.Source as Button;
            b.Background = new SolidColorBrush(Colors.Azure);
        }

        void HandleThis(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }
      
    }
}
