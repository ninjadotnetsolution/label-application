using System;
using System.Collections.Generic;
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
using InvoiceManager.ViewModels;

namespace InvoiceManager.Views
{
    /// <summary>
    /// Interaction logic for ConnectPage.xaml
    /// </summary>
    public partial class ConnectPage : Page
    {
        public ConnectPage()
        {
            InitializeComponent();
            DataContext = new UserVM();
        }

        private void onChangePass(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).Password = txtPassword.Password; }
        }

        private void onChangeNewPass(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).NewPassword = newPassword.Password; }
        }

        private void onChangeCfmPass(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).CfmPassword = cfmPassword.Password; }
        }

        private void onChangeDBPass(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            { ((dynamic)this.DataContext).DBPassword = dbPassword.Password; }
        }
    }
}
