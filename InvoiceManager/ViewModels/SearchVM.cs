using InvoiceManager.Common;
using InvoiceManager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InvoiceManager.ViewModels
{
    public class SearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SearchVM() {
            db = new InvoiceDbContext();

            db.Invoices = new List<Invoice>();
            Invoices = new ObservableCollection<Invoice>(db.Invoices);
            CloseCommand = new RelayCommand(o => closeClick(o));
            ResetCommand = new RelayCommand(o => resetClick(o));
            ProcessCommand = new RelayCommand(o => processClick(o));

            SearchCommand = new RelayCommand(o => searchClick(o));
            InvoiceTypes = new ObservableCollection<InvoiceType> { InvoiceType.All, InvoiceType.Cash, InvoiceType.Credit, InvoiceType.Check, InvoiceType.DebitCard, InvoiceType.GiftCard };

        }

        public InvoiceDbContext db;

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


        private List<User> selectedItems = new List<User>();
        public List<User> SelectedItems
        {
            get => selectedItems;
            set
            {
                selectedItems = value;
                this.OnPropertyChanged("SelectedItems");
            }
        }

        private DateTime from = new DateTime(2010, 1, 1);
        public DateTime From
        {
            get => from;
            set {
                from = value;
                this.OnPropertyChanged("To");
            }
        }

        
        private DateTime to = new DateTime(DateTime.Today);
        public DateTime To
        {
            get => to;
            set
            {
                to = value;
                this.OnPropertyChanged("To");
            }
        }

        private InvoiceType selectedType = InvoiceType.Cash;
        public InvoiceType SelectedType
        {
            get => selectedType;
            set
            {
                selectedType = value;
                this.OnPropertyChanged("SelectedType");
            }
        }

        private Summary totalSummary = new Summary();
        public Summary TotalSummary
        {
            get => totalSummary;
            set
            {
                totalSummary = value;
                this.OnPropertyChanged("TotalSummary");
            }
        }

        private Summary selectedSummary = new Summary();
        public Summary SelectedSummary
        {
            get => selectedSummary;
            set
            {
                selectedSummary = value;
                this.OnPropertyChanged("SelectedSummary");
            }
        }

        public ObservableCollection<InvoiceType> InvoiceTypes { get; set; } 



        private ObservableCollection<Invoice> invoices = new ObservableCollection<Invoice>();
        public ObservableCollection<Invoice> Invoices
        {
            get => invoices;
            set
            {
                invoices = value;
                OnPropertyChanged("Invoices");
            }
        }

        private ObservableCollection<Invoice> filteredInvoices = new ObservableCollection<Invoice>();
        public ObservableCollection<Invoice> FilteredInvoices
        {
            get
            {

                TotalSummary.TotalInvoicecs = filteredInvoices.Count;
                TotalSummary.TotalGrand = filteredInvoices.Sum(item => item.GrandTotal);
                TotalSummary.Credit = filteredInvoices.Where(item => item.Type == "CC").Sum(item => item.GrandTotal);
                TotalSummary.Cash = filteredInvoices.Where(item => item.Type == "CA").Sum(item => item.GrandTotal);
                TotalSummary.Gift = filteredInvoices.Where(item => item.Type == "GC").Sum(item => item.GrandTotal);
                TotalSummary.Other = filteredInvoices.Where(item => item.Type == "DC").Sum(item => item.GrandTotal);
                OnPropertyChanged("TotalSummary");
                return filteredInvoices;
            }
            set
            {
                filteredInvoices = value;
                OnPropertyChanged("FilteredInvoices");
            }
        }

        private ObservableCollection<Invoice> selectedInvoices = new ObservableCollection<Invoice>();
        public ObservableCollection<Invoice> SelectedInvoices
        {
            get
            {
                return selectedInvoices;
            }
            set
            {

                selectedInvoices = value;

                selectedSummary.TotalInvoicecs = filteredInvoices.Where(item => item.Checked).ToList().Count;
                selectedSummary.TotalGrand = filteredInvoices.Where(item => item.Checked).Sum(item => item.GrandTotal);
                selectedSummary.Credit = filteredInvoices.Where(item => item.Checked && item.Type == "CC").Sum(item => item.GrandTotal);
                selectedSummary.Cash = filteredInvoices.Where(item => item.Checked && item.Type == "CA").Sum(item => item.GrandTotal);
                selectedSummary.Gift = filteredInvoices.Where(item => item.Checked && item.Type == "GC").Sum(item => item.GrandTotal);
                selectedSummary.Other = filteredInvoices.Where(item => item.Checked && item.Type == "DC").Sum(item => item.GrandTotal);
                OnPropertyChanged("selectedSummary");
                OnPropertyChanged("SelectedInvoices");
            }
        }


        public ICommand SearchCommand { get; set; }
        private async void searchClick(object sender)
        {
            await Task.Run(async () =>
            {
                filteredInvoices = new ObservableCollection<Invoice>(await Service.Instance.Search(From, To, SelectedType));
                OnPropertyChanged("FilteredInvoices");
            });
        }

        public ICommand CloseCommand { get; set; }
        private void closeClick(object sender)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public ICommand ResetCommand { get; set; }
        private void resetClick(object sender)
        {
            From = new DateTime();
            To = new DateTime();
            SelectedType = InvoiceType.All;
        }

        public ICommand ProcessCommand { get; set; }
        private async void processClick(object sender)
        {
            var selectedItems = FilteredInvoices.Select(item => item.Number);
            if(selectedItems.Count() > 0)
            {
                IsProcessing = Visibility.Visible;
                Cursor.Current = Cursors.WaitCursor;
                await Task.Run(async () =>
                {
                    await Service.Instance.Update(selectedItems.ToList());

                    IsProcessing = Visibility.Hidden;
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("All Invoices Processed Succesfully");
                    filteredInvoices = new ObservableCollection<Invoice>(await Service.Instance.Search(From, To, SelectedType));
                    OnPropertyChanged("FilteredInvoices");
                });
            }
        }
    }
}
