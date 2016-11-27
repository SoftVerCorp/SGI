using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedProductEventArgs : EventArgs
    {
        public SelectedProductEventArgs(Product item)
        {
            this.SelectedProduct = item;
        }

        public Product SelectedProduct { get; set; }
    }
}
