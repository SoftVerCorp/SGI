using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model.Entidades
{
    public class VentasAdeudos
    {

        public int IdCliente { get; set; }

        public string Nombre { get; set; }

        public string Telefono { get; set; }

        public string TipoDeCliente { get; set; }

        public double LimiteDeCredito { get; set; }

        public int Documentos { get; set; }

        public int DocumentosVencidos { get; set; }

        public int DocumentosPorCobrar { get; set; }

        public double SaldoVencido { get; set; }

        public bool Pintar
        {
            get
            {
                if (DocumentosVencidos > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
