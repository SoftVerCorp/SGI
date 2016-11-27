using SGI.Helpers;
using SGI.Model;
using SGI.Model.Entidades;
using SGI.Stuffs;
using SGI.View.CreditoYCobranza;
using SGI.ViewModel.CreditoYCobranza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SGI.ViewModel.Ventas
{
    public class AbonosVM : ViewModelBase
    {
        #region Private Fields

        private List<ClienteVenta> clientes;
        private ClienteVenta selectedCliente;
        private bool isEnableCmbUbicacion;

        private List<Ubicacion> ubicaciones;
        private Ubicacion ubicacionSeleccionada;

        private DateTime? fechaInicial;
        private DateTime? fechaFinal;

        private int idTipoDeVenta;

        private int idEstatusDeVenta;

        private List<Model.Entidades.Ventas> ventas;

        private Model.Entidades.Ventas ventaSeleccionada;




        #endregion

        #region Constructors

        public AbonosVM()
        {
            try
            {
                this.idTipoDeVenta = (int)SGI.Enumeration.TipoDeVentaEnum.Credito;
                this.idEstatusDeVenta = (int)SGI.Enumeration.EstatusVentaEnum.Abierta;

                Repository.ClientesDisponiblesCache = Repository.GetClientesDisponibles();
                this.Clientes = Repository.ClientesDisponiblesCache;

                this.ubicaciones = new List<Ubicacion>();
                this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.UbicacionSeleccionada = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();


                if (ManejadorUbicacion.EsMatriz)
                {
                    IsEnableCmbUbicacion = true;
                }

            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Public Properties

        public Model.Entidades.Ventas VentaSeleccionada
        {
            get { return ventaSeleccionada; }
            set
            {

                ventaSeleccionada = value;
                RaisePropertyChanged(() => VentaSeleccionada);
            }
        }

        public List<Model.Entidades.Ventas> Ventas
        {
            get { return ventas; }
            set
            {
                ventas = value;
                RaisePropertyChanged(() => Ventas);
            }
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




        #endregion


        public override void OnSelectedItemGridClick(object parameters)
        {
            try
            {
                MouseButtonEventArgs mouse = parameters as MouseButtonEventArgs;
                Model.Entidades.Ventas vta = Helpers.DataGridRowHelper.GetDatagridRow(mouse) as Model.Entidades.Ventas;

                if (vta == null)
                    return;

                Abonar ab = new Abonar();
                ab.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
                ab.DataContext = new AbonarVM(vta.IdVenta,vta.MontoTotal);
                ab.Show();
            }
            catch (Exception ex)
            {

            }
        }
        private void Limpiar()
        {
            this.SelectedCliente = null;
            this.FechaFinal = null;
            this.FechaFinal = null;
            this.UbicacionSeleccionada = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();

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

                Ventas = Repository.ObtenerVentas(this.FechaFinal, this.FechaFinal, this.UbicacionSeleccionada.Id, this.idTipoDeVenta, this.idEstatusDeVenta, idCliente);
            }
            catch (Exception ex)
            {

            }
        }

    }
}
