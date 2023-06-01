using Dapper;
using LabelManager.Models;
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

namespace LabelManager.Common
{
   

    public sealed class Service
    {
        private static volatile Service instance;
        private static object syncRoot = new Object();

        public OleDbConnection connection;
        public bool isLoading = false;
        public async Task<bool> Connect(string _label, string _provider, string _server, string _database, string _userName, string _password, string _connString)
        {
            if (_connString != null && _connString.Length > 0 && _connString.Split(';').Length > 4)
            {
                return await Connect(_label, _connString);
            }
            
            string connString = $"Provider={_provider};Server={_server};uid={_userName};pwd={_password};Database={_database}";
            connection = new OleDbConnection(connString);
            {
                try
                {
                    await connection.OpenAsync();
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
            }
        }

        public async Task<bool> Connect(string _label, string _connString)
        {
            connection = new OleDbConnection(_connString);
            {
                try
                {
                    await connection.OpenAsync();

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
            }
        }

        public async Task<List<Invoice>> Search(DateTime from, DateTime to, InvoiceType selectedType)
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

            {

                string queryString = "";
                if (type == null)
                {
                    queryString = $"SELECT IT.Invoice_Number as Number, IT.DateTime as DateTime , IIF(IT.CustNum = '101', 'N', 'Y') as Member, \r\nIT.Payment_Method as Type, II1.LineCount as LineCount, \r\nCAST(ROUND((II.PricePer+II.Tax1Per+II.Tax2Per),2) as numeric(36,2)) as ModeTotal, \r\nIT.Grand_Total as GrandTotal FROM [dbo].[Invoice_Totals] IT \r\nINNER JOIN [dbo].[Invoice_Itemized] II ON IT.Invoice_Number = II.Invoice_Number \r\nINNER JOIN (Select IIS.Invoice_Number, Count(IIS.LineNum) as LineCount \r\nFROM [dbo].[Invoice_Itemized] IIS  GROUP BY IIS.Invoice_Number) II1 ON IT.Invoice_Number = II1.Invoice_Number \r\nWHERE II.LineNum = 1 AND IT.Grand_Total > 0 AND CONVERT(VARCHAR(8), IT.DateTime, 112) >= '{Helpers.DateToStr12(from)}' AND CONVERT(VARCHAR(8), IT.DateTime, 112) <= '{Helpers.DateToStr12(to)}' ORDER BY IT.Grand_Total DESC";
                }
                else
                {
                    queryString = $"SELECT IT.Invoice_Number as Number, IT.DateTime as DateTime , IIF(IT.CustNum = '101', 'N', 'Y') as Member, \r\nIT.Payment_Method as Type, II1.LineCount as LineCount, \r\nCAST(ROUND((II.PricePer+II.Tax1Per+II.Tax2Per),2) as numeric(36,2)) as ModeTotal, \r\nIT.Grand_Total as GrandTotal FROM [dbo].[Invoice_Totals] IT \r\nINNER JOIN [dbo].[Invoice_Itemized] II ON IT.Invoice_Number = II.Invoice_Number \r\nINNER JOIN (Select IIS.Invoice_Number, Count(IIS.LineNum) as LineCount \r\nFROM [dbo].[Invoice_Itemized] IIS  GROUP BY IIS.Invoice_Number) II1 ON IT.Invoice_Number = II1.Invoice_Number \r\nWHERE II.LineNum = 1 AND IT.Grand_Total > 0 AND CONVERT(VARCHAR(8), IT.DateTime, 112) >= '{Helpers.DateToStr12(from)}' AND CONVERT(VARCHAR(8), IT.DateTime, 112) <= '{Helpers.DateToStr12(to)}' \r\nAND IT.Payment_Method = '{type}' ORDER BY IT.Grand_Total DESC";
                }

                try
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryAsync<Invoice>(queryString, null, null, 60, null);
                    result = res.ToList();
                    if(result.Count == 0)
                    {
                        MessageBox.Show("No Invoice Records are Available");
                    }
                    connection.Close();

                }catch
                {
                    MessageBox.Show("Query Timed Out");

                }
            }

            return result;
        }

        public async Task<List<TypeTotal>> GetTotal(DateTime from, DateTime to)
        {
            List<TypeTotal> result = new List<TypeTotal>();

            {
                string queryString = $"Select IT.Payment_Method as Type, COUNT(IT.Invoice_Number) as InvoiceCount, SUM(IT.Grand_Total) as GrandTotal\r\n FROM [dbo].[Invoice_Totals] IT\r\n WHERE \r\n CONVERT(VARCHAR(8), IT.DateTime, 112) >= '{Helpers.DateToStr12(from)}' AND CONVERT(VARCHAR(8), IT.DateTime, 112) <= '{Helpers.DateToStr12(to)}' \r\n GROUP BY IT.Payment_Method";
                try
                {
                    await connection.OpenAsync();
                    var res = await connection.QueryAsync<TypeTotal>(queryString, null, null, 60, null);
                    result = res.ToList();
                    connection.Close();

                }
                catch
                {
                }
            }

            return result;
        }


        public async Task<List<Invoice>> Update(List<int> numbers)
        {
            List<Invoice> result = new List<Invoice>();

            {
                isLoading = true;
                await connection.OpenAsync(); ;
                for(int i = 0; i < numbers.Count; i++)
                {
                    string firstQuery = $"Update dbo.Invoice_Itemized SET IsAnalyzed = 1 Where Invoice_Number = {numbers[i]}";
                    string secondQuery = $"Update dbo.Labels_Activity SET IsAnalyzed = 1 Where TransactionNumber = {numbers[i]}";
                    int resCode = connection.Execute(firstQuery);
                    if (resCode == 1)
                    {
                        connection.Execute(secondQuery);
                    }

                }
                isLoading = false;

                connection.Close();
            }

            return result;
        }


        private Service() 
        { }
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
