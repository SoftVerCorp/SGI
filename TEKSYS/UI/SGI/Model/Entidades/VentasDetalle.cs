using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model.Entidades
{
    public class VentasDetalle
    {
        public string Producto { get; set; }

        public string Clave { get; set; }

        public string Pedimento { get; set; }

        public double Cantidad { get; set; }

        public double PrecioUnitario { get; set; }

        public double Descuento { get; set; }

        public double Total { get; set; }
    }
}
