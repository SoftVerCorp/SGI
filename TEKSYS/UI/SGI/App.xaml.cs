using SGI.View;
using SGI.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SGI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                Loggin login = new Loggin();
                login.DataContext = new LoginVM();
                login.ShowDialog();

                //NewEmployee view = new NewEmployee();
                //view.DataContext = new NewEmployeeVM();
                //view.ShowDialog();

                //MainWindow mainWindow = new MainWindow();
                //mainWindow.DataContext = new MainVM(string.Empty);
                //mainWindow.Show();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
