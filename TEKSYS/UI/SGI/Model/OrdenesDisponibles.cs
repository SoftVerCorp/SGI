using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SGI.Model
{
    public class OrdenesDisponibles
    {
        public int IdProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public int IdOrden { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime? FechaEntrega { get; set; }
        public string CodigoEstado { get; set; }
        public string CorreoProveedor { get; set; }
        public string CondicionPagoNombre { get; set; }

        public int IdUbicacion { get; set; }
        public string Ubicacion { get; set; }

        public int Dias { get; set; }

        public string DetalleOc { get; set; }

        public double Total { get; set; }

        public int? idGenerador { get; set; }
        public int? IdAutoriza { get; set; }
        public int? IdRecibe { get; set; }

        public string Genera { get; set; }
        public string Autoriza { get; set; }
        public string Recibe { get; set; }

        public string RutaFoto { get; set; }

        public object ImageSource
        {
            get
            {
                BitmapImage image = new BitmapImage();

                try
                {
                    var ruta = "/Resources/Images/withoutimage.png";
                    if (!String.IsNullOrEmpty(RutaFoto))
                    {
                        ruta = RutaFoto;
                    }
                    image.BeginInit();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    image.UriSource = new Uri(ruta, UriKind.Absolute);
                    image.EndInit();
                }
                catch
                {
                    return DependencyProperty.UnsetValue;
                }

                return image;
            }
        }
    }
}
