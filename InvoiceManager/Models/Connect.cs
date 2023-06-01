using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelManager.Models
{
    public class Connect
    {
        public Connect()
        { }

        public Connect(int id, string connString)
        {
            List<string> items = connString.Split(';').ToList();
            if (items.Count > 5)
            {
                Id = id;
                Label = items[0].Split('=')[1];
                Provider = items[1].Split('=')[1];
                Server = items[2].Split('=')[1];
                DBUserName = items[3].Split('=')[1];
                DBPassword = items[4].Split('=')[1];
                Database = items[5].Split('=')[1];
            }
        }

        public int Id { get; set; }
        public string Label { get; set; }
        public string Provider { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string DBUserName { get; set; }
        public string DBPassword { get; set; }
    }
}