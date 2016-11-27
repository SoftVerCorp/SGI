using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ProductInOffert
    {
        /// <summary>
        /// 
        /// </summary>
        public int IdProductIntOffer { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int IdProduct { get; set; }

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
        public int IdOfferType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string OfferType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double OffertPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? BeginDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndDate { get; set; }

    }
}
