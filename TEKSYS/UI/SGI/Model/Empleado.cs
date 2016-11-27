using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Empleado
    {

        public Empleado()
        {
            this.FechaIngreso = DateTime.Now;
            this.FechaNacimiento = DateTime.Now.AddYears(-18);
            this.Id = -1;
        }

        /// <summary>
        /// Obtiene o establece el Id del empleado
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del empleado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Get or Set apellido empleado
        /// </summary>
        public string Apellidos { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FechaNacimiento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LugarNacimiento { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EstadoCivil { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Domicilio { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Ciudad { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int CP { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Telefono { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Celular { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FechaIngreso { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Puesto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public double Salario { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiasVacaciones { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int DiasVacacionesPendientes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Foto { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        public int IdPuesto { get; set; }


        public string NombreCompleto
        {
            get
            {
                return string.Format("{0} {1}", Nombre, Apellidos);
            }
        }

    }
}
