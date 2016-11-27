using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public ClienteVenta IdCliente { get; set; }
        public int IdUbicacion { get; set; }
        public DateTime FechaVenta { get; set; }
        public int idVendedor { get; set; }
        public string NombreVendedor { get; set; }
    }
}
