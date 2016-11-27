using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ProductoDetalle : ViewModelBase
    {
        public int cantidad;

        public int IdProducto { get; set; }

        public string Producto { get; set; }

        public string Pedimento { get; set; }

        public int IdUbicacionOrigen { get; set; }

        public int Cantidad
        {
            get
            {
                return cantidad;
            }
            set
            {
                if (value <= CantidadDisponible)
                {
                    cantidad = value;
                }
                else
                {
                    cantidad = CantidadDisponible;
                }
                RaisePropertyChanged(() => Cantidad);
            }
        }

        public int CantidadDisponible { get; set; }

        public int IdUbicacionDestino { get; set; }

        public int IdPaqueteria { get; set; }

        public int IdInventario { get; set; }

        public DateTime FechaSalida { get; set; }

        public DateTime? FechaEntrega { get; set; }

        public string Paqueteria { get; set; }

        public string Origen { get; set; }

        public string Destino { get; set; }

        public string Guia { get; set; }

    }
}
