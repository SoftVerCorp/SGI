using SGI.Model;
using SGI.Model.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.ViewModel.Ventas
{
    public class DetalleVentaVM
    {
        List<VentasDetalle> detalleVenta;



        public DetalleVentaVM(int idVenta)
        {
            try
            {
                detalleVenta = Repository.ObtenerVentasDetalle(idVenta);
            }
            catch (Exception ex)
            {

            }
        }


        public List<VentasDetalle> DetalleVenta
        {
            get { return detalleVenta; }
        }
    }
}
