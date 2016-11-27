using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedOrderBuyEventArgs : EventArgs
    {
        public SelectedOrderBuyEventArgs(OrderBuy item)
        {
            this.SelectedOrderBuy = item;
        }

        /// <summary>
        /// 
        /// </summary>
        public OrderBuy SelectedOrderBuy { get; set; }
    }
}
