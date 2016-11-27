using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGI.Enumeration
{
    public partial class Constants
    {
        public const string ProcedureInsFamily = "[catalogos].[InsertFamilia]";
        public const string ProcedureInsTrademark = "[Catalogos].[InsMarcas]";
        public const string ProcedureInsProducts = "[Catalogos].[InsProductos]";
        public const string ProcedureInsModels = "[Catalogos].[InsModelos]";
        public const string ProcedureInsCoins = "[Catalogos].[InsMonedas]";
        public const string ProcedureInsOfferType = "[Productos].[Ins_Tipo_Oferta]";
        public const string ProcedureInsOfferPrice = "[Productos].[InsPrecioOferta]";
        public const string ProcedureInsCostConcept = "[dbo].[InsCostoConcepto]";
        public const string ProcedureInsUser = "[Catalogos].[InsUsuario]";
        public const string ProcedureInsProviders = "[Catalogos].[InsProveedores]";        
        public const string ProcedureInsPaymentCondition = "[Catalogos].[InsCondicionPago]";
        public const string ProcedureInsStatusBuy = "[Catalogos].[InsEstatusCompra]";
        public const string ProcedureInsOrderBuy = "[Compras].[InsOrdenCompra]";
        public const string ProcedureInsOrderBuyDetail = "[Compras].[InsDetalleOrdenCompra]";

        public const string ProcedureGetModels = "Catalogos.ObtModelos";
        public const string ProcedureGetTrademark = "Catalogos.ObtMarcas";
        public const string ProcedureGetFamilies = "Catalogos.GetFamilias";
        public const string ProcedureGetCoins = "[Catalogos].[ObtMonedas]";
        public const string ProcedureGetProducts = "[Catalogos].[ObtProductos]";
        public const string ProcedureGetProductsInOffert = "[Catalogos].[ObtProductosEnOferta]";
        public const string ProcedureGetOfferType = "[Productos].[ObtTipo_Oferta]";
        public const string ProcedureGetUser = "[Catalogos].[GetUsuario]";
        public const string ProcedureGetCostConcept = "[dbo].[ObtCostoConcepto]";
        public const string ProcedureGetProviders = "[Catalogos].[ObtProveedores]";
        
        public const string ProcedureGetPaymentCondition = "[Catalogos].[ObtCondicionPago]";
        public const string ProcedureGetStatusBuy = "[Catalogos].[ObtEstatusCompra]";
        public const string ProcedureGetOrderBuy = "[Compras].[ObtOrdenCompra]";
        public const string ProcedureGetDetailOrderBuy = "[Compras].[ObtDetalleOrdenCompra]";
        public const string ProcedureGetVerifySend = "[Catalogos].[ObtVerificacionEnvio]";
        public const string ProcedureGetEmployeeListMails = "[Catalogos].[ObtListaCorreosEmpleados]";

        public const string ProcedureDelProduct = "[Catalogos].[EliProductos]";
        public const string ProcedureDelFamily = "[catalogos].[DeleteFamilias]";
        public const string ProcedureDelTrademark = "[Catalogos].[EliMarcas]";
        public const string ProcedureDelModels = "[Catalogos].[EliModelos]";
        public const string ProcedureDelCoins = "[Catalogos].[EliMonedas]";
        public const string ProcedureDelPriceOffert = "[Productos].[EliPreciosOferta]";
        public const string ProcedureDelCosteConcept = "[dbo].[EliCostoConcepto]";
        public const string ProcedureDelProviders = "[Catalogos].[EliProveedores]";        
        public const string ProcedureDelPaymentCondition = "[Catalogos].[EliCondicionPago]";
        public const string ProcedureDelStatusBuy = "[Catalogos].[EliEstatusCompra]";
        public const string ProcedureDelOrderBuy = "[Compras].[EliOrdenCompra]";
        public const string ProcedureDelOfferType = "[Productos].[Eli_Tipo_Oferta]";

        public const string ProcedureUpdProduct = "[Catalogos].[ActProductos]";
        public const string ProcedureUpdFamily = "[catalogos].[UpdateFamilia]";
        public const string ProcedureUpdTrademark = "[Catalogos].[ActMarcas]";
        public const string ProcedureUpdModels = "[Catalogos].[ActModelos]";
        public const string ProcedureUpdCoins = "[Catalogos].[ActMonedas]";
        public const string ProcedureUpdPriceOffert = "[Productos].[ActPreciosOferta]";
        public const string ProcedureUpdCosteConcept = "[dbo].[ActCostoConcepto]";
        public const string ProcedureUpdProviders = "[Catalogos].[ActProveedores]";        
        public const string ProcedureUpdPaymentCondition = "[Catalogos].[ActCondicionPago]";
        public const string ProcedureUpdStatusBuy = "[Catalogos].[ActEstatusCompra]";
        public const string ProcedureUpdOrderBuy = "[Compras].[ActOrdenCompra]";
        public const string ProcedureUpdOffertType = "[Productos].[Act_Tipo_Oferta]";


        public const string ProcedureGetMarcas = "catalogos.GetMarcas";
        public const string ProcedureInsertMarcas = "catalogos.InsertMarcas";
        public const string ProcedureUpdateMarca = "catalogos.UpdateMarca";
        public const string ProcedureDeleteMarca = "catalogos.DeleteMarca";


        public const string ProcedureGetColores = "catalogos.GetColores";
        public const string ProcedureInsertColor = "catalogos.InsertColor";
        public const string ProcedureUpdateColor = "catalogos.UpdateColor";
        public const string ProcedureDeleteColor = "catalogos.DeleteColor";

        public const string ProcedureGetMedidas = "catalogos.GetMedidas";
        public const string ProcedureInsertMedida = "catalogos.InsertMedida";
        public const string ProcedureUpdateMedida = "catalogos.UpdateMedida";
        public const string ProcedureDeleteMedida = "catalogos.DeleteMedida";

        public const string ProcedureGetSubFamilias = "catalogos.GetSubFamilias";
        public const string ProcedureInsertSubFamilia = "catalogos.InsertSubFamilia";
        public const string ProcedureUpdateSubFamilia = "catalogos.UpdateSubFamilia";
        public const string ProcedureDeleteSubFamilia = "catalogos.DeleteSubFamilia";

        public const string ProcedureGetModelos = "catalogos.GetModelo";
        public const string ProcedureInsertModelo = "catalogos.InsertModelo";
        public const string ProcedureUpdateModelo = "catalogos.UpdateModelo";
        public const string ProcedureDeleteModelo = "catalogos.DeleteModelo";

        public const string ProcedureGetProductos = "catalogos.GetProductos";
        public const string ProcedureInsertProducto = "catalogos.InsertProducto";
        public const string ProcedureUpdateProducto = "catalogos.UpdateProducto";
        public const string ProcedureDeleteProducto = "catalogos.DeleteProducto";

        public const string ProcedureGetSuppliers = "catalogos.GetSuppliers";
        public const string ProcedureGetTypePay = "catalogos.GetTypePay";

        public const string ProcedureInsertOrderBuy = "catalogos.InsertOrderBuy";
        public const string ProcedureInsertOrderBuyDetail = "catalogos.InsertOrderBuyDetail";

        public const string ProcedureGetOC = "catalogos.GetOC";
        public const string ProcedureGetOCDetalle = "catalogos.GetOCDetalle";
        public const string ProcedureUpdateEstatusOC = "catalogos.UpdateEstatusOC";
        public const string ProcedureGetOCLastId = "catalogos.GetOCLastId";
        public const string ProcedureGetOCDLastId = "catalogos.GetOCDLastId";
        public const string ProcedureObtenerOrdenesDisp = "compras.ObtenerOrdenesDisponibles";
        public const string ProcedureObtenerDetalleOC = "compras.ObtenerDetalleOrden";
        public const string ProcedureActualizarEstadoOrden = "Compras.ActualizarEstadoOrden";

        public const string ProcedureActualizarInventario = "Compras.ActualizarInventario";
        public const string ProcedureObtenerUbicacion = "Compras.ObtenerAlmacenes";
        public const string ProcedureObtenerInventario = "inventarios.ObtenerInventario";
        public const string ProcedureObtenerTipoMovInventario = "[Inventarios].[ObtenerTipoMovInv]";
        public const string ProcedureObtenerHistMovInventario = "[Inventarios].[ObtenerHistoricoMovInv]";
        public const string ObtenerUsuarios = "[catalogos].[ObtenerUsuarios]";
        public const string AdminProveedores = "Catalogos.AdminProveedor";
        public const string AdminUsuarios = "Catalogos.AdminUsuarios";
        public const string ActualizarDetalleInv = "[Inventarios].[ActualizarDetalleInventario]";
        public const string DetalleInventarioById = "Inventarios.ObtenerDetalleInv";
        public const string eliminarDetalle = "compras.EliminarDetalle";

        public const string ProdecureObtenerTipoDeCliente = "Catalogos.GetTipoDeCliente";
        public const string ProdecureInsertarTipoDeCliente = "Catalogos.InsertTipoDeCliente";
        public const string ProdecureEliminarTipoDeCliente = "Catalogos.DeleteTipoDeCliente";
        public const string ProdecureActualizarTipoDeCliente = "Catalogos.UpdateTipoDeCliente";

        public const string ProdecureObtenerConceptoImportacion = "[Catalogos].[GetConceptos_Importacion]";
        public const string ProdecureInsertarConceptoImportacion = "[Catalogos].[InsertConceptos_Importacion]";
        public const string ProdecureEliminarConceptoImportacion = "[Catalogos].[DeleteConceptos_Importacion]";
        public const string ProdecureActualizarConceptoImportacion = "[Catalogos].[UpdateConceptos_Importacion]";

        public const string ProdecureInsertarGastosDeImportacion = "Compras.InsertGastos_Importacion";
        public const string ProdecureObtenerGastosDeImportacion = "Compras.GetGastosDeImportacion";
        public const string ProdecureObtenerGastosDeImportacionDetalle = "Compras.GetGastosDeImportacionDetalle";

        public const string ProdecureObtenerPaqueterias = "Catalogos.GetPaqueterias";
        public const string ProdecureInsertarPaqueterias = "Catalogos.InsertPaqueteria";
        public const string ProdecureEliminarPaqueterias = "Catalogos.DeletePaqueteria";
        public const string ProdecureActualizarPaqueterias = "Catalogos.UpdatePaqueteria";

        public const string ProdecureObtenerOCPorProveedor = "[compras].[GetOrdenesDeCompraPorProveedor]";
        public const string ProdecureInsertarOCHomologada = "[catalogos].[InsertOrdenDeCpmpraHomologada]";
        public const string ProdecureEliminarOCPorHomologacion = "[catalogos].[DeleteOrdenDeCompraYDetalle]";

        public const string ProdecureObtenerPedimentoXProducto = "[Inventarios].[GetPedimentoPorProducto]";
        public const string ProdecureTotalProductosInventario = "Inventarios.GetTotalProducosEnInventario";


        public const string ProdecureObtenerTipoUsuario = "Catalogos.GetTipoUsuarios";

        public const string ProcedureObtenerTipoNotificacion = "Catalogos.GetTipoNotificacion";
        public const string ProcedureInsertarUsuarioTipoNotificacion = "[Correos].[InsertUsuario_Notificacion_Correo]";
        public const string ProcedureObtenerCorreosPorTipoNotificacion = "CORREOS.ObtenerCorreosPorTipoNotificacion";
        public const string ProcedureObtenerUsuariosPorNotificacion = "Correos.GetCorreosPorNotificacion";

        public const string ProdecureObtenerTipoDocumento = "CATALOGOS.GetTipoDocumento";
        public const string ProdecureInsertOrdenCompraAdjuntos = "Compras.InsertOrdenCompraAdjuntos";
        public const string ProdecureGetAdjuntosPorOrdenDeCompra = "Compras.GetAdjuntosPorOrdenDeCompra";

    }
}
