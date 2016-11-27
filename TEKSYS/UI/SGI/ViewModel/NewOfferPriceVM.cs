using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.View.DialogsInformation;
using SGI.ViewModel.DialogsInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class NewOfferPriceVM : ViewModelBase
    {
        #region Private Fields

        private string productName;
        private string offerTypeName;

        private int idProductInOffer;
        private int productId;
        private int offerTypeId;

        private bool isActive;

        private double price;

        private DateTime? beginDate;
        private DateTime? endDate;


        #endregion

        #region Public Fields

        public event EventHandler OnAddNewOfferPrice;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase NewCoinsVM
        /// </summary>
        public NewOfferPriceVM()
        {
            try
            {
                this.IsActive = true;
                this.OperationType = Enumeration.Operation.Create;
                this.TitleWindow = "Nuevo precio en oferta";
            }
            catch (Exception ex)
            {

            }
        }

        public NewOfferPriceVM(ProductInOffert po)
        {
            try
            {
                this.IsActive = true;
                this.OperationType = Enumeration.Operation.Update;
                this.TitleWindow = "Modificar precio en oferta";

                if (po != null)
                {
                    this.productId = po.IdProduct;
                    this.idProductInOffer = po.IdProductIntOffer;
                    this.offerTypeId = po.IdOfferType;
                    this.ProductName = po.ProductName;
                    this.OfferTypeName = po.OfferType;
                    this.Price = po.OffertPrice;
                    this.BeginDate = po.BeginDate;
                    this.EndDate = po.EndDate;
                }
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
        public bool IsActive
        {
            get { return isActive; }
            set
            {
                if (isActive != value)
                {
                    isActive = value;
                    RaisePropertyChanged(() => IsActive);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la fecha final de la oferta.
        /// </summary>
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                if (endDate != value)
                {
                    endDate = value;
                    RaisePropertyChanged(() => EndDate);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la fecha inicial de la oferta.
        /// </summary>
        public DateTime? BeginDate
        {
            get { return beginDate; }
            set
            {
                if (BeginDate != value)
                {
                    beginDate = value;
                    RaisePropertyChanged(() => BeginDate);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el precio de la oferta.
        /// </summary>
        public double Price
        {
            get { return price; }
            set
            {
                if (price != value)
                {
                    price = value;
                    RaisePropertyChanged(() => Price);
                }
            }
        }


        /// <summary>
        /// Obtiene o establece el nombre del tipo de oferta
        /// </summary>
        public string OfferTypeName
        {
            get { return offerTypeName; }
            set
            {
                if (offerTypeName != value)
                {
                    offerTypeName = value;
                    RaisePropertyChanged(() => OfferTypeName);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el nombre del producto elegido.
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
                }
            }
        }

        /// <summary>
        /// Obtiene un comando para abrir la ventana para elegir un producto
        /// </summary>
        public ICommand OpenProduct
        {
            get
            {
                return new RelayCommand(s => OnSelectProduct());
            }
        }

        /// <summary>
        /// Obtiene un comando para abrir la ventana para elegir un tipo de oferta.
        /// </summary>
        public ICommand OpenOfferType
        {
            get
            {
                return new RelayCommand(s => this.OnSelectedOfferType());
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Abre la ventana de busqueda de tipo de oferta
        /// </summary>
        private void OnSelectedOfferType()
        {
            try
            {
                //ViewOfferType vOfferType = new ViewOfferType();
                //ViewOfferTypeVM viewModel = new ViewOfferTypeVM();
                //viewModel.OnSelectedOfferType += OnviewModelOnSelectedOfferType;
                //vOfferType.DataContext = viewModel;
                //vOfferType.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Obtiene el tipo de oferta de la ventana de busqueda.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnviewModelOnSelectedOfferType(object sender, Classes.SelectedOfferTypeEventArgs e)
        {
            if (e.OfferType != null)
            {
                this.OfferTypeName = e.OfferType.OfferTypeName;
                this.offerTypeId = e.OfferType.Id;
            }
        }

        /// <summary>
        /// Abre la ventana de busqueda del producto.
        /// </summary>
        private void OnSelectProduct()
        {
            try
            {
                ViewProducts viewProduct = new ViewProducts();
                ViewProductsVM wpVM = new ViewProductsVM(new ProductsViewVM());
                wpVM.OnSelectedProduct += OnwpVMOnSelectedProduct;
                viewProduct.DataContext = wpVM;
                viewProduct.ShowDialog();
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
        private void OnwpVMOnSelectedProduct(object sender, Classes.SelectedProductEventArgs e)
        {
            try
            {
                if (e.SelectedProduct != null)
                {
                    this.productId = e.SelectedProduct.Id;
                    this.ProductName = e.SelectedProduct.Name;
                }
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Añade una nueva oferta.
        /// </summary>
        public override void OnAccept()
        {
            if (string.IsNullOrEmpty(this.ProductName))
            {
                MessageBox.Show("Debe elegir un producto", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (string.IsNullOrEmpty(this.OfferTypeName))
            {
                MessageBox.Show("Debe elegir un tipo de oferta", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (this.BeginDate != null && this.EndDate != null)
            {
                if (this.BeginDate > this.EndDate)
                {
                    MessageBox.Show("La fecha inicial es  mayor a la fecha final", "Seleccione otra fecha", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }

            try
            {
                string errorMessage = string.Empty;
                int error = 0;

                if (this.OperationType == Enumeration.Operation.Create)
                {
                    var result = Repository.InsOfferPrice(this.productId, this.offerTypeId, this.Price, this.BeginDate, this.EndDate, ref error, ref errorMessage);

                    if (!result || error == -1)
                    {
                        MessageBox.Show("Error " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }

                    MessageBox.Show("Datos guardados con exito ", "Datos Guardados", MessageBoxButton.OK, MessageBoxImage.Information);

                    OnAddNewOfferPrice(true, null);
                }
                else
                {
                    if (this.OperationType == Enumeration.Operation.Update)
                    {
                        var result = Repository.UpdPriceInOffert(this.idProductInOffer, this.productId, this.offerTypeId, this.Price, this.BeginDate, this.EndDate, ref errorMessage);

                        if (!result)
                        {
                            MessageBox.Show("Error modificando los datos " + errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        MessageBox.Show("Datos modificados con exito ", "Datos modificados", MessageBoxButton.OK, MessageBoxImage.Information);

                        OnAddNewOfferPrice(this, null);
                    }
                }

                OnClose();
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
            try
            {
                this.OfferTypeName = string.Empty;
                this.ProductName = string.Empty;
                this.Price = 0;
                this.BeginDate = null;
                this.EndDate = null;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
