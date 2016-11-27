using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Checadas : ViewModelBase
    {

        public Checadas()
        {
            Detalles = new List<ChecadaDetalle>();
        }

        public int IdChecada { get; set; }

        public DateTime Fecha { get; set; }

        public string Justificacion { get; set; }

        public int IdEstado { get; set; }

        public string Estado { get; set; }

        public string JustitificadoPor { get; set; }

        public double TotalHoras
        {
            get
            {
                double result = 0;
                double aux;

                if (Detalles != null && Detalles.Count > 0)
                {
                    var checadaDetalle = Detalles.First();

                    TimeSpan t1 = checadaDetalle.Entrada - checadaDetalle.SalidaComida;

                    TimeSpan t2 = checadaDetalle.EntradaComida - checadaDetalle.Salida;

                    TimeSpan T = t1 + t2;

                    result = T.TotalHours;

                }

                return result;
            }
        }

        public List<ChecadaDetalle> Detalles { get; set; }

    }
}
