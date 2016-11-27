using SGI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Classes
{
    public class SelectedOfferTypeEventArgs : EventArgs
    {
        public OfferType OfferType { get; set; }

        public SelectedOfferTypeEventArgs(OfferType offerTypeP)
        {
            this.OfferType = offerTypeP;
        }
    }
}
