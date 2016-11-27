using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Editors;

namespace SGI.AutoCombo
{
    public class UsuariosSuggestionProvider : ISuggestionProvider
    {
        public System.Collections.IEnumerable GetSuggestions(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return null;
            }
            if (filter.Length < 1)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(filter))
            {
                return null;
            }

            List<Usuario> lst = new List<Usuario>();

            lst = Repository.UsuariosDisponiblesCache.Where(d =>
                d.Codigo.ToUpper().Contains(filter.ToUpper()) ||
                d.Nombre.ToUpper().Contains(filter.ToUpper())
                ).ToList();
            return lst;
        }
    }
}
