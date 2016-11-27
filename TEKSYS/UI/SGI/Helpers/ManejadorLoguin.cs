using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Helpers
{
    public static class ManejadorLoguin
    {
        public static string usuario;
        public static int idUsuario;

        public static void InicializarUsuario(string usuarioP, int idUsuarioP)
        {
            usuario = usuarioP;
            idUsuario = idUsuarioP;
        }
    }
}
