using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace LabelManager.Converters
{
    public class SummaryConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            decimal Total = 0;
            decimal Amount = 0;
            string TotalAmount = string.Empty;
            Total = (values[0] != null && values[0] != DependencyProperty.UnsetValue) ? System.Convert.ToDecimal(values[0]) : 0;
            Amount = (values[0] != null && values[1] != DependencyProperty.UnsetValue) ? System.Convert.ToDecimal(values[1]) : 0;
            if(Total == 0 || Amount == 0)
            {
                return "0";
            }
            TotalAmount = $"${Amount*3/100} ({((Amount/Total*100)*3/100).ToString("0.00")}%)";
            return TotalAmount;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
