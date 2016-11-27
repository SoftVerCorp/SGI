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

namespace SGI.ViewModel.DialogsInformation
{
    public class ProductsOnOfferControlVM : ViewModelBase
    {
        #region Private Fields

        private string productName;
        private string productDescription;

        private ProductInOffert selectedItem;

        private List<ProductInOffert> itemList;
        private List<ProductInOffert> itemListAux;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ProductsOnOfferControlVM()
        {
            try
            {
                this.ItemList = Repository.GetProductsInOffert(string.Empty);
                this.itemListAux = this.ItemList;
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
        public ProductInOffert SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
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


        /// <summary>
        /// Obtiene o establece una lista de productos
        /// </summary>
        public List<ProductInOffert> ItemList
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
        #endregion

        #region Private Methods

        public override void OnDeleteItem(object param)
        {
            try
            {
                ProductInOffert product = param as ProductInOffert;

                MessageBoxResult result = MessageBox.Show("¿Esta seguro de querer eliminar este elemento", "Eliminar elementos", MessageBoxButton.OKCancel, MessageBoxImage.Information);

                if (result == MessageBoxResult.OK)
                {
                    if (product == null)
                    {
                        MessageBox.Show("Debe elegir un producto para eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    string msg = string.Empty;

                   var res = Repository.DelProductInOffert(product.IdProductIntOffer,ref msg);

                    if(!res)
                    {
                        MessageBox.Show("Error al eliminar los datos " + msg, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Elemento eliminado", "Dato eliminado", MessageBoxButton.OK, MessageBoxImage.Exclamation);

                    Task.Run(() => this.OnRefresh());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnUpdateItem(object param)
        {
            try
            {
                ProductInOffert obj = param as ProductInOffert;

                if (obj == null)
                {
                    MessageBox.Show("Debe elegir un producto a modificar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                NewOfferPrice view = new NewOfferPrice();
                NewOfferPriceVM viewModel = new NewOfferPriceVM(obj);
                viewModel.OnAddNewOfferPrice += viewModel_OnAddNewOfferPrice;
                view.DataContext = viewModel;
                view.ShowDialog();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        public override void OnAddItem(object param)
        {
            try
            {
                NewOfferPrice view = new NewOfferPrice();
                NewOfferPriceVM vm = new NewOfferPriceVM();
                vm.OnAddNewOfferPrice += VMOnAddNewOfferPrice;
                view.DataContext = vm;
                view.ShowDialog();
            }
            catch (Exception ex)
            {

            }
        }

        void viewModel_OnAddNewOfferPrice(object sender, EventArgs e)
        {
            OnRefresh();
        }

        void VMOnAddNewOfferPrice(object sender, EventArgs e)
        {
            OnRefresh();
        }



        /// <summary>
        /// 
        /// </summary>
        private void OnRefresh()
        {
            try
            {
                this.ItemList = Repository.GetProductsInOffert(string.Empty);
                this.itemListAux = this.ItemList;
            }
            catch (Exception ex)
            {

            }
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

        private async Task<List<ProductInOffert>> GetList()
        {
            List<ProductInOffert> lst = new List<ProductInOffert>();

            try
            {
                var aux = this.itemListAux;

                lst = aux.Where(
                      s =>
                         (

                          ((!string.IsNullOrEmpty(this.ProductName) ? s.ProductName.ToUpper().Contains(this.ProductName.ToUpper()) : true))
                          &&
                          ((!string.IsNullOrEmpty(this.ProductDescription) ? s.ProductDescription.ToUpper().Contains(this.ProductDescription.ToUpper()) : true))

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
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
        {
            if (string.IsNullOrEmpty(this.ProductName))
            {
                MessageBox.Show("Debe ingresar un nombre", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                var result = Repository.InsCoins(this.ProductName, ref error, ref errorMessage);

                if (!result || error == -1)
                {
                    MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                this.CleanText();
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
