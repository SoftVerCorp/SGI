using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGI.ViewModel.Inventarios
{
    public class MovInventarioVM : ViewModelBase
    {
        #region Private Fields

        private DateTime? fechaInicial;
        private DateTime? fechaFinal;

        private int idMovimiento;
        private int idUbicacion;

        private string producto;

        private List<Ubicacion> ubicaciones;
        private List<TipoMovInventario> tipoMovInventario;
        private List<HistoricoMovInv> movInventario;


        #endregion

        #region Constructors

        public MovInventarioVM()
        {
            try
            {
                this.FechaFinal = DateTime.Now;
                this.FechaInicial = DateTime.Now.AddDays(-1);

                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.idUbicacion = -1;

                this.tipoMovInventario = new List<TipoMovInventario>();
                this.tipoMovInventario.Add(new TipoMovInventario { Id = -1, Nombre = "Seleccionar" });
                this.tipoMovInventario.AddRange(Repository.ObtenerTipoMovInventario());
                this.idMovimiento = -1;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public List<HistoricoMovInv> MovInventario
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

        public List<TipoMovInventario> TipoMovInventario
        {
            get { return tipoMovInventario; }
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
                    var fileName = "MovInventario.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.MovInventario);

                    ExportToExcel.ExportDocument(dataTable, "Movimientos de Inventario", pathFile + "/" + fileName);

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
                MovInventario = Repository.ObtenerHistMovInventario(this.FechaInicial, this.FechaFinal, this.IdUbicacion, this.IdMovimiento, this.Producto);
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
                this.MovInventario = new List<HistoricoMovInv>();
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
