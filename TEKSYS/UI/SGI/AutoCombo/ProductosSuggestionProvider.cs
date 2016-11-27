namespace SGI.AutoCombo
{
    using Model;
    using System.Collections.Generic;
    using System.Linq;
    using WpfControls.Editors;

    public class ProductosSuggestionProvider : ISuggestionProvider
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

            List<ProductoDisponible> lst = new List<ProductoDisponible>();

            lst = Repository.ProductosDisponiblesCache.Where(d =>
                d.NombreProducto.ToUpper().Contains(filter.ToUpper()) ||
                d.CveProveedor.ToUpper().Contains(filter.ToUpper()) ||
                d.CveTeknobike.ToUpper().Contains(filter.ToUpper()) 
                ).ToList();
            return lst;
        }

    }
}
