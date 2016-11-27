using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class Usuario : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Correo { get; set; }

        public int IdUbicacion { get; set; }

        public string Ubicacion { get; set; }

        public int IdTipoUsuario { get; set; }

        public string TipoUsuario { get; set; }


        public string Password { get; set; }

        private string foto;

        /// <summary>
        /// Gets or sets the correo.
        /// </summary>
        /// <value>
        /// The correo.
        /// </value>
        public string Foto
        {
            get { return foto; }
            set
            {
                foto = value;
                RaisePropertyChanged(() => Foto);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool Active { get; set; }
    }
}
