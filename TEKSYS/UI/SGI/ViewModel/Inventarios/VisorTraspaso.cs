using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.Inventarios
{
    public class VisorTraspaso : ViewModelBase
    {
        #region Private Fields

        private DateTime? fechaInicial;
        private DateTime? fechaFinal;

        private int idMovimiento;
        private int idUbicacion;

        private string producto;

        private List<Ubicacion> ubicaciones;
        private List<string> tipoTraspaso;
        private string tipoSeleccionado;

        private List<ProductoDetalle> movInventario;
        private List<ProductoDetalle> movInventarioDetalle;

        private ProductoDetalle detalleSeleccionado;



        private string guia;

        public string Guia
        {
            get { return guia; }
            set
            {
                guia = value;
                RaisePropertyChanged(() => Guia);
            }
        }


        #endregion

        #region Constructors

        public VisorTraspaso()
        {
            try
            {
                this.FechaFinal = DateTime.Now;
                this.FechaInicial = DateTime.Now.AddDays(-1);

                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.idUbicacion = -1;

                tipoTraspaso = new List<string>() { "En transito", "Entregados", "Todos" };
                RaisePropertyChanged(() => TiposTraspaso);
                this.idMovimiento = -1;

                this.MovInventario = Repository.ObtenerTraspaso(FechaFinal.Value.AddMonths(-1), DateTime.Now, -1, null);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public ProductoDetalle DetalleSeleccionado
        {
            get { return detalleSeleccionado; }
            set
            {
                detalleSeleccionado = value;
                RaisePropertyChanged(() => DetalleSeleccionado);
            }
        }

        public List<ProductoDetalle> MovInventarioDetalle
        {
            get { return movInventarioDetalle; }
            set
            {
                movInventarioDetalle = value;
                RaisePropertyChanged(() => MovInventarioDetalle);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<ProductoDetalle> MovInventario
        {
            get { return movInventario; }
            set
            {
                if (movInventario != value)
                {
                    movInventario = value;
                    RaisePropertyChanged(() => MovInventario);
                }
            }
        }

        public string Producto
        {
            get { return producto; }
            set
            {
                if (producto != value)
                {
                    producto = value;
                    RaisePropertyChanged(() => Producto);
                }
            }
        }

        public int IdMovimiento
        {
            get { return idMovimiento; }
            set
            {
                if (idMovimiento != value)
                {
                    idMovimiento = value;
                    RaisePropertyChanged(() => IdMovimiento);
                }
            }
        }

        public int IdUbicacion
        {
            get { return idUbicacion; }
            set
            {
                if (idUbicacion != value)
                {
                    idUbicacion = value;
                    RaisePropertyChanged(() => IdUbicacion);
                }
            }
        }

        public List<string> TiposTraspaso
        {
            get { return tipoTraspaso; }
        }

        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
        }


        public DateTime? FechaFinal
        {
            get { return fechaFinal; }
            set
            {
                if (fechaFinal != value)
                {
                    fechaFinal = value;
                    RaisePropertyChanged(() => FechaFinal);
                }
            }
        }

        public DateTime? FechaInicial
        {
            get { return fechaInicial; }
            set
            {
                if (fechaInicial != value)
                {
                    fechaInicial = value;
                    RaisePropertyChanged(() => FechaInicial);
                }
            }
        }

        public string TipoSeleccionado
        {
            get { return tipoSeleccionado; }
            set
            {
                tipoSeleccionado = value;
                RaisePropertyChanged(() => TipoSeleccionado);
            }
        }

        public ICommand BuscarCmd
        {
            get
            {
                return new RelayCommand(s => Buscar());
            }
        }

        public ICommand LimpiarCmd
        {
            get
            {
                return new RelayCommand(s => Limpiar());
            }
        }

        public ICommand RecibirCmd
        {
            get
            {
                return new RelayCommand(s => Recibir());
            }
        }

        #endregion

        #region Private Methods

        public void Recibir()
        {
            try
            {
                if (this.DetalleSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un elemento a transpasar");
                    return;
                }

                var result = MessageBox.Show("¿Desea realizar el transpaso?", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (result != MessageBoxResult.OK)
                    return;

                StringBuilder sb = new StringBuilder();
                sb.Append("<Detalles>");

                foreach (var item in MovInventarioDetalle)
                {
                    sb.Append("<Detalle>");
                    sb.Append("<IdInventario>" + item.IdInventario + "</IdInventario>");
                    sb.Append("<IdProducto>" + item.IdProducto + "</IdProducto>");
                    sb.Append("<pedimento>" + item.Pedimento + "</pedimento>");
                    sb.Append("<Cantidad>" + item.CantidadDisponible + "</Cantidad>");
                    sb.Append("</Detalle>");
                }

                sb.Append("</Detalles>");

                int error = 0;
                string msg = string.Empty;
                Repository.RecibirInventario(DetalleSeleccionado.IdUbicacionOrigen, DetalleSeleccionado.IdUbicacionDestino, DetalleSeleccionado.Guia, sb.ToString(), ref error, ref msg);

                if (error != 0)
                {
                    MessageBox.Show("Error al realizar la recepcion del inventario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Recepcion realizada correctamente");
                Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al realizar la recepcion del inventario", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void ExportarExcel()
        {
            try
            {
                System.Windows.Forms.FolderBrowserDialog broserDialog = new System.Windows.Forms.FolderBrowserDialog();

                if (broserDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var pathFile = broserDialog.SelectedPath;
                    var fileName = "Transpasos.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.MovInventario);

                    ExportToExcel.ExportDocument(dataTable, "Transpasos de Inventario", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void Buscar()
        {
            try
            {
                MovInventario = Repository.ObtenerTraspaso(FechaInicial.Value, FechaFinal.Value, IdUbicacion, Guia);
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            ProductoDetalle item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as ProductoDetalle;

            if (item == null)
                return;

            try
            {
                this.DetalleSeleccionado = item;
                this.MovInventarioDetalle = Repository.ObtenerTraspasoDetalle(item.Guia);
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void Limpiar()
        {
            try
            {
                this.FechaFinal = DateTime.Now;
                this.FechaInicial = DateTime.Now.AddDays(-1);
                this.IdUbicacion = -1;
                this.IdMovimiento = -1;
                this.Producto = string.Empty;
                this.MovInventario = new List<ProductoDetalle>();
                this.MovInventarioDetalle = new List<ProductoDetalle>();
                this.DetalleSeleccionado = null;
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
