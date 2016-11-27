using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedProductsOnOffer : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        public SelectedProductsOnOffer(ProductInOffert model)
        {
            this.ProductInOffert = model;
        }

        /// <summary>
        /// 
        /// </summary>
        public ProductInOffert ProductInOffert { get; set; }
    }
}
