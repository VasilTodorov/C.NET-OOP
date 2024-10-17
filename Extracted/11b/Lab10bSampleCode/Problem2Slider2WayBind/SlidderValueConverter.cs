using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Animation;

namespace Problem2Slider2WayBind
{
    [ValueConversion(typeof(double), typeof(string))]
    public class SlidderValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double convertedValue = (double)(value ?? 0.0);
            return string.Format("{0:F2}", convertedValue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = double.TryParse((string)value,
                                         out double convertedValue);
            if (!result ) { return 0; }
            return convertedValue;
        }
    }
}
