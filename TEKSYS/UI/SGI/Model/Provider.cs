using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Provider
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Rfc { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// Gets or sets the correo.
        /// </summary>
        /// <value>
        /// The correo.
        /// </value>
        public string Correo { get; set; }

        public int IdTipoPago { get; set; }

        public int CantidadDeDias { get; set; }

        public string TipoPago { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
