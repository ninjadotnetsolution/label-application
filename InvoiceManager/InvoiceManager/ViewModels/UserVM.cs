using InvoiceManager.Common;
using InvoiceManager.Models;
using InvoiceManager.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InvoiceManager.ViewModels
{
    internal class UserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public UserVM()
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "connects.txt");
            File.OpenWrite(path).Close();

            if (File.Exists(path))
            {
                List<string> _connects = File.ReadAllLines(path).ToList();
                for(int i = 2; i < _connects.Count; i++)
                {
                    if (_connects[i].Length > 0)
                    {
                        connects.Add(new Connect(i, _connects[i]));
                    }

                }
            }

            ConnectCommand = new RelayCommand(o => connectClick(o));
            TestCommand = new RelayCommand(o => testClick(o));
            ResetPasswordCommand = new RelayCommand(o => resetPasswordClick(o));

        }


        private ObservableCollection<Connect> connects = new ObservableCollection<Connect>();
        public ObservableCollection<Connect> Connects
        {
            get => connects;
            set
            {
                connects = value;
                OnPropertyChanged("Connects");
            }
        }

        private Connect selectedConnect { get; set; }
        public Connect SelectedConnect
        {
            get => selectedConnect;
            set
            {
                selectedConnect = value;
                Label = selectedConnect.Label;
                Provider = selectedConnect.Provider;
                Server = selectedConnect.Server;
                Database = selectedConnect.Database;
                DBUserName = selectedConnect.DBUserName;
                DBPassword = selectedConnect.DBPassword;
                OnPropertyChanged("SelectedConnect");
                OnPropertyChanged("Label");
                OnPropertyChanged("HostName");
                OnPropertyChanged("Database");
                OnPropertyChanged("DBUserName");
                OnPropertyChanged("DBPassword");
            }
        }

        private Visibility isProcessing = Visibility.Hidden;
        public Visibility IsProcessing
        {
            get => isProcessing;
            set
            {
                isProcessing = value;
                this.OnPropertyChanged("IsProcessing");
            }
        }

        private bool connectable = false;
        public bool Connectable
        {
            get => connectable;
            set
            {
                connectable = value;
                this.OnPropertyChanged("Connectable");
            }
        }

        private string connString { get; set; } = "";
        public string ConnString
        {
            get => connString;
            set
            {
                connString = value;
                OnPropertyChanged("ConnString");
            }
        }

        private string userName { get; set; } = "konark";
        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged("UserName");
            }
        }

        private string password { get; set; } = "Biryan!123";
        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }

        private string newPassword { get; set; } = "";
        public string NewPassword
        {
            get => newPassword;
            set
            {
                newPassword = value;
                OnPropertyChanged("NewPassword");
            }
        }

        private string cfmPassword { get; set; } = "";
        public string CfmPassword
        {
            get => cfmPassword;
            set
            {
                cfmPassword = value;
                OnPropertyChanged("CfmPassword");
            }
        }

        private string label { get; set; } = "";
        public string Label
        {
            get => label;
            set
            {
                label = value;
                OnPropertyChanged("Label");
            }
        }

        private string server { get; set; }
        public string Server
        {
            get => server;
            set
            {
                server = value;
                OnPropertyChanged("Server");
            }
        }

        private string provider { get; set; } = "SQLOLEDB.1";
        public string Provider
        {
            get => provider;
            set
            {
                provider = value;
                OnPropertyChanged("Provider");
            }
        }

        private string database { get; set; } = "";
        public string Database
        {
            get => database;
            set
            {
                database = value;
                OnPropertyChanged("Database");
            }
        }

        private string dbUserName { get; set; } = "";
        public string DBUserName
        {
            get => dbUserName;
            set
            {
                dbUserName = value;
                OnPropertyChanged("DBUserName");
            }
        }

        private string dbPassword { get; set; } = "pcAmer1ca";
        public string DBPassword
        {
            get => dbPassword;
            set
            {
                dbPassword = value;
                OnPropertyChanged("DBPassword");
            }
        }

        public ICommand ConnectCommand { get; set; }
        private async void connectClick(object sender)
        {
            IsProcessing = Visibility.Visible;
            var path = Path.Combine(Directory.GetCurrentDirectory(), "connects.txt");
            string _user = "";
            string _password = "";
            if (File.Exists(path))
            {
                List<string> words = File.ReadAllLines(path).ToList();
                _user = words[0];
                _password = words[1];
            } else
            {
                var asmbly = Assembly.GetExecutingAssembly();
                var filePath = "InvoiceManager.Resources.credential.txt";
                using (Stream s = asmbly.GetManifestResourceStream(filePath))
                using (StreamReader sr = new StreamReader(s))
                {
                    string credential = sr.ReadLine();
                    _user = credential.Split(' ')[0];
                    _password = credential.Split(' ')[1];
                }
            }
            if (_user != userName || _password != password)
            {
                IsProcessing = Visibility.Hidden;
                MessageBox.Show("Wrong password");
                return;
            }

            await Task.Run(async () =>
            {
                if (await Service.Instance.Connect(label, provider, server, database, dbUserName, dbPassword, connString))
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate {
                        // your code
                        Helpers.mainFrame.Navigate(new SearchPage());
                    });
                }
                IsProcessing = Visibility.Hidden;
            });

        }

        public ICommand ResetPasswordCommand { get; set; }
        private void resetPasswordClick(object sender)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "connects.txt");
            string _user = "";
            string _password = "";
            if (File.Exists(path))
            {
                List<string> words = File.ReadAllLines(path).ToList();
                _user = words[0];
                _password = words[1];
            }
            else
            {
                var asmbly = Assembly.GetExecutingAssembly();
                var filePath = "InvoiceManager.Resources.credential.txt";
                using (Stream s = asmbly.GetManifestResourceStream(filePath))
                using (StreamReader sr = new StreamReader(s))
                {
                    string credential = sr.ReadLine();
                    _user = credential.Split(' ')[0];
                    _password = credential.Split(' ')[1];
                }


            }


            if ((_user != userName || _password != password) || cfmPassword != newPassword)
            {
                return;
            }else
            {

                File.OpenWrite(path).Close();

                List<string> _connects = new List<string>();
                _connects.Add(_user);
                _connects.Add(newPassword);
                List<string> _original = File.ReadAllLines(path).ToList();
                for (int i = 2; i < _original.Count; i++)
                {
                    _connects.Add(_original[i]);
                }
                for (int i = 2; i < _connects.Count; i++)
                {
                    File.WriteAllLines(path, _connects);
                }
            }

        }

        public ICommand TestCommand { get; set; }
        private async void testClick(object sender)
        {
            IsProcessing = Visibility.Visible;
            await Task.Run(async () =>
            {
                bool result = await Service.Instance.Connect(Label, provider, server, database, dbUserName, dbPassword, connString);
                    
                if (result)
                {
                    MessageBox.Show("Success");
                }
                IsProcessing = Visibility.Hidden;
            });

        }


    }
}
