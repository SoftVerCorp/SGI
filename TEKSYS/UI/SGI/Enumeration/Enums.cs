using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Enumeration
{
    public enum Operation
    {
        None,
        Update,
        Create
    }

    public enum FormType
    {
        ProviderView
    }

    public enum RegionType
    {
        New,
        Search,
    }

    public enum TiposDeNotificacion
    {
        Ninguna,
        GeneracionOrdenDeCompra
    }

    public enum TipoDeVentaEnum
    {
        Contado = 1,
        Credito = 2
    }

    public enum EstatusVentaEnum
    {
        Abierta = 1,
        Pagada = 2
    }
}
