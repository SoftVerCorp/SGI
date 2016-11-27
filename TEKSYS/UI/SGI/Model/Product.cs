using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public partial class Product : ViewModelBase
    {
        /// <summary>
        /// Obtiene o establece el Id del producto
        /// </summary>
        public int Id { get; set; }

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
        public string SelectedModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedCoin { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string SelectedFamily { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SelectedTrademark { get; set; }

        public string Providers { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TeknobikeKey { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sku { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Wholesale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double MediumWholesale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double PublicPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Pieces { get; set; }

        /// <summary>
        /// Gets or sets the ultima compra.
        /// </summary>
        /// <value>
        /// The ultima compra.
        /// </value>
        public string UltimaCompra { get; set; }
        /// <summary>
        /// Gets or sets the ultima venta.
        /// </summary>
        /// <value>
        /// The ultima venta.
        /// </value>
        public string UltimaVenta { get; set; }

        /// <summary>
        /// Gets or sets the precio distribuidor.
        /// </summary>
        /// <value>
        /// The precio distribuidor.
        /// </value>
        public double PrecioDistribuidor { get; set; }

        /// <summary>
        /// Gets or sets the add valorioum.
        /// </summary>
        /// <value>
        /// The add valorioum.
        /// </value>
        public double AddValorioum { get; set; }

        /// <summary>
        /// Gets or sets the igi.
        /// </summary>
        /// <value>
        /// The igi.
        /// </value>
        public double IGI { get; set; }
        /// <summary>
        /// Gets or sets the impuesto3.
        /// </summary>
        /// <value>
        /// The impuesto3.
        /// </value>
        public double Impuesto3 { get; set; }

        public int InventarioTotal { get; set; }

        public int Inventario { get; set; }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }

            set
            {
                cantidad = value;
                IsEdited = true;
                RaisePropertyChanged(()=> Cantidad);
            }
        }

        private int cantidad;

        public bool IsEdited { get; set; }

        public string UPC { get; set; }

    }
}
