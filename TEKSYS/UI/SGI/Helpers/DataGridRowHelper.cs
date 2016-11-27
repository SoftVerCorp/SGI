using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

namespace SGI.Helpers
{
    public static class DataGridRowHelper
    {
        public static object GetDatagridRow(MouseButtonEventArgs e)
        {

            DependencyObject dep = (DependencyObject)e.OriginalSource;

            while ((dep != null) && !(dep is DataGridCell) && !(dep is DataGridColumnHeader))
            {
                dep = VisualTreeHelper.GetParent(dep);
            }

            if (dep == null)
                return null;

            if (dep is DataGridColumnHeader)
            {
                return null;
                // DataGridColumnHeader columnHeader = dep as DataGridColumnHeader;
                // do something
            }

            if (dep is DataGridCell)
            {
                DataGridCell cell = dep as DataGridCell;
                // do something

                while ((dep != null) && !(dep is DataGridRow))
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }

                DataGridRow row = dep as DataGridRow;

                if (row == null)
                    return null;

                return row.Item;

            }

            return null;
        }
    }
}
