using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class HistoricoMovInv
    {
        public DateTime FechaMovimiento { get; set; }

        public string Movimiento { get; set; }

        public string Ubicacion { get; set; }

        public string Producto { get; set; }

        public int Cantidad { get; set; }

        public string Pedimento { get; set; }
    }
}
