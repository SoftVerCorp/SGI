using SGI.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfControls.Editors;

namespace SGI.AutoCombo
{
    public class EmpleadosProvider : ISuggestionProvider
    {
        public IEnumerable GetSuggestions(string filter)
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

            List<Empleado> lst = new List<Empleado>();

            lst = Repository.EmpleadosCache.Where(d => d.Nombre.ToUpper().Contains(filter.ToUpper())).ToList();

            return lst;
        }
    }
}
