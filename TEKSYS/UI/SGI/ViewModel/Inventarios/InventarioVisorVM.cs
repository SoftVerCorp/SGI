using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Transactions;
using SGI.Helpers;

namespace SGI.ViewModel.Inventarios
{
    public class InventarioVisorVM : ViewModelBase
    {
        #region Private Fields

        private List<Ubicacion> ubicaciones;
        private List<InventarioProducto> inventario;
        private InventarioProducto productoSeleccionado;

        private Ubicacion ubicacionSel;
        private string producto;
        private int totalProductos;

        private int totalProductosEnInventario;



        #endregion

        #region Constructors

        public InventarioVisorVM()
        {
            try
            {

                ubicaciones = Repository.ObtenerUbicaciones();
                Ubicaciones.Insert(0, new Ubicacion { Id = -1, Nombre = "Selecciona ubicación", Activo = true });
                RaisePropertyChanged(() => Ubicaciones);

                UbicacionSel = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();

                //new Task(() =>
                //{
                    this.TotalProductosEnInventario = Repository.ObtenerTotalDeProductosEnInventario(ManejadorUbicacion.IdUbicacion);
                //});
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region Public Properties

        public int TotalProductosEnInventario
        {
            get { return totalProductosEnInventario; }
            set
            {
                totalProductosEnInventario = value;
                RaisePropertyChanged(() => TotalProductosEnInventario);
            }
        }

        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
            set
            {
                ubicaciones = value;
                RaisePropertyChanged(() => Ubicaciones);
            }
        }


        public List<InventarioProducto> Inventario
        {
            get { return inventario; }
            set
            {
                inventario = value;
                RaisePropertyChanged(() => Inventario);
            }
        }

        public Ubicacion UbicacionSel
        {
            get { return ubicacionSel; }
            set
            {
                ubicacionSel = value;
                RaisePropertyChanged(() => UbicacionSel);
            }
        }


        public string Producto
        {
            get { return producto; }
            set
            {
                producto = value;
                RaisePropertyChanged(() => Producto);
            }
        }


        public InventarioProducto ProductoSeleccionado
        {
            get { return productoSeleccionado; }
            set
            {
                productoSeleccionado = value;
                RaisePropertyChanged(() => ProductoSeleccionado);
                GetInventarioDetalle();
            }
        }

        public ICommand Buscar
        {
            get
            {
                return new RelayCommand(s => OnBuscar());
            }
        }


        public int TotalProductos
        {
            get { return totalProductos; }
            set
            {
                totalProductos = value;
                RaisePropertyChanged(() => TotalProductos);
            }
        }


        #endregion

        #region Private Methods

        public override void ExportarExcel()
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog broserDialog = new System.Windows.Forms.FolderBrowserDialog();

                if (broserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var pathFile = broserDialog.SelectedPath;
                    var fileName = "Inventario.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.Inventario);

                    ExportToExcel.ExportDocument(dataTable, "Inventario", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        public void OnBuscar()
        {
            try
            {
                if (ubicacionSel.Id == -1)
                {
                    new Task(() =>
                        {
                            Inventario = Repository.ObtenerInventario(null, producto);
                            if (Inventario != null && Inventario.Count > 0)
                            {
                                TotalProductos = Inventario.Sum(s => s.Cantidad);
                            }
                        }).Start();
                }
                else
                {
                    new Task(() =>
                    {
                        Inventario = Repository.ObtenerInventario(ubicacionSel.Id, producto);
                        if (Inventario != null && Inventario.Count > 0)
                        {
                            TotalProductos = Inventario.Sum(s => s.Cantidad);
                        }
                    }).Start();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error al recibir la orden", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GetInventarioDetalle()
        {
            if (productoSeleccionado != null)
            {
                ProductoSeleccionado.Detalle = Repository.GetDetalleInventario(ProductoSeleccionado.IdMovimiento);
            }
        }
        #endregion

    }
}
