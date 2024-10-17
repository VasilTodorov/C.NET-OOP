using System;
using System.Globalization;
using System.Windows.Data;

namespace Patterns.Utilities
{
    public class HasValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (value != null) == (bool.Parse(parameter as string ?? "True"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
