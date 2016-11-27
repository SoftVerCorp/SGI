using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ArchivoAdjunto
    {

        public int idTipo { get; set; }

        public string TipoArchivo { get; set; }

        public string Extension { get; set; }

        public string NombreArchivo { get; set; }

        public string RutaArchivo { get; set; }

        public int IdOC { get; set; }
    }
}
