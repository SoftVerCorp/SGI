-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtProductos]
	-- Add the parameters for the stored procedure here
	@Producto varchar(60) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	 P.Id
	,P.Nombre AS [Producto] 
	,p.[Description]
	,M.Id AS IdMarca
	,M.Marca
	,p.Id_Modelo
	,p.Id_Familia
	,p.Id_Moneda
	,p.Clave_Proveedor
    ,p.Clave_Teknobike
    ,p.Sku
	,p.Costo
	,p.Precio_Mayoreo as [Mayoreo]
	,p.Precio_Medio_Mayoreo 
	,p.Precio_Publico
	,p.Piezas
	  FROM 
	  Catalogos.Productos P INNER JOIN [Catalogos].[Marcas] M
	  ON P.Id_Marca = M.Id
	   WHERE 
	(@Producto IS NULL OR @Producto = '' OR P.Nombre = @Producto)
	AND p.Activo = 1
END