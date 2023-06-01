using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager.Models
{
    public class Summary
    {
        public int TotalInvoicecs { get; set; }
        public float TotalGrand { get; set; }
        public float Credit { get; set; }
        public float Cash { get; set; }
        public float Gift { get; set; }
        public float Other { get; set; }
    }
}
