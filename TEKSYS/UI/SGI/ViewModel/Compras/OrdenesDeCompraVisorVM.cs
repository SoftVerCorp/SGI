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
using SGI.View.OC;
using SGI.ViewModel.OC;
using SGI.ViewModel.Catalogos;
using SGI.Helpers;

namespace SGI.ViewModel
{
    public class OrdenesDeCompraVisorVM : ViewModelBase
    {
        #region Private Fields

        private int idSupplier { get; set; }
        private string supplierName { get; set; }
        private string direction { get; set; }
        private string deliveryTo { get; set; }
        private string billTo { get; set; }
        private int days { get; set; }
        private DateTime dateOutPut { get; set; }
        private DateTime dateDeliver { get; set; }
        private List<DetalleOrdenCompraModel> detailOrderListStore;
        private List<DetalleOrdenCompraModel> detailOrderList;
        private int selectedTypePay { get; set; }
        private List<TypePay> typePayList { get; set; }
        private OrderBuy selectedOC { get; set; }
        private double totalGeneral { get; set; }
        private System.Windows.Visibility isModeAuto;
        private System.Windows.Visibility isModeCreacion;

        private int idOC { get; set; }
        private long number { get; set; }
        private int contador { get; set; }
        private List<OrderBuy> ocList { get; set; }
        private List<OrderBuy> ocListStore { get; set; }
        private string idOrdenSeleccionada;
        private List<OrdenesDisponibles> ordenesDisp;

        private OrdenesDisponibles ordenSeleccionada;

        private DateTime finDateOutPut { get; set; }
        private DateTime finDateDeliver { get; set; }
        private string estatusSel;

        public List<String> Estatus { get; set; }
        #endregion

        #region Constructors

        public OrdenesDeCompraVisorVM()
        {
            this.dateOutPut = DateTime.Today;
            this.dateDeliver = DateTime.Today;
            this.finDateOutPut = DateTime.Today;
            this.finDateDeliver = DateTime.Today;
            this.Estatus = new List<string> 
            {
                "Generada",         
                "Autorizada",
                "Recibida",
                "Cancelada",
                "Todas"
            };
            this.EstatusSel = Estatus.FirstOrDefault();
            //this.DetailOrderListStore = new List<DetalleOrdenCompraModel>();

            //OnRefresh(true);
            //this.TypePayList = Repository.GetTypePay();

            //IsModeAuto = System.Windows.Visibility.Collapsed;
            //IsModeCreacion = System.Windows.Visibility.Visible;

        }

        #endregion

        #region Public Properties

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

        public OrderBuy SelectedOC
        {
            get { return selectedOC; }
            set
            {
                selectedOC = value;
                RaisePropertyChanged(() => SelectedOC);
            }
        }

        public List<TypePay> TypePayList
        {
            get { return typePayList; }
            set
            {
                typePayList = value;
                RaisePropertyChanged(() => TypePayList);
            }
        }

        public int SelectedTypePay
        {
            get { return selectedTypePay; }
            set
            {
                selectedTypePay = value;
                RaisePropertyChanged(() => SelectedTypePay);
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

        public int Days
        {
            get { return this.days; }
            set
            {
                this.days = value;
                RaisePropertyChanged(() => Days);
            }
        }

        public DateTime DateOutPut
        {
            get { return this.dateOutPut; }
            set
            {
                this.dateOutPut = value;
                RaisePropertyChanged(() => DateOutPut);
                SearchAsync();
            }
        }

        public DateTime DateDeliver
        {
            get { return this.dateDeliver; }
            set
            {
                this.dateDeliver = value;
                RaisePropertyChanged(() => DateDeliver);
                SearchAsync();
            }
        }

        public DateTime FinDateOutPut
        {
            get { return this.finDateOutPut; }
            set
            {
                this.finDateOutPut = value;
                RaisePropertyChanged(() => FinDateOutPut);
                SearchAsync();
            }
        }

        public DateTime FinDateDeliver
        {
            get { return this.finDateDeliver; }
            set
            {
                this.finDateDeliver = value;
                RaisePropertyChanged(() => FinDateDeliver);
                SearchAsync();
            }
        }

        public string IdOrdenSeleccionada
        {
            get { return idOrdenSeleccionada; }
            set
            {
                idOrdenSeleccionada = value;
                RaisePropertyChanged(() => IdOrdenSeleccionada);
            }
        }

        public List<OrdenesDisponibles> OrdenesDisp
        {
            get { return ordenesDisp; }
            set
            {
                ordenesDisp = value;
                RaisePropertyChanged(() => OrdenesDisp);
            }
        }

        public OrdenesDisponibles OrdenSeleccionada
        {
            get { return ordenSeleccionada; }
            set
            {
                ordenSeleccionada = value;
                RaisePropertyChanged(() => OrdenSeleccionada);
            }
        }


        public string EstatusSel
        {
            get { return estatusSel; }
            set
            {
                estatusSel = value;
                RaisePropertyChanged(() => EstatusSel);
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

        public ICommand BuscarOCDispCmd
        {
            get
            {
                return new RelayCommand(s => BuscandoOrdenes());
            }
        }

        public ICommand AutorizarOrdenCmd
        {
            get
            {
                return new RelayCommand(s => AutorizarOrden());
            }
        }

        public ICommand RechazarOrdenCmd
        {
            get
            {
                return new RelayCommand(s => RechazarOrden());
            }
        }

        public ICommand RecibirOrdenCmd
        {
            get
            {
                return new RelayCommand(s => RecibirOrden());
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

        public List<DetalleOrdenCompraModel> DetailOrderList
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

        public ICommand EditarOrden
        {
            get
            {
                return new RelayCommand(s => OnEditarOrden());
            }
        }

        public ICommand VerArchivosCmd
        {
            get
            {
                return new RelayCommand(s => OnVerArchivos());
            }
        }

        public List<OrderBuy> OcList
        {
            get { return this.ocList; }
            set
            {
                this.ocList = value;
                RaisePropertyChanged(() => OcList);
            }
        }

        public List<OrderBuy> OcListStore
        {
            get { return this.ocListStore; }
            set
            {
                this.ocListStore = value;
                RaisePropertyChanged(() => OcListStore);
            }
        }

        public ICommand VerGastosImportacionCmd
        {
            get
            {
                return new RelayCommand(s => MostrarGastosImportacion());
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
                    var fileName = "OrdenesCompra.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.OrdenesDisp);

                    ExportToExcel.ExportDocument(dataTable, "Ordenes de Compra", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }

        private void MostrarGastosImportacion()
        {
            try
            {
                if (OrdenSeleccionada == null)
                {
                    MessageBox.Show("Debe seleccionar una orden de compra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!ordenSeleccionada.CodigoEstado.ToUpper().Equals(("Recibida").ToUpper()))
                {
                    MessageBox.Show("La orden debe ser recibida para agregar gastos de importacion");
                    return;
                }

                GastosDeImportacion gi = new GastosDeImportacion();
                gi.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                gi.DataContext = new GastosDeImportacionVM(OrdenSeleccionada.IdOrden);
                gi.Show();

            }
            catch (Exception ex)
            {

            }
        }


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
                this.contador += 1;

                DetalleOrdenDeCompra view = new DetalleOrdenDeCompra();
                //view.Width = 500;
                //view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                DetalleOrdenDeCompraVM orderDetailVM = new DetalleOrdenDeCompraVM(this.contador);
                orderDetailVM.OnCloseProduct += ((s, e) => view.Close());
                view.DataContext = orderDetailVM;
                view.ShowDialog();

                DetalleOrdenCompraModel o = new DetalleOrdenCompraModel();

                if (view.DataContext != null)
                {
                    if (!((DetalleOrdenDeCompraVM)view.DataContext).IsCancel)
                    {
                        o.Line = ((DetalleOrdenDeCompraVM)view.DataContext).Line;
                        o.DateOutPut = ((DetalleOrdenDeCompraVM)view.DataContext).DateOutPut;
                        o.Quantity = ((DetalleOrdenDeCompraVM)view.DataContext).Quantity;
                        o.UnitPrice = ((DetalleOrdenDeCompraVM)view.DataContext).UnitPrice;
                        o.Tax = ((DetalleOrdenDeCompraVM)view.DataContext).Tax;
                        o.Amount = ((DetalleOrdenDeCompraVM)view.DataContext).Amount;
                        o.IdProduct = ((DetalleOrdenDeCompraVM)view.DataContext).IdProduct;
                        o.ProductDescription = ((DetalleOrdenDeCompraVM)view.DataContext).Description;

                        o.Total = o.Amount + o.Tax;

                        DetailOrderListStore.Add(o);

                        TotalGeneral += o.Total;
                    }

                }

                if (DetailOrderListStore != null && DetailOrderListStore.Count > 0)
                {
                    DetailOrderList = DetailOrderListStore;
                }

            }
            catch (Exception ex)
            {

            }
        }

        public override void OnAccept()
        {
            try
            {
                int id_orderbuy = 0;
                OrderBuy ob = new OrderBuy();

                ob.IdProvider = this.IdSupplier;
                ob.Direccion_Envio = this.DeliveryTo;
                ob.StatusName = this.BillTo;
                ob.FechaEmision = this.DateOutPut;
                ob.FechaEntrega = this.DateDeliver;
                ob.IdPaymentCondition = this.SelectedTypePay;
                ob.Dias = this.Days;

                id_orderbuy = Repository.InsertOrderBuy(ob, 1);

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

                    MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Error", "Registro no modificado", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Error", "Registro no modificado", MessageBoxButton.OK, MessageBoxImage.Error);

                throw;
            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {

            //if (ordenSeleccionada == null)
            //    return;

            //var archivos = Repository.GetArchivos(ordenSeleccionada.IdOrden);

            // var vista = new verArchivos();
            // vista.SetDatos(archivos);
            // vista.ShowDialog();
        }

        public void OnEditarOrden()
        {
            if (OrdenSeleccionada == null)
                return;

            var verdetalle = new OrdenesDeCompraEditar();
            var vm = new OrdenesDeCompraVM(OrdenSeleccionada);
            verdetalle.DataContext = vm;
            vm.cerrar += ((s, e) => verdetalle.Close());
            verdetalle.ShowDialog();
        }

        //public override void OnDeleteItem(object param)
        //{
        //    MessageBoxResult resultAlert = MessageBoxResult.OK;

        //    string msg = string.Empty;
        //    try
        //    {

        //        resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        //        if (resultAlert != MessageBoxResult.OK)
        //            return;

        //        bool result = false;

        //        if (detailOrderListStore.Remove(SelectedOC))
        //        {  
        //            DetailOrderList = detailOrderListStore;
        //            result = true;
        //            TotalGeneral -= SelectedProduct.Total;
        //        }

        //        if (result)
        //        {
        //            MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);
        //        }
        //        else
        //        {
        //            MessageBox.Show("Error  " + msg, "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        if (resultAlert == MessageBoxResult.OK)
        //        {
        //            //OnClean();
        //            //Task.Run(() => this.OnRefresh());
        //        }
        //    }
        //}

        private void OnSearchTradeMark()
        {
            try
            {
                OrdenesDeCompraAutorizacion view = new OrdenesDeCompraAutorizacion();
                //view.Width = 500;
                //view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                OrdenesDeCompraAutorizarVM autorizar = new OrdenesDeCompraAutorizarVM(OrdenSeleccionada.IdOrden);

                view.DataContext = autorizar;
                view.ShowDialog();

                OnRefresh(true);

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

        private void OnRefresh(bool isInit)
        {
            try
            {
                BuscandoOrdenes();
            }
            catch (Exception ex)
            {

            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.OcList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async void BuscandoOrdenes()
        {
            try
            {
                OrdenesDisp = await Task.Run(() => Repository.ObtenerOrdenesDisp(String.IsNullOrEmpty(idOrdenSeleccionada) ? null : (int?)Convert.ToInt32(idOrdenSeleccionada),
                    IdSupplier == 0 ? null : (int?)IdSupplier, estatusSel == "Todas" ? null : estatusSel));
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<OrderBuy>> GetList()
        {
            List<OrderBuy> lst = new List<OrderBuy>();

            try
            {
                var aux = this.OcListStore;

                lst = aux.Where(
                      s =>
                         (
                          (((this.DateOutPut != null ? s.FechaEmision >= this.DateOutPut : true))
                            && ((this.FinDateOutPut != null ? s.FechaEmision <= this.DateOutPut : true))) ||
                          (((this.DateDeliver != null ? s.FechaEmision >= this.DateDeliver : true))
                            && ((this.FinDateDeliver != null ? s.FechaEmision <= this.FinDateDeliver : true)))
                         )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }

        private void RecibirOrden()
        {
            try
            {
                if (ordenSeleccionada.CodigoEstado.ToUpper() == "Autorizada".ToUpper())
                {
                    var view = new OrdenesDeCompraVisorRecibe();
                    view.WindowState = WindowState.Normal;
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    var autorizar = new OrdenesDeCompraVisorRecibeVM(OrdenSeleccionada.IdOrden);

                    view.DataContext = autorizar;
                    autorizar.cerrar += ((s, e) => view.Close());
                    view.ShowDialog();

                    OnRefresh(true);
                }
                else
                {
                    MessageBox.Show("La orden no esta en estado Autorizada", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void RechazarOrden()
        {
            if (ordenSeleccionada.CodigoEstado.ToUpper() == "Generada".ToUpper())
            {
                if (MessageBox.Show("¿Realmente deseas cancelar la orden seleccionada?", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Repository.ActualizarEstadoOrden(ordenSeleccionada.IdOrden, 4, 0, null,string.Empty);
                    OnRefresh(true);
                }
            }
            else
            {
                MessageBox.Show("La orden no esta en estado Generada", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void AutorizarOrden()
        {
            try
            {
                if (ordenSeleccionada.CodigoEstado.ToUpper() == "Generada".ToUpper())
                {
                    var view = new OrdenesDeCompraVisorAutoriza();
                    view.WindowState = WindowState.Normal;
                    view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    var autorizar = new OrdenesDeCompraVisorAutorizarVM(OrdenSeleccionada.IdOrden);
                    view.DataContext = autorizar;
                    autorizar.cerrar += ((s, e) => view.Close());
                    view.ShowDialog();

                    OnRefresh(true);
                }
                else
                {
                    MessageBox.Show("La orden no esta en estado Generada", "Informacion", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void OnVerArchivos()
        {
            try
            {
                if (ordenSeleccionada != null)
                {
                    var archivos = new verArchivos();
                    archivos.verGrid.ItemsSource = Repository.GetArchivos(ordenSeleccionada.IdOrden);
                    archivos.ShowDialog();
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

    }
}
