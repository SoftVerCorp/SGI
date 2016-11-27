using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model.Entidades
{
    public class Ventas
    {
        public int IdVenta { get; set; }

        public DateTime Fecha { get; set; }

        public int IdUbicacion { get; set; }

        public string Ubicacion { get; set; }

        public int IdVendedor { get; set; }

        public string Vendedor { get; set; }

        public int IdCliente { get; set; }

        public string Cliente { get; set; }

        public int IdTipoDeVenta { get; set; }

        public string TipoDeVenta { get; set; }

        public int IdEstatus { get; set; }

        public string Estatus { get; set; }

        public double MontoTotal { get; set; }

    }
}
