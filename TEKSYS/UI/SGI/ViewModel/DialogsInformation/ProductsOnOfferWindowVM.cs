using SGI.Classes;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.DialogsInformation
{
    public class ProductsOnOfferWindowVM : ViewModelBase
    {
        #region Private Fields

        private ProductsOnOfferControlVM productsOnOfferControlVM;

        #endregion

        #region Public Fields

        public event EventHandler<SelectedProductsOnOffer> OnSelectedProductInOffert;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase EmployeeWindowVM
        /// </summary>
        public ProductsOnOfferWindowVM(ProductsOnOfferControlVM param)
        {
            try
            {
                this.ProductsOnOfferControlVM = param;
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
        public ProductsOnOfferControlVM ProductsOnOfferControlVM
        {
            get { return productsOnOfferControlVM; }
            set
            {
                if (productsOnOfferControlVM != value)
                {
                    productsOnOfferControlVM = value;
                    RaisePropertyChanged(() => ProductsOnOfferControlVM);
                }
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        public override void OnAccept()
        {
            if (this.ProductsOnOfferControlVM == null)
                return;

            try
            {
                if (OnSelectedProductInOffert != null)
                {
                    OnSelectedProductInOffert(this, new SelectedProductsOnOffer(this.ProductsOnOfferControlVM.SelectedItem));
                }               
            }
            catch (Exception ex)
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

