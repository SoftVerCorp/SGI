using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ChecadaDetalle
    {
        public int IdChecadaDetalle { get; set; }

        public int IdChecada { get; set; }

        public DateTime Entrada { get; set; }

        public DateTime SalidaComida { get; set; }

        public DateTime EntradaComida { get; set; }

        public DateTime Salida { get; set; }
    }
}
