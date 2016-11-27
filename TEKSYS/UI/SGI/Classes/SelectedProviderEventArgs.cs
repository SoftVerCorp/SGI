using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedProviderEventArgs : EventArgs
    {
        public SelectedProviderEventArgs(Provider param)
        {
            this.Item = param;
        }

        public Provider Item { get; set; }
    }
}
