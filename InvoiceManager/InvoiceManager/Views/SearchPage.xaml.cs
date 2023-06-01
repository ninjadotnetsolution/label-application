using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using InvoiceManager.Models;
using InvoiceManager.ViewModels;

namespace InvoiceManager.Views
{
    /// <summary>
    /// Interaction logic for SearchPage.xaml
    /// </summary>
    public partial class SearchPage : Page
    {
        public SearchPage()
        {
            InitializeComponent();
            DataContext = new SearchVM();
        }

        private void onSelectInvoices(object sender, SelectionChangedEventArgs args)
        {
            if (this.DataContext != null)
            {
                ObservableCollection<Invoice> selectedItems = ((dynamic)this.DataContext).SelectedInvoices;
                ObservableCollection<Invoice> items = ((dynamic)this.DataContext).FilteredInvoices;
                foreach (Invoice item in args.AddedItems)
                {
                    items = new ObservableCollection <Invoice> (items.Select(it =>
                    {
                        if(it.Number == item.Number)
                        {
                            it.Checked = true;
                        }
                        return it;
                    }));
                    selectedItems.Add(item);
                }
                foreach (Invoice item in args.RemovedItems)
                {
                    items = new ObservableCollection<Invoice>(items.Select(it =>
                    {
                        if (it.Number == item.Number)
                        {
                            it.Checked = false;
                        }
                        return it;
                    }));
                    selectedItems.Remove(item);
                }

                ((dynamic)this.DataContext).SelectedInvoices = selectedItems;
                ((dynamic)this.DataContext).FilteredInvoices = items;
            }
        }
    }
}
