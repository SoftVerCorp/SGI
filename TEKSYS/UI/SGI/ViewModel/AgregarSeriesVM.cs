using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using SGI.Model;

namespace SGI.ViewModel
{
    public class AgregarSeriesVM : ViewModelBase
    {
        private DetalleOrdenCompraModel detalle;

        public DetalleOrdenCompraModel Detalle
        {
            get { return detalle; }
            set 
            {
                detalle = value;
                RaisePropertyChanged(()=> Detalle);
            }
        }

        public AgregarSeriesVM(DetalleOrdenCompraModel model)
        {
            if (model.Series == null)
            {
                model.Series = new Dictionary<int, SerieModel>();
                for (int i = 0; i < model.Recibido; i++ )
                {
                    model.Series.Add(i, new SerieModel() { Nombre = "Producto " + (i + 1).ToString(), Valor = "" });
                }
            }
            else if(model.Recibido != model.Quantity)
            {
                model.Series = new Dictionary<int, SerieModel>();
                for (int i = 0; i < model.Recibido; i++)
                {
                    model.Series.Add(i, new SerieModel() { Nombre = "Producto " + (i + 1).ToString(), Valor = "" });
                }
            }
            else
            {

            }

            this.Detalle = model;
        }

    }
}
