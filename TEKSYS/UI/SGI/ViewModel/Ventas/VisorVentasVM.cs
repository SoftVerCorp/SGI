using SGI.Helpers;
using SGI.Model;
using SGI.Model.Entidades;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGI.ViewModel.Ventas
{
    public class VisorVentasVM : ViewModelBase
    {
        #region Private Fields

        private List<ClienteVenta> clientes;
        private ClienteVenta selectedCliente;
        private bool isEnableCmbUbicacion;

        private List<Ubicacion> ubicaciones;
        private Ubicacion ubicacionSeleccionada;

        private DateTime? fechaInicial;
        private DateTime? fechaFinal;

        private List<TipoDeVenta> tiposDeVenta;
        private int idTipoDeVenta;

        private List<EstatusDeVenta> estatusDeVenta;
        private int idEstatusDeVenta;

        private List<Model.Entidades.Ventas> ventas;





        #endregion

        public VisorVentasVM()
        {
            try
            {
                Repository.ClientesDisponiblesCache = Repository.GetClientesDisponibles();
                this.Clientes = Repository.ClientesDisponiblesCache;

                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.UbicacionSeleccionada = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();

                this.tiposDeVenta = new List<TipoDeVenta>();
                this.tiposDeVenta.Add(new TipoDeVenta { Id = -1, Nombre = "Seleccionar" });
                this.tiposDeVenta.AddRange(Repository.GetTipoDeVenta());
                this.idTipoDeVenta = -1;

                this.estatusDeVenta = new List<EstatusDeVenta>();
                this.estatusDeVenta.Add(new EstatusDeVenta { Id = -1, Nombre = "Seleccionar" });
                this.estatusDeVenta.AddRange(Repository.GetStatusDeVenta());
                this.IdEstatusDeVenta = -1;


                if (ManejadorUbicacion.EsMatriz)
                {
                    IsEnableCmbUbicacion = true;
                }
            }
            catch (Exception ex)
            {

            }
        }

        #region Public Properties

        public List<Model.Entidades.Ventas> Ventas
        {
            get { return ventas; }
            set
            {
                ventas = value;
                RaisePropertyChanged(() => Ventas);
            }
        }



        public int IdEstatusDeVenta
        {
            get { return idEstatusDeVenta; }
            set
            {
                idEstatusDeVenta = value;
                RaisePropertyChanged(() => IdEstatusDeVenta);
            }
        }

        public List<EstatusDeVenta> EstatusDeVenta
        {
            get { return estatusDeVenta; }
        }


        public int IdTipoDeVenta
        {
            get { return idTipoDeVenta; }
            set
            {
                idTipoDeVenta = value;
                RaisePropertyChanged(() => IdTipoDeVenta);
            }
        }


        public List<TipoDeVenta> TiposDeVenta
        {
            get { return tiposDeVenta; }
        }


        public DateTime? FechaFinal
        {
            get { return fechaFinal; }
            set
            {
                fechaFinal = value;
                RaisePropertyChanged(() => FechaFinal);
            }
        }

        public DateTime? FechaInicial
        {
            get { return fechaInicial; }
            set
            {
                fechaInicial = value;
                RaisePropertyChanged(() => FechaInicial);
            }
        }

        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
        }

        public Ubicacion UbicacionSeleccionada
        {
            get { return ubicacionSeleccionada; }
            set
            {
                ubicacionSeleccionada = value;
                RaisePropertyChanged(() => UbicacionSeleccionada);
            }
        }

        public bool IsEnableCmbUbicacion
        {
            get { return isEnableCmbUbicacion; }
            set
            {
                isEnableCmbUbicacion = value;
                RaisePropertyChanged(() => IsEnableCmbUbicacion);
            }
        }

        public List<ClienteVenta> Clientes
        {
            get
            {
                return clientes;
            }

            set
            {
                clientes = value;
                RaisePropertyChanged(() => Clientes);
            }
        }

        public ClienteVenta SelectedCliente
        {
            get
            {
                return selectedCliente;
            }

            set
            {
                selectedCliente = value;
                RaisePropertyChanged(() => SelectedCliente);
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

        public ICommand MostrarDetalleCmd
        {
            get
            {
                return new RelayCommand(VerDetalle);
            }
        }


        #endregion

        #region Private Methods

        private void VerDetalle(object param)
        {
            Model.Entidades.Ventas ventaAux = param as Model.Entidades.Ventas;

            if (ventaAux == null)
                return;

            View.Ventas.DetalleVenta dv = new View.Ventas.DetalleVenta();

            dv.DataContext = new DetalleVentaVM(ventaAux.IdVenta);
            dv.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            dv.ShowDialog();

        }

        private void Limpiar()
        {
            this.SelectedCliente = null;
            this.FechaFinal = null;
            this.FechaFinal = null;
            this.UbicacionSeleccionada = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();
            this.IdTipoDeVenta = -1;
            this.IdEstatusDeVenta = -1;
            this.Ventas = new List<Model.Entidades.Ventas>();
        }

        private void Buscar()
        {
            try
            {
                int idCliente = -1;

                if (SelectedCliente != null)
                {
                    idCliente = SelectedCliente.idCliente;
                }

                Ventas = Repository.ObtenerVentas(this.FechaFinal, this.FechaFinal, this.UbicacionSeleccionada.Id, this.IdTipoDeVenta, this.IdEstatusDeVenta, idCliente);
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
