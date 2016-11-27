using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace SGI.Model
{
    public class InventarioProducto : ViewModelBase
    {
        private List<DetalleInventario> detalle;
        public Int64 IdMovimiento { get; set; }
        public string ClaveTek { get; set; }
        public string ClaveProv { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaMovimiento { get; set; }

        public string SubFamilia { get; set; }
        public string Familia { get; set; }
        public string Modelo { get; set; }
        public string Medida { get; set; }
        public string Marca { get; set; }
        public string Color { get; set; }

        public string Pedimento { get; set; }

        public List<DetalleInventario> Detalle
        {
            get { return detalle; }
            set
            {
                detalle = value;
                RaisePropertyChanged(() => Detalle);
            }
        }


    }

    public class DetalleInventario
    {
        public Int64 Id { get; set; }
        public int IDOCDetalle { get; set; }
        public Int64 IdMovimiento { get; set; }
        public string Serie { get; set; }
        public bool Vendido { get; set; }

        public string VendidoStr
        {
            get { return Vendido ? "Si" : "No"; }
        }
        public DateTime? FechaVenta { get; set; }
        public DateTime? FechaEntrada { get; set; }
    }
}
