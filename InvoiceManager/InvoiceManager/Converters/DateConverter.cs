using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceManager.Converters
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is DateTime val)
            {
                string date = $"{val.Day}/{val.Month}/{val.Year}";
                return date;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is string val)
            {
                List<string> numbers = val.Split('/').ToList();
                if(numbers.Count > 2)
                {
                    try
                    {
                        var time = new DateTime(int.Parse(numbers[2]) , int.Parse(numbers[1]), int.Parse(numbers[0]), 0, 0, 0);
                        return time;

                    }catch
                    {
                        return value;
                    }
                }
                return value;
            }
            return value;
        }
    }
}
