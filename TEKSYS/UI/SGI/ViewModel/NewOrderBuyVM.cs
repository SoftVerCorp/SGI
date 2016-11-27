using SGI.Helpers;
using SGI.Model;
using SGI.Stuffs;
using SGI.View.DialogsInformation;
using SGI.ViewModel.DialogsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class NewOrderBuyVM : ViewModelBase
    {
        #region Private Fields

        private int id;
        private int providerId;
        private int employeeBuyeerId;
        private int employeeValidatorId;
        private int selectedPayment;
        private int statusBuyId;

        private bool isNotify;
        private bool isEnableButton;

        private string name;
        private string providerName;
        private string employeeBuyeerName;
        private string employeeValidatorName;
        private string orderBuy;

        private DateTime? colocationDate;
        private DateTime? validationDate;

        private List<PaymentCondition> paymentList;
        private List<StatusBuy> statusBuyList;


        #endregion

        #region Public Fields

        public event EventHandler OnAddOrderBuy;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewOrderBuyVM()
        {
            try
            {
                this.TitleWindow = "Agregar nueva orden de compra";
                this.OperationType = Enumeration.Operation.Create;
                this.ColocationDate = DateTime.Now;
                this.IsEnableButton = true;

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
            finally
            {

            }
        }

        /// <summary>
        /// Representa una nueva instancia de la clase NewOrderBuyVM
        /// </summary>
        public NewOrderBuyVM(OrderBuy obj)
        {
            this.TitleWindow = "Modificar orden de compra";
            this.OperationType = Enumeration.Operation.Update;
            this.IsEnableButton = true;

            try
            {

                this.PaymentList = new List<PaymentCondition>();
                this.PaymentList.Add(new PaymentCondition { Id = -1, Name = "Seleccione una forma de pago" });
                this.PaymentList.AddRange(Repository.GetPaymentConditions(string.Empty));


                this.StatusBuyList = new List<StatusBuy>();
                this.StatusBuyList.Add(new StatusBuy { Id = -1, Name = "Seleccione el estatus" });
                this.StatusBuyList.AddRange(Repository.GetStatusBuy(string.Empty));

                this.isNotify = obj.IsNotifyBuyStatus;
            }
            catch (Exception ex)
            {

            }


            if (obj != null)
            {
                this.id = obj.Id;
                this.ColocationDate = obj.DateColocation;
                this.ValidationDate = obj.DateValidation;
                this.StatusBuyId = obj.IdBuyStatus;
                this.employeeBuyeerId = obj.IdEmployeeBuyer;
                this.EmployeeBuyeerName = obj.EmployeeBuyeerName;
                this.employeeValidatorId = obj.IdEmployeeValidator;
                this.EmployeeValidatorName = obj.EmployeeValidatorName;
                this.SelectedPayment = obj.IdPaymentCondition;
                this.providerId = obj.IdProvider;
                this.ProviderName = obj.ProviderName;
                this.OrderBuy = obj.NumberOrderBuy;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public bool IsEnableButton
        {
            get { return isEnableButton; }
            set
            {
                if (isEnableButton != value)
                {
                    isEnableButton = value;
                    RaisePropertyChanged(() => IsEnableButton);
                }
            }
        }

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


        #endregion

        #region Private Methods

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

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
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

                IsEnableButton = false;

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

                if (OnAddOrderBuy != null)
                {
                    OnAddOrderBuy(true, null);
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsEnableButton = true;
                OnClose();
            }
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

        /// <summary>
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {

        }

        #endregion
    }
}