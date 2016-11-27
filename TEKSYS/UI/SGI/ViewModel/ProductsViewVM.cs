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

namespace SGI.ViewModel
{
    public class ProductsViewVM : ViewModelBase
    {
        #region Private Fields

        private int productId;
        private string selectedModel;
        private string selectedCoin;
        private string selectedFamily;
        private string selectedTrademark;
        private string providers;
        private string teknobikeKey;
        private string sku;
        private string name;
        private string description;
        private double wholesale;
        private double mediumWholesale;
        private double publicPrice;
        private double cost;
        private int pieces;

        private string productName;
        private string productDescription;

        private Product selectedProduct;

        private List<Product> productList;
        private List<Product> productListAux;
        private List<Models> listModels;
        private List<Coin> listCoins;
        private List<Families> listFamilies;
        private List<Trademark> listTrademarks;


        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ProductsViewVM()
        {
            try
            {

                this.OperationType = Enumeration.Operation.Create;

                this.listModels = new List<Models>();
                this.listModels.Add(new Models { Id = -1, Model = "Seleccionar" });
                this.listModels.AddRange(Repository.GetModels(string.Empty));
                this.selectedModel = "-1";

                this.listTrademarks = new List<Trademark>();
                this.listTrademarks.Add(new Trademark { Id = -1, TrademarkName = "Seleccionar" });
                this.listTrademarks.AddRange(Repository.GetTrademarks(string.Empty));
                this.selectedTrademark = "-1";

                this.listFamilies = new List<Families>();
                this.listFamilies.Add(new Families { Id = -1, FamilyName = "Seleccionar" });
                this.listFamilies.AddRange(Repository.GetFamilies(string.Empty));
                this.selectedFamily = "-1";

                this.listCoins = new List<Coin>();
                this.listCoins.Add(new Coin { Id = -1, CoinName = "Seleccionar" });
                this.listCoins.AddRange(Repository.GetCoins(string.Empty));
                this.selectedCoin = "-1";

                this.ProductList = Repository.GetProducts(string.Empty);
                this.productListAux = this.ProductList;
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
        public int Pieces
        {
            get { return pieces; }
            set
            {
                if (pieces != value)
                {
                    pieces = value;
                    RaisePropertyChanged(() => Pieces);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el costo del producto.
        /// </summary>
        public double Cost
        {
            get { return cost; }
            set
            {
                if (cost != value)
                {
                    cost = value;
                    RaisePropertyChanged(() => Cost);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el precio publico.
        /// </summary>
        public double PublicPrice
        {
            get { return publicPrice; }
            set
            {
                if (publicPrice != value)
                {
                    publicPrice = value;
                    RaisePropertyChanged(() => PublicPrice);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el precio del medio mayoreo.
        /// </summary>
        public double MediumWholesale
        {
            get { return mediumWholesale; }
            set
            {
                if (mediumWholesale != value)
                {
                    mediumWholesale = value;
                    RaisePropertyChanged(() => MediumWholesale);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece el precio de mayoreo.
        /// </summary>
        public double Wholesale
        {
            get { return wholesale; }
            set
            {
                if (wholesale != value)
                {
                    wholesale = value;
                    RaisePropertyChanged(() => Wholesale);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la descripción del producto.
        /// </summary>
        public string Description
        {
            get { return description; }
            set
            {
                if (description != value)
                {
                    description = value;
                    RaisePropertyChanged(() => Description);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre del producto.
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
        /// Obtiene o establece el SKU
        /// </summary>
        public string Sku
        {
            get { return sku; }
            set
            {
                if (sku != value)
                {
                    sku = value;
                    RaisePropertyChanged(() => Sku);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la clave del teknobike
        /// </summary>
        public string TeknobikeKey
        {
            get { return teknobikeKey; }
            set
            {
                if (teknobikeKey != value)
                {
                    teknobikeKey = value;
                    RaisePropertyChanged(() => TeknobikeKey);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece la clave del proveedor.
        /// </summary>
        public string Providers
        {
            get { return providers; }
            set
            {
                if (providers != value)
                {
                    providers = value;
                    RaisePropertyChanged(() => Providers);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de la marca seleccionada
        /// </summary>
        public string SelectedTrademark
        {
            get { return selectedTrademark; }
            set
            {
                if (selectedTrademark != value)
                {
                    selectedTrademark = value;
                    RaisePropertyChanged(() => SelectedTrademark);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de la familia seleccionada.
        /// </summary>
        public string SelectedFamily
        {
            get { return selectedFamily; }
            set
            {
                if (selectedFamily != value)
                {
                    selectedFamily = value;
                    RaisePropertyChanged(() => SelectedFamily);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el valor de la moneda seleccionada.
        /// </summary>
        public string SelectedCoin
        {
            get { return selectedCoin; }
            set
            {
                if (selectedCoin != value)
                {
                    selectedCoin = value;
                    RaisePropertyChanged(() => SelectedCoin);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el valor del modelo seleccionado.
        /// </summary>
        public string SelectedModel
        {
            get { return selectedModel; }
            set
            {
                if (selectedModel != value)
                {
                    selectedModel = value;
                    RaisePropertyChanged(() => this.SelectedModel);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public List<Models> ListModels
        {
            get { return listModels; }
            set
            {
                if (listModels != value)
                {
                    listModels = value;
                    RaisePropertyChanged(() => this.ListModels);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Coin> ListCoins
        {
            get { return listCoins; }
            set
            {
                if (listCoins != value)
                {
                    listCoins = value;
                    RaisePropertyChanged(() => ListCoins);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Families> ListFamilies
        {
            get { return listFamilies; }
            set
            {
                if (listFamilies != value)
                {
                    listFamilies = value;
                    RaisePropertyChanged(() => ListFamilies);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public List<Trademark> ListTrademarks
        {
            get { return listTrademarks; }
            set
            {
                if (listTrademarks != value)
                {
                    listTrademarks = value;
                    RaisePropertyChanged(() => ListTrademarks);
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        public Product SelectedItem
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        /// <summary>
        /// Obtiene o establece el filtro por descripcion
        /// </summary>
        public string ProductDescription
        {
            get { return productDescription; }
            set
            {
                if (productDescription != value)
                {
                    productDescription = value;
                    RaisePropertyChanged(() => ProductDescription);
                    SearchAsync();
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre de la moneda.
        /// </summary>
        public string ProductName
        {
            get { return productName; }
            set
            {
                if (productName != value)
                {
                    productName = value;
                    RaisePropertyChanged(() => ProductName);
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

        public ICommand SaveNewEmployee
        {
            get
            {
                return new RelayCommand(s => OnSaveNewEmployee());
            }
        }

        /// <summary>
        /// Obtiene o establece una lista de productos
        /// </summary>
        public List<Product> ProductList
        {
            get { return productList; }
            set
            {
                if (productList != value)
                {
                    productList = value;
                    RaisePropertyChanged(() => ProductList);
                }
            }
        }

        #endregion

        #region Private Methods

        public override void OnSelectedItemGridClick(object parameters)
        {
            Product item = Helpers.DataGridRowHelper.GetDatagridRow(parameters as MouseButtonEventArgs) as Product;

            if (item == null)
                return;          

            try
            {
                this.OperationType = Enumeration.Operation.Update;
                this.SelectedModel = item.SelectedModel;
                this.SelectedTrademark = item.IdTrademark.ToString();
                this.SelectedFamily = item.SelectedFamily;
                this.SelectedCoin = item.SelectedCoin;
                this.productId = item.Id;
                this.Providers = item.Providers;
                this.TeknobikeKey = item.TeknobikeKey;
                this.Sku = item.Sku;
                this.Name = item.Name;
                this.Description = item.Description;
                this.Wholesale = item.Wholesale;
                this.MediumWholesale = item.MediumWholesale;
                this.PublicPrice = item.PublicPrice;
                this.Cost = item.Cost;
                this.Pieces = item.Pieces;

                this.selectedProduct = item;
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnClean()
        {
            this.OperationType = Enumeration.Operation.Create;
            this.SelectedModel = "-1";
            this.SelectedTrademark = "-1";
            this.SelectedFamily = "-1";
            this.SelectedCoin = "-1";
            this.productId = 0;
            this.Providers = string.Empty;
            this.TeknobikeKey = string.Empty;
            this.Sku = string.Empty;
            this.Name = string.Empty;
            this.Description = string.Empty;
            this.Wholesale = 0.0;
            this.MediumWholesale = 0.0;
            this.PublicPrice = 0.0;
            this.Cost = 0.0;
            this.Pieces = 0;
        }

        /// <summary>
        /// Guarda un nuevo elemento en el catalogo de productos.
        /// </summary>
        /// 
        private void OnSaveNewEmployee()
        {

            if (string.IsNullOrEmpty(this.SelectedModel))
            {
                MessageBox.Show("Debe seleccionar un modelo", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.SelectedTrademark))
            {
                MessageBox.Show("Debe seleccionar una marca", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.SelectedFamily))
            {
                MessageBox.Show("Debe seleccionar una familia", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.SelectedCoin))
            {
                MessageBox.Show("Debe seleccionar un tipo de moneda", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.name))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                Product product = new Product();
                product.Id = this.productId;
                product.SelectedModel = this.SelectedModel;
                product.SelectedCoin = this.SelectedCoin;
                product.SelectedFamily = this.SelectedFamily;
                product.SelectedTrademark = this.SelectedTrademark;
                product.Providers = this.Providers;
                product.TeknobikeKey = this.TeknobikeKey;
                product.Sku = this.Sku;
                product.Name = this.Name;
                product.Description = this.Description;
                product.Wholesale = this.Wholesale;
                product.MediumWholesale = this.MediumWholesale;
                product.PublicPrice = this.PublicPrice;
                product.Cost = this.Cost;
                product.Pieces = this.Pieces;

                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsProducts(product, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
                    OnClean();
                    Task.Run(() => this.OnRefresh());
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var result = MessageBox.Show("¿Esta Seguro de querer modificar este producto", "Modificar producto", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);

                        if (result != MessageBoxResult.OK)
                            return;

                        var res = Repository.UpdProducts(product);

                        if (!res)
                        {
                            MessageBox.Show("Error modificando datos ", "Error", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos Modificados", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.OnClean();
                        Task.Run(() => this.OnRefresh());

                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                OnClose();
            }
        }

        public override void OnDeleteItem(object param)
        {
            try
            {
              
                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    if (productId == 0)
                    {
                        MessageBox.Show("Debe elegir un producto para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    Repository.DelProduct(productId);

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.OnRefresh());
                    OnClean();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh()
        {
            try
            {
                this.ProductList = Repository.GetProducts(string.Empty);
                this.productListAux = this.ProductList;
            }
            catch (Exception ex)
            {

            }
        }

        public async void SearchAsync()
        {
            try
            {
                this.ProductList = await Task.Run(() => this.GetList());
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
                var aux = this.productListAux;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.ProductName) ? s.Name.ToUpper().Contains(this.ProductName.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.ProductDescription) ? s.Description.ToUpper().Contains(this.ProductDescription.ToUpper()) : true))

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
        /// Limpiar el texto despues de guardar los datos.
        /// </summary>
        private void CleanText()
        {
            this.ProductName = string.Empty;
        }

        #endregion
    }
}

