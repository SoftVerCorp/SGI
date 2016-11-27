using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Transactions;

namespace SGI.ViewModel.Inventarios
{
    public class TransferenciaDeInventariosVM : ViewModelBase
    {
        private List<Ubicacion> origen;
        private List<Ubicacion> destino;
        private List<Paqueterias> paqueterias;

        private List<string> pedimentos;



        private int idUbucacionOrigen;
        private int idUbicacionDestino;
        private int idPaqueteriaSeleccionada;
        private int idUsuarioLogueado;
        private int cantidadInventario;
        private int cantidadATranspasar;

        private string usuarioLogueado;
        private string detalle;
        private string pedimentoSeleccionado;


        private ObservableCollection<ProductoDetalle> detalles;
        private List<ProductoDisponible> productos;
        private ProductoDisponible selectedProducto;
        private DateTime fechaSeleccionada;
        private string guia;

        public TransferenciaDeInventariosVM()
        {
            try
            {
                this.origen = new List<Ubicacion>();
                this.origen.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.origen.AddRange(Repository.ObtenerUbicaciones());
                this.IdUbicacionOrigen = ManejadorUbicacion.IdUbicacion;

                this.destino = new List<Ubicacion>();
                this.destino.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                this.destino.AddRange(Repository.ObtenerUbicaciones());
                this.IdUbicacionDestino = -1;

                this.Paqueterias = new List<Paqueterias>();
                this.Paqueterias.Add(new Paqueterias { Id = -1, Nombre = "Seleccionar" });
                this.Paqueterias.AddRange(Repository.ObtenerPaqueterias());
                this.IdPaqueteriaSeleccionada = -1;


                this.UsuarioLogueado = ManejadorLoguin.usuario;
                this.idUsuarioLogueado = ManejadorLoguin.idUsuario;
                this.FechaSeleccionada = DateTime.Now;

                Repository.ProductosDisponiblesCache = Repository.GetProductosDisponibles();
                this.productos = Repository.ProductosDisponiblesCache;

                Detalles = new ObservableCollection<ProductoDetalle>();
            }
            catch (Exception ex)
            {

            }
        }

        #region Public Properties


        public string PedimentoSeleccionado
        {
            get { return pedimentoSeleccionado; }
            set
            {
                pedimentoSeleccionado = value;
                RaisePropertyChanged(() => PedimentoSeleccionado);
            }
        }

        public List<string> Pedimentos
        {
            get { return pedimentos; }
            set
            {
                pedimentos = value;
                RaisePropertyChanged(() => Pedimentos);
            }
        }

        public int CantidadATranspasar
        {
            get { return cantidadATranspasar; }
            set
            {
                cantidadATranspasar = value;
                RaisePropertyChanged(() => CantidadATranspasar);
            }
        }

        public ObservableCollection<ProductoDetalle> Detalles
        {
            get { return detalles; }
            set
            {
                detalles = value;
                RaisePropertyChanged(() => Detalles);
            }
        }

        public int IdPaqueteriaSeleccionada
        {
            get { return idPaqueteriaSeleccionada; }
            set
            {
                idPaqueteriaSeleccionada = value;
                RaisePropertyChanged(() => IdPaqueteriaSeleccionada);
            }
        }

        public List<Paqueterias> Paqueterias
        {
            get { return paqueterias; }
            set
            {
                paqueterias = value;
                RaisePropertyChanged(() => Paqueterias);
            }
        }

        public int CantidadInventario
        {
            get { return cantidadInventario; }
            set
            {
                cantidadInventario = value;
                RaisePropertyChanged(() => CantidadInventario);
            }
        }

        public string Detalle
        {
            get { return detalle; }
            set
            {
                detalle = value;
                RaisePropertyChanged(() => Detalle);
            }
        }


        public DateTime FechaSeleccionada
        {
            get { return fechaSeleccionada; }
            set
            {
                fechaSeleccionada = value;
                RaisePropertyChanged(() => FechaSeleccionada);
            }
        }


        public string Guia
        {
            get { return guia; }
            set
            {
                guia = value;
                RaisePropertyChanged(() => Guia);
            }
        }


        public ProductoDisponible SelectedProducto
        {
            get
            {
                return selectedProducto;
            }

            set
            {
                selectedProducto = value;
                RaisePropertyChanged(() => SelectedProducto);

                if (SelectedProducto != null)
                {
                    this.Detalle = SelectedProducto.Detalle;
                    this.CantidadInventario = SelectedProducto.Inventario;
                    this.Pedimentos = new List<string>();
                    this.Pedimentos.Add("Seleccionar");
                    this.Pedimentos.AddRange(Repository.ObtenerPedimentosPorProducto(SelectedProducto.IdProducto));
                    this.PedimentoSeleccionado = "Seleccionar";
                }
            }
        }

        public string UsuarioLogueado
        {
            get { return usuarioLogueado; }
            set
            {
                if (usuarioLogueado != value)
                {
                    usuarioLogueado = value;
                    RaisePropertyChanged(() => UsuarioLogueado);
                }
            }
        }

        public int IdUbicacionDestino
        {
            get { return idUbicacionDestino; }
            set
            {
                if (idUbicacionDestino != value)
                {
                    idUbicacionDestino = value;
                    RaisePropertyChanged(() => IdUbicacionDestino);
                }
            }
        }

        public List<Ubicacion> Destino
        {
            get { return destino; }
        }

        public List<Ubicacion> Origen
        {
            get { return origen; }
        }

        public int IdUbicacionOrigen
        {
            get { return idUbucacionOrigen; }
            set
            {
                if (idUbucacionOrigen != value)
                {
                    idUbucacionOrigen = value;
                    RaisePropertyChanged(() => IdUbicacionOrigen);
                }
            }
        }

        public ICommand AgregarProductoAlGridCmd
        {
            get
            {
                return new RelayCommand(s => AgregarProductosAlGrid());
            }
        }

        public ICommand CrearTraspasoCmd
        {
            get
            {
                return new RelayCommand(s => CrearTraspaso());
            }
        }

        public ICommand EliminarElementoCmd
        {
            get
            {
                return new RelayCommand(EliminarElemento);
            }
        }

        public ICommand NuevoProductoCmd
        {
            get
            {
                return new RelayCommand(s => NuevoProducto());
            }
        }

        #endregion

        #region Private Methods

        private void NuevoProducto()
        {
            try
            {
                this.SelectedProducto = null;
                this.Detalle = string.Empty;
                this.Pedimentos = new List<string>();
                this.Pedimentos.Add(string.Empty);
                this.PedimentoSeleccionado = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        private void EliminarElemento(object param)
        {
            try
            {
                var val = param as ProductoDetalle;

                if (val == null)
                    return;

                this.Detalles.Remove(val);
            }
            catch (Exception ex)
            {

            }
        }
        private void Limpiar()
        {
            try
            {
                this.SelectedProducto = null;
                this.PedimentoSeleccionado = string.Empty;
                this.Pedimentos = new List<string>();
               
                this.Detalle = string.Empty;
                this.Detalles = new ObservableCollection<ProductoDetalle>();

                this.IdUbicacionDestino = -1;
                this.IdPaqueteriaSeleccionada = -1;
                this.Guia = string.Empty;
                this.FechaSeleccionada = DateTime.Now;
                this.NuevoProducto();
            }
            catch (Exception ex)
            {

            }
        }
        private void AgregarProductosAlGrid()
        {
            try
            {
                //if (PedimentoSeleccionado.Equals("Seleccionar") || string.IsNullOrEmpty(PedimentoSeleccionado))
                //{

                //    MessageBox.Show("Debe seleccionar un Pedimento");
                //    return;
                //}

                if (SelectedProducto == null)
                {
                    MessageBox.Show("Debe seleccionar un producto");
                    return;
                }

                var item = Detalles.Where(s => s.IdProducto == SelectedProducto.IdProducto && s.Pedimento.ToUpper().Equals(this.PedimentoSeleccionado.ToUpper())).ToList();

                if (item.Count > 0)
                {
                    MessageBox.Show("Item ya existe");
                    return;
                }

                if (IdUbicacionDestino == -1)
                {
                    MessageBox.Show("Debe seleccionar un destino");
                    return;
                }


                if (IdPaqueteriaSeleccionada == -1)
                {
                    MessageBox.Show("Debe seleccionar una paqueteria");
                    return;
                }


                //if (CantidadATranspasar > SelectedProducto.Cantidad)
                //{
                //    MessageBox.Show("La cantidad existente es menos a la que se va a transpasar");
                //    return;
                //}

                this.Detalles.Add(new ProductoDetalle
                {
                    IdInventario = SelectedProducto.IdInventario,

                    Producto = SelectedProducto.NombreProducto,
                    Cantidad = 0,
                    Pedimento = PedimentoSeleccionado,
                    CantidadDisponible = SelectedProducto.Inventario,
                    IdUbicacionDestino = this.IdUbicacionDestino,
                    IdUbicacionOrigen = this.IdUbicacionOrigen,
                    IdPaqueteria = this.IdPaqueteriaSeleccionada
                });


            }
            catch (Exception ex)
            {

            }
        }

        private void CrearTraspaso()
        {
            try
            {
                using (var ts = new TransactionScope())
                {
                    foreach (var item in Detalles)
                    {
                        Repository.InsTraspaso(item.IdUbicacionDestino, item.IdUbicacionOrigen, item.Pedimento, FechaSeleccionada, item.IdPaqueteria, item.IdInventario, Guia, item.Cantidad);
                    }

                    ts.Complete();
                }
                MessageBox.Show("¡Traspaso registrado!");
                this.Limpiar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al tratar de guardar el traspaso, Codigo de error:" + ex.Message);
            }
        }

        #endregion
    }
}
