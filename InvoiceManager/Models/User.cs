using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class User
    {
        public User()
        {
            Id = 0;
            Name = "";
            Password = "";
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

    }
}