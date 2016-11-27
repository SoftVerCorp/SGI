-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[InsProductos]
	-- Add the parameters for the stored procedure here
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
@Piezas INT = 0,
@Error INT OUTPUT,
@ErrorMessage VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRAN
	BEGIN
		BEGIN TRY

    -- Insert statements for procedure here
	INSERT INTO [Catalogos].[Productos]
	(
		[Id_Modelo],
		[Id_Marca],
		[Id_Familia],
		[Id_Moneda],
		[Clave_Proveedor],
		[Clave_Teknobike],
		[Sku],
		[Nombre],
		[Description],
		[Precio_Mayoreo],
		[Precio_Medio_Mayoreo],
		[Precio_Publico],
		[Costo],
		[Piezas]
	)
	VALUES 
	(
		@Id_Modelo,	
		@Id_Marca,	
		@Id_Familia ,	
		@Id_Moneda,	
		@Clave_Proveedor,
		@Clave_Teknobike ,
		@Sku ,
		@Nombre ,
		@Description,
		@Precio_Mayoreo ,
		@Precio_Medio_Mayoreo ,
		@Precio_Publico,
		@Costo,
		@Piezas
	)

	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH
	END

END