using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model.Entidades
{
    public class TipoDocumentos
    {
        /// <summary>
        /// Obtiene o establece el id del tipo de documento
        /// </summary>
        public int IdDocumento { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del tipo de documento
        /// </summary>
        public string Nombre { get; set; }
    }
}
