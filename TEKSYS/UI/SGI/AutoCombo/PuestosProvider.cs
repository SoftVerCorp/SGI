using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Editors;

namespace SGI.AutoCombo
{
    public class PuestosProvider : ISuggestionProvider
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

            List<Puesto> lst = new List<Puesto>();

            lst = Repository.PuestosCache.Where(d => d.Nombre.ToUpper().Contains(filter.ToUpper())).ToList();
            return lst;
        }
    }
}
