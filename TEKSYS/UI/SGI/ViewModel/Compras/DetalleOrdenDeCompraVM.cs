using SGI.Enumeration;
using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using SGI.View.Catalogos;
using SGI.ViewModel.Catalogos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SGI.ViewModel
{
    public class DetalleOrdenDeCompraVM : ViewModelBase
    {
        #region Private Fields

        private int line { get; set; }
        private DateTime dateOutPut { get; set; }
        private int quantity { get; set; }
        private double unitPrice { get; set; }
        private double tax { get; set; }
        private double amount { get; set; }
        private int idProduct { get; set; }
        private string description { get; set; }
        private string nombre;

        private bool isCancel { get; set; }

        #endregion

        #region Public Fields

        public event EventHandler OnCloseProduct;

        #endregion

        #region Public Properties

        public DateTime DateOutPut
        {
            get { return this.dateOutPut; }
            set
            {
                this.dateOutPut = value;
                RaisePropertyChanged(() => DateOutPut);
            }
        }

        public int Line
        {
            get { return this.line; }
            set
            {
                this.line = value;
                RaisePropertyChanged(() => Line);
            }
        }

        public int Quantity
        {
            get { return this.quantity; }
            set
            {
                this.quantity = value;
                this.Amount = this.quantity * this.UnitPrice;
                RaisePropertyChanged(() => Quantity);
            }
        }

        public double UnitPrice
        {
            get { return this.unitPrice; }
            set
            {
                this.unitPrice = value;
                this.Amount = this.unitPrice * this.Quantity;
                RaisePropertyChanged(() => UnitPrice);
            }
        }

        public double Tax
        {
            get { return this.tax; }
            set
            {
                this.tax = value;
                RaisePropertyChanged(() => Tax);
            }
        }

        public double Amount
        {
            get { return this.amount; }
            set
            {
                this.amount = value;
                RaisePropertyChanged(() => Amount);
            }
        }

        public int IdProduct
        {
            get { return this.idProduct; }
            set
            {
                this.idProduct = value;
                RaisePropertyChanged(() => IdProduct);
            }
        }


        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                RaisePropertyChanged(() => Nombre);
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

        public Product ProductoSel { get; set; }
        public ICommand SearchProducts
        {
            get
            {
                return new RelayCommand(s => OnSearchProduct());
            }
        }

        public bool IsCancel
        {
            get { return this.isCancel; }
            set
            {
                this.isCancel = value;
                RaisePropertyChanged(() => IsCancel);
            }
        }

        #endregion

        #region Constructors

        public DetalleOrdenDeCompraVM(int count = 0)
        {
            try
            {
                this.DateOutPut = DateTime.Today;
                this.Line = Repository.GetOCDLastId() + count;
                this.Quantity = 1;
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private void OnSearchProduct()
        {
            try
            {
                CatalogoProductos view = new CatalogoProductos();
                view.Width = 900;
                view.Height = 800;
                view.WindowState = WindowState.Normal;
                view.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                CatalogoProductosVM productkVM = new CatalogoProductosVM(false, -1);
                productkVM.SelectedTab = 1;
                view.DataContext = productkVM;
                productkVM.OnAddProduct += ((s, e) => view.Close());
                view.ShowDialog();

                if (view.DataContext != null)
                {
                    this.IdProduct = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Id;
                    this.Description = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Name;
                    this.Nombre = ((CatalogoProductosVM)view.DataContext).SelectedProduct.Name;
                    this.ProductoSel = ((CatalogoProductosVM)view.DataContext).SelectedProduct;
                }

            }
            catch (Exception ex)
            {

            }
        }

        public override void OnAccept()
        {
            this.IsCancel = false;

            if (this.OnCloseProduct != null)
            {
                this.OnCloseProduct(this, null);
            }
        }

        public override void OnClean()
        {

            this.IsCancel = true;

            if (this.OnCloseProduct != null)
            {
                this.OnCloseProduct(this, null);
            }
        }

        #endregion
    }
}
