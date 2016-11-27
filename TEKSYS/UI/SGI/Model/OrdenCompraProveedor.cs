using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class OrdenCompraProveedor : ViewModelBase
    {
        public int IdOrdenCompra { get; set; }

        public string Proveedor { get; set; }

        public int IdProveedor { get; set; }

        public int IdUbicacion { get; set; }

        public int IdProducto { get; set; }

        public string Producto { get; set; }

        private int cantidad;

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                RaisePropertyChanged(() => Cantidad);
                SetTotal();
            }
        }

        public string UOM { get; set; }

        public double Impuestos { get; set; }

        public int Linea { get; set; }

        private void SetTotal()
        {
            try
            {
                Total = PrecioUnitario * Cantidad;
            }
            catch (Exception ex)
            {

            }
        }

        private double total;
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



        private double precioUnitario;

        /// <summary>
        /// 
        /// </summary>
        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set
            {
                if (precioUnitario != value)
                {
                    precioUnitario = value;
                    RaisePropertyChanged(() => PrecioUnitario);
                    SetTotal();
                }
            }
        }


        public string Ubicacion { get; set; }
    }
}
