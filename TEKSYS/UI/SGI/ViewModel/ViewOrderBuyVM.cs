using SGI.Helpers;
using SGI.Model;
using SGI.Reporting;
using SGI.Stuffs;
using SGI.View;
using SGI.View.DialogsInformation;
using SGI.ViewModel.DialogsInformation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class ViewOrderBuyVM : ViewModelBase
    {
        #region Private Fields

        private int id;
        private int providerId;
        private int employeeBuyeerId;
        private int employeeValidatorId;
        private int selectedPayment;
        private int statusBuyId;
        private bool isNotify;
        private string name;
        private string providerName;
        private string employeeBuyeerName;
        private string employeeValidatorName;
        private string orderBuy;
        private DateTime? colocationDate;
        private DateTime? validationDate;
        private List<PaymentCondition> paymentList;
        private List<StatusBuy> statusBuyList;


        private string providerNameFilter;
        private string orderBuyFilter;
        private string employeeBuyeerFilter;
        private string employeeValidatorFilter;

        private DateTime beginDateFilter;
        private DateTime endDateFilter;

        private bool isEnableControl;
        private bool isExcelEnable;
        private bool isReportEnable;

        private OrderBuy selectedProduct;

        private List<OrderBuy> itemList;
        private List<OrderBuy> itemListAux;

        private DataGrid dataGridView;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ViewOrderBuyVM()
        {
            try
            {
                this.OperationType = Enumeration.Operation.Create;
                this.IsEnableControl = true;
                this.IsExcelEnable = true;
                this.IsReportEnable = true;
                this.InitDates();
                this.InitData();

                this.ColocationDate = DateTime.Now;

                this.PaymentList = new List<PaymentCondition>();
                this.PaymentList.Add(new PaymentCondition { Id = -1, Name = "Seleccione una forma de pago" });
                this.PaymentList.AddRange(Repository.GetPaymentConditions(string.Empty));
                this.SelectedPayment = -1;

                this.StatusBuyList = new List<StatusBuy>();
                this.StatusBuyList.Add(new StatusBuy { Id = -1, Name = "Seleccione el estatus" });
                this.StatusBuyList.AddRange(Repository.GetStatusBuy(string.Empty));
                this.StatusBuyId = -1;

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
        public List<StatusBuy> StatusBuyList
        {
            get { return statusBuyList; }
            set
            {
                if (statusBuyList != value)
                {
                    statusBuyList = value;
                    RaisePropertyChanged(() => StatusBuyList);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public int StatusBuyId
        {
            get { return statusBuyId; }
            set
            {
                if (statusBuyId != value)
                {
                    statusBuyId = value;
                    RaisePropertyChanged(() => StatusBuyId);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public DateTime? ValidationDate
        {
            get { return validationDate; }
            set
            {
                if (validationDate != value)
                {
                    validationDate = value;
                    RaisePropertyChanged(() => ValidationDate);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? ColocationDate
        {
            get { return colocationDate; }
            set
            {
                if (colocationDate != value)
                {
                    colocationDate = value;
                    RaisePropertyChanged(() => ColocationDate);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderBuy
        {
            get { return orderBuy; }
            set
            {
                if (orderBuy != value)
                {
                    orderBuy = value;
                    RaisePropertyChanged(() => OrderBuy);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SelectedPayment
        {
            get { return selectedPayment; }
            set
            {
                if (selectedPayment != value)
                {
                    selectedPayment = value;
                    RaisePropertyChanged(() => SelectedPayment);
                }
            }
        }



        /// <summary>
        /// 
        /// </summary>
        public List<PaymentCondition> PaymentList
        {
            get { return paymentList; }
            set
            {
                if (paymentList != value)
                {
                    paymentList = value;
                    RaisePropertyChanged(() => PaymentList);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeValidatorName
        {
            get { return employeeValidatorName; }
            set
            {
                if (employeeValidatorName != value)
                {
                    employeeValidatorName = value;
                    RaisePropertyChanged(() => EmployeeValidatorName);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public string EmployeeBuyeerName
        {
            get { return employeeBuyeerName; }
            set
            {
                if (employeeBuyeerName != value)
                {
                    employeeBuyeerName = value;
                    RaisePropertyChanged(() => EmployeeBuyeerName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string ProviderName
        {
            get { return providerName; }
            set
            {
                if (providerName != value)
                {
                    providerName = value;
                    RaisePropertyChanged(() => ProviderName);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Name
        {
            get { return name; }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged(() => Name);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectedProvider
        {
            get
            {
                return new RelayCommand(s => OnSelectedProvider());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectedEmployeeValidator
        {
            get
            {
                return new RelayCommand(s => OnSelectedEmployeeValidator());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand SelectedEmployeeBuyeer
        {
            get
            {
                return new RelayCommand(s => OnSelectedEmployeeBuyeer());
            }
        }

        public bool IsExcelEnable
        {
            get { return isExcelEnable; }
            set
            {
                if (isExcelEnable != value)
                {
                    isExcelEnable = value;
                    RaisePropertyChanged(() => IsExcelEnable);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsEnableControl
        {
            get { return isEnableControl; }
            set
            {
                if (isEnableControl != value)
                {
                    isEnableControl = value;
                    RaisePropertyChanged(() => IsEnableControl);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReportEnable
        {
            get { return isReportEnable; }
            set
            {
                if (isReportEnable != value)
                {
                    isReportEnable = value;
                    RaisePropertyChanged(() => IsReportEnable);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeValidatorFilter
        {
            get { return employeeValidatorFilter; }
            set
            {
                if (employeeBuyeerFilter != value)
                {
                    employeeValidatorFilter = value;
                    RaisePropertyChanged(() => EmployeeValidatorFilter);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeBuyeerFilter
        {
            get { return employeeBuyeerFilter; }
            set
            {
                if (employeeBuyeerFilter != value)
                {
                    employeeBuyeerFilter = value;
                    RaisePropertyChanged(() => EmployeeBuyeerFilter);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime EndDateFilter
        {
            get { return endDateFilter; }
            set
            {
                if (endDateFilter != value)
                {
                    endDateFilter = value;
                    RaisePropertyChanged(() => EndDateFilter);
                }
            }
        }

        public DateTime BeginDateFilter
        {
            get { return beginDateFilter; }
            set
            {
                if (beginDateFilter != value)
                {
                    beginDateFilter = value;
                    RaisePropertyChanged(() => BeginDateFilter);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public OrderBuy SelectedItem
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrderBuyFilter
        {
            get { return orderBuyFilter; }
            set
            {
                if (orderBuyFilter != value)
                {
                    orderBuyFilter = value;
                    RaisePropertyChanged(() => OrderBuyFilter);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la moneda.
        /// </summary>
        public string ProviderNameFilter
        {
            get { return providerNameFilter; }
            set
            {
                if (providerNameFilter != value)
                {
                    providerNameFilter = value;
                    RaisePropertyChanged(() => ProviderNameFilter);
                    SearchAsync();
                }
            }
        }

        public ICommand Refresh
        {
            get
            {
                return new RelayCommand(s => this.OnRefresh());
            }
        }


        /// <summary>
        /// Obtiene o establece una lista de ordenes de compra
        /// </summary>
        public List<OrderBuy> ItemList
        {
            get { return itemList; }
            set
            {
                if (itemList != value)
                {
                    itemList = value;
                    RaisePropertyChanged(() => ItemList);
                }
            }
        }



     


        public ICommand ExcelExport
        {
            get
            {
                return new RelayCommand(s => this.OnExcelExport());
            }
        }

        public ICommand LoadedControl
        {
            get
            {
                return new RelayCommand(OnLoadedControl);
            }
        }

        public ICommand ViewDetail
        {
            get
            {
                return new RelayCommand(OnViewDetail);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CreateReport
        {
            get
            {
                return new RelayCommand(OnCreateReport);
            }
        }

        #endregion

        #region Private Methods

        public override void OnSave()
        {
            if (string.IsNullOrEmpty(this.OrderBuy))
            {
                MessageBox.Show("Debe ingresar una orden de compra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.ProviderName))
            {
                MessageBox.Show("Debe ingresar una proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.EmployeeBuyeerName))
            {
                MessageBox.Show("Debe ingresar el empleado comprador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.EmployeeValidatorName))
            {
                MessageBox.Show("Debe ingresar el empleado validador", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (SelectedPayment == -1)
            {
                MessageBox.Show("Debe seleccionar la forma de pago", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (StatusBuyId == -1)
            {
                MessageBox.Show("Debe seleccionarel estatus de la compra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                OrderBuy model = new OrderBuy();
                model.Id = this.id;
                model.DateColocation = this.ColocationDate;
                model.DateValidation = this.ValidationDate;
                model.IdBuyStatus = this.StatusBuyId;
                model.IdEmployeeBuyer = this.employeeBuyeerId;
                model.IdEmployeeValidator = this.employeeValidatorId;
                model.IdPaymentCondition = this.SelectedPayment;
                model.IdProvider = this.providerId;
                model.NumberOrderBuy = this.OrderBuy;               

                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsOrderBuy(model, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var resp = MessageBox.Show("¿Desea modificar los datos?", "Modificar Datos", MessageBoxButton.OKCancel, MessageBoxImage.Question);

                        if (resp == MessageBoxResult.Cancel)
                            return;

                        if (this.isNotify)
                        {
                            MessageBox.Show("La orden de compra ha sido generada, no se puede modificar " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        var result = Repository.UpdOrderBuy(model, ref error, ref errorMessage);

                        if (!result || error < 0)
                        {
                            MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        try
                        {
                            SendMailToEmployee();
                        }
                        catch (Exception ex)
                        {

                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                //if (OnAddOrderBuy != null)
                //{
                //    OnAddOrderBuy(true, null);
                //}

            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClean();
                Task.Run(() => { InitData(); });
                //IsEnableButton = true;
                //OnClose();
            }
        }

        public override void OnClean()
        {
            this.OperationType = Enumeration.Operation.Create;
            this.id = 0;
            this.InitDates();
            this.StatusBuyId = -1;
            this.employeeBuyeerId = -1;
            this.EmployeeBuyeerName = string.Empty;
            this.employeeValidatorId = -1;
            this.EmployeeValidatorName = string.Empty;
            this.SelectedPayment = -1;
            this.providerId = -1;
            this.ProviderName = string.Empty;
            this.OrderBuy = string.Empty;
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as OrderBuy;

            if (item == null)
                return;

            this.OperationType = Enumeration.Operation.Update;
            this.id = item.Id;
            this.ColocationDate = item.DateColocation;
            this.ValidationDate = item.DateValidation;
            this.StatusBuyId = item.IdBuyStatus;
            this.employeeBuyeerId = item.IdEmployeeBuyer;
            this.EmployeeBuyeerName = item.EmployeeBuyeerName;
            this.employeeValidatorId = item.IdEmployeeValidator;
            this.EmployeeValidatorName = item.EmployeeValidatorName;
            this.SelectedPayment = item.IdPaymentCondition;
            this.providerId = item.IdProvider;
            this.ProviderName = item.ProviderName;
            this.OrderBuy = item.NumberOrderBuy;
        }


        private void OnSelectedProvider()
        {
            try
            {
                ProvidersWindow view = new ProvidersWindow();
                ViewProvidersVM vm = new ViewProvidersVM();
                view.DataContext = new ProvidersWindowVM(vm);
                view.ShowDialog();

                if (vm.SelectedItem != null)
                {
                    this.providerId = vm.SelectedItem.Id;
                    this.ProviderName = vm.SelectedItem.Name;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSelectedEmployeeValidator()
        {
            try
            {
                EmployeeWindow view = new EmployeeWindow();
                ViewEmployeesVM vm = new ViewEmployeesVM();
                view.DataContext = new EmployeeWindowVM(vm);
                view.ShowDialog();

                if (vm.SelectedItem != null)
                {
                    this.employeeValidatorId = vm.SelectedItem.Id;
                    this.EmployeeValidatorName = vm.SelectedItem.NombreCompleto;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OnSelectedEmployeeBuyeer()
        {
            try
            {
                EmployeeWindow view = new EmployeeWindow();
                ViewEmployeesVM vm = new ViewEmployeesVM();
                view.DataContext = new EmployeeWindowVM(vm);
                view.ShowDialog();

                if (vm.SelectedItem != null)
                {
                    this.employeeBuyeerId = vm.SelectedItem.Id;
                    this.EmployeeBuyeerName = vm.SelectedItem.NombreCompleto;
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void OnViewDetail(object param)
        {
            try
            {
                if (param == null)
                    return;

                OrderBuy model = param as OrderBuy;

                if (model == null)
                    return;

                DetailOrderBuyWindow view = new DetailOrderBuyWindow();
                view.DataContext = new DetailOrderBuyVM(model, view);
                view.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnLoadedControl(object param)
        {
            if (param == null)
                return;
            try
            {
                ViewOrderBuy view = param as ViewOrderBuy;

                if (view == null)
                    return;

                dataGridView = view.gridOrderBuys;
            }
            catch (Exception ex)
            {

            }
        }

        private void OnCreateReport(object param)
        {

            this.IsEnableControl = false;

            try
            {
                if (this.SelectedItem == null)
                {
                    MessageBox.Show("Debe seleccionar una orden de compra", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                ReportView rv = new ReportView();
                rv.GenerateOrderBuyDetailReport(SelectedItem.Id, SelectedItem.NumberOrderBuy, SelectedItem.EmployeeBuyeerName, SelectedItem.ProviderName, SelectedItem.EmployeeValidatorName);
                rv.ShowDialog();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.IsEnableControl = true;
            }

            //Task.Run(() =>
            //{

            //});
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnExcelExport()
        {

            //var x = dataGridView.ItemsSource;

            //var y = dataGridView.Items;

            //Dictionary<string, string> dic = new Dictionary<string, string>();


            //for (int i = 0; i < dataGridView.Items.Count; i++)
            //{
            //    var a = dataGridView.Items[0];

            //    for (int j = 0; j < dataGridView.Columns.Count; j++)
            //    {
            //        var n = dataGridView.Columns[j];                    
            //        dic.Add(n.Header.ToString(), n.SortMemberPath.ToString());
            //    }
            //}

            //foreach (string it in dic.Values)
            //{

            //    var values = this.ItemList.Select(xe => xe.GetType().GetProperty(it).GetValue(xe));
            //}


            IsExcelEnable = false;
            var directoryReports = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SGI/Reports/";

            directoryReports += Helps.GetRandomFileName("OrdenCompra");

            Task.Run(() =>
            {
                try
                {
                    var dataTable = ExportToExcel.ListToDataTable(this.ItemList);

                    if (dataTable == null)
                    {
                        MessageBox.Show("Error al exportar archivo , no hay datos a exportar", "Error Exportación", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    ExportToExcel.ExportDocument(dataTable, "Ordenes de compra", directoryReports);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al exportar archivo", "Error Exportación", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                finally
                {
                    IsExcelEnable = true;
                }
            });

        }

        private void InitData()
        {
            try
            {
                this.ItemList = Repository.GetOrdersBuy(BeginDateFilter, EndDateFilter);
                this.itemListAux = this.ItemList;
            }
            catch (Exception ex)
            {

            }
        }

        private void InitDates()
        {
            var dateAux = DateTime.Now;
            this.BeginDateFilter = new DateTime(dateAux.Year, dateAux.Month, dateAux.Day, 0, 0, 0);
            this.EndDateFilter = BeginDateFilter.AddDays(1);

        }

        ///// <summary>
        ///// Limpiar el texto despues de guardar los datos.
        ///// </summary>
        //private void OnCleanItems()
        //{
        //    try
        //    {
        //        this.ProviderNameFilter = string.Empty;
        //        this.OrderBuyFilter = string.Empty;
        //        this.EmployeeBuyeerFilter = string.Empty;
        //        this.EmployeeValidatorFilter = string.Empty;
        //        this.InitDates();
        //        this.OnRefresh();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnDeleteItem(object param)
        {
            try
            {
              
                string msg = string.Empty;
                int error = 0;

                if (this.id == 0)
                {
                    MessageBox.Show("Debe elegir un producto para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {


                    var res = Repository.DelOrderBuy(this.id, ref error, ref msg);

                    if (!res || error < 0)
                    {
                        MessageBox.Show("Error eliminando elemento " + msg, "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                OnClean();
                Task.Run(() => { InitData(); });
                //IsEnableButton = true;
                //OnClose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnUpdateItem(object param)
        {
            try
            {
                OrderBuy item = param as OrderBuy;


                if (item == null)
                {
                    MessageBox.Show("Debe elegir un producto a modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewOrderBuyView view = new NewOrderBuyView();
                NewOrderBuyVM vm = new NewOrderBuyVM(item);
                vm.OnAddOrderBuy += VMOnAddOrderBuy;
                view.DataContext = vm;
                view.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnAddItem(object param)
        {
            try
            {
                NewOrderBuyView view = new NewOrderBuyView();
                NewOrderBuyVM vm = new NewOrderBuyVM();
                vm.OnAddOrderBuy += VMOnAddOrderBuy;
                view.DataContext = vm;
                view.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VMOnAddOrderBuy(object sender, EventArgs e)
        {
            OnRefresh();
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh()
        {
            IsEnableControl = false;

            Task.Run(() =>
            {
                try
                {
                    this.ItemList = Repository.GetOrdersBuy(this.BeginDateFilter, this.EndDateFilter);
                    this.itemListAux = this.ItemList;
                }
                catch (Exception ex)
                {

                }
                finally
                {
                    IsEnableControl = true;
                }
            });
        }

        public async void SearchAsync()
        {
            try
            {
                this.ItemList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<OrderBuy>> GetList()
        {
            List<OrderBuy> lst = new List<OrderBuy>();

            await Task.Delay(10);

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.ProviderNameFilter) ? s.ProviderName.ToUpper().Contains(this.ProviderNameFilter.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.OrderBuyFilter) ? s.NumberOrderBuy.ToUpper().Contains(this.OrderBuyFilter.ToUpper()) : true))
                            &&
                          ((!string.IsNullOrEmpty(this.EmployeeBuyeerFilter) ? s.EmployeeBuyeerName.ToUpper().Contains(this.EmployeeBuyeerFilter.ToUpper()) : true))
                            &&
                          ((!string.IsNullOrEmpty(this.EmployeeValidatorFilter) ? s.EmployeeValidatorName.ToUpper().Contains(this.EmployeeValidatorFilter.ToUpper()) : true))
                         )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public override void OnAccept()
        {
        }

        private void SendMailToEmployee()
        {
            try
            {
                if (Repository.GetVerifySend(this.StatusBuyId) > 0)
                {
                    var lstMails = Repository.GetEmployeesMails();

                    if (lstMails.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();

                        sb.AppendLine("<table  style='width:800px; border:1px solid black;'>");
                        sb.AppendLine("<thead>");
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<th style='background-color:#242F70; color:#FFFFFF; text-align: left;height:30px;border: 1px solid black;' colspan='8'>Detalle de la Compra</th>");
                        sb.AppendLine("</tr>");

                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td style='width:150px;'>Numero :</td><td style='width:250px;'>" + this.OrderBuy + "</td>");
                        sb.AppendLine("<td style='width:150px;'>Proveedor :</td><td style='width:250px;'>" + this.ProviderName + "</td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("</tr>");

                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td style='width:160px;'>Empleado comprador :</td>");
                        sb.AppendLine("<td style='style='width:240px;'>" + this.EmployeeBuyeerName + "</td>");
                        sb.AppendLine("<td style='width:160px;'>Empleado verificador :</td>");
                        sb.AppendLine("<td style='style='width:240px;'>" + this.EmployeeValidatorName + "</td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("<td></td>");
                        sb.AppendLine("</tr>");
                        sb.AppendLine("</thead>");

                        sb.AppendLine("</table>");
                        sb.AppendLine("</br>");

                        sb.AppendLine("<table style='width:800px;'>");
                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td style='background-color:#242F70; color:#FFFFFF; text-align: left;height:30px;' colspan='7'>Productos</td>");
                        sb.AppendLine("</tr>");

                        sb.AppendLine("<tr>");
                        sb.AppendLine("<td style='width:50px;height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>No.</td>");
                        sb.AppendLine("<td style='width:150px;height:30px;background-color:#878686;border: 1px solid black;text-align: center;'>Articulo</td>");
                        sb.AppendLine("<td style='width:200px; height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>Descripcion</td>");
                        sb.AppendLine("<td style='width:120px; height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>Marca</td>");
                        sb.AppendLine("<td style='width:100px;height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>Cantidad</td>");
                        sb.AppendLine("<td style='width:100px;height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>Costo</td>");
                        sb.AppendLine("<td style='width:150px;height:30px;background-color:#878686; border: 1px solid black;text-align: center;'>Total</td>");
                        sb.AppendLine("</tr>");

                        var lstProducts = Repository.GetOrdersBuyDetail(this.id);

                        double total = 0;
                        int counter = 0;

                        if (lstProducts.Count > 0)
                        {
                            foreach (var item in lstProducts)
                            {
                                string bgColor = "#EEEEEE";

                                if (counter % 2 == 0)
                                {
                                    bgColor = "#dddddd";
                                }

                                sb.AppendLine("<tr>");
                                sb.AppendLine("<td style='width:50px;height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: center;'>" + item.Sequence + "</td>");
                                sb.AppendLine("<td style='width:150px;height:30px;background-color:" + bgColor + ";border: 1px solid black;text-align: left;'>" + item.ProductName + "</td>");
                                sb.AppendLine("<td style='width:200px; height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: left;'>" + item.ProductDescription + "</td>");
                                sb.AppendLine("<td style='width:120px; height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: center;'>" + item.TrademarkName + "</td>");
                                sb.AppendLine("<td style='width:100px;height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: center;'>" + item.Pieces + "</td>");
                                sb.AppendLine("<td style='width:100px;height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: center;'>" + item.Price + "</td>");
                                sb.AppendLine("<td style='width:150px;height:30px;background-color:" + bgColor + "; border: 1px solid black;text-align: center;'>" + item.Total + "</td>");
                                sb.AppendLine("</tr>");

                                total += item.Total;
                                counter++;
                            }


                        }

                        sb.AppendLine("<tr>");

                        sb.AppendLine("<td style='height:30px;' colspan='5'>");

                        sb.AppendLine("</td>");

                        sb.AppendLine("<td style='border: 1px solid black;text-align: right;height:30px;'>");
                        sb.AppendLine("Total: $ ");
                        sb.AppendLine("</td>");

                        sb.AppendLine("<td style='border: 1px solid black;text-align: center;height:30px;'>");
                        sb.AppendLine(total.ToString());
                        sb.AppendLine("</td>");

                        sb.AppendLine("</tr>");

                        sb.AppendLine("</table>");

                        HelperMail.SendMail(lstMails, "Orden de compra generada", sb.ToString());
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
