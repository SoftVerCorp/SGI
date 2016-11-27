using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using SGI.Helpers;
using SGI.Model;
using SGI.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;

namespace SGI.ViewModel.Ventas
{
    public class RealizarVentaVM : ViewModelBase
    {
        private List<Cliente> clientes;
        private Cliente selectedCliente;
        private List<ProductoDisponible> productos;
        private ProductoDisponible selectedProducto;
        private bool sinHuellaDigital;
        private ObservableCollection<ProductoDisponible> productosCompra;
        private double totalTotal;
        private ProductoDisponible selectedProductoVenta;
        private List<string> pedimentos;
        private string pedimentoSeleccionad;

        private List<TipoDeVenta> tiposDeVenta;
        private int idTipoDeVenta;

        private string ubicacion;

        private int idUsuario;
        private int idUbicacion;



        public RealizarVentaVM()
        {
            try
            {
                //Repository.ClientesDisponiblesCache = Repository.GetClientesDisponibles();
                //this.Clientes = Repository.ClientesDisponiblesCache;

                Repository.ClientesCache = Repository.GetClientes(ManejadorUbicacion.IdUbicacion);
                this.Clientes = Repository.ClientesCache;
                
                Repository.ProductosDisponiblesCache = Repository.GetProductosDisponibles();
                this.productos = Repository.ProductosDisponiblesCache;
                SinHuellaDigital = true;
                ProductosCompra = new ObservableCollection<ProductoDisponible>();
                ProductosCompra.CollectionChanged += ProductosCompra_CollectionChanged;

                Pedimentos = new List<string>();
                Pedimentos.Add(string.Empty);

                tiposDeVenta = new List<TipoDeVenta>();
                tiposDeVenta.Add(new TipoDeVenta { Id = -1, Nombre = "Seleccionar" });
                tiposDeVenta.AddRange(Repository.GetTipoDeVenta());
                idTipoDeVenta = -1;

                idUbicacion = ManejadorUbicacion.IdUbicacion;
                ubicacion = ManejadorUbicacion.Ubicacion;
                idUsuario = ManejadorLoguin.idUsuario;
                
            }
            catch (Exception ex)
            {

            }

        }

        #region Properties

        public string Ubicacion
        {
            get { return ubicacion; }
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

        /// <summary>
        /// 
        /// </summary>
        public List<TipoDeVenta> TiposDeVenta
        {
            get { return tiposDeVenta; }
        }

        public string PedimentoSeleccionado
        {
            get { return pedimentoSeleccionad; }
            set
            {
                pedimentoSeleccionad = value;
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

        public List<Cliente> Clientes
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

        public Cliente SelectedCliente
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
                    this.Pedimentos = Repository.ObtenerPedimentosPorProducto(SelectedProducto.IdProducto);
                }
            }
        }

        public bool SinHuellaDigital
        {
            get
            {
                return sinHuellaDigital;
            }

            set
            {
                sinHuellaDigital = value;
                RaisePropertyChanged(() => SinHuellaDigital);
            }
        }

        public ObservableCollection<ProductoDisponible> ProductosCompra
        {
            get
            {
                return productosCompra;
            }

            set
            {
                productosCompra = value;
                RaisePropertyChanged(() => ProductosCompra);
            }
        }

        public double TotalTotal
        {
            get
            {
                return totalTotal;
            }

            set
            {
                totalTotal = value;
                RaisePropertyChanged(() => TotalTotal);
            }
        }

        public ProductoDisponible SelectedProductoVenta
        {
            get
            {
                return selectedProductoVenta;
            }

            set
            {
                selectedProductoVenta = value;
                RaisePropertyChanged(() => SelectedProductoVenta);
            }
        }
        public RelayCommand AgregarProductoCmd
        {
            get { return new RelayCommand(OnAgregarProducto); }
        }

        public RelayCommand EliminarProductoCmd
        {
            get { return new RelayCommand(OnEliminarProducto); }
        }
        public RelayCommand LimpiarCmd
        {
            get { return new RelayCommand(OnLimpiar); }
        }
        public RelayCommand RealizarVentaCmd
        {
            get { return new RelayCommand(OnRealizarVenta); }
        }

        #endregion

        private void OnAgregarProducto()
        {
            try
            {

                if (IdTipoDeVenta == -1)
                {
                    MessageBox.Show("Por favor selecciona el tipo de venta", "Informacion", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }

                if (selectedCliente == null)
                {
                    MessageBox.Show("Por favor selecciona un cliente para agregar productos", "Informacion", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    return;
                }
                if (SelectedProducto != null)
                {
                    var cantidadTotal = selectedProducto.Cantidad;
                    var existProduct = ProductosCompra.FirstOrDefault(d => d.IdProducto == selectedProducto.IdProducto);
                    if (existProduct != null)
                    {
                        cantidadTotal = cantidadTotal + existProduct.Cantidad;

                        if (cantidadTotal > selectedProducto.Inventario)
                        {
                            MessageBox.Show("No existe stock suficiente para este producto!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            return;
                        }
                        else
                        {
                            existProduct.Cantidad = cantidadTotal;
                            
                            if (productosCompra != null && productosCompra.Count > 0)
                            {
                                TotalTotal = productosCompra.Sum(d => d.TotalTotal);
                            }

                            SelectedProducto = null;

                            return;
                        }
                    }
                    if (cantidadTotal > selectedProducto.Inventario)
                    {
                        MessageBox.Show("No existe stock suficiente para este producto!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        return;
                    }

                    var descuentos = Repository.GetDescuentosDisponibles(selectedProducto.IdProducto, selectedProducto.IdMarca, selectedProducto.IdUbicacion, selectedCliente.IdTipoCliente, DateTime.Now);
                    DescuentosDisponibles descuentoAplicado = null;
                    if (descuentos != null)
                    {
                        // ya vienen ordenados desde BD.
                        descuentoAplicado = descuentos.FirstOrDefault();
                        selectedProducto.Descuento = descuentoAplicado == null ? 0 : descuentoAplicado.Descuento;
                        selectedProducto.TipoDescuento = descuentoAplicado == null ? "" : descuentoAplicado.TipoDescuento.ToLower();
                        selectedProducto.IdTipoDescuento = descuentoAplicado == null ? -1 : descuentoAplicado.IdDescuento;
                    }
                    var productoNuevo = (ProductoDisponible)SelectedProducto.Clone();
                    productoNuevo.Pedimento = this.PedimentoSeleccionado;

                    ProductosCompra.Add(productoNuevo);

                    SelectedProducto = null;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al tratar de agregar el producto...." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnEliminarProducto()
        {
            try
            {
                if (SelectedProductoVenta != null)
                {
                    ProductosCompra.Remove(SelectedProductoVenta);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al tratar de eliminar el producto...." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void ProductosCompra_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (productosCompra != null && productosCompra.Count > 0)
            {
                TotalTotal = productosCompra.Sum(d => d.TotalTotal);
            }
        }

        private void OnLimpiar()
        {
            try
            {
                ProductosCompra.CollectionChanged -= ProductosCompra_CollectionChanged;
                ProductosCompra = new ObservableCollection<ProductoDisponible>();
                ProductosCompra.CollectionChanged += ProductosCompra_CollectionChanged;

                SelectedCliente = null;
                SinHuellaDigital = true;
                TotalTotal = 0;

                SelectedProducto = null;
                IdTipoDeVenta = -1;


            }
            catch (Exception ex)
            {

            }
        }

        private void OnRealizarVenta()
        {
            try
            {

                if (IdTipoDeVenta == -1)
                {
                    MessageBox.Show("Debe seleccionar un tipo de venta");
                    return;
                }


                if (Repository.ValidarLimiteDeCredito(SelectedCliente.IdCliente, TotalTotal) > 0)
                {
                    MessageBox.Show("No se puede realizar la venta,El usuario sobrepasara su limite de credito");                   
                    return;
                }

                if (Repository.ValidarDocumentoVencido(SelectedCliente.IdCliente) > 0)
                {
                    MessageBox.Show("No se puede realizar la venta,El usuario tiene documentos vencidos");
                    return;
                }



                if (SelectedCliente != null && ProductosCompra != null)
                {
                    using (var ts = new TransactionScope())
                    {
                        int idventa = Repository.InsVenta(DateTime.Now, idUbicacion, idUsuario, selectedCliente.IdCliente, "", this.IdTipoDeVenta, TotalTotal);
                        // int idventa = 0;
                        if (idventa == -1)
                        {
                            throw new Exception("Error al tratar de insertar la venta");
                        }
                        foreach (var p in productosCompra)
                        {
                            Repository.InsVentaDetalle(
                                  p.IdProducto,
                                  p.Cantidad,
                                  p.PrecioUnitario,
                                  "",
                                  idventa,
                                  p.TipoDescuento,
                                  p.IdTipoDescuento,
                                  p.Descuento,
                                  1,
                                  null, p.Pedimento, p.PrecioDescuento, p.TotalTotal);
                        }
                        ts.Complete();
                    }
                    MessageBox.Show("Venta guardada correctamente....", "Venta", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnLimpiar();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al tratar de guardar la compra...." + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
