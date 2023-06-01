using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceManager.Converters
{
    public class TimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime val)
            {
                return $"{val.Hour}:{val.Minute}:{val.Second}";
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is string val)
            {
                List<string> numbers = val.Split(':').ToList();
                if(numbers.Count > 2)
                {
                    var time = new DateTime(0, 0, 0, int.Parse(numbers[0]), int.Parse(numbers[1]), int.Parse(numbers[2]));
                    return time;
                }
                return value;
            }
            return value;
        }
    }
}
