using InvoiceManager.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace InvoiceManager.Converters
{
    public class PaymentTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string val)
            {
                switch(val)
                {
                    case "CA":
                        return InvoiceType.Cash;
                    case "CC":
                        return InvoiceType.Credit;
                    case "CH":
                        return InvoiceType.Check;
                    case "DC":
                        return InvoiceType.DebitCard;
                    case "GC":
                        return InvoiceType.GiftCard;
                }
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            if (value is InvoiceType val)
            {
                switch (val)
                {
                    case InvoiceType.Cash:
                        return "CA";
                    case InvoiceType.Credit:
                        return "CC";
                    case InvoiceType.Check:
                        return "CH";
                    case InvoiceType.DebitCard:
                        return "DC";
                    case InvoiceType.GiftCard:
                        return "GC";
                }
            }
            return value;
        }
    }
}
