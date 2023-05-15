using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Models
{
    public class InvoiceDbContext 
    {
        /*protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(
                "Data Source=printer.db");
            optionsBuilder.UseLazyLoadingProxies();
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; }*/
        public List<User> Users { get; set; }
        public List<Invoice> Invoices { get; set; }
        public List<Connect> Connects { get; set; }

    }

}
