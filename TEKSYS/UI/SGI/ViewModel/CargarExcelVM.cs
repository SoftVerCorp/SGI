using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Office.Interop.Excel;

namespace SGI.ViewModel
{
    public class CargarExcelVM : ViewModelBase
    {
        private ObservableCollection<ProductoExcel> data;
        public event EventHandler cerrar;
        public ObservableCollection<ProductoExcel> Data
        {
            get { return data; }
            set 
            { 
                data = value;
                RaisePropertyChanged("Data");
            }
        }

        public CargarExcelVM()
        {

        }

        public ICommand CargarExcel
        {
            get { return new RelayCommand(OnCargarExcel); }
        }

        public ICommand AceptarExcel
        {
            get { return new RelayCommand(OnAceptarExcel); }
        }


        private void OnCargarExcel()
        {
            try
            {
                var rutaArchivo = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = ".xlsx";
                dialog.Filter = "(.xlsx)|*.xlsx";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.Cancel))
                    return;
                else
                {
                    rutaArchivo = dialog.FileName;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook;
                    Microsoft.Office.Interop.Excel.Worksheet worksheet;
                    Microsoft.Office.Interop.Excel.Range range;
                    workbook = excelApp.Workbooks.Open(rutaArchivo);
                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                    range = worksheet.UsedRange;

                    int column = 0;
                    int row = 0;

                    //var initRow = 0;
                    var initColumn = 1;
                    Data = new ObservableCollection<ProductoExcel>();

                    for (row = 2; row <= 500; row++)
                    {
                        var item = new ProductoExcel()
                        {
                            CVEProveedor = Convert.ToString((range.Cells[row, initColumn] as Range).Value),
                            NombreProducto = Convert.ToString((range.Cells[row, initColumn + 1] as Range).Value),
                            Precio = Convert.ToDouble((range.Cells[row, initColumn + 2] as Range).Value),
                            Cantidad = Convert.ToDouble((range.Cells[row, initColumn + 3] as Range).Value)

                        };
                        if(!String.IsNullOrEmpty(item.CVEProveedor) && item.Precio > 0)
                            data.Add(item);

                    }
                    workbook.Close(false, Missing.Value, Missing.Value);
                    excelApp.Quit();
                    RaisePropertyChanged(() => Data);
                }
            }
            catch(Exception ex)
            {
                System.Windows.MessageBox.Show("Error al importar el archivo, verifica que las columnas tengan datos y haber seleccionado el area de impresion.." , "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnAceptarExcel()
        {
            if (cerrar != null)
                cerrar(this, new EventArgs());
        }
    }

    
    public class ProductoExcel
    {
        public string CVEProveedor { get; set; }
        public string NombreProducto { get; set; }
        public double? Precio { get; set; }
        public double? Cantidad { get; set; }
    }
}
