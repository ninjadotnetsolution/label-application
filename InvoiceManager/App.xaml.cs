using LabelManager.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LabelManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        MainWindow mainWindow = null;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }

        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            
            SplashWindow splash = new SplashWindow();
            splash.Show();
            mainWindow = new MainWindow();
            Thread.Sleep(1500);
            mainWindow.Show();
            splash.Close();
        }
    }
}
