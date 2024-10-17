using System;
using System.Windows;
using System.Windows.Data;

namespace DataConverterExample1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConverterSample : Window
    {

        public ConverterSample()
        {
            InitializeComponent();
        }
    }
    [ValueConversion(typeof(string), typeof(bool))]
    public class YesNoToBooleanConverter : IValueConverter
    {
        public YesNoToBooleanConverter()
        {

        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch (value.ToString().ToLower())
            {
                case "yes":
                case "y":
                    return true;
                case "no":
                case "n":
                    return false;
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value == true)
                    return "Yes";
                else
                    return "No";
            }
            return "no";
        }
    }
}

