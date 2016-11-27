using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace SGI.Model
{
    public class Cliente : ViewModelBase
    {

        public Cliente()
        {
            this.IdCliente = -1;
        }

        private string foto;

        #region Cliente

        public int IdCliente { get; set; }
        public int IdTipoCliente { get; set; }
        public string TipoCliente { get; set; }
        public int IdUbicacion { get; set; }
        public string Ubicacion { get; set; }
        public int IdUsario { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime FechaModificacion { get; set; }
        public bool Incobrable { get; set; }

        #endregion

        #region Condiciones de credito

        public double SaldoInicial { get; set; }
        public double LimiteDeCredito { get; set; }
        public int DiasCredito { get; set; }
        public double SaldoDelCliente { get; set; }
        public double SaldoAFavor { get; set; }
        public double CreditoUtilizado { get; set; }
        public double TotalCreditoUtilizado { get; set; }
        public double TotalTraspaso { get; set; }
        public object Celular { get; internal set; }


        #endregion

        #region Datos Comerciales
        public string NombreComercial { get; set; }
        public string PaginaWeb { get; set; }
        public string Contacto { get; set; }
        public string TelefonoContacto { get; set; }
        public string DireccionEnvio { get; set; }
        public string Telefono1 { get; set; }
        public string Telefono2 { get; set; }
        public string Telefono3 { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }

        #endregion

        #region

        public string NombreFiscal { get; set; }
        public string Direccion { get; set; }
        public string RFC { get; set; }
        public string Colonia { get; set; }
        public string CP { get; set; }
        public string Estado { get; set; }
        public string Ciudad { get; set; }
        public string Zona { get; set; }
        public int IdTipoPersona { get; set; }
        public string TipoPersona { get; set; }

        #endregion

        #region Datos Internet

        public string Usuario { get; set; }
        public string Password { get; set; }
        public bool PermitirComprarPorInternet { get; set; }

        #endregion+

        public double DescuentoCliente { get; set; }
        public string HuellaDigital { get; set; }

        //private double limiteDeCredito;

        //public double LimiteDeCredito
        //{
        //    get { return limiteDeCredito; }
        //    set
        //    {
        //        limiteDeCredito = value;
        //        RaisePropertyChanged(() => LimiteDeCredito);
        //    }
        //}


        public string Foto
        {
            get
            {
                return foto;
            }

            set
            {
                foto = value;
                RaisePropertyChanged(() => Foto);
            }
        }

        public object ImageSource
        {
            get
            {
                BitmapImage image = new BitmapImage();

                try
                {
                    var ruta = "/Resources/Images/withoutimage.png";
                    if (!String.IsNullOrEmpty(foto))
                    {
                        ruta = foto;
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
