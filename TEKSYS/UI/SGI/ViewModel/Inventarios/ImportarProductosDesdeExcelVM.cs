using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.ViewModel.Catalogos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Inventarios
{
    public class ImportarProductosDesdeExcelVM : ViewModelBase
    {
        #region privateFields

        private int idProveedor = -1;
        private string proveedor;
        private string rutaArchivo;



        #endregion

        public ImportarProductosDesdeExcelVM()
        {

        }

        #region Public Properties

        public string RutaArchivo
        {
            get { return rutaArchivo; }
            set
            {
                rutaArchivo = value;
                RaisePropertyChanged(() => RutaArchivo);
            }
        }


        public ICommand Importarcmd
        {
            get
            {
                return new RelayCommand(s => Importar());
            }
        }

        public string Proveedor
        {
            get { return proveedor; }
            set
            {
                proveedor = value;
                RaisePropertyChanged(() => Proveedor);
            }
        }


        public ICommand BuscarProveedorCmd
        {
            get
            {
                return new RelayCommand(s => BuscarProveedor());
            }
        }


        public ICommand BuscarArchivoCmd
        {
            get
            {
                return new RelayCommand(s => BuscarArchivo());
            }

        }
        #endregion



        private void BuscarProveedor()
        {
            try
            {
                CatalogoProveedoresView view = new CatalogoProveedoresView();
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoProveedoresVM supplierkVM = new CatalogoProveedoresVM();
                view.DataContext = supplierkVM;
                supplierkVM.OnAddSupplier += ((s, e) => view.Close());
                view.ShowDialog();


                if (view.DataContext != null)
                {
                    this.idProveedor = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Id;
                    this.Proveedor = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Name;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void BuscarArchivo()
        {
            try
            {
                RutaArchivo = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = ".xlsx";
                dialog.Filter = "(.xlsx)|*.xlsx";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.Cancel))
                    return;
                else
                {
                    RutaArchivo = dialog.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void Importar()
        {
            try
            {
                if (this.idProveedor == -1)
                {
                    MessageBox.Show("Debe elegir un proveedor");
                    return;
                }


                if (string.IsNullOrEmpty(rutaArchivo))
                {
                    MessageBox.Show("Debe elegir unarchivo");
                    return;
                }


                var res = MessageBox.Show("¿Esta seguro de querer importar los productos?", "Confirmacion", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (res != MessageBoxResult.OK)
                {
                    return;
                }

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
                var Data = new ObservableCollection<ProductoExcel>();

                for (row = 2; row <= 200; row++)
                {
                    var item = new ProductoExcel()
                    {
                        CVEProveedor = Convert.ToString((range.Cells[row, initColumn] as Range).Value),
                        NombreProducto = Convert.ToString((range.Cells[row, initColumn + 1] as Range).Value),
                        Precio = Convert.ToDouble((range.Cells[row, initColumn + 2] as Range).Value),
                        Cantidad = 0

                    };

                    if (!String.IsNullOrEmpty(item.CVEProveedor) && item.Precio > 0)
                        Data.Add(item);

                }
                workbook.Close(false, Missing.Value, Missing.Value);
                excelApp.Quit();

                dt_cerrar(Data);

                MessageBox.Show("Productos importados con exito");
                this.Proveedor = string.Empty;
                this.idProveedor = -1;
                this.RutaArchivo = string.Empty;

            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al importar el archivo, verifica que las columnas tengan datos y haber seleccionado el area de impresion..", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void dt_cerrar(ObservableCollection<ProductoExcel> Data)
        {

            if (Data != null && Data.Count > 0)
            {

                var allproducts = Repository.GetProducts(string.Empty, string.Empty, SGI.Properties.Settings.Default.Matriz);

                foreach (var item in Data)
                {
                    var exist = allproducts.FirstOrDefault(s => s.CveProvider == item.CVEProveedor && s.IdProvider == idProveedor);

                    string errorMessage = string.Empty;
                    int error = 0;
                    if (exist != null)
                    {
                        exist.Cost = item.Precio.Value;
                        exist.Description = item.NombreProducto;
                        Repository.UpdateProducto(exist, ref error, ref errorMessage);
                    }
                    else
                    {
                        var product = new Product()
                        {
                            CveProvider = item.CVEProveedor,
                            CveTeknobike = item.CVEProveedor,
                            Name = item.NombreProducto,
                            Description = item.NombreProducto,
                            Cost = item.Precio.Value,
                            IdProvider = idProveedor
                        };

                        Repository.InsertProducto(product, ref error, ref errorMessage);
                    }
                }


            }

        }

    }
}
