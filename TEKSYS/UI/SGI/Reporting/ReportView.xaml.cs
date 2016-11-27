using Microsoft.Reporting.WinForms;
using SGI.Enumeration;
using SGI.Model;
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
using System.Windows.Shapes;

namespace SGI.Reporting
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : Window
    {
        public ReportView()
        {
            InitializeComponent();
            this.Loaded += ReportView_Loaded;
        }

        void ReportView_Loaded(object sender, RoutedEventArgs e)
        {

        }

        public void GenerateOrderBuyDetailReport(int orderBuy, string orderBuyName, string employeeBuyer, string provider, string employeValidator)
        {
            try
            {
                //orderBuy = 24;
                //orderBuyName = "XXXXXX";
                //employeeBuyer = "Juan Miguel Perez Leal";
                //provider = "Juan Miguel Perez Leal 1";
                //employeValidator = "Jumipe";

                var lstDetails = Repository.GetOrdersBuyDetail(orderBuy);
                Reporting.LocalReport.ReportEmbeddedResource = ReportsName.OrderBuyDetailReport;
                Reporting.LocalReport.DataSources.Add(new ReportDataSource("DetailOrderBuy", lstDetails));
                Reporting.LocalReport.SetParameters(new ReportParameter("OrderBuy", orderBuyName));
                Reporting.LocalReport.SetParameters(new ReportParameter("EmployeeBuyer", employeeBuyer));
                Reporting.LocalReport.SetParameters(new ReportParameter("Provider", provider));
                Reporting.LocalReport.SetParameters(new ReportParameter("EmployeeValidator", employeValidator));

             
                Reporting.RefreshReport();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
