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
using System.Collections.ObjectModel;
using SGI.ViewModel.Catalogos;
using SGI.Helpers;
using SGI.View.Catalogos;

namespace SGI.ViewModel
{
    public class OrdenesDeCompraVM : ViewModelBase
    {
        #region Private Fields

        private int idSupplier { get; set; }
        private string supplierName { get; set; }
        private string direction { get; set; }
        private string deliveryTo { get; set; }
        private string billTo { get; set; }

        private DateTime dateOutPut { get; set; }
        private DateTime dateDeliver { get; set; }
        private List<DetalleOrdenCompraModel> detailOrderListStore;
        private ObservableCollection<DetalleOrdenCompraModel> detailOrderList;
        private List<DetalleOrdenCompraModel> toDeleteDetail;

        private DetalleOrdenCompraModel selectedProduct { get; set; }
        private double totalGeneral { get; set; }
        private System.Windows.Visibility isModeAuto;
        private System.Windows.Visibility isModeCreacion;
        public event EventHandler cerrar;
        private int idOC { get; set; }
        private long number { get; set; }
        private int contador { get; set; }
        private List<Empleado> empleados;
        private Empleado empleado;
        private OrdenesDisponibles ActualizarOrden;
        private string status;
        private string tipoDePago;
        private int dias;
        private List<Ubicacion> ubicaciones;
        private int ubicacionSeleccionada;






        #endregion

        #region Constructors

        public OrdenesDeCompraVM(OrdenesDisponibles actualizarOrden)
        {
            this.DateOutPut = DateTime.Today;
            this.DateDeliver = DateTime.Today;
            this.DetailOrderListStore = new List<DetalleOrdenCompraModel>();
            //this.TypePayList = Repository.GetTypePay();
            this.Empleados = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
            EmpleadoSeleccionado = empleados.FirstOrDefault(e => e.Id == ManejadorLoguin.idUsuario);

            this.ubicaciones = new List<Ubicacion>();
            this.ubicaciones.Add(new Ubicacion { Id = -1, Nombre = "Seleccionar" });
            this.ubicaciones.AddRange(Repository.ObtenerUbicaciones());
            this.ubicacionSeleccionada = ManejadorUbicacion.IdUbicacion;
            // this.UbicacionSeleccionada = -1;

            //this.TypePayList = new List<TypePay>();
            //this.TypePayList.Add(new TypePay { Id = -1, description = "Seleccionar" });
            //this.TypePayList.AddRange(Repository.GetTypePay());

            //this.SelectedTypePay = -1;
            this.IdSupplier = -1;

            this.contador = 0;
            IsModeAuto = System.Windows.Visibility.Collapsed;
            IsModeCreacion = System.Windows.Visibility.Visible;
            toDeleteDetail = new List<DetalleOrdenCompraModel>();
            this.Number = Repository.GetOCLastId() + 1;

            if (actualizarOrden != null)
            {
                Number = actualizarOrden.IdOrden;
                // SelectedTypePay = typePayList.FirstOrDefault(d => d.description.ToUpper() == actualizarOrden.CondicionPagoNombre.ToUpper()).Id;
                EmpleadoSeleccionado = empleados.FirstOrDefault(e => e.Id == actualizarOrden.idGenerador);
                this.DateOutPut = actualizarOrden.FechaEmision;
                this.DateDeliver = actualizarOrden.FechaEntrega == null ? DateTime.Today : actualizarOrden.FechaEntrega.Value;
                //  this.Days = actualizarOrden.Dias;
                this.DetailOrderList = new ObservableCollection<DetalleOrdenCompraModel>(Repository.ObtenerDetalleOrden(actualizarOrden.IdOrden));
                this.IdSupplier = actualizarOrden.IdProveedor;
                this.SupplierName = actualizarOrden.NombreProveedor;
                this.contador = DetailOrderList != null && DetailOrderList.Count > 0 ? DetailOrderList.Max(d => d.Line) : 0;
                this.TotalGeneral = DetailOrderList != null && DetailOrderList.Count > 0 ? detailOrderList.Sum(d => d.Monto + d.Tax) : 0;
                this.ActualizarOrden = actualizarOrden;
                this.Status = actualizarOrden.CodigoEstado;
                this.TipoDePago = actualizarOrden.CondicionPagoNombre;
                this.Dias = actualizarOrden.Dias;
                this.UbicacionSeleccionada = actualizarOrden.IdUbicacion;
            }

            IdProduct = -1;
            if (detailOrderList != null)
                this.detailOrderList.CollectionChanged += detailOrderList_CollectionChanged;

        }


        void detailOrderList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);
        }
        #endregion

        #region Public Properties

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

        public int Dias
        {
            get { return dias; }
            set
            {
                dias = value;
                RaisePropertyChanged(() => Dias);
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

        public long Number
        {
            get { return number; }
            set
            {
                number = value;
                RaisePropertyChanged(() => Number);
            }
        }

        public double TotalGeneral
        {
            get { return totalGeneral; }
            set
            {
                totalGeneral = value;
                RaisePropertyChanged(() => TotalGeneral);
            }
        }


        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                RaisePropertyChanged(() => Status);
            }
        }

        public DetalleOrdenCompraModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(() => SelectedProduct);
            }
        }



        public int IdSupplier
        {
            get { return this.idSupplier; }
            set
            {
                this.idSupplier = value;
                RaisePropertyChanged(() => IdSupplier);
            }
        }

        public string SupplierName
        {
            get { return this.supplierName; }
            set
            {
                this.supplierName = value;
                RaisePropertyChanged(() => SupplierName);
            }
        }

        public string Direction
        {
            get { return this.direction; }
            set
            {
                this.direction = value;
                RaisePropertyChanged(() => Direction);
            }
        }

        public string DeliveryTo
        {
            get { return this.deliveryTo; }
            set
            {
                this.deliveryTo = value;
                RaisePropertyChanged(() => DeliveryTo);
            }
        }

        public string BillTo
        {
            get { return this.billTo; }
            set
            {
                this.billTo = value;
                RaisePropertyChanged(() => BillTo);
            }
        }

        //public int Days
        //{
        //    get { return this.days; }
        //    set
        //    {
        //        this.days = value;
        //        RaisePropertyChanged(() => Days);
        //    }
        //}

        public DateTime DateOutPut
        {
            get { return this.dateOutPut; }
            set
            {
                this.dateOutPut = value;
                RaisePropertyChanged(() => DateOutPut);
            }
        }

        public DateTime DateDeliver
        {
            get { return this.dateDeliver; }
            set
            {
                this.dateDeliver = value;
                RaisePropertyChanged(() => DateDeliver);
            }
        }

        public ICommand SearchSupplier
        {
            get
            {
                return new RelayCommand(s => OnSearchSupplier());
            }
        }

        public ICommand SearchOrderDetail
        {
            get
            {
                return new RelayCommand(s => OnSearchOrderDetail());
            }
        }

        public List<DetalleOrdenCompraModel> DetailOrderListStore
        {
            get { return this.detailOrderListStore; }
            set
            {
                this.detailOrderListStore = value;
                RaisePropertyChanged(() => DetailOrderListStore);
            }
        }

        public ObservableCollection<DetalleOrdenCompraModel> DetailOrderList
        {
            get { return this.detailOrderList; }
            set
            {
                this.detailOrderList = value;
                RaisePropertyChanged(() => DetailOrderList);
            }
        }

        public System.Windows.Visibility IsModeAuto
        {
            get { return this.isModeAuto; }
            set
            {
                this.isModeAuto = value;
                RaisePropertyChanged(() => IsModeAuto);
            }
        }

        public System.Windows.Visibility IsModeCreacion
        {
            get { return this.isModeCreacion; }
            set
            {
                this.isModeCreacion = value;
                RaisePropertyChanged(() => IsModeCreacion);
            }
        }

        public ICommand Autorizar
        {
            get
            {
                return new RelayCommand(s => OnSearchTradeMark());
            }
        }

        public ICommand Actualizar
        {
            get
            {
                return new RelayCommand(s => OnActualizarOrden());
            }
        }


        public List<Empleado> Empleados
        {
            get { return empleados; }
            set
            {
                empleados = value;
                RaisePropertyChanged(() => Empleados);
            }
        }

        public Empleado EmpleadoSeleccionado
        {
            get { return empleado; }
            set
            {
                empleado = value;
                RaisePropertyChanged(() => EmpleadoSeleccionado);
            }
        }

        public ICommand SearchProducts
        {
            get
            {
                return new RelayCommand(s => OnSearchProduct());
            }
        }

        #endregion

        #region Private Methods

        private void OnSearchSupplier()
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
                    this.IdSupplier = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Id;
                    this.SupplierName = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Name;
                    this.Direction = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.Address;
                    this.Dias = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.CantidadDeDias;
                    this.TipoDePago = ((CatalogoProveedoresVM)view.DataContext).SelectedProvider.TipoPago;
                }

            }
            catch (Exception ex)
            {

            }
        }

        //private void OnSearchOrderDetail()
        //{
        //    try
        //    {
        //        this.contador += 1;

        //        DetalleOrdenDeCompra view = new DetalleOrdenDeCompra();
        //        //view.Width = 500;
        //        //view.Height = 500;
        //        view.WindowState = WindowState.Normal;
        //        view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        //        DetalleOrdenDeCompraVM orderDetailVM = new DetalleOrdenDeCompraVM(this.contador);
        //        orderDetailVM.OnCloseProduct += ((s, e) => view.Close());
        //        view.DataContext = orderDetailVM;
        //        view.ShowDialog();

        //        DetalleOrdenCompraModel o = new DetalleOrdenCompraModel();

        //        if (view.DataContext != null)
        //        {
        //            if (!((DetalleOrdenDeCompraVM)view.DataContext).IsCancel)
        //            {
        //                o.Id = -1;
        //                o.Line = ((DetalleOrdenDeCompraVM)view.DataContext).Line;
        //                o.DateOutPut = ((DetalleOrdenDeCompraVM)view.DataContext).DateOutPut;
        //                o.Quantity = ((DetalleOrdenDeCompraVM)view.DataContext).Quantity;
        //                o.Recibido = ((DetalleOrdenDeCompraVM)view.DataContext).Quantity;
        //                o.UnitPrice = ((DetalleOrdenDeCompraVM)view.DataContext).UnitPrice;
        //                o.Tax = ((DetalleOrdenDeCompraVM)view.DataContext).Tax;
        //                o.Amount = ((DetalleOrdenDeCompraVM)view.DataContext).Amount;
        //                o.IdProduct = ((DetalleOrdenDeCompraVM)view.DataContext).IdProduct;
        //                o.ProductDescription = ((DetalleOrdenDeCompraVM)view.DataContext).Description;
        //                o.Nombre = ((DetalleOrdenDeCompraVM)view.DataContext).Nombre;
        //                o.CveProveedor = ((DetalleOrdenDeCompraVM)view.DataContext).ProductoSel.CveProvider;
        //                o.CveTecnobike = ((DetalleOrdenDeCompraVM)view.DataContext).ProductoSel.CveTeknobike;
        //                o.Total = o.Amount + o.Tax;

        //                DetailOrderListStore.Add(o);

        //                if (DetailOrderList == null)
        //                {
        //                    DetailOrderList = new ObservableCollection<DetalleOrdenCompraModel>();
        //                    DetailOrderList.Add(o);
        //                }
        //                else
        //                {
        //                    DetailOrderList.Add(o);
        //                }

        //                TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);
        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        public override void OnAccept()
        {
            try
            {
                if (EmpleadoSeleccionado == null)
                {
                    MessageBox.Show("Debes seleccionar un usuario que Genera la orden", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (UbicacionSeleccionada == -1)
                {
                    MessageBox.Show("Debes seleccionar una ubicacion", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //if (this.selectedTypePay == -1)
                //{
                //    MessageBox.Show("Debe seleccionar una condición de pago", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}

                if (this.IdSupplier == -1)
                {
                    MessageBox.Show("Debe seleccionar un proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                int id_orderbuy = 0;
                OrderBuy ob = new OrderBuy();

                ob.IdProvider = this.IdSupplier;
                ob.Direccion_Envio = this.DeliveryTo;
                ob.StatusName = this.BillTo;
                ob.FechaEmision = this.DateOutPut;
                ob.FechaEntrega = this.DateDeliver;
                ob.IdUbicacion = this.UbicacionSeleccionada;
                //  ob.IdPaymentCondition = this.SelectedTypePay;
                // ob.Dias = this.Days;
                ob.idGenerador = EmpleadoSeleccionado.Id;

                using (var ts = new TransactionScope())
                {
                    id_orderbuy = Repository.InsertOrderBuy(ob, 1);
                    Number = id_orderbuy;

                    if (id_orderbuy > 0)
                    {
                        if (detailOrderList.Count > 0)
                        {
                            foreach (DetalleOrdenCompraModel doc in detailOrderList)
                            {
                                doc.Id_OrderBuy = id_orderbuy;
                                idOC = id_orderbuy;
                                Repository.InsertOrderBuyDetail(doc);

                                IsModeAuto = System.Windows.Visibility.Visible;
                                IsModeCreacion = System.Windows.Visibility.Collapsed;
                            }
                        }

                    }
                    ts.Complete();
                    MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error", "Registro no modificado", MessageBoxButton.OK, MessageBoxImage.Error);

                throw;
            }
            if (cerrar != null)
                cerrar(null, new EventArgs());
        }


        private void OnActualizarOrden()
        {
            try
            {
                if (EmpleadoSeleccionado == null)
                {
                    MessageBox.Show("Debes seleccionar un usuario que Autoriza", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                //if (this.selectedTypePay == -1)
                //{
                //    MessageBox.Show("Debe seleccionar una condición de pago", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}
                int id_orderbuy = 0;
                OrderBuy ob = new OrderBuy();

                ob.IdProvider = this.IdSupplier;
                ob.Direccion_Envio = this.DeliveryTo;
                ob.StatusName = this.BillTo;
                ob.FechaEmision = this.DateOutPut;
                ob.FechaEntrega = this.DateDeliver;
                //ob.IdPaymentCondition = this.SelectedTypePay;
                //ob.Dias = this.Days;
                ob.idGenerador = EmpleadoSeleccionado.Id;
                ob.Id = ActualizarOrden.IdOrden;

                using (var ts = new TransactionScope())
                {
                    id_orderbuy = Repository.InsertOrderBuy(ob, 2);
                    Number = ActualizarOrden.IdOrden;

                    foreach (DetalleOrdenCompraModel doc in detailOrderList)
                    {
                        doc.Id_OrderBuy = ActualizarOrden.IdOrden;
                        idOC = ActualizarOrden.IdOrden;
                        Repository.InsertOrderBuyDetail(doc);

                        IsModeAuto = System.Windows.Visibility.Visible;
                        IsModeCreacion = System.Windows.Visibility.Collapsed;
                    }

                    foreach (var item in toDeleteDetail)
                    {
                        Repository.EliminarDetalle(item.Id);
                    }

                    ts.Complete();
                    MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error", "Registro no modificado", MessageBoxButton.OK, MessageBoxImage.Error);

                throw;
            }
            if (cerrar != null)
                cerrar(null, new EventArgs());
        }


        public override void OnSelectedItemGridClick(object parameters)
        {
            DetalleOrdenCompraModel item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as DetalleOrdenCompraModel;

            if (item == null)
                return;

            this.SelectedProduct = item;
            TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);
        }

        public override void OnDeleteItem(object param)
        {
            MessageBoxResult resultAlert = MessageBoxResult.OK;

            string msg = string.Empty;
            try
            {

                resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (resultAlert != MessageBoxResult.OK)
                    return;

                bool result = false;

                toDeleteDetail.Add(SelectedProduct);

                TotalGeneral -= SelectedProduct.Total;
                int i = 0;
                foreach (var item in DetailOrderList)
                {
                    i++;
                    item.Line = i;
                }
                this.contador = i;
                result = DetailOrderList.Remove(SelectedProduct);


                if (result)
                {
                    MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error  " + msg, "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (resultAlert == MessageBoxResult.OK)
                {
                    //OnClean();
                    //Task.Run(() => this.OnRefresh());
                }
            }
        }

        private void OnSearchTradeMark()
        {
            try
            {
                OrdenesDeCompraAutorizacion view = new OrdenesDeCompraAutorizacion();
                //view.Width = 500;
                //view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                OrdenesDeCompraAutorizarVM autorizar = new OrdenesDeCompraAutorizarVM(idOC);
                //tradeMarkVM.OnAddTradeMark += ((s, e) => view.Close());
                view.DataContext = autorizar;
                view.ShowDialog();

                //if (view.DataContext != null)
                //{
                //    this.TradeMarkName = ((CatalogoMarcasViewModel)view.DataContext).SelectedTradeMark.Marca;
                //    this.idTradeMark = ((CatalogoMarcasViewModel)view.DataContext).SelectedTradeMark.Id;
                //}

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchProduct()
        {
            try
            {
                if (IdSupplier == -1)
                {
                    MessageBox.Show("Selecciona primero el proveedor por favor...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                CatalogoProductos view = new CatalogoProductos();
                view.Width = 900;
                view.Height = 800;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoProductosVM productkVM = new CatalogoProductosVM(false, IdSupplier);
                productkVM.SelectedTab = 1;
                view.DataContext = productkVM;
                productkVM.OnAddProduct += ((s, e) => view.Close());
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    if (((CatalogoProductosVM)view.DataContext).ProductosImportados != null)
                    {
                        foreach (var prod in ((CatalogoProductosVM)view.DataContext).ProductosImportados)
                        {
                            DetalleOrdenCompraModel o = new DetalleOrdenCompraModel();

                            if (prod.Cantidad != 0)
                            {
                                this.contador += 1;
                                o.Id = -1;
                                o.Line = contador;
                                o.Quantity = prod.Cantidad;
                                o.Recibido = prod.Cantidad;
                                o.UnitPrice = prod.Cost;
                                o.Tax = prod.AddValorioum + prod.IGI + prod.Impuesto3;
                                o.Amount = (prod.Cantidad * prod.Cost);
                                o.IdProduct = prod.Id;
                                o.ProductDescription = prod.Description;
                                o.Nombre = prod.Name;
                                o.CveProveedor = prod.CveProvider;
                                o.CveTecnobike = prod.CveTeknobike;
                                o.Total = o.Amount + o.Tax;
                                DetailOrderListStore.Add(o);

                                if (DetailOrderList == null)
                                {
                                    DetailOrderList = new ObservableCollection<DetalleOrdenCompraModel>();
                                    DetailOrderList.Add(o);
                                }
                                else
                                {
                                    DetailOrderList.Add(o);
                                }

                                TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);

                                IdProduct = -1;
                                Line = 0;
                                Quantity = 0;
                                UnitPrice = 0;
                                Tax = 0;
                                Description = "";
                                Nombre = "";
                                ProductoSel = null;
                            }
                        }


                    }
                    else
                    {
                        this.IdProduct = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Id;
                        this.Description = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Name;
                        this.Nombre = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Name;
                        this.ProductoSel = ((CatalogoProductosVM)view.DataContext).SelectedProduct;
                        this.Line = contador + 1;
                        this.Tax = ProductoSel.AddValorioum + ProductoSel.IGI + ProductoSel.Impuesto3;
                    }
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchOrderDetail()
        {
            try
            {


                DetalleOrdenCompraModel o = new DetalleOrdenCompraModel();

                if (IdProduct != -1 && Quantity != 0 && UnitPrice != 0)
                {
                    this.contador += 1;
                    o.Id = -1;
                    o.Line = Line;
                    o.Quantity = Quantity;
                    o.Recibido = Quantity;
                    o.UnitPrice = UnitPrice;
                    o.Tax = Tax;
                    o.Amount = Amount;
                    o.IdProduct = IdProduct;
                    o.ProductDescription = Description;
                    o.Nombre = Nombre;
                    o.CveProveedor = ProductoSel.CveProvider;
                    o.CveTecnobike = ProductoSel.CveTeknobike;
                    o.Total = o.Amount + o.Tax;
                    DetailOrderListStore.Add(o);

                    if (DetailOrderList == null)
                    {
                        DetailOrderList = new ObservableCollection<DetalleOrdenCompraModel>();
                        DetailOrderList.Add(o);
                    }
                    else
                    {
                        DetailOrderList.Add(o);
                    }

                    TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);

                    IdProduct = -1;
                    Line = 0;
                    Quantity = 0;
                    UnitPrice = 0;
                    Tax = 0;
                    Description = "";
                    Nombre = "";
                    ProductoSel = null;
                }
                else
                {
                    MessageBox.Show("Llena todos los campos por favor...", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {

            }

        }

        #endregion

        #region add product
        private int line { get; set; }
        private int quantity { get; set; }
        private double unitPrice { get; set; }
        private double tax { get; set; }
        private double amount { get; set; }
        private int idProduct { get; set; }
        private string description { get; set; }
        private string nombre;
        private double totalItem;
        public Product ProductoSel { get; set; }
        public int Line
        {
            get { return this.line; }
            set
            {
                this.line = value;
                RaisePropertyChanged(() => Line);
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                this.quantity = value;
                RaisePropertyChanged(() => Quantity);
                RaisePropertyChanged(() => Amount);
                RaisePropertyChanged(() => TotalItem);
            }
        }

        public double UnitPrice
        {
            get { return this.unitPrice; }
            set
            {
                this.unitPrice = value;
                RaisePropertyChanged(() => UnitPrice);
                RaisePropertyChanged(() => Amount);
                RaisePropertyChanged(() => TotalItem);
            }
        }

        public double Tax
        {
            get { return this.tax; }
            set
            {
                this.tax = value;
                RaisePropertyChanged(() => Tax);
                RaisePropertyChanged(() => Amount);
                RaisePropertyChanged(() => TotalItem);
            }
        }

        public double Amount
        {
            get { return unitPrice * quantity; }
        }

        public double TotalItem
        {
            get { return this.Amount + tax; }
        }

        public int IdProduct
        {
            get { return this.idProduct; }
            set
            {
                this.idProduct = value;
                RaisePropertyChanged(() => IdProduct);
            }
        }


        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                RaisePropertyChanged(() => Nombre);
            }
        }

        public string Description
        {
            get { return this.description; }
            set
            {
                this.description = value;
                RaisePropertyChanged(() => Description);
            }
        }
        #endregion

    }
}
