using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class Invoice
    {
        public long StoreID { get; set; }
        public int Number { get; set; }
        public DateTime DateTime { get; set; }
        public String Type { get; set; }
        public int LineCount { get; set; }
        public float ModeTotal { get; set; }
        public float GrandTotal { get; set; }
        public bool Checked { get; set; }

        public Invoice(long id, InvoiceType type)
        {
            this.Type = type.ToString();
            this.StoreID = id;
            this.ModeTotal = 0.5f;
            this.GrandTotal = 0.6f;
        }

        public Invoice()
        {
            this.Checked = false;
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
