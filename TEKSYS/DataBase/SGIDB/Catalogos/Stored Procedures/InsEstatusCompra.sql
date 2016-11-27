-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[InsEstatusCompra] 
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(60),
	@EnviaNotificacion BIT,
	@Error INT OUTPUT,
	@ErrorMessage VARCHAR(200) OUTPUT		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @Counter AS INT;	

	BEGIN TRAN

		BEGIN TRY
			SET @Counter = (SELECT COUNT(*) FROM [Catalogos].[Estatus_Compra] A WHERE UPPER(LTRIM(RTRIM(A.Nombre))) =  UPPER(LTRIM(RTRIM(@Nombre))));
			
			IF @Counter > 0 
				BEGIN
					SET @Error = -1	
					SET @ErrorMessage = 'Ya Existe un concepto de pago con el mismo nombre';
				END 
			ELSE
				BEGIN

					SET @Counter = (SELECT COUNT(*) FROM [Catalogos].[Estatus_Compra] A WHERE A.EnviaNotificacion = 1);
			
					IF @Counter > 0 
						BEGIN
						SET @Error = -1	
						SET @ErrorMessage = 'Ya Existe un concepto que envia notificaciones';
					END 
					ELSE
						BEGIN
							SET @Error = 0;	
							INSERT INTO [Catalogos].[Estatus_Compra](Nombre,EnviaNotificacion)				
							VALUES(@Nombre,@EnviaNotificacion)
						END
			    END
				
	
	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH

END