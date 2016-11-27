using SGI.Classes;
using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.DialogsInformation
{
    public class OrderBuyWindowVM : ViewModelBase
    {
        #region Private Fields

        private ViewOrderBuyVM viewOrderBuyVM;

        #endregion

        #region Public Fields

        public event EventHandler<SelectedOrderBuyEventArgs> OnSelectedOrderBuy;

        #endregion

        #region Constructors

        /// <summary>
        /// Representa una nueva instancia de la clase EmployeeWindowVM
        /// </summary>
        public OrderBuyWindowVM(ViewOrderBuyVM param)
        {
            try
            {
                this.ViewOrderBuyVM = param;
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

        #endregion

        #region Private Methods

        /// <summary>
        /// 
        /// </summary>
        public override void OnAccept()
        {
            if (this.ViewOrderBuyVM == null)
                return;
            try
            {
                if (OnSelectedOrderBuy != null)
                {
                    OnSelectedOrderBuy(this, new SelectedOrderBuyEventArgs(this.ViewOrderBuyVM.SelectedItem));
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
