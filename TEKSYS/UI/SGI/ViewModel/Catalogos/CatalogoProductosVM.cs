using Microsoft.Win32;
using SGI.Enumeration;
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
using System.Collections.ObjectModel;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using SGI.View.Catalogos;
using SGI.Helpers;

namespace SGI.ViewModel.Catalogos
{
    public class CatalogoProductosVM : ViewModelBase
    {
        #region Private Fields

        //private CatalogModelVM catalogModelVMObj;

        private int id;
        private string nameText;
        private string modelName;
        private string familyName;
        private string tradeMarkName;
        private string measurementName;
        private string colorName;
        private string providerKey;
        private string tecknobike;
        private string imagen;
        private double wholesalePrice;
        private double mediumWholesalePrice;
        private double publicPrice;
        private double cost;
        private string description;
        private bool internet;
        private double precioDistribuidor;
        private double addValorem;
        private double igi;
        private double impuesto3;
        private int idSearchProvider;
        
        private List<Product> productsList;
        private List<Product> productsListStore;

        private List<Models> listaDeModelos;
        private List<Measure> listaDeMedidas;
        private List<Brand> listaMarcas;
        private List<Color> listaColor;
        private List<SubFamilies> listaSubFamilias;

        private string nameSearch;
        private string descriptionSearch;

        private int idModeloSeleccionado;
        private int idMedidaSeleccionado;
        private int idMarcaSeleccionada;
        private int idColorSeleccionado;
        private int idSubFamiliasSeleccionado;

        private int idFamily;
        private int idTradeMark;

        private int idColor;

        private new Operation operationType;
        private bool modoEdicion;

        private System.Windows.Visibility isModeSearch;
        private Product selectedProduct;

        private Provider selectedProvider;
        private List<Provider> providerList;

        public List<Product> ProductosImportados { get; private set; }
        #endregion

        #region Public Fields

        public event EventHandler OnAddProduct;

        private Visibility visibilityCantidad;

        private int selectedTab;

        #endregion

        #region Constructors

        public CatalogoProductosVM()
        {
            try
            {
                this.ListaDeModelos = new List<Models>();
                this.ListaDeModelos.Add(new Models { Id = -1, Model = "Seleccionar" });
                this.ListaDeModelos.AddRange(Repository.GetModels(string.Empty));
                this.IdModeloSeleccionado = -1;

                this.ListaDeMedidas = new List<Measure>();
                this.ListaDeMedidas.Add(new Measure { Id = -1, MedidaString = "Seleccionar" });
                this.ListaDeMedidas.AddRange(Repository.GetMedidas(string.Empty, string.Empty));
                this.IdMedidaSeleccionado = -1;

                this.ListaMarcas = new List<Brand>();
                this.ListaMarcas.Add(new Brand { Id = -1, Marca = "Seleccionar" });
                this.ListaMarcas.AddRange(Repository.GetMarcas(string.Empty));
                this.IdMarcaSeleccionada = -1;

                this.ListaColor = new List<Color>();
                this.ListaColor.Add(new Color { Id = -1, ColorString = "Seleccionar" });
                this.ListaColor.AddRange(Repository.GetColores(string.Empty, string.Empty));
                this.IdColorSeleccionado = -1;

                this.ListaSubFamilias = new List<SubFamilies>();
                this.ListaSubFamilias.Add(new SubFamilies { Id = -1, SubFamilyName = "Seleccionar" });
                this.ListaSubFamilias.AddRange(Repository.GetSubFamilias(-1, string.Empty, string.Empty));
                this.IdSubFamiliasSeleccionado = -1;

                this.ProviderList = new List<Provider>();
                this.ProviderList.Add(new Provider { Id = -1, Name = "Seleccionar", CompanyName = "Seleccionar"});
                this.ProviderList.AddRange(Repository.GetSuppliers(-1));
                this.SelectedProvider = ProviderList.FirstOrDefault();

                this.OperationType = Enumeration.Operation.Create;
                this.idSearchProvider = -1;
                this.VisibilityCantidad = Visibility.Hidden;
                this.SelectedTab = 0;
                OnRefresh();
            }
            catch (Exception)
            {

            }
        }

        public CatalogoProductosVM(bool isModeSearchValue, int idsearchProvider)
        {
            try
            {
                idSearchProvider = idsearchProvider;
                if (isModeSearchValue)
                {
                    IsModeSearch = System.Windows.Visibility.Visible;                    
                }
                else
                {
                    IsModeSearch = System.Windows.Visibility.Collapsed;
                }

                this.OperationType = Enumeration.Operation.Create;
                this.VisibilityCantidad = Visibility.Visible;
                this.SelectedTab = 0;
                OnRefresh();
                ProductosImportados = new List<Product>();
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Obtiene o establece el Id de la medida seleccionada
        /// </summary>
        public int IdMedidaSeleccionado
        {
            get { return idMedidaSeleccionado; }
            set
            {
                if (idMedidaSeleccionado != value)
                {
                    idMedidaSeleccionado = value;
                    RaisePropertyChanged(() => IdMedidaSeleccionado);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdSubFamiliasSeleccionado
        {
            get { return idSubFamiliasSeleccionado; }
            set
            {
                if (idSubFamiliasSeleccionado != value)
                {
                    idSubFamiliasSeleccionado = value;
                    RaisePropertyChanged(() => IdSubFamiliasSeleccionado);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Color> ListaColor
        {
            get { return this.listaColor; }
            set
            {
                if(this.listaColor != value)
                {
                    this.listaColor = value;
                    RaisePropertyChanged(() => ListaColor);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<SubFamilies> ListaSubFamilias
        {
            get { return this.listaSubFamilias; }
            set
            {
                if (this.listaSubFamilias != value)
                {
                    this.listaSubFamilias = value;
                    RaisePropertyChanged(() => ListaSubFamilias);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Brand> ListaMarcas
        {
            get { return listaMarcas; }
            set
            {
                if (listaMarcas != value)
                {
                    listaMarcas = value;
                    RaisePropertyChanged(() => ListaMarcas);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdColorSeleccionado
        {
            get
            {
                return idColorSeleccionado;
            }
            set
            {
                if (idColorSeleccionado != value)
                {
                    idColorSeleccionado = value;
                    RaisePropertyChanged(() => IdColorSeleccionado);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int IdMarcaSeleccionada
        {
            get { return idMarcaSeleccionada; }
            set
            {
                if (idMarcaSeleccionada != value)
                {
                    idMarcaSeleccionada = value;
                    RaisePropertyChanged(() => IdMarcaSeleccionada);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de medidas
        /// </summary>
        public List<Measure> ListaDeMedidas
        {
            get { return listaDeMedidas; }
            set
            {
                if (listaDeMedidas != value)
                {
                    listaDeMedidas = value;
                    RaisePropertyChanged(() => ListaDeMedidas);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el Id del modelo seleccionado
        /// </summary>
        public int IdModeloSeleccionado
        {
            get { return idModeloSeleccionado; }
            set
            {
                if (idModeloSeleccionado != value)
                {
                    idModeloSeleccionado = value;
                    RaisePropertyChanged(() => IdModeloSeleccionado);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de modelos
        /// </summary>
        public List<Models> ListaDeModelos
        {
            get { return listaDeModelos; }
            set
            {
                listaDeModelos = value;
                RaisePropertyChanged(() => ListaDeModelos);
            }
        }

        public List<Provider> ProviderList
        {
            get { return this.providerList; }
            set
            {
                this.providerList = value;
                RaisePropertyChanged(() => ProviderList);

            }
        }

        public Provider SelectedProvider
        {
            get { return this.selectedProvider; }
            set
            {
                this.selectedProvider = value;
                RaisePropertyChanged(() => SelectedProvider);

            }
        }

        public int Id
        {
            get { return id; }
            set
            {
                this.id = value;
                RaisePropertyChanged(() => Id);
            }
        }

        public string NameText
        {
            get { return this.nameText; }
            set
            {
                this.nameText = value;
                RaisePropertyChanged(() => NameText);
            }
        }

        public string ModelName
        {
            get { return this.modelName; }
            set
            {
                this.modelName = value;
                RaisePropertyChanged(() => ModelName);
            }
        }

        public string FamilyName
        {
            get { return this.familyName; }
            set
            {
                this.familyName = value;
                RaisePropertyChanged(() => FamilyName);
            }
        }

        public string TradeMarkName
        {
            get { return this.tradeMarkName; }
            set
            {
                this.tradeMarkName = value;
                RaisePropertyChanged(() => TradeMarkName);
            }
        }

        public string MeasurementName
        {
            get { return this.measurementName; }
            set
            {
                this.measurementName = value;
                RaisePropertyChanged(() => MeasurementName);
            }
        }

        public string ColorName
        {
            get { return this.colorName; }
            set
            {
                this.colorName = value;
                RaisePropertyChanged(() => ColorName);
            }
        }

        public string ProviderKey
        {
            get { return this.providerKey; }
            set
            {
                this.providerKey = value;
                RaisePropertyChanged(() => ProviderKey);
            }
        }

        public string Tecknobike
        {
            get { return this.tecknobike; }
            set
            {
                this.tecknobike = value;
                RaisePropertyChanged(() => Tecknobike);
            }
        }

        public string Imagen
        {
            get { return this.imagen; }
            set
            {
                this.imagen = value;
                RaisePropertyChanged(() => Imagen);
            }
        }

        public double WholesalePrice
        {
            get { return this.wholesalePrice; }
            set
            {
                this.wholesalePrice = value;
                RaisePropertyChanged(() => WholesalePrice);
            }
        }

        public double MediumWholesalePrice
        {
            get { return this.mediumWholesalePrice; }
            set
            {
                this.mediumWholesalePrice = value;
                RaisePropertyChanged(() => MediumWholesalePrice);
            }
        }

        public double PublicPrice
        {
            get { return this.publicPrice; }
            set
            {
                this.publicPrice = value;
                RaisePropertyChanged(() => PublicPrice);
            }
        }

        public double Cost
        {
            get { return this.cost; }
            set
            {
                this.cost = value;
                RaisePropertyChanged(() => Cost);
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

        public bool Internet
        {
            get { return this.internet; }
            set
            {
                this.internet = value;
                RaisePropertyChanged(() => Internet);
            }
        }


        public double AddValorem
        {
            get { return addValorem; }
            set 
            { 
                addValorem = value;
                RaisePropertyChanged(() => AddValorem);
            }
        }

        public double IGI
        {
            get { return igi; }
            set 
            {
                igi = value;
                RaisePropertyChanged(() => IGI);
            }
        }


        public double Impuesto3
        {
            get { return impuesto3; }
            set 
            {
                impuesto3 = value;
                RaisePropertyChanged(() => Impuesto3);
            }
        }

        public double PrecioDistribuidor
        {
            get { return precioDistribuidor; }
            set 
            {
                precioDistribuidor = value;
                RaisePropertyChanged(() => PrecioDistribuidor);
            }
        }

        public List<Product> ProductsList
        {
            get { return this.productsList; }
            set
            {
                this.productsList = value;
                RaisePropertyChanged(() => ProductsList);
            }
        }

        public string NameSearch
        {
            get { return this.nameSearch; }
            set
            {
                this.nameSearch = value;
                RaisePropertyChanged(() => NameSearch);
                SearchAsync();
            }
        }

        public string DescriptionSearch
        {
            get { return this.descriptionSearch; }
            set
            {
                this.descriptionSearch = value;
                RaisePropertyChanged(() => DescriptionSearch);
                SearchAsync();
            }
        }

        public bool ModoEdicion
        {
            get { return this.modoEdicion; }
            set
            {
                this.modoEdicion = value;
                RaisePropertyChanged(() => ModoEdicion);
            }
        }

        public new Operation OperationType
        {
            get { return this.operationType; }
            set
            {
                this.operationType = value;
                RaisePropertyChanged(() => OperationType);
                this.ModoEdicion = (value == Enumeration.Operation.Update);
            }
        }

        public ICommand SearchModel
        {
            get
            {
                return new RelayCommand(s => OnSearchModelo());
            }
        }

        public ICommand SearchFamily
        {
            get
            {
                return new RelayCommand(s => OnSearchFamily());
            }
        }

        public ICommand SearchTradeMark
        {
            get
            {
                return new RelayCommand(s => OnSearchTradeMark());
            }
        }

        public ICommand SearchMeasurement
        {
            get
            {
                return new RelayCommand(s => OnSearchMeasurement());
            }
        }

        public ICommand SearchColors
        {
            get
            {
                return new RelayCommand(s => OnSearchColors());
            }
        }

        public ICommand DoubleClickItem
        {
            get
            {
                return new RelayCommand(OnSelectedItemGridDoubleClick);
            }
        }

        public ICommand ImportarProductos
        {
            get
            {
                return new RelayCommand(OnImportarProductos);
            }
        }

        public ICommand AgregarImportados
        {
            get
            {
                return new RelayCommand(OnAgregarImportados);
            }
        }

        public System.Windows.Visibility IsModeSearch
        {
            get { return this.isModeSearch; }
            set
            {
                this.isModeSearch = value;
                RaisePropertyChanged(() => IsModeSearch);
            }
        }

        public Product SelectedProduct
        {
            get { return this.selectedProduct; }
            set
            {
                this.selectedProduct = value;
                RaisePropertyChanged(() => SelectedProduct);
            }
        }


        public Visibility VisibilityCantidad
        {
            get { return visibilityCantidad; }
            set
            { 
                visibilityCantidad = value;
                RaisePropertyChanged(() => VisibilityCantidad);
            }
        }


        public int SelectedTab
        {
            get { return selectedTab; }
            set 
            { 
                selectedTab = value;
                RaisePropertyChanged(() => SelectedTab);
            }
        }

        /// <summary>
        /// Obtiene el comando para buscar una imagen.
        /// </summary>

        public ICommand BuscarImagen
        {
            get
            {
                return new RelayCommand(s => OnBuscarImagen());
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
                    var fileName = "CatalogoProductos.xls";

                    var dataTable = ExportToExcel.ListToDataTable(this.ProductsList);

                    ExportToExcel.ExportDocument(dataTable, "Catalogo de Productos", pathFile + "/" + fileName);

                    System.Windows.MessageBox.Show("Archivo exportado correctamente");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al exportar archivo de excel");
            }
        }


        private void OnBuscarImagen()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                if (openFileDialog.ShowDialog() == true)
                {
                    Imagen = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {

            }
        }
        public async void SearchAsync()
        {
            try
            {
                this.ProductsList = await Task.Run(() => this.GetList());
            }
            catch (Exception ex)
            {

            }
        }

        private async Task<List<Product>> GetList()
        {
            List<Product> lst = new List<Product>();

            try
            {
                if(ProductosImportados != null)
                {
                    var productosmodificados = ProductsList.Where(d => d.IsEdited);
                    foreach(var prodmodif in productosmodificados)
                    {
                        var existeprod = ProductosImportados.FirstOrDefault(d=> d.Id == prodmodif.Id);
                        if(existeprod != null)
                        {
                            existeprod.Cantidad = prodmodif.Cantidad;
                        }
                        else
                        {
                            ProductosImportados.Add(prodmodif);
                        }
                    }
                }


                var aux = this.productsListStore;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.NameSearch) ? s.Name.ToUpper().Contains(this.NameSearch.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.DescriptionSearch) ? s.Description.ToUpper().Contains(this.DescriptionSearch.ToUpper()) : true))

                         )
                    ).ToList();

                return lst;
            }
            catch (Exception ex)
            {
                return lst;
            }
        }

        ///// <summary>
        ///// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        ///// </summary>
        public override void OnAccept()
        {

            MessageBoxResult resultAlert = MessageBoxResult.OK;

            if (string.IsNullOrEmpty(this.NameText)
                    || string.IsNullOrEmpty(this.ProviderKey) || string.IsNullOrEmpty(this.Tecknobike) || string.IsNullOrEmpty(this.Imagen))
            {
                MessageBox.Show("Falta algun campo por llenar", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            //if (this.WholesalePrice <= 0 || this.MediumWholesalePrice <= 0 || this.PublicPrice <= 0 || this.Cost <= 0)
            if (this.PublicPrice <= 0)
            {
                MessageBox.Show("Las cantidades deben ser mayores que cero", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.SelectedProvider.Id < 0)
            {
                MessageBox.Show("Debes seleccionar un proveedor", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                Product productInfo = new Product();
                productInfo.Name = this.NameText;
                productInfo.IdModel = this.IdModeloSeleccionado;
                productInfo.IdFamily = this.idFamily;
                productInfo.IdSubFamily = this.IdSubFamiliasSeleccionado;
                productInfo.IdTrademark = this.IdMarcaSeleccionada;
                productInfo.IdMeasure = this.IdMedidaSeleccionado;
                productInfo.IdColor = this.IdColorSeleccionado;
                productInfo.CveProvider = this.ProviderKey;
                productInfo.CveTeknobike = this.Tecknobike;
                productInfo.Image = this.Imagen;
                productInfo.Description = this.Description;
                productInfo.Wholesale = this.WholesalePrice;
                productInfo.MediumWholesale = this.MediumWholesalePrice;
                productInfo.Cost = this.Cost;
                productInfo.PublicPrice = this.PublicPrice;
                productInfo.Internet = this.Internet;
                productInfo.Active = true;
                productInfo.PrecioDistribuidor = this.PrecioDistribuidor;
                productInfo.AddValorioum = this.addValorem;
                productInfo.IGI = this.igi;
                productInfo.Impuesto3 = this.Impuesto3;
                productInfo.IdProvider = this.SelectedProvider.Id;

                if (this.OperationType == Enumeration.Operation.Create)
                {

                    var result = Repository.InsertProducto(productInfo, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else if (this.OperationType == Enumeration.Operation.Update)
                {
                    productInfo.Id = this.Id;
                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de actualizar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.UpdateProducto(productInfo, ref error, ref errorMessage);

                    if (result)
                    {
                        MessageBox.Show("Registro modificado con exito ", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error  " + errorMessage, "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error", "Fallo transaccion", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (resultAlert == MessageBoxResult.OK)
                {
                    OnClean();
                    Task.Run(() => this.OnRefresh());
                }
            }
        }

        public override void OnClean()
        {
            this.OperationType = Enumeration.Operation.Create;

            this.NameText = string.Empty;
            this.IdModeloSeleccionado = -1;
            this.IdColorSeleccionado = -1;
            this.idFamily = -1;
            this.idTradeMark = -1;
            this.IdMedidaSeleccionado = -1;
            this.IdSubFamiliasSeleccionado = -1;
            this.IdMarcaSeleccionada = -1;
            this.idColor = -1;
            this.SelectedProvider = this.ProviderList.FirstOrDefault();
            this.ProviderKey = string.Empty;
            this.Tecknobike = string.Empty;
            this.Imagen = string.Empty;
            this.Description = string.Empty;
            this.WholesalePrice = 0;
            this.MediumWholesalePrice = 0;
            this.Cost = 0;
            this.PublicPrice = 0;
            this.ModelName = string.Empty;
            this.TradeMarkName = string.Empty;
            this.ColorName = string.Empty;
            this.FamilyName = string.Empty;
            this.MeasurementName = string.Empty;
            this.NameSearch = string.Empty;
            this.DescriptionSearch = string.Empty;
            this.Internet = false;
            this.PrecioDistribuidor = 0;
            this.AddValorem = 0;
            this.IGI = 0;
            this.Impuesto3 = 0;
            this.SelectedProvider = ProviderList.FirstOrDefault();
        }

        private void OnRefresh()
        {
            try
            {
                if (idSearchProvider != -1)
                {
                    this.ProductsList = Repository.GetProducts(string.Empty, string.Empty, SGI.Properties.Settings.Default.Matriz).Where(d => d.IdProvider == idSearchProvider).ToList();
                    this.productsListStore = this.ProductsList;
                }
                else
                {
                    this.ProductsList = Repository.GetProducts(string.Empty, string.Empty, SGI.Properties.Settings.Default.Matriz);
                    this.productsListStore = this.ProductsList;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnSelectedItemGridClick(object parameters)
        {
            Product item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Product;

            if (item == null)
                return;

            try
            {

                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {
                    this.SelectedProduct = item;

                    //if (this.OnAddProduct != null)
                    //{
                    //    this.OnAddProduct(this, null);
                    //}
                }
                else
                {

                    this.OperationType = Enumeration.Operation.Update;

                    this.Id = item.Id;
                    this.NameText = item.Name;
                    this.IdModeloSeleccionado = item.IdModel;
                    this.IdColorSeleccionado = item.IdColor;
                    this.ModelName = item.SelectedModel;
                    this.idTradeMark = item.IdTrademark;
                    this.TradeMarkName = item.SelectedTrademark;
                    this.idColor = item.IdColor;
                    this.ColorName = item.ColorName;
                    this.IdMedidaSeleccionado = item.IdMeasure;
                    this.IdMarcaSeleccionada = item.IdTrademark;
                    this.MeasurementName = item.MeasureName;
                    this.idFamily = item.IdFamily;
                    this.FamilyName = item.SelectedFamily;
                    this.ProviderKey = item.CveProvider;
                    this.Tecknobike = item.CveTeknobike;
                    this.Imagen = item.Image;
                    this.WholesalePrice = item.Wholesale;
                    this.MediumWholesalePrice = item.MediumWholesale;
                    this.PublicPrice = item.PublicPrice;
                    this.Cost = item.Cost;
                    this.Internet = item.Internet;
                    this.Description = item.Description;
                    this.IdSubFamiliasSeleccionado = item.IdSubFamily;
                    this.PrecioDistribuidor = item.PrecioDistribuidor;
                    this.AddValorem = item.AddValorioum;
                    this.IGI = item.IGI;
                    this.Impuesto3 = item.Impuesto3;
                    this.SelectedProvider = ProviderList.FirstOrDefault(p=> p.Id == item.IdProvider);

                }

            }
            catch (Exception ex)
            {

            }
        }

        public void OnSelectedItemGridDoubleClick(object parameters)
        {
            Product item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Product;

            if (item == null)
                return;

            try
            {
                if (IsModeSearch == System.Windows.Visibility.Collapsed)
                {
                    this.SelectedProduct = item;

                    if (this.OnAddProduct != null)
                    {
                        this.OnAddProduct(this, null);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            MessageBoxResult resultAlert = MessageBoxResult.OK;

            string msg = string.Empty;
            try
            {
                if (this.OperationType == Enumeration.Operation.Update)
                {
                    resultAlert = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Advertencia", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                    if (resultAlert != MessageBoxResult.OK)
                        return;

                    var result = Repository.DeleteProducto((int)param, ref msg);

                    if (result)
                    {
                        MessageBox.Show("Registro eliminado con exito ", "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        MessageBox.Show("Error  " + msg, "Registro eliminado", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
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
                    OnClean();
                    Task.Run(() => this.OnRefresh());
                }
            }
        }

        public override void OnRefreshSearch()
        {
            CleanSearch();
            Task.Run(() => this.OnRefresh());
        }

        private void CleanSearch()
        {
            this.NameSearch = string.Empty;
            this.DescriptionSearch = string.Empty;
        }

        private void OnSearchModelo()
        {
            try
            {
                CatalogModelView view = new CatalogModelView();
                view.Width = 500;
                view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                view.DataContext = new CatalogModelVM(false);
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.ModelName = ((CatalogModelVM)view.DataContext).SelectedModel.Model;
                    this.IdModeloSeleccionado = ((CatalogModelVM)view.DataContext).SelectedModel.Id;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchFamily()
        {
            try
            {
                CatalogoFamiliasView view = new CatalogoFamiliasView();
                view.Width = 500;
                view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoFamiliasViewModel familyVM = new CatalogoFamiliasViewModel(false);
                //familyVM.OnAddFamily += ((s, e) => view.Close());
                view.DataContext = familyVM;
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.FamilyName = ((CatalogoFamiliasViewModel)view.DataContext).SelectedFamily.FamilyName;
                    this.idFamily = ((CatalogoFamiliasViewModel)view.DataContext).SelectedFamily.Id;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchTradeMark()
        {
            try
            {
                CatalogoMarcasView view = new CatalogoMarcasView();
                view.Width = 500;
                view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoMarcasViewModel tradeMarkVM = new CatalogoMarcasViewModel(false);
                //tradeMarkVM.OnAddTradeMark += ((s, e) => view.Close());
                view.DataContext = tradeMarkVM;
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.TradeMarkName = ((CatalogoMarcasViewModel)view.DataContext).SelectedTradeMark.Marca;
                    this.idTradeMark = ((CatalogoMarcasViewModel)view.DataContext).SelectedTradeMark.Id;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchMeasurement()
        {
            try
            {
                CatalogoMedidaView view = new CatalogoMedidaView();
                view.Width = 800;
                view.Height = 700;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoMedidaViewModel measurementVM = new CatalogoMedidaViewModel(false);
                //measurementVM.OnAddMeasurement += ((s, e) => view.Close());
                view.DataContext = measurementVM;
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.MeasurementName = ((CatalogoMedidaViewModel)view.DataContext).SelectedMeasurement.MedidaString;
                    this.IdMedidaSeleccionado = ((CatalogoMedidaViewModel)view.DataContext).SelectedMeasurement.Id;
                }

            }
            catch (Exception ex)
            {

            }
        }

        private void OnSearchColors()
        {
            try
            {
                CatalogoColorView view = new CatalogoColorView();
                view.Width = 800;
                view.Height = 500;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoColorViewModel colorVM = new CatalogoColorViewModel(false);
                //colorVM.OnAddColor += ((s, e) => view.Close());
                view.DataContext = colorVM;
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.ColorName = ((CatalogoColorViewModel)view.DataContext).SelectedColor.ColorString;
                    this.idColor = ((CatalogoColorViewModel)view.DataContext).SelectedColor.Id;
                }

            }
            catch (Exception ex)
            {

            }
        }


        private void OnImportarProductos(object parameters)
        {
            //var vista = new CargarExcelProductos();
            //var dt = new CargarExcelVM();
            //vista.DataContext = dt;
            //dt.cerrar += ((s, e) => vista.Close());
            //dt.cerrar += dt_cerrar;
            //vista.ShowDialog();

            try
            {
                var rutaArchivo = "";
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.DefaultExt = ".xlsx";
                dialog.Filter = "(.xlsx)|*.xlsx";
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                if (dialog.ShowDialog().Equals(System.Windows.Forms.DialogResult.Cancel))
                    return;
                else
                {
                    rutaArchivo = dialog.FileName;
                    Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                    Microsoft.Office.Interop.Excel.Workbook workbook;
                    Microsoft.Office.Interop.Excel.Worksheet worksheet;
                    Microsoft.Office.Interop.Excel.Range range;
                    workbook = excelApp.Workbooks.Open(rutaArchivo);
                    worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];

                    range = worksheet.UsedRange;

                    int column = 0;
                    int row = 0;

                    //var initRow = 0;
                    var initColumn = 1;
                    var Data = new ObservableCollection<ProductoExcel>();

                    for (row = 2; row <= 200; row++)
                    {
                        var item = new ProductoExcel()
                        {
                            CVEProveedor = Convert.ToString((range.Cells[row, initColumn] as Range).Value),
                            NombreProducto = Convert.ToString((range.Cells[row, initColumn + 1] as Range).Value),
                            Precio = Convert.ToDouble((range.Cells[row, initColumn + 2] as Range).Value),
                            Cantidad = 0

                        };
                        if (!String.IsNullOrEmpty(item.CVEProveedor) && item.Precio > 0)
                            Data.Add(item);

                    }
                    workbook.Close(false, Missing.Value, Missing.Value);
                    excelApp.Quit();

                    dt_cerrar(Data);
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error al importar el archivo, verifica que las columnas tengan datos y haber seleccionado el area de impresion..", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void dt_cerrar(ObservableCollection<ProductoExcel> Data)
        {

            if (Data != null && Data.Count > 0)
            {

                var allproducts = Repository.GetProducts(string.Empty, string.Empty, SGI.Properties.Settings.Default.Matriz);

                foreach (var item in Data)
                {
                    var exist = allproducts.FirstOrDefault(s => s.CveProvider == item.CVEProveedor && s.IdProvider == idSearchProvider);
                    string errorMessage = string.Empty;
                    int error = 0;
                    if (exist != null)
                    {
                        exist.Cost = item.Precio.Value;
                        exist.Description = item.NombreProducto;
                        Repository.UpdateProducto(exist, ref error, ref errorMessage);
                    }
                    else
                    {
                        var product = new Product()
                        {
                            CveProvider = item.CVEProveedor,
                            CveTeknobike = item.CVEProveedor,
                            Name = item.NombreProducto,
                            Description = item.NombreProducto,
                            Cost = item.Precio.Value,
                            IdProvider = idSearchProvider
                        };

                        Repository.InsertProducto(product, ref error, ref errorMessage);
                    }
                }


                var refreshProducts = Repository.GetProducts(string.Empty, string.Empty, SGI.Properties.Settings.Default.Matriz);
                ProductosImportados = new List<Product>();
                foreach (var item in Data)
                {
                    var exist = allproducts.FirstOrDefault(s => s.CveProvider == item.CVEProveedor && s.IdProvider == idSearchProvider);
                    if (exist != null)
                    {
                        exist.Cantidad = Convert.ToInt32(item.Cantidad.Value);
                        ProductosImportados.Add(exist);
                    }
                }
            }    

            

            //this.ProductsList = Repository.GetProducts(string.Empty, string.Empty);
            //this.productsListStore = this.ProductsList;

           // var productsFilters = new List<Product>();

            //foreach(var item in Data)
            //{
            //    var items = productsList.Where(d => d.CveProvider == item.CVEProveedor && d.IdProvider == idSearchProvider);
            //    if(items != null)
            //    {
            //        productsFilters.AddRange(items);
            //    }
            //}

            ProductsList = ProductosImportados;
            SelectedTab = 1;

           

        }

        private void OnAgregarImportados(object parameters)
        {
            if (ProductosImportados != null)
            {
                    var productosmodificados = ProductsList.Where(d => d.IsEdited);
                    foreach (var prodmodif in productosmodificados)
                    {
                        var existeprod = ProductosImportados.FirstOrDefault(d => d.Id == prodmodif.Id);
                        if (existeprod != null)
                        {
                            existeprod.Cantidad = prodmodif.Cantidad;
                        }
                        else
                        {
                            ProductosImportados.Add(prodmodif);
                        }
                    }
                

                if (this.OnAddProduct != null)
                {
                    this.OnAddProduct(this, null);
                }
            }

            else if(SelectedProduct != null)
            {
                if (this.OnAddProduct != null)
                {
                    this.OnAddProduct(null, null);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("No hay productos importados desde excel o seleccionados de la tabla...", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        #endregion
    }
}
