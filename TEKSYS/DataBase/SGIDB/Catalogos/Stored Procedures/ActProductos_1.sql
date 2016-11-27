-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ActProductos]
	-- Add the parameters for the stored procedure here
@Id_Producto AS INT,	
@Id_Modelo AS INT,	
@Id_Marca AS INT,	
@Id_Familia AS INT,	
@Id_Moneda AS INT,	
@Clave_Proveedor VARCHAR(50) = NULL,
@Clave_Teknobike VARCHAR(50),
@Sku VARCHAR(50),
@Nombre VARCHAR(50),
@Description VARCHAR(50) = NULL,
@Precio_Mayoreo  DECIMAL(18,0) = NULL,
@Precio_Medio_Mayoreo  DECIMAL(18,0) = NULL,
@Precio_Publico  DECIMAL(18,0) = NULL,
@Costo  DECIMAL(18,0) = NULL,
@Piezas INT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	

    -- Insert statements for procedure here
	UPDATE [Catalogos].[Productos]	
		SET [Id_Modelo] = @Id_Modelo,
		 [Id_Marca]= @Id_Marca,
		 [Id_Familia]= @Id_Familia,
		 [Id_Moneda]= @Id_Moneda,
		 [Clave_Proveedor]= @Clave_Proveedor,
		 [Clave_Teknobike]= @Clave_Teknobike ,
		 [Sku]= @Sku,
		 [Nombre]= @Nombre,
		 [Description]= @Description,
		 [Precio_Mayoreo]= @Precio_Mayoreo,
		 [Precio_Medio_Mayoreo]= @Precio_Medio_Mayoreo,
		 [Precio_Publico]=@Precio_Publico ,
		 [Costo]= @Costo,
		 [Piezas] = @Piezas
	WHERE ID = @Id_Producto

	

END