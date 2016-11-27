using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.ViewModel.Catalogos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel.OC
{
    public class OrdenCompraHomologadaVM : ViewModelBase
    {
        private int idProveedor;
        private string proveedor;
        private string direccion;
        private int dias;
        private string tipoDePago;
        private DateTime? fecha;
        private List<Ubicacion> ubicaciones;
        private int ubicacionSeleccionada;
        private int idUsuario;
        private string usuario;



        private ObservableCollection<OrdenCompraProveedor> ordenDeCompraProveedor;
        private ObservableCollection<OrdenCompraProveedor> ordenDeCompraProveedorTotal;

        public OrdenCompraHomologadaVM()
        {
            try
            {
                Fecha = DateTime.Now;
                ubicaciones = new List<Ubicacion>();
                ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
                ubicaciones.AddRange(Repository.ObtenerUbicaciones());
                this.UbicacionSeleccionada = -1;
                this.idUsuario = ManejadorLoguin.idUsuario;
                this.Usuario = ManejadorLoguin.usuario;
                //  this.OrdenDeCompraProveedor = new ObservableCollection<OrdenCompraProveedor>();

            }
            catch (Exception ex)
            {

            }
        }

        void OrdenDeCompraProveedor_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {


        }




        #region Public Properties

        private long numeroOc;
        public long NumeroOc
        {
            get { return numeroOc; }
            set
            {
                numeroOc = value;
                RaisePropertyChanged(() => NumeroOc);
            }
        }

        public string Usuario
        {
            get { return usuario; }
            set
            {
                usuario = value;
                RaisePropertyChanged(() => Usuario);
            }
        }



        public int UbicacionSeleccionada
        {
            get { return ubicacionSeleccionada; }
            set
            {
                ubicacionSeleccionada = value;
                RaisePropertyChanged(() => UbicacionSeleccionada);
            }
        }

        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
        }
        public DateTime? Fecha
        {
            get { return fecha; }
            set
            {
                fecha = value;
                RaisePropertyChanged(() => Fecha);
            }
        }

        public string TipoDePago
        {
            get { return tipoDePago; }
            set
            {
                tipoDePago = value;
                RaisePropertyChanged(() => TipoDePago);
            }
        }

        public int Dias
        {
            get { return dias; }
            set
            {
                dias = value;
                RaisePropertyChanged(() => Dias);
            }
        }


        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                RaisePropertyChanged(() => Direccion);
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

        public ICommand BuscarProveedoresCmd
        {
            get
            {
                return new RelayCommand(s => BuscarProveedores());
            }
        }

        public ObservableCollection<OrdenCompraProveedor> OrdenDeCompraProveedor
        {
            get { return ordenDeCompraProveedor; }
            set
            {
                ordenDeCompraProveedor = value;
                RaisePropertyChanged(() => OrdenDeCompraProveedor);
            }
        }

        public ObservableCollection<OrdenCompraProveedor> OrdenDeCompraProveedorTotal
        {
            get { return ordenDeCompraProveedorTotal; }
            set
            {
                ordenDeCompraProveedorTotal = value;
                RaisePropertyChanged(() => OrdenDeCompraProveedorTotal);
            }
        }

        public ICommand CambioSeleccionCmd
        {
            get
            {
                return new RelayCommand(s => EventoCambioSeleccion());
            }
        }

        public ICommand GuardarCmd
        {
            get
            {
                return new RelayCommand(s => GuardarOrdenDeCompra());
            }
        }

        #endregion

        #region Private Methods

        private void GuardarOrdenDeCompra()
        {
            try
            {
                var msg = MessageBox.Show("¿Esta seguro de querer homologar las orden de compra", "Confirmación", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                if (msg != MessageBoxResult.OK)
                    return;


                if (ubicacionSeleccionada == -1)
                {
                    MessageBox.Show("Debe seleccionar una ubicacion");
                    return;
                }

                if (this.idProveedor == -1)
                {
                    MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                int id_orderbuy = 0;

                OrderBuy ob = new OrderBuy();

                ob.IdProvider = this.idProveedor;
                ob.Direccion_Envio = string.Empty;
                ob.StatusName = "Generada";
                ob.FechaEmision = this.Fecha.Value;
                ob.IdUbicacion = this.UbicacionSeleccionada;
                ob.idGenerador = this.idUsuario;

                using (var ts = new TransactionScope())
                {
                    id_orderbuy = Repository.InsertarOrderDeCompraHomologada(ob, 1);
                    NumeroOc = id_orderbuy;

                    if (id_orderbuy > 0)
                    {
                        if (OrdenDeCompraProveedor != null)
                        {
                            foreach (var item in OrdenDeCompraProveedor)
                            {
                                Repository.EliminarOrderDeCompraDetalle(item.IdOrdenCompra);
                            }
                        }


                        if (OrdenDeCompraProveedorTotal != null)
                        {
                            if (OrdenDeCompraProveedorTotal.Count > 0)
                            {
                                foreach (var doc in OrdenDeCompraProveedorTotal)
                                {
                                    doc.IdOrdenCompra = id_orderbuy;
                                    // idOC = id_orderbuy;
                                    Repository.InsertOrderHomologadaDetalle(doc);
                                }
                            }
                        }

                    }
                    ts.Complete();

                    MessageBox.Show("Orden de Compra generada con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                    if (thisWindow != null)
                    {
                        thisWindow.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar la orden de compra ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void EventoCambioSeleccion()
        {

            try
            {
                if (OrdenDeCompraProveedor == null)
                {
                    MessageBox.Show("No hay elementos para actualizar");
                    return;
                }

                var y = (from r in OrdenDeCompraProveedor
                         group r by new
                         {
                             r.IdProducto,
                             r.Producto,
                             r.PrecioUnitario,
                             r.UOM,
                             r.Impuestos
                             //r.Description
                         } into g
                         select new OrdenCompraProveedor
                         {
                             IdProducto = g.Key.IdProducto,
                             Producto = g.Key.Producto,
                             PrecioUnitario = g.Key.PrecioUnitario,
                             UOM = g.Key.UOM,
                             Cantidad = g.Sum(z => z.Cantidad),
                             Impuestos = g.Key.Impuestos
                         }).ToList();

                OrdenDeCompraProveedorTotal = new ObservableCollection<OrdenCompraProveedor>(y);
            }
            catch (Exception ex)
            {

            }

        }

        private void BuscarProveedores()
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
                    this.Direccion = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Address;
                    this.Dias = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.CantidadDeDias;
                    this.TipoDePago = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.TipoPago;

                    this.OrdenDeCompraProveedor = new ObservableCollection<OrdenCompraProveedor>(Repository.ObtenerOrdenDeCompraPorProveedor(this.idProveedor));
                    //this.OrdenDeCompraProveedor.CollectionChanged += OrdenDeCompraProveedor_CollectionChanged;
                    EventoCambioSeleccion();
                }

            }
            catch (Exception ex)
            {

            }
        }


        #endregion

    }
}
