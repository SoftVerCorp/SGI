-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtProductosEnOferta]
	-- Add the parameters for the stored procedure here
	@Producto varchar(60) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	SELECT
	po.Id AS IdProductoPrecioOferta
	,P.[Id] AS IdProducto
	,P.[Nombre] AS Producto
	,P.[Description] AS DescripcionProducto
	,TP.Id AS IdTipoOferta
	,TP.Tipo_Oferta
    ,PO.[fecha_Inicio]
	,PO.[Fecha_Final]
	,PO.[Precio] AS PrecioOferta
	FROM
	[Productos].[Precios_Oferta] PO 
	INNER JOIN [Catalogos].[Productos] P ON PO.Id_Producto = P.Id
	INNER JOIN [Productos].[Tipo_Oferta] TP ON PO.Id_Producto_Tipo_Oferta = TP.Id	
	WHERE 
	(@Producto IS NULL OR @Producto = '' OR P.Nombre = @Producto)
END