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
using System.Net.Mail;
using System.Collections.ObjectModel;
using SGI.Helpers;
using SGI.Enumeration;

namespace SGI.ViewModel
{
    public class OrdenesDeCompraVisorAutorizarVM : ViewModelBase
    {
        #region Private Fields

        private int idSupplier { get; set; }
        private string supplierName { get; set; }
        private string direction { get; set; }
        private string deliveryTo { get; set; }
        private string billTo { get; set; }
        private int days { get; set; }
        private DateTime dateOutPut { get; set; }
        private DateTime? dateDeliver { get; set; }
        private List<DetalleOrdenCompraModel> detailOrderListStore;
        private ObservableCollection<DetalleOrdenCompraModel> detailOrderList;
        private string selectedTypePay { get; set; }
        private List<TypePay> typePayList { get; set; }
        private DetalleOrdenCompraModel selectedProduct { get; set; }
        private double totalGeneral { get; set; }
        private List<Empleado> empleados;
        private Empleado empleado;
        public event EventHandler cerrar;
        private int number { get; set; }
        private OrdenesDisponibles OC { get; set; }
        private string estatusOC { get; set; }
        private int IdOC { get; set; }

        #endregion

        #region Constructors

        public OrdenesDeCompraVisorAutorizarVM(int idOC)
        {
            //this.DateOutPut = DateTime.Today;
            //this.DateDeliver = DateTime.Today;
            //this.DetailOrderListStore = new List<DetalleOrdenCompraModel>();

            //this.TypePayList = new List<TypePay>();
            //this.TypePayList.Add(new TypePay { Id = -1, description = "Seleccionar" });
            //this.TypePayList.AddRange(Repository.GetTypePay());

            //this.SelectedTypePay = -1;

            this.Empleados = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);
            this.EmpleadoSeleccionado = Empleados.Where(s => s.Id == ManejadorLoguin.idUsuario).FirstOrDefault();
            this.IdOC = idOC;

            SetOC(idOC);
            if (detailOrderList != null)
                this.detailOrderList.CollectionChanged += detailOrderList_CollectionChanged;

        }
        void detailOrderList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);
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

        public DateTime? DateDeliver
        {
            get { return this.dateDeliver; }
            set
            {
                this.dateDeliver = value;
                RaisePropertyChanged(() => DateDeliver);
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
        #endregion

        #region Private Methods


        public override void OnAccept()
        {
            try
            {
                if (EmpleadoSeleccionado == null)
                {
                    MessageBox.Show("Debes seleccionar un usuario que Autoriza", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (MessageBox.Show("¿Realmente deseas Autorizar la orden seleccionada?", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    Repository.ActualizarEstadoOrden(OC.IdOrden, 2, EmpleadoSeleccionado.Id, null, string.Empty);
                    SetOC(OC.IdOrden);

                    new Task(() => SendEmail(OC, DetailOrderList.ToList())).Start();
                }
            }
            catch (Exception ex)
            {

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
        }



        private void SetOC(int idOC)
        {
            this.OC = Repository.ObtenerOrdenesDisp(idOC, null, null).FirstOrDefault();

            this.idSupplier = this.OC.IdProveedor;
            this.SupplierName = this.OC.NombreProveedor;
            this.Number = this.OC.IdOrden;
            this.DateOutPut = this.OC.FechaEmision;
            this.DateDeliver = this.OC.FechaEntrega;
            this.SelectedTypePay = this.OC.CondicionPagoNombre;
            this.Days = this.OC.Dias;
            this.EstatusOC = this.OC.CodigoEstado;

            this.DetailOrderList = new ObservableCollection<DetalleOrdenCompraModel>(Repository.ObtenerDetalleOrden(idOC));

            this.TotalGeneral = this.DetailOrderList.Sum(x => x.Total);
        }

        public void SendEmail(OrdenesDisponibles OC, List<DetalleOrdenCompraModel> detalle, string fromAddress = "teksys2016@gmail.com", string mailPassword = "teksystem")
        {
            try
            {
                if (!String.IsNullOrEmpty(OC.CorreoProveedor))
                {
                    var mails = Repository.ObtenerCorreosPorTipoDeNotificacion((int)TiposDeNotificacion.GeneracionOrdenDeCompra,ManejadorUbicacion.IdUbicacion);

                    MailMessage mail = new MailMessage(fromAddress, OC.CorreoProveedor);

                  //  mail.From = fromAddress;
                    
                  //  mail.CC

                    if (mails != null)
                    {
                        if(mails.Count > 0)
                        {
                            foreach(var s in mails)
                            {
                                mail.CC.Add(s);
                            }
                        }
                    }

                    mail.Subject = "Aviso de orden de compra: " + OC.IdOrden;
                    mail.IsBodyHtml = true;




                    var html = "<p><strong>Notificacion de orden autorizada:</strong></p>" +
                                "<p><strong>Numero de orden : " + OC.IdOrden + "</strong></p>" +

                                "<p><strong>Fecha emisión : " + OC.FechaEmision.ToShortDateString() + " </strong></p>" +
                                "<p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>" +
                                "<table style=\"margin-left: auto; margin-right: auto; height: 56px;border: 1px solid black; border-collapse: collapse;\" width=\"802\">" +
                                "<tbody>" +
                                "<tr  style=\"border: 1px solid black; border-collapse: collapse; text-align: center;background-color: #f1f1c1;\">" +
                                "<td><strong>Linea&nbsp;</strong></td>" +
                                "<td><strong>Clave Teknobike</strong></td>" +
                                "<td><strong>clave proveedor&nbsp;</strong></td>" +
                                "<td><strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; Nombre &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;</strong></td>" +
                                "<td><strong>Cantidad&nbsp;</strong></td>" +
                                "<td><strong>Precio U.</strong></td>" +
                                "<td><strong>Impuestos</strong></td>" +
                                "<td><strong>&nbsp;Monto &nbsp;</strong></td>" +
                                "<td><strong>Total &nbsp;&nbsp;</strong></td>" +
                                "</tr>";

                    foreach (var item in detalle)
                    {
                        var htmlitem = "<tr  style=\"border: 1px solid black; border-collapse: collapse; text-align: center;\">" +
                       "<td>" + item.Line + "</td>" +
                       "<td>" + item.CveTecnobike + "</td>" +
                       "<td>" + item.CveProveedor + "</td>" +
                       "<td>" + item.Nombre + "</td>" +
                       "<td>" + item.Quantity + "</td>" +
                       "<td>" + item.UnitPrice + "</td>" +
                       "<td>" + item.Tax + "</td>" +
                       "<td" + item.Amount + "</td>" +
                       "<td>" + item.Total + "</td>" +
                       "</tr>";
                        html = html + htmlitem;
                    }


                    html = html + "</tbody>" +
                                "</table>" +
                                "<p>&nbsp;</p>" +
                                "<p>TeknoBikes</p>" +
                                "<p>&nbsp;</p>";


                    mail.Body = html;

                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                    smtpClient.Credentials = new System.Net.NetworkCredential()
                    {
                        UserName = fromAddress,
                        Password = mailPassword
                    };

                    smtpClient.EnableSsl = true;
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object s,
                            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                            System.Security.Cryptography.X509Certificates.X509Chain chain,
                            System.Net.Security.SslPolicyErrors sslPolicyErrors)
                    {
                        return true;
                    };

                    smtpClient.Send(mail);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al enviar el correo al proveedor!!!", "Informacion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion

    }
}
