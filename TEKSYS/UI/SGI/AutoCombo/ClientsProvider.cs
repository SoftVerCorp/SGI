using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Editors;

namespace SGI.AutoCombo
{

    public class ClientsProvider : ISuggestionProvider
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

            List<Cliente> lst = new List<Cliente>();

            lst = Repository.ClientesCache.Where(d => d.NombreComercial.ToUpper().Contains(filter.ToUpper())).ToList();
            return lst;
        }

    }

}
