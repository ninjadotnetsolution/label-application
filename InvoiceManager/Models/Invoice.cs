using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager.Models
{
    public class Invoice
    {
        public long StoreID { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public String Type { get; set; }
        public String Member { get; set; }
        public int LineCount { get; set; }
        public float ModeTotal { get; set; }
        public float GrandTotal { get; set; }
        public bool Checked { get; set; } = false;

        public InvoiceType GetInvoiceType()
        {
            switch (this.Type)
            {
                case "CA":
                    return InvoiceType.Cash;
                case "GC":
                    return InvoiceType.GiftCard;
                case "CC":
                    return InvoiceType.Credit;
                default:
                    return Models.InvoiceType.All;
            }
        }


    }

    public enum InvoiceType
    {
        Cash = 0,
        GiftCard = 1,
        Credit = 2,
        Check = 3,
        DebitCard = 4,
        All = 5
    }

}
