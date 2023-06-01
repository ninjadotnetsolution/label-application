using LabelManager.Common;
using LabelManager.Models;
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

namespace LabelManager.ViewModels
{
    public class SearchVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public SearchVM() {

            CloseCommand = new RelayCommand(o => closeClick(o));
            ResetCommand = new RelayCommand(o => resetClick(o));
            ProcessCommand = new RelayCommand(o => processClick(o));

            SearchCommand = new RelayCommand(o => searchClick(o));
            InvoiceTypes = new ObservableCollection<InvoiceType> { InvoiceType.All, InvoiceType.Cash, InvoiceType.Credit, InvoiceType.GiftCard };

            From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day );

         
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

        private DateTime from = DateTime.Today;
        public DateTime From
        {
            get => from;
            set {
                from = value;
                this.OnPropertyChanged("From");
            }
        }

        
        private DateTime to = DateTime.Today;
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

        private SubSummary selectedSummary = new SubSummary();
        public SubSummary SelectedSummary
        {
            get => selectedSummary;
            set
            {
                selectedSummary = value;
                this.OnPropertyChanged("SelectedSummary");
            }
        }

        public ObservableCollection<InvoiceType> InvoiceTypes { get; set; }

        private ObservableCollection<TypeTotal> typeTotals = new ObservableCollection<TypeTotal>();
        public ObservableCollection<TypeTotal> TypeTotals
        {
            get => typeTotals;
            set
            {
                typeTotals = value;
                TotalSummary.TotalInvoicecs = TotalSummary.TotalInvoicecs;
                TotalSummary.TotalGrand = typeTotals.Sum(item => item.GrandTotal);
                var cash = typeTotals.FirstOrDefault(item => item.Type == "CA");
                if (cash != null)
                {
                    TotalSummary.Cash = cash.GrandTotal;
                }
                var credit = typeTotals.FirstOrDefault(item => item.Type == "CC");
                if (credit != null)
                {
                    TotalSummary.Credit = credit.GrandTotal;
                }
                var gift = typeTotals.FirstOrDefault(item => item.Type == "GC");
                if (gift != null)
                {
                    TotalSummary.Gift = gift.GrandTotal;
                }
                var other = typeTotals.FirstOrDefault(item => item.Type == "DC" || item.Type == "ST");
                if (other != null)
                {
                    TotalSummary.Other = other.GrandTotal;
                }
                this.OnPropertyChanged("TotalSummary");
                OnPropertyChanged("TypeTotals");
            }
        }



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
                return filteredInvoices;
            }
            set
            {
                filteredInvoices = value;
                TotalSummary.TotalInvoicecs = filteredInvoices.Count;
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

                SelectedSummary.TotalInvoicecs = filteredInvoices.Where(item => item.Checked).ToList().Count;
                SelectedSummary.Amount = filteredInvoices.Where(item => item.Checked).Sum(item => item.GrandTotal - item.ModeTotal)*3/100;
                switch (SelectedType)
                {
                    case InvoiceType.Cash:
                        SelectedSummary.Balance = (TotalSummary.TotalGrand - TotalSummary.Cash) * 3 / 100 - SelectedSummary.Amount;
                        break;
                    case InvoiceType.GiftCard:
                        SelectedSummary.Balance = (TotalSummary.TotalGrand - TotalSummary.Gift) * 3 / 100 - SelectedSummary.Amount;
                        break;
                    case InvoiceType.Credit:
                        SelectedSummary.Balance = (TotalSummary.TotalGrand - TotalSummary.Credit) * 3 / 100 - SelectedSummary.Amount;
                        break;
                    case InvoiceType.All:
                        SelectedSummary.Balance = (TotalSummary.TotalGrand - TotalSummary.Other) * 3 / 100 - SelectedSummary.Amount;
                        break;

                }
                OnPropertyChanged("SelectedSummary");
                OnPropertyChanged("SelectedInvoices");
            }
        }


        public ICommand SearchCommand { get; set; }
        private async void searchClick(object sender)
        {
            if (To < From)
            {
                MessageBox.Show("Invalid Date Range");
                return;
            }
            IsProcessing = Visibility.Visible;
            await Task.Run(async () =>
            {
                FilteredInvoices = new ObservableCollection<Invoice>(await Service.Instance.Search(From, To, SelectedType));
                OnPropertyChanged("FilteredInvoices");
                var _typeTotals = await Service.Instance.GetTotal(From, To);
                TypeTotals = new ObservableCollection<TypeTotal>(_typeTotals);

            });

            IsProcessing = Visibility.Hidden;

        }

        public ICommand CloseCommand { get; set; }
        private void closeClick(object sender)
        {
            Environment.Exit(Environment.ExitCode);
        }

        public ICommand ResetCommand { get; set; }
        private void resetClick(object sender)
        {
            From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            SelectedType = InvoiceType.All;
            FilteredInvoices = new ObservableCollection<Invoice>();

            SelectedInvoices = new ObservableCollection<Invoice>();
        }

        public ICommand ProcessCommand { get; set; }
        private async void processClick(object sender)
        {
            var selectedItems = FilteredInvoices.Select(item => item.Number);
            if(selectedItems.Count() > 0)
            {
                IsProcessing = Visibility.Visible;
                Mouse.OverrideCursor = Cursors.Wait;
                await Task.Run(async () =>
                {
                    await Service.Instance.Update(selectedItems.ToList());

                    IsProcessing = Visibility.Hidden;
                    Mouse.OverrideCursor = Cursors.Arrow;
                    MessageBox.Show("All Labels Processed Succesfully");
                    filteredInvoices = new ObservableCollection<Invoice>(await Service.Instance.Search(From, To, SelectedType));
                    OnPropertyChanged("FilteredInvoices");
                });
            }else
            {
                MessageBox.Show("Please select any item");
            }
        }
    }
}
