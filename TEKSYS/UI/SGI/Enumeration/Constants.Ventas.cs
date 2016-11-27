using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Enumeration
{
    public partial class Constants
    {
        public const string GetClientesDisponibles = "Ventas.ClientesDisponibles";
        public const string GetProductosDisponibles = "Ventas.GetProductosDisponibles";
        public const string GetDescuentosDisponibles = "[Ventas].[GetDescuentosProductos]";
        public const string InsVenta = "Ventas.InsVenta";
        public const string InsVentaDetalle = "Ventas.InsVentaDetalle";
        public const string InsAbono = "VENTAS.INSERT_Abonos";

        public const string GetClientes = "Ventas.GetCliente";
        public const string InsUpdClientes = "Ventas.InsUpdCliente";
        public const string EliminarClientes = "Ventas.EliminarCliente";

        public const string ProdecureObtenerAgentes = "Catalogos.GetAgenteAduanal";
        public const string ProdecureInsertarAgentes = "Catalogos.InsertAgenteAduanal";
        public const string ProdecureEliminarAgentes = "Catalogos.DeleteAgenteAduanal";
        public const string ProdecureActualizarAgentes = "Catalogos.UpdateAgenteAduanal";

        public const string ProdecureObtenerAlmacen = "Catalogos.GetAlmacen";
        public const string ProdecureInsertarAlmacen = "Catalogos.InsertAlmacen";
        public const string ProdecureEliminarAlmacen = "Catalogos.DeleteAlmacen";
        public const string ProdecureActualizarAlmacen = "Catalogos.UpdateAlmacen";

        public const string InsTraspaso = "Inventarios.InsTraspaso";
        public const string GetTraspaso = "Inventarios.ObtenerEnTransito";
        public const string GetTraspasoDetalle = "[Inventarios].[ObtenerEnTransitoDetalle]";
        public const string InsRecepcionInventario = "Inventarios.RecibirInventario";

        public const string ProcedureGetTipoDeVenta = "[Ventas].[GetTipoDeVenta]";
        public const string ProcedureGetStatusDeVenta = "[Ventas].[GetEstatusVenta]";
        public const string ProcedureGetVentas = "[Ventas].[GetVentas]";
        public const string ProcedureGetDetalleVentas = "Ventas.GetDetalleVenta";
        public const string ProcedureGetAdeudos = "[Clientes].[GetAdeudos]";
        public const string ProcedureGetAbonos = "[VENTAS].[GetAbonos]";
        public const string ProcedureValidarLimiteDeCredito = "CLIENTES.ValidarLimiteDeCredito";
        public const string ProcedureValidarDocumentoVencido = "VENTAS.ValidarDocumentoVencido";

        public const string GetTipoPersona = "[Clientes].[GETTipoPersona]";
        public const string DeleteCliente = "[Clientes].[DeleteCliente]";
        public const string GetClientePorId = "[Clientes].[GetclientesPorId]";
        public const string InsCliente = "[Clientes].[InsertCliente]";
        public const string UpdCliente = "[Clientes].[UpdateCliente]";

        public const string SPGetEmpleados = "[Empleados].[GetEmpleados]";
        public const string SPInsEmpleado = "[Empleados].[InsEmpleado]";
        public const string SPDelEmpleado = "[Empleados].[DelEmpleado]";
        public const string SPUpdEmpleado = "[Empleados].[UpdEmpleado]";

        public const string SPGetPuestos = "[Empleados].[GetPuestos]";
        public const string SPInsPuesto = "[Empleados].[InsPuesto]";
        public const string SPDelPuesto = "[Empleados].[DelPuesto]";
        public const string SPUpdPuesto = "[Empleados].[UpdPuesto]";

        public const string SPGetChecadas = "[Empleados].[GetChecadas]";
        public const string SPGetChecadaDetalle = "[Empleados].[GetChecadasDetalle]";
        public const string SPInsChecada = "[Empleados].[InsChecada]";

    }
}
