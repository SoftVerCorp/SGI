using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ClienteVenta
    {
        public int idCliente { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Telefono { get; set; }
        public string CP { get; set; }
        public string Ciudad { get; set; }
        public string Estado { get; set; }
        public int idTipoCliente { get; set; }
        public double DescuentoCliente { get; set; }
        public string TipoCliente { get; set; }
        public string Detalle
        {
            get {return String.Format("Ciudad : {0},{1}, Tipo cliente {2}, Direccion {3}...",Ciudad,Estado,TipoCliente,Direccion); }
        }
    }
}
