using LabelManager.Common;
using LabelManager.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LabelManager.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public MainWindowVM()
        {
            PreNavigationCommand = new RelayCommand(o => preNavigationClick(o));
            CloseCommand = new RelayCommand(o => closeClick(o));
            this.MainFrame = new Frame();
            MainFrame.Navigate(new ConnectPage());
        }


        public Frame MainFrame
        {
            get => Helpers.mainFrame;
            set
            {
                Helpers.mainFrame = value;
                OnPropertyChanged("MainFrame");
            }
        }


        public ICommand PreNavigationCommand { get; set; }
        private void preNavigationClick(object sender)
        {
            this.MainFrame.Navigate(new ConnectPage());
        }

        public ICommand CloseCommand { get; set; }
        private void closeClick(object sender)
        {
            Environment.Exit(Environment.ExitCode);
        }

    }
}
