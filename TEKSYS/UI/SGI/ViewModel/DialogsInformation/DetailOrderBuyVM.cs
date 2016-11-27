using SGI.Model;
using SGI.Stuffs;
using SGI.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace SGI.ViewModel.DialogsInformation
{
    public class DetailOrderBuyVM : ViewModelBase
    {
        #region Private Fields

        private int counterSequence;

        private OrderBuy model;
        private OrderBuyDetail selectedItem;

        private Window thisWindow;

        private ObservableCollection<OrderBuyDetail> detailCollection;

        #endregion

        #region Constructors

        public DetailOrderBuyVM(OrderBuy modelP, Window wnd)
        {
            try
            {
                this.thisWindow = wnd;
                this.counterSequence = 0;
                this.Model = modelP;
                this.DetailCollection = new ObservableCollection<OrderBuyDetail>();
                this.GetOrderDetail();
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
        public OrderBuyDetail SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    RaisePropertyChanged(() => SelectedItem);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<OrderBuyDetail> DetailCollection
        {
            get { return detailCollection; }
            set
            {
                if (detailCollection != value)
                {
                    detailCollection = value;
                    RaisePropertyChanged(() => DetailCollection);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public OrderBuy Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    RaisePropertyChanged(() => Model);
                }
            }
        }

        #endregion

        #region Private Methods

        private void GetOrderDetail()
        {
            try
            {
                if (this.Model != null)
                {
                    var details = Repository.GetOrdersBuyDetail(this.Model.Id);

                    if (details.Count > 0)
                    {
                        this.DetailCollection = new ObservableCollection<OrderBuyDetail>(details);
                        this.counterSequence = this.DetailCollection.Count();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnAccept()
        {
            int errorCode = 0;
            string msg = string.Empty;
            bool result = false;

            try
            {
                if (this.Model == null)
                {
                    System.Windows.Forms.MessageBox.Show("Error ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                if (this.DetailCollection.Count == 0)
                {
                    System.Windows.Forms.MessageBox.Show("Error, No hay productos a guardar ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder sb = new StringBuilder();

                sb.Append("<ROOT>");

                foreach (var item in DetailCollection)
                {
                    sb.Append("<Product>");
                    sb.Append("<IdProducto>" + item.ProductId + "</IdProducto>");
                    sb.Append("<IdTrademark>" + item.IdTrademark + "</IdTrademark>");
                    sb.Append("<IdProvider>" + this.Model.IdProvider + "</IdProvider>");
                    sb.Append("<OrderBuy>" + this.Model.Id + "</OrderBuy>");
                    sb.Append("<Price>" + item.Price + "</Price>");
                    sb.Append("<Pieces>" + item.Pieces + "</Pieces>");
                    sb.Append("</Product>");
                }

                sb.Append("</ROOT>");


                result = Repository.InsOrderBuyDetails(sb.ToString(), this.Model.Id, this.model.IdBuyStatus, ref errorCode, ref msg);

                if (!result || errorCode < 0)
                {
                    System.Windows.Forms.MessageBox.Show("Error al guardar orden de compra " + msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                System.Windows.Forms.MessageBox.Show("Datos guardados correctamente ", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                OnClose();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        public override void OnAddItem(object param)
        {
            try
            {
                ViewProducts view = new ViewProducts();
                ViewProductsVM vm = new ViewProductsVM(new ProductsViewVM());
                view.DataContext = vm;
                view.ShowDialog();

                if (vm.ProductsView != null)
                {
                    if (vm.ProductsView.SelectedItem != null)
                    {
                        var exist = this.DetailCollection.Where(s => s.ProductId == vm.ProductsView.SelectedItem.Id && vm.ProductsView.SelectedItem.IdTrademark == s.IdTrademark);

                        if (exist.Count() > 0)
                        {
                            System.Windows.MessageBox.Show("Error , el producto seleccionado ya existe", "Error agregando producto", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }

                        OrderBuyDetail model = new OrderBuyDetail();
                        model.ProductId = vm.ProductsView.SelectedItem.Id;
                        model.ProductName = vm.ProductsView.SelectedItem.Name;
                        model.ProductDescription = vm.ProductsView.SelectedItem.Description;
                        model.IdTrademark = vm.ProductsView.SelectedItem.IdTrademark;
                        model.TrademarkName = vm.ProductsView.SelectedItem.TrademarkName;
                        model.Price = vm.ProductsView.SelectedItem.Cost;
                        model.Pieces = vm.ProductsView.SelectedItem.Pieces;
                        counterSequence++;
                        model.Sequence = counterSequence;
                        this.DetailCollection.Add(model);

                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public override void OnDeleteItem(object param)
        {
            OrderBuyDetail model = param as OrderBuyDetail;

            if (model == null)
            {
                System.Windows.MessageBox.Show("Debe seleccionar un elemento ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                if (this.DetailCollection.Count == 0)
                {
                    System.Windows.MessageBox.Show("No hay elementos a eliminar ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                var result = System.Windows.MessageBox.Show("¿Esta seguro de eliminar este elemento? ", "Error", MessageBoxButton.OKCancel, MessageBoxImage.Error);

                if (result == MessageBoxResult.OK)
                {
                    this.DetailCollection.Remove(model);
                    //OnAccept();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error " + ex.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void OnClose()
        {
            try
            {
                if (this.thisWindow != null)
                {
                    this.thisWindow.Close();
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
