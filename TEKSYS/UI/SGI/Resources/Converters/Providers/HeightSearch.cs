using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SGI.Resources.Converters.Providers
{
    public class HeightSearch : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            HeightRegionModel ho = value as HeightRegionModel;


            if (ho == null)
            {
                return 300;
            }

            switch (ho.FormType)
            {
                case Enumeration.FormType.ProviderView:
                    if (ho.IsExpanded)
                    {
                        return 300;
                    }
                    break;
            }


            return 0;


            //if (val)
            //{
            //    return 300;
            //}
            //else
            //{
            //    return 0;
            //}
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
