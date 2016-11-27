namespace SGI.AutoCombo
{
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using WpfControls.Editors;

    public class ClientsSuggestionProvider : ISuggestionProvider
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

            List<ClienteVenta> lst = new List<ClienteVenta>();

            lst = Repository.ClientesDisponiblesCache.Where(d=> d.Nombre.ToUpper().Contains(filter.ToUpper())).ToList();
            return lst;
        }

    }
}
