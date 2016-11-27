using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Model
{
    public class ProductoDisponible : ViewModelBase, ICloneable
    {
        private int cantidad;
        private double descuento;
        private double preciounitario;

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdUbicacion { get; set; }
        public string Ubicacion { get; set; }
        public string CveProveedor { get; set; }
        public string CveTeknobike { get; set; }
        public string Pedimento { get; set; }

        public double PrecioUnitario
        {
            get { return preciounitario; }
            set
            {
                preciounitario = value;
                RaisePropertyChanged(() => PrecioUnitario);
            }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                RaisePropertyChanged(() => Cantidad);
                RaisePropertyChanged(() => PrecioDescuento);
                RaisePropertyChanged(() => TotalProducto);
                RaisePropertyChanged(() => TotalTotal);
            }
        }

        public double Descuento
        {
            get { return descuento; }
            set
            {
                descuento = value;
                RaisePropertyChanged(() => Descuento);
            }
        }

        public double TotalProducto
        {
            get
            {
                return cantidad * preciounitario;
            }
        }

        public double PrecioDescuento
        {
            get
            {
                var totalDesc = 0.0;
                totalDesc = (descuento / 100) * TotalProducto;
                return totalDesc;
            }
        }

        public double TotalTotal
        {
            get
            {
                return TotalProducto - PrecioDescuento;
            }
        }

        public int Inventario { get; set; }



        public string Detalle
        {
            get
            {
                return String.Format("Marca: {0}, Ubicacion: {1}, CveTek: {2}, CveProv: {3}, Inventario: {4}...",
                                      Marca, Ubicacion, CveTeknobike, CveProveedor, Inventario);
            }
        }

        public string NombreMostrar
        {
            get
            {
                return String.Format("{0}, CveTek: {1}, CveProv: {2}",
                                      NombreProducto, CveTeknobike, CveProveedor);
            }
        }

        public string TipoDescuento { get; set; }

        public int IdTipoDescuento { get; set; }

        public int IdInventario { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
