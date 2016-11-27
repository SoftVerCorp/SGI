using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Sexo
    {
        public Sexo(string nombre)
        {
            this.Nombre = nombre;
        }
        public string Nombre { get; set; }
    }

    public class EstadoCivil
    {
        public EstadoCivil(string nombre)
        {
            this.Nombre = nombre;
        }

        public string Nombre { get; set; }
    }
}
