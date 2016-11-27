-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Productos].[InsPrecioOferta] 
	-- Add the parameters for the stored procedure here
	
	@Id_Producto AS INT,
	@Id_Producto_Tipo_Oferta AS INT,
	@Precio AS DECIMAL(18,0),
	@Fecha_Inicio AS DATE = NULL,
	@Fecha_Final AS DATE = NULL,			
	@Error  INT OUTPUT,
	@ErrorMessage VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	

	BEGIN TRAN

		BEGIN TRY		
						
			INSERT INTO[Productos].[Precios_Oferta]	
			(			
			[Id_Producto],
			[Id_Producto_Tipo_Oferta],
			[Precio],
			[fecha_Inicio],
			[Fecha_Final]			
			)
			VALUES
			(
			@Id_Producto ,
			@Id_Producto_Tipo_Oferta ,
			@Precio,
			@Fecha_Inicio,
			@Fecha_Final 
			)
	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH

END