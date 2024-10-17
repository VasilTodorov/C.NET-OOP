using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Problem2DataSliderBinding
{
    [ValueConversion(typeof(double), typeof(string))]
    public class DataConverter : IValueConverter
    {
        /// <summary>
        /// Convert Slider input (double) to string value 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return string.Format("{0:F2}",(double)value);
        }

        /// <summary>
        /// Convert TextBox input (string) to double value 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var result = double.TryParse(value.ToString(), out double resultValue);
            if (! result) return 0; 
            return resultValue;

        }
    }
}
