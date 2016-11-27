using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public partial class Product
    {
        public int IdFamily { get; set; }
        public int IdSubFamily { get; set; }
        public int IdModel { get; set; }
        public string Image { get; set; }
        public int IdColor { get; set; }
        public string ColorName { get; set; }
        public short IdCoin { get; set; }
        public int IdMeasure { get; set; }
        public int IdProvider { get; set; }
        public string MeasureName { get; set; }
        public string CveProvider { get; set; }
        public string CveTeknobike { get; set; }
        public bool Active { get; set; }
        public bool Internet { get; set; }
        public string SubFamilyName { get; set; }
    }
}
