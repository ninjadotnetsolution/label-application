using Dapper;
using InvoiceManager.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InvoiceManager.Common
{
   

    public sealed class Service
    {
        private static volatile Service instance;
        private static object syncRoot = new Object();

        public OleDbConnection connection;
        public bool isLoading = false;
        public bool Connect(string _label, string _provider, string _server, string _database, string _userName, string _password, string _connString)
        {
            if (_connString != null && _connString.Length > 0 && _connString.Split(';').Length > 4)
            {
                return Connect(_label, _connString);
            }
            
            string connString = $"Provider={_provider};Server={_server};uid={_userName};pwd={_password};Database={_database}";
            connection = new OleDbConnection(connString);

            //using (Service.Instance.connection = new OleDbConnection(connString))
            {
                try
                {
                    connection.Open();

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "connects.txt");
                    File.OpenWrite(path).Close();

                    List<string> _connects = File.ReadAllLines(path).ToList();
                    if (!_connects.Any(item => item.Contains(connString)))
                    {
                        _connects.Add($"Label={_label}{connString}");
                        File.WriteAllLines(path, _connects);
                    }
                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false; ;
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }



            //SqlConnection conn = new SqlConnection(connString);
            //try
            //{
            //    conn.Open();
            //    MessageBox.Show("Passed");
            //    return true;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    return false;
            //}

        }

        public bool Connect(string _label, string _connString)
        {
            connection = new OleDbConnection(_connString);
            //using (Service.Instance.connection = new OleDbConnection(_connString))
            {
                try
                {
                    connection.Open();

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "connects.txt");
                    File.OpenWrite(path).Close();

                    List<string> _connects = File.ReadAllLines(path).ToList();
                    if (!_connects.Any(item => item.Contains(_connString)))
                    {
                        _connects.Add($"Label={_label}{_connString}");
                        File.WriteAllLines(path, _connects);
                    }
                    connection.Close();
                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false; ;
                }
                // The connection is automatically closed when the
                // code exits the using block.
            }




            //SqlConnection conn = new SqlConnection(_connString);

            //try
            //{
            //    conn.Open();
            //    MessageBox.Show("Passed");

            //    return true;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Failure");
            //    return false;
            //}

        }

        public List<Invoice> Search(DateTime from, DateTime to, InvoiceType selectedType)
        {
            
            List<Invoice> result = new List<Invoice>();

            string type = "";
            switch (selectedType)
            {
                case InvoiceType.Cash:
                    type = "CA";
                    break;
                case InvoiceType.Credit:
                    type = "CC";
                    break;
                case InvoiceType.Check:
                    type = "CH";
                    break;
                case InvoiceType.DebitCard:
                    type = "DC";
                    break;
                case InvoiceType.GiftCard:
                    type = "GC";
                    break;
                case InvoiceType.All:
                    type = null;
                    break;
            }

            //using (Service.Instance.connection = new OleDbConnection(connString))
            {

                string queryString = "";
                if (type == null)
                {
                    queryString = $"SELECT MAX(dbo.Invoices.Store_ID) as StoreID, dbo.Invoices.Invoice_Number as Number, MAX(dbo.Invoices.DateTime) as DateTime, MAX(dbo.Invoices.Payment_Method) as Type, SUM(dbo.Invoice_Itemized.LineNum) as LineCount, MAX(dbo.Invoices.Grand_Total) as GrandTotal, CAST(ROUND((SUM(dbo.Invoice_Itemized.PricePer)+SUM(dbo.Invoice_Itemized.Tax1Per)+SUM(dbo.Invoice_Itemized.Tax2Per)),2) as numeric(36,2)) as ModeTotal\r\nFROM dbo.Invoices\r\nLEFT JOIN dbo.Invoice_Itemized ON dbo.Invoices.Invoice_Number = dbo.Invoice_Itemized.Invoice_Number\r\nWHERE DateTime > '{from}' AND DateTime < '{to}' \r\nGROUP BY dbo.Invoices.Invoice_Number\r\n";
                }
                else
                {
                    queryString = $"SELECT MAX(dbo.Invoices.Store_ID) as StoreID, dbo.Invoices.Invoice_Number as Number, MAX(dbo.Invoices.DateTime) as DateTime, MAX(dbo.Invoices.Payment_Method) as Type, SUM(dbo.Invoice_Itemized.LineNum) as LineCount, MAX(dbo.Invoices.Grand_Total) as GrandTotal, CAST(ROUND((SUM(dbo.Invoice_Itemized.PricePer)+SUM(dbo.Invoice_Itemized.Tax1Per)+SUM(dbo.Invoice_Itemized.Tax2Per)),2) as numeric(36,2)) as ModeTotal\r\nFROM dbo.Invoices\r\nLEFT JOIN dbo.Invoice_Itemized ON dbo.Invoices.Invoice_Number = dbo.Invoice_Itemized.Invoice_Number\r\nWHERE DateTime > '{from}' AND DateTime < '{to}' AND Payment_Method = '{type}'\r\nGROUP BY dbo.Invoices.Invoice_Number\r\n";
                }

                connection.Open();
                result = connection.Query<Invoice>(queryString).ToList();
                connection.Close();
            }

            return result;
        }


        public List<Invoice> Update(List<int> numbers)
        {
            string connString = $"Provider=SQLOLEDB.1;Server=192.168.125.25;uid=testuser;pwd=!Aa12345;Database=KCIMART";

            List<Invoice> result = new List<Invoice>();

            //using (Service.Instance.connection = new OleDbConnection(connString))
            {
                isLoading = true;
                string strNumbers = string.Join(",", numbers);
                connection.Open();
                for(int i = 0; i < numbers.Count; i++)
                {
                    string firstQuery = $"Update dbo.Invoice_Itemized SET IsAnalyzed = 1 Where Invoice_Number = {numbers[i]}";
                    string secondQuery = $"Update dbo.Labels_Activity SET IsAnalyzed = 1 Where TransactionNumber = {numbers[i]}";
                    CommandDefinition command = new CommandDefinition(firstQuery, connString);
                    int resCode = connection.Execute(firstQuery);
                    resCode = connection.Execute(secondQuery);

                }
                isLoading = false;

                connection.Close();
            }

            return result;
        }


        private Service() 
        { 

        }
        ~ Service()
        {
            if (connection != null)
            {
                connection.Dispose();
            }
        }

        public static Service Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Service();
                    }
                }

                return instance;
            }
        }
    }
}
