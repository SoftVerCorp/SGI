-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[ObtDetalleOrdenCompra]
	-- Add the parameters for the stored procedure here
	@IdOrdenCompra INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
	
	
	SELECT 
	   ROW_NUMBER() OVER(ORDER BY DC.[Id] DESC) AS [Sequence]
	  ,DC.[Id]
      ,DC.[IdProducto]
	  ,p.Nombre AS Producto
	  ,P.[Description] AS ProductoDescripcion
      ,DC.[IdMarca]
	  ,MA.[Marca] as Marca
      ,DC.[IdOrdenCompra]
      ,DC.[IdProveedor]
      ,DC.[Costo]
      ,DC.[Piezas]
      ,DC.[Precio]
  FROM [SGI].[Compras].[DetalleOrdenCompra] DC
  INNER JOIN [Catalogos].[Productos] P ON DC.IdProducto = P.Id
  INNER JOIN [Catalogos].Marcas MA ON DC.IdMarca = MA.Id
  WHERE DC.[IdOrdenCompra] = @IdOrdenCompra  
	
END