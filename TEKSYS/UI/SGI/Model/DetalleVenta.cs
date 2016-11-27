using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public int idProducto { get; set; }
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }
        public double Descuento { get; set; }
        public  int? IdDescuento { get; set; }
        public int? IdDescuentoCliente { get; set; }
        public int IdVenta { get; set; }
    }
}
