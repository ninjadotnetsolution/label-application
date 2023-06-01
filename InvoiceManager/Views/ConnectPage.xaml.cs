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
using LabelManager.Models;
using LabelManager.ViewModels;

namespace LabelManager.Views
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

        private void onItemSelect(object sender, SelectionChangedEventArgs e)
        {
            if (this.DataContext != null)
            {
                Connect connect = ((dynamic)this.DataContext).SelectedConnect;
                dbPassword.Password = connect.DBPassword;
            }
        }
    }
}
