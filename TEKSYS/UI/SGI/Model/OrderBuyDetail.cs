using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class OrderBuyDetail : ViewModelBase
    {
        #region Private Fields

        private int pieces;

        private double price;
        private double total;


        #endregion

        #region Public Properties

        /// <summary>
        /// 
        /// </summary>
        public int IdOrderBuy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdProvider { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProductDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdTrademark { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TrademarkName { get; set; }

        /// <summary>
        /// 
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
                    SetTotal();
                }
            }
        }

        public int Pieces
        {
            get { return pieces; }
            set
            {
                if (pieces != value)
                {
                    pieces = value;
                    RaisePropertyChanged(() => Pieces);
                    SetTotal();
                }
            }
        }


        public double Total
        {
            get { return total; }
            set
            {
                if (total != value)
                {
                    total = value;
                    RaisePropertyChanged(() => Total);
                }
            }
        }

        #endregion

        #region Private Methods

        private void SetTotal()
        {
            try
            {
                Total = Price * Pieces;
            }
            catch (Exception ex)
            {

            }
        }

        #endregion
    }
}
