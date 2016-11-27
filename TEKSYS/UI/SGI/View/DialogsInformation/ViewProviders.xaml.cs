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

namespace SGI.View.DialogsInformation
{
    /// <summary>
    /// Interaction logic for ViewProviders.xaml
    /// </summary>
    public partial class ViewProviders : UserControl
    {
        private bool isExpandedSearch;
        private bool isExpandedNew;

        public ViewProviders()
        {
            InitializeComponent();
            isExpandedSearch = true;
            isExpandedNew = true;
            bdrOperations.Visibility = System.Windows.Visibility.Collapsed;
            brdSearch.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!isExpandedNew)
            {

                bdrOperations.Visibility = System.Windows.Visibility.Collapsed;
                isExpandedNew = true;
            }
            else
            {
                bdrOperations.Visibility = System.Windows.Visibility.Visible;
                isExpandedNew = false;
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (!isExpandedSearch)
            {
                brdSearch.Visibility = System.Windows.Visibility.Collapsed;
                isExpandedSearch = true;
            }
            else
            {
                brdSearch.Visibility = System.Windows.Visibility.Visible;
                isExpandedSearch = false;
            }

        }
    }
}
