using SGI.Helpers;
using SGI.Stuffs;
using SGI.View;
using SGI.View.Catalogos;
using SGI.View.Contabilidad;
using SGI.View.Correo;
using SGI.View.CreditoYCobranza;
using SGI.View.DialogsInformation;
using SGI.View.Inventarios;
using SGI.View.OC;
using SGI.View.Ventas;
using SGI.ViewModel.Catalogos;
using SGI.ViewModel.Contabilidad;
using SGI.ViewModel.Correo;
using SGI.ViewModel.CreditoYCobranza;
using SGI.ViewModel.DialogsInformation;
using SGI.ViewModel.Inventarios;
using SGI.ViewModel.OC;
using SGI.ViewModel.Ventas;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class MainVM : ViewModelBase
    {
        #region Private Fields

        private string userName;


        private ViewProductsVM products;
        private ProductsViewVM productsView;
        private ProductsOnOfferControlVM productsInOffertVM;
        private ViewOrderBuyVM viewOrderBuyVM;
        private string _dateTimeNow;


        #endregion

        #region Constructors

        /// <summary>
        /// Crea una nueva instancia de la clase MainVM
        /// </summary>
        public MainVM(string user)
        {
            try
            {
                this.userName = ManejadorLoguin.usuario;
                this._dateTimeNow = DateTime.Now.ToString("dddd MM yyyy");    
                this.CreateDirectory();
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
        public ViewOrderBuyVM ViewOrderBuyVM
        {
            get { return viewOrderBuyVM; }
            set
            {
                if (viewOrderBuyVM != value)
                {
                    viewOrderBuyVM = value;
                    RaisePropertyChanged(() => ViewOrderBuyVM);
                }
            }
        }

        public ProductsOnOfferControlVM ProductsInOffertVM
        {
            get { return productsInOffertVM; }
            set
            {
                if (productsInOffertVM != value)
                {
                    productsInOffertVM = value;
                    RaisePropertyChanged(() => ProductsInOffertVM);
                }
            }
        }

        public string UserName
        {
            get { return this.userName; }
        }

        public ProductsViewVM ProductsView
        {
            get { return productsView; }
            set
            {
                if (productsView != value)
                {
                    productsView = value;
                    RaisePropertyChanged(() => ProductsView);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ViewProductsVM Products
        {
            get { return products; }
            set
            {
                if (products != value)
                {
                    products = value;
                    RaisePropertyChanged(() => Products);
                }
            }
        }


        public string DateTimeNow
        {
            get
            {
                return _dateTimeNow;
            }
            set
            {
                _dateTimeNow = value;
                RaisePropertyChanged(() => this.DateTimeNow);
            }
        }


        /// <summary>
        /// Obtiene el comando para abrir la venta para añadir nuevos productos.
        /// </summary>
        public ICommand NewProduct
        {
            get
            {
                return new RelayCommand(s => this.OnNewProduct());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewTrademark
        {
            get
            {
                return new RelayCommand(s => this.OnNewTrademark());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewModel
        {
            get
            {
                return new RelayCommand(s => this.OnNewModel());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogoFamilias
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogoFamilias());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogoSubFamilias
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogoSubFamilias());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogoMarcas
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogoMarcas());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogoColor
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogoColor());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogoMedida
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogoMedida());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewCoins
        {
            get
            {
                return new RelayCommand(s => this.OnNewCoins());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogModel
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogModel());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand CatalogProduct
        {
            get
            {
                return new RelayCommand(s => this.OnCatalogProduct());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewOfferType
        {
            get
            {
                return new RelayCommand(s => this.OnNewOfferType());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewOffer
        {
            get
            {
                return new RelayCommand(s => this.OnNewOffer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewCostConcept
        {
            get
            {
                return new RelayCommand(s => this.OnNewCostConcept());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewProduct
        {
            get
            {
                return new RelayCommand(s => this.OnViewProducts());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        //public ICommand ViewFamilies
        //{
        //    get
        //    {
        //        return new RelayCommand(s => this.OnViewFamilies());
        //    }
        //}

        public ICommand ViewTrademarks
        {
            get
            {
                return new RelayCommand(s => this.OnViewTrademarks());
            }
        }

        public ICommand ViewModels
        {
            get
            {
                return new RelayCommand(s => this.OnViewModels());
            }
        }

        public ICommand ViewCoins
        {
            get
            {
                return new RelayCommand(s => this.OnViewCoins());
            }
        }

        public ICommand NewUSer
        {
            get
            {
                return new RelayCommand(s => this.OnNewUser());
            }
        }

        public ICommand LogOut
        {
            get
            {
                return new RelayCommand(s => this.OnLogOut());
            }
        }

        /// <summary>
        /// Obtiene el comando para abrir la ventana de costo concepto
        /// </summary>
        public ICommand ViewCosteConcept
        {
            get
            {
                return new RelayCommand(s => this.OnViewCosteConcept());
            }
        }

        public ICommand NewProvider
        {
            get
            {
                return new RelayCommand(s => this.OnNewProvider());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewProviders
        {
            get
            {
                return new RelayCommand(s => this.OnViewProviders());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewEmployeesCmd
        {
            get
            {
                return new RelayCommand(s => this.OnViewEmployees());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand NewPaymentCondition
        {
            get
            {
                return new RelayCommand(s => this.OnNewPaymentCondition());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewPaymentCondition
        {
            get
            {
                return new RelayCommand(s => this.OnViewPaymentCondition());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewStatusBuy
        {
            get
            {
                return new RelayCommand(s => this.OnNewStatusBuy());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewStatusBuy
        {
            get
            {
                return new RelayCommand(s => this.OnViewStatusBuy());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand NewOrderBuy
        {
            get
            {
                return new RelayCommand(s => this.OnNewOrderBuy());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewOrderBuy
        {
            get
            {
                return new RelayCommand(s => this.OnViewOrderBuy());
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewProductsInOffer
        {
            get
            {
                return new RelayCommand(s => this.OnViewProductsInOffer());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand ViewOfferType
        {
            get
            {
                return new RelayCommand(s => this.OnViewOfferType());
            }
        }

        /// <summary>
        /// Obtiene el comando para abrir la ventana de ordenes de compra
        /// </summary>
        public ICommand MostarOrdenCompraCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarOrdenesDeCompra());
            }
        }

        public ICommand MostarOrdenesCompra
        {
            get
            {
                return new RelayCommand(s => this.MostrarListaOrdenesDeCompra());
            }
        }

        public ICommand MostrarInventario
        {
            get
            {
                return new RelayCommand(s => this.OnMostrarInventario());
            }
        }

        public ICommand CatalogoProveedores
        {
            get
            {
                return new RelayCommand(s => this.OnMostrarProveedores());
            }
        }

        public ICommand CatalogoUsuarios
        {
            get
            {
                return new RelayCommand(s => this.OnMostrarUsuarios());
            }
        }

        public ICommand Test
        {
            get
            {
                return new RelayCommand(s => this.TestCam());
            }
        }

        public ICommand MostarMovInventarioCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarMovimientosInventario());
            }
        }

        public ICommand RealizarVentaCmd
        {
            get
            {
                return new RelayCommand(s => this.RealizarVenta());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand TransferenciaInvCmd
        {
            get
            {
                return new RelayCommand(s => this.RealizarTransferenciaInv());
            }
        }

        public ICommand ConsultarTransferenciaInvCmd
        {
            get
            {
                return new RelayCommand(s => this.ConsultarTransferenciaInv());
            }
        }

        public ICommand MostrarTipoDeClienteCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarTipoDeCliente());
            }
        }

        public ICommand MostrarClientes
        {
            get
            {
                return new RelayCommand(s => this.OnMostrarClientes());
            }
        }


        public ICommand MostrarAgentesCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarAgentes());
            }
        }

        public ICommand MostrarAlmacenCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarAlmacen());
            }
        }

        public ICommand MostrarVisorAdeudosCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarVisorAdeudos());
            }
        }

        public ICommand ViewChecadasCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarChecadas());
            }
        }

        private void MostrarVisorAdeudos()
        {
            try
            {
                VisorDeAbonos va = new VisorDeAbonos();
                va.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                va.DataContext = new VisorDeAbonosVM();
                va.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void TestCam()
        {
            var tomarfoto = new foto();
            tomarfoto.ShowDialog();
        }

        public ICommand ConceptosDeImportacionCmd
        {
            get
            {
                return new RelayCommand(s => this.ConceptosDeImportacion());
            }
        }

        public ICommand MostrarPaqueteriasmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarPaqueterias());
            }
        }

        public ICommand MostrarOrdenHomologadaCmd
        {
            get
            {
                return new RelayCommand(s => this.MostrarOrdenHomologada());
            }
        }

        public ICommand ImportarProductosDesdeExcelCmd
        {
            get
            {
                return new RelayCommand(s => ImportarProductosDesdeExcelFn());
            }
        }

        public ICommand NotificacionesPorCorreoCmd
        {
            get
            {
                return new RelayCommand(s => NotificacionesPorCorreo());
            }
        }

        public ICommand VisorVentasCmd
        {
            get
            {
                return new RelayCommand(s => MostrarVisorVentas());
            }
        }

        public ICommand VisorAbonosCmd
        {
            get
            {
                return new RelayCommand(s => MostrarVisorAbonos());
            }
        }

        #endregion

        #region Private Methods

        private void MostrarVisorAbonos()
        {
            try
            {
                Abonos wnd = new Abonos();
                wnd.DataContext = new AbonosVM();
                wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                wnd.Show();
            }
            catch (Exception ex)
            {

            }
        }


        private void MostrarVisorVentas()
        {
            try
            {
                VisorVentas wnd = new VisorVentas();
                wnd.DataContext = new VisorVentasVM();
                wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                wnd.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void NotificacionesPorCorreo()
        {
            try
            {
                NotificacionDeCorreo wnd = new NotificacionDeCorreo();
                wnd.DataContext = new NotificacionDeCorreoVM();
                wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                wnd.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void ImportarProductosDesdeExcelFn()
        {
            try
            {
                ImportarProductosDesdeExcel wnd = new ImportarProductosDesdeExcel();
                wnd.DataContext = new ImportarProductosDesdeExcelVM();
                wnd.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                wnd.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarOrdenHomologada()
        {
            try
            {
                OrdenCompraHomologada win = new OrdenCompraHomologada();
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.DataContext = new OrdenCompraHomologadaVM();
                win.Show();
            }
            catch (Exception ex)
            {

            }
        }


        private void MostrarPaqueterias()
        {
            try
            {
                CatalogoPaqueterias cp = new CatalogoPaqueterias();
                cp.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                cp.DataContext = new CatalogoPaqueteriasVM();
                cp.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void ConceptosDeImportacion()
        {
            try
            {
                ConceptosDeImportacion win = new ConceptosDeImportacion();
                win.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                win.DataContext = new CatalogoConceptosImportacionVM();
                win.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void RealizarTransferenciaInv()
        {
            try
            {
                TransferenciaDeInventario ti = new TransferenciaDeInventario();
                ti.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                ti.DataContext = new TransferenciaDeInventariosVM();
                //rv.DataContext = new MovInventarioVM();
                ti.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void ConsultarTransferenciaInv()
        {
            try
            {
                VisorTraspasos ti = new VisorTraspasos();
                ti.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                ti.DataContext = new VisorTraspaso();
                //rv.DataContext = new MovInventarioVM();
                ti.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void RealizarVenta()
        {
            try
            {
                RealizarVenta rv = new RealizarVenta();
                rv.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                rv.DataContext = new RealizarVentaVM();
                rv.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void MostrarMovimientosInventario()
        {
            try
            {
                MovimientosDeInventario mi = new MovimientosDeInventario();
                mi.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                mi.DataContext = new MovInventarioVM();
                mi.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void CreateDirectory()
        {
            try
            {
                string directoryImages = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SGI/Images/";
                string directoryReports = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/SGI/Reports/";

                if (!Directory.Exists(directoryImages))
                {
                    Directory.CreateDirectory(directoryImages);
                }

                if (!Directory.Exists(directoryReports))
                {
                    Directory.CreateDirectory(directoryReports);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarOrdenesDeCompra()
        {
            try
            {
                OrdenesDeCompra oc = new OrdenesDeCompra();
                var vm = new OrdenesDeCompraVM(null);
                oc.DataContext = vm;
                vm.cerrar += ((s, e) => oc.Close());
                oc.Show();

            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarListaOrdenesDeCompra()
        {
            try
            {
                OrdenesDeCompraVisor oc = new OrdenesDeCompraVisor();
                oc.DataContext = new OrdenesDeCompraVisorVM();
                oc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnMostrarInventario()
        {
            try
            {
                InventarioVisor oc = new InventarioVisor();
                oc.DataContext = new InventarioVisorVM();
                oc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnViewOfferType()
        {
            try
            {
                ViewOfferType view = new ViewOfferType();
                view.DataContext = new ViewOfferTypeVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnViewProductsInOffer()
        {
            try
            {
                ProductsOnOfferWindow view = new ProductsOnOfferWindow();
                view.DataContext = new ProductsOnOfferWindowVM(new ProductsOnOfferControlVM());
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnViewOrderBuy()
        {
            try
            {
                OrderBuyWindow view = new OrderBuyWindow();
                OrderBuyWindowVM vm = new OrderBuyWindowVM(new ViewOrderBuyVM());
                view.DataContext = vm;
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnNewOrderBuy()
        {
            try
            {

                NewOrderBuyView view = new NewOrderBuyView();
                view.DataContext = new NewOrderBuyVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnViewStatusBuy()
        {
            try
            {
                ViewStatusBuy view = new ViewStatusBuy();
                view.DataContext = new ViewStatusBuyVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        public void OnNewStatusBuy()
        {
            try
            {
                NewStatusBuyView view = new NewStatusBuyView();
                view.DataContext = new NewStatusBuyVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnViewPaymentCondition()
        {
            try
            {
                ViewPaymentConditions view = new ViewPaymentConditions();
                view.DataContext = new ViewPaymentConditionVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void OnNewPaymentCondition()
        {
            try
            {
                NewPaymentConditionView view = new NewPaymentConditionView();
                view.DataContext = new NewPaymentConditionVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        ///// <summary>
        ///// 
        ///// </summary>
        //private void OnNewEmployee()
        //{
        //    try
        //    {
        //        NewEmployee ne = new NewEmployee();
        //        ne.DataContext = new NewEmployeeVM();
        //        ne.Show();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}



        /// <summary>
        /// Abre venta de empleados
        /// </summary>
        private void OnViewEmployees()
        {
            try
            {
                EmpleadosView empView = new EmpleadosView();
                //EmployeeWindow ew = new EmployeeWindow();
                empView.DataContext = new EmpleadosViewModel();
                empView.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarChecadas()
        {
            try
            {
                ChecadasView cv = new ChecadasView();
                cv.DataContext = new ChecadasViewModel();
                cv.Show();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewProviders()
        {
            try
            {
                ProvidersWindow pw = new ProvidersWindow();
                pw.DataContext = new ProvidersWindowVM(new ViewProvidersVM());
                pw.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewProvider()
        {
            try
            {
                NewProviders view = new NewProviders();
                view.DataContext = new NewProviderVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewCosteConcept()
        {
            try
            {

                ViewCosteConcept view = new ViewCosteConcept();
                view.DataContext = new ViewCostConceptVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnLogOut()
        {
            try
            {
                Loggin lg = new Loggin();
                lg.DataContext = new LoginVM();
                lg.Show();
                var x = this.thisWindow;
                x.Close();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnNewUser()
        {
            try
            {
                NewUserView view = new NewUserView();
                view.DataContext = new NewUserViewVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewCoins()
        {
            try
            {
                ViewCoins view = new ViewCoins();
                view.DataContext = new ViewCoinsVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnViewModels()
        {
            try
            {
                ViewModels view = new ViewModels();
                view.DataContext = new ViewModelsVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnViewTrademarks()
        {
            try
            {
                ViewTrademarks view = new ViewTrademarks();
                view.DataContext = new ViewTrademarksVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Abre la ventana para agregar un nuevo concepto de costo
        /// </summary>
        private void OnNewCostConcept()
        {
            try
            {
                NewCostConcept view = new NewCostConcept();
                view.DataContext = new NewCostConceptVM();
                view.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewOffer()
        {
            try
            {
                NewOfferPrice nOffer = new NewOfferPrice();
                nOffer.DataContext = new NewOfferPriceVM();
                nOffer.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        //private void OnViewFamilies()
        //{
        //    try
        //    {
        //        ViewFamilies vf = new ViewFamilies();
        //        vf.DataContext = new ViewFamilyVM();
        //        vf.ShowDialog();
        //    }
        //    catch (Exception ex)
        //    {

        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        private void OnViewProducts()
        {
            try
            {
                ViewProducts vProduct = new ViewProducts();
                vProduct.DataContext = new ViewProductsVM(new ProductsViewVM());
                vProduct.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewOfferType()
        {
            try
            {
                NewOfferTypeView nOffer = new NewOfferTypeView();
                nOffer.DataContext = new NewOfferTypeVM();
                nOffer.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewCoins()
        {
            try
            {
                NewCoinsView mCoin = new NewCoinsView();
                mCoin.DataContext = new NewCoinsVM();
                mCoin.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogModel()
        {
            try
            {
                CatalogModelView mModel = new CatalogModelView();
                mModel.DataContext = new CatalogModelVM();
                mModel.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogProduct()
        {
            try
            {
                CatalogoProductos cProduct = new CatalogoProductos();
                cProduct.DataContext = new CatalogoProductosVM();
                cProduct.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnNewModel()
        {
            try
            {
                NewModelsView mView = new NewModelsView();
                mView.DataContext = new NewModelsVM();
                mView.Show();
            }
            catch (Exception ex)
            {

            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogoFamilias()
        {
            try
            {
                CatalogoFamiliasView mCF = new CatalogoFamiliasView();
                mCF.DataContext = new CatalogoFamiliasViewModel();
                mCF.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogoSubFamilias()
        {
            try
            {
                CatalogoSubFamiliasView mCSF = new CatalogoSubFamiliasView();
                mCSF.DataContext = new CatalogoSubFamiliasViewModel();
                mCSF.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogoMarcas()
        {
            try
            {
                CatalogoMarcasView mM = new CatalogoMarcasView();
                mM.DataContext = new CatalogoMarcasViewModel();
                mM.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogoColor()
        {
            try
            {
                CatalogoColorView mCC = new CatalogoColorView();
                mCC.DataContext = new CatalogoColorViewModel();
                mCC.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnCatalogoMedida()
        {
            try
            {
                CatalogoMedidaView mCM = new CatalogoMedidaView();
                mCM.DataContext = new CatalogoMedidaViewModel();
                mCM.Show();
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void OnNewTrademark()
        {
            try
            {
                NewTrademarkView tView = new NewTrademarkView();
                tView.DataContext = new NewTrademarkVM();
                tView.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnMostrarProveedores()
        {
            var proveedores = new ManejoProveedores();
            proveedores.DataContext = new CatalogoProveedoresVM();
            proveedores.Show();
        }

        private void OnMostrarUsuarios()
        {
            var usuarios = new CatalogoUsuarios();
            usuarios.DataContext = new CatalogoUsuariosVM();
            usuarios.Show();
        }
        /// <summary>
        /// 
        /// </summary>
        public override void OnClose()
        {
            try
            {
                Process.GetCurrentProcess().Kill();
            }
            catch (Exception ex)
            {

            }
        }



        /// <summary>
        /// Abre la ventana para añadir un nuevo producto
        /// </summary>
        private void OnNewProduct()
        {
            try
            {
                //NewProduct newProduct = new NewProduct();
                //var viewModel = new NewProductVM();
                //viewModel.OnRefreshProducts += OnViewModelOnRefreshProducts;
                //newProduct.DataContext = viewModel;

                //newProduct.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarTipoDeCliente()
        {
            try
            {
                CatalogoTipoDeCliente tc = new CatalogoTipoDeCliente();
                tc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tc.DataContext = new CatalogoTipoDeClienteVM();
                tc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void OnMostrarClientes()
        {
            try
            {
                CatalogoClienteView tc = new CatalogoClienteView();
                //CatalogoClientes tc = new CatalogoClientes();
                tc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tc.DataContext = new CatalogoClienteViewModel();
                tc.Show();
            }
            catch (Exception ex)
            {

            }
        }


        private void MostrarAgentes()
        {
            try
            {
                CatalogoAgenteAduanal tc = new CatalogoAgenteAduanal();
                tc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tc.DataContext = new CatalogoAgenteAduanalVM();
                tc.Show();
            }
            catch (Exception ex)
            {

            }
        }

        private void MostrarAlmacen()
        {
            try
            {
                var tc = new CatalogoAlmacen();
                tc.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                tc.DataContext = new CatalogoAlmacenVM();
                tc.Show();
            }
            catch (Exception ex)
            {

            }
        }


        private void OnViewModelOnRefreshProducts(object sender, EventArgs e)
        {
            if (ProductsView != null)
            {
                ProductsView.Refresh.Execute(null);
            }
        }

        #endregion


    }
}
