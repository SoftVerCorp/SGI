using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Puesto
    {
        /// <summary>
        /// Identificador unico del puesto
        /// </summary>
        public int IdPuesto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Salario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Activo { get; set; }
    }
}
