using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Helpers
{
    public static class ManejadorUbicacion
    {
        public static int IdUbicacion { get; set; }
        public static string Ubicacion { get; set; }
        public static bool EsMatriz { get; set; }

        public static void EstableceUbicacion(int idUbicacion)
        {
            IdUbicacion = idUbicacion;
        }

        public static void EstableceUbicacion(int idUbicacion, string ubicacion, bool esMatriz)
        {
            IdUbicacion = idUbicacion;
            Ubicacion = ubicacion;
            EsMatriz = esMatriz;
        }

        public static void EstableceUbicacion(int idUbicacion, bool esMatriz)
        {
            IdUbicacion = idUbicacion;           
            EsMatriz = esMatriz;
        }

    }
}
