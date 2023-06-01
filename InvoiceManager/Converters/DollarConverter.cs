using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace LabelManager.Converters
{
    public class DollarConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is float val)
            {
                return $"${(val*3/100).ToString("0.00")}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is string val)
            {
                List<string> numbers = val.Split('$').ToList();
                if(numbers.Count > 1)
                {
                    return numbers[1];
                }
                return value;
            }
            return value;
        }
    }
}
