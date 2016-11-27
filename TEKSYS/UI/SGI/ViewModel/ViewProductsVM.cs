using SGI.Classes;
using SGI.Model;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SGI.ViewModel
{
    public class ViewProductsVM : ViewModelBase
    {
        #region Private Fields

        private ProductsViewVM productsView;

        #endregion

        #region Public Fields

        public event EventHandler<SelectedProductEventArgs> OnSelectedProduct;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public ViewProductsVM(ProductsViewVM productsViewP)
        {
            try
            {
                this.ProductsView = productsViewP;
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

        #endregion

        #region Private Methods

        /// <summary>
        /// Ejecuta la accion para crear un nuevo elemento en el catalogo de familias.
        /// </summary>
        public override void OnAccept()
        {
            if (this.ProductsView == null)
                return;
            try
            {
                if (OnSelectedProduct != null)
                {
                    OnSelectedProduct(this, new SelectedProductEventArgs(this.ProductsView.SelectedItem));
                }              
            }
            catch(Exception ex)
            {

            }
            finally
            {
                this.OnClose();
            }
        }

        #endregion
    }
}
