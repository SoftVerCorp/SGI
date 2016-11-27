using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.ViewModel.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class OrdenesDeCompraAutorizarVM  : ViewModelBase
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
        private string selectedTypePay { get; set; }
        private List<TypePay> typePayList { get; set; }
        private DetalleOrdenCompraModel selectedProduct { get; set; }
        private double totalGeneral { get; set; }
        private List<Empleado> empleados;
        private int number { get; set; }
        private OrderBuy OC { get; set; }
        private string estatusOC { get; set; }
        private int IdOC { get; set; }


        #endregion

        #region Constructors

        public OrdenesDeCompraAutorizarVM(int idOC)
        {
            //this.DateOutPut = DateTime.Today;
            //this.DateDeliver = DateTime.Today;
            //this.DetailOrderListStore = new List<DetalleOrdenCompraModel>();

            //this.TypePayList = new List<TypePay>();
            //this.TypePayList.Add(new TypePay { Id = -1, description = "Seleccionar" });
            //this.TypePayList.AddRange(Repository.GetTypePay());

            //this.SelectedTypePay = -1;
            this.Empleados = Repository.GetEmployees("",ManejadorUbicacion.IdUbicacion);
            this.IdOC = idOC;
            
            SetOC(idOC);

        }

        #endregion

        #region Public Properties

        public int Number
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

        public DetalleOrdenCompraModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(() => SelectedProduct);
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

        public string SelectedTypePay
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

        public List<DetalleOrdenCompraModel> DetailOrderList
        {
            get { return this.detailOrderList; }
            set
            {
                this.detailOrderList = value;
                RaisePropertyChanged(() => DetailOrderList);
            }
        }

        public string EstatusOC
        {
            get { return this.estatusOC; }
            set
            {
                this.estatusOC = value;
                RaisePropertyChanged(() => EstatusOC);
            }
        }


        public List<Empleado> Empleados
        {
            get { return empleados; }
            set 
            {
                empleados = value;
                RaisePropertyChanged(()=> Empleados);
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
                DetalleOrdenDeCompra view = new DetalleOrdenDeCompra();
                //view.Width = 500;
                //view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                DetalleOrdenDeCompraVM orderDetailVM = new DetalleOrdenDeCompraVM();
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
                        o.Nombre = ((DetalleOrdenDeCompraVM)view.DataContext).Nombre;
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
                string estatus = string.Empty;

                estatus = Repository.UpdateEstatusOC(IdOC, 2);

                if (!string.IsNullOrEmpty(estatus) && estatus != "-1")
                {
                    this.EstatusOC = estatus;
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
            DetalleOrdenCompraModel item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as DetalleOrdenCompraModel;

            if (item == null)
                return;

             this.SelectedProduct = item;
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

                if (detailOrderListStore.Remove(SelectedProduct))
                {
                    DetailOrderList = detailOrderListStore;
                    result = true;
                    TotalGeneral -= SelectedProduct.Total;
                }

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


        private void SetOC(int idOC)
        {
            this.OC = Repository.GetOC(idOC).FirstOrDefault();

            this.idSupplier = this.OC.IdProvider;
            this.SupplierName = this.OC.ProviderName;
            this.Number = this.OC.Id;
            this.DateOutPut = this.OC.FechaEmision;
            this.DateDeliver = this.OC.FechaEntrega;
            this.SelectedTypePay = this.OC.ConditionPayment;
            this.Days = this.OC.Dias;
            this.EstatusOC = this.OC.StatusName;


            this.DetailOrderList = Repository.GetOCDetalle(idOC);

            this.TotalGeneral = this.DetailOrderList.Sum(x => x.Total);
        }

        #endregion

    }
}
