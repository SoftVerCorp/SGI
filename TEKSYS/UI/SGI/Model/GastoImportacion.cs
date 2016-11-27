using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class GastoImportacion
    {
        public int IdAgenteAduanal { get; set; }

        public int IdOrdenDeCompra { get; set; }

        public string NoCuenta { get; set; }

        public DateTime Fecha { get; set; }

    }
}
