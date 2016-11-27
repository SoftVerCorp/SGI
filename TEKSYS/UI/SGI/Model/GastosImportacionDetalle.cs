using SGI.Stuffs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class GastosImportacionDetalle : ViewModelBase
    {
        #region Private Fields

        private double costoEstimado;
        private DateTime? fechaCostoEstimado;
        private double costoReal;
        private DateTime? fechaCostoReal;



        #endregion

        public int IdConcepto { get; set; }

        public string Concepto { get; set; }



        public double CostoEstimado
        {
            get { return costoEstimado; }
            set
            {
                if (costoEstimado != value)
                {
                    costoEstimado = value;
                    RaisePropertyChanged(() => CostoEstimado);
                }
            }
        }

        public DateTime? FechaCostoEstimado
        {
            get { return fechaCostoEstimado; }
            set
            {
                if (fechaCostoEstimado != value)
                {
                    fechaCostoEstimado = value;
                    RaisePropertyChanged(() => FechaCostoEstimado);
                }
            }
        }

        public double CostoReal
        {
            get { return costoReal; }
            set
            {
                if (costoReal != value)
                {
                    costoReal = value;
                    RaisePropertyChanged(() => CostoReal);
                }
            }
        }

        public DateTime? FechaCostoReal
        {
            get { return fechaCostoReal; }
            set
            {
                if (fechaCostoReal != value)
                {
                    fechaCostoReal = value;
                    RaisePropertyChanged(() => FechaCostoReal);
                }
            }
        }

    }
}
