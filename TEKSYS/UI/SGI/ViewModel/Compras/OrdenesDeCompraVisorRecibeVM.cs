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
using Microsoft.Win32;
using System.IO;
using SGI.Helpers;
using SGI.ViewModel.OC;
using SGI.View.OC;

namespace SGI.ViewModel
{
    public class OrdenesDeCompraVisorRecibeVM : ViewModelBase
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
        private List<Ubicacion> ubicaciones;
        private Ubicacion ubicacionSel;
        private List<Empleado> empleados;
        private Empleado empleado;
        private DetalleOrdenCompraModel selectedProduct { get; set; }
        private double totalGeneral { get; set; }
        private string rutaArchivo;
        public event EventHandler cerrar;
        private int number { get; set; }
        private OrdenesDisponibles OC { get; set; }
        private string estatusOC { get; set; }
        private int IdOC { get; set; }

        private List<ArchivoAdjunto> archivospendientes;

        private string pedimento;



        #endregion

        #region Constructors

        public OrdenesDeCompraVisorRecibeVM(int idOC)
        {
            //this.DateOutPut = DateTime.Today;
            //this.DateDeliver = DateTime.Today;
            //this.DetailOrderListStore = new List<DetalleOrdenCompraModel>();

            //this.TypePayList = new List<TypePay>();
            //this.TypePayList.Add(new TypePay { Id = -1, description = "Seleccionar" });
            //this.TypePayList.AddRange(Repository.GetTypePay());

            //this.SelectedTypePay = -1;

            this.Empleados = Repository.GetEmployees("", ManejadorUbicacion.IdUbicacion);

            ubicaciones = Repository.ObtenerUbicaciones();
            Ubicaciones.Insert(0, new Ubicacion { Id = -1, Nombre = "Selecciona ubicación", Activo = true });
            RaisePropertyChanged(() => Ubicaciones);
            // UbicacionSel = ubicaciones.FirstOrDefault();
            UbicacionSel = ubicaciones.Where(s => s.Id == ManejadorUbicacion.IdUbicacion).FirstOrDefault();
            this.IdOC = idOC;

            //Usuario a partir del logueo
            this.empleado = Empleados.Where(s => s.Id == ManejadorLoguin.idUsuario).FirstOrDefault();

            SetOC(idOC);
            if (detailOrderList != null)
                this.DetailOrderList.CollectionChanged += detailOrderList_CollectionChanged;

        }
        void detailOrderList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            TotalGeneral = detailOrderList == null ? 0 : detailOrderList.Sum(d => d.Monto + d.Tax);
        }

        #endregion

        #region Public Properties

        public string Pedimento
        {
            get { return pedimento; }
            set
            {
                pedimento = value;
                RaisePropertyChanged(() => Pedimento);
            }
        }

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


        public List<Ubicacion> Ubicaciones
        {
            get { return ubicaciones; }
            set
            {
                ubicaciones = value;
                RaisePropertyChanged(() => Ubicaciones);
            }
        }


        public Ubicacion UbicacionSel
        {
            get { return ubicacionSel; }
            set
            {
                ubicacionSel = value;
                RaisePropertyChanged(() => UbicacionSel);
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

        public ICommand AdjuntarCommand
        {
            get { return new RelayCommand(s => OnAdjuntar()); }
        }


        public string RutaArchivo
        {
            get { return rutaArchivo; }
            set
            {
                rutaArchivo = value;
                RaisePropertyChanged(() => RutaArchivo);
            }
        }

        #endregion

        #region Private Methods


        public override void OnAccept()
        {
            try
            {
                //if (string.IsNullOrEmpty(Pedimento))
                //{
                //    MessageBox.Show("Debes ingresar el pedimento un pedimento", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //    return;
                //}

                if (EmpleadoSeleccionado == null)
                {
                    MessageBox.Show("Debes seleccionar un usuario que Recibe", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (ubicacionSel == null)
                {
                    MessageBox.Show("Selecciona una ubicacion.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                if (ubicacionSel.Id == -1)
                {
                    MessageBox.Show("Selecciona una ubicacion.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (MessageBox.Show("¿Realmente deseas Recibir la orden seleccionada?", "Informacion", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    using (var TS = new TransactionScope())
                    {
                        Repository.ActualizarEstadoOrden(OC.IdOrden, 3, EmpleadoSeleccionado.Id, RutaArchivo, this.Pedimento);
                        var date = DateTime.Now;
                       
                        foreach (var item in detailOrderList)
                        {
                            Repository.ActualizarInventario(item.IdProduct, item.Recibido, date, ubicacionSel.Id, item.Id, this.Pedimento, item.Series);
                        }

                        if (archivospendientes != null)
                        {
                            foreach (var arch in archivospendientes)
                            {
                                Repository.InsArchivo(arch);
                            }
                        }
                        TS.Complete();
                    }
                    this.OC = Repository.ObtenerOrdenesDisp(OC.IdOrden, null, null).FirstOrDefault();
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Error", "Error al recibir la orden", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (cerrar != null)
                cerrar(null, new EventArgs());
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            var item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as DetalleOrdenCompraModel;

            if (item == null)
                return;

            this.SelectedProduct = item;
            var agregarseries = new AgregarSeriesComentario();
            agregarseries.DataContext = new AgregarSeriesVM(SelectedProduct);
            agregarseries.ShowDialog();

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

        private void OnAdjuntar()
        {
            AdjuntarDocumentsVM vm = new AdjuntarDocumentsVM(this.IdOC);

            CargarAdjuntos vista = new CargarAdjuntos();
            vista.DataContext = vm;
            vm.Aceptar += ((s, e) => vista.Close());
            vista.ShowDialog();

            this.archivospendientes = vm.Archivos.ToList();

        }
        #endregion

    }
}
