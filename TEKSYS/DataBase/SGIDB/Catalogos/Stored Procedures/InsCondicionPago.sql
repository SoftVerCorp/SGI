-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[InsCondicionPago] 
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(60),
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
			SET @Counter = (SELECT COUNT(*) FROM [Catalogos].[Condicion_Pago] A WHERE UPPER(LTRIM(RTRIM(A.Nombre))) =  UPPER(LTRIM(RTRIM(@Nombre))));
			
			IF @Counter > 0 
				BEGIN
					SET @Error = -1	
					SET @ErrorMessage = 'Ya Existe un concepto de pago con el mismo nombre';
				END 
			ELSE
				BEGIN
					SET @Error = 0;

	
					INSERT INTO [Catalogos].[Condicion_Pago]	(Nombre)				
					VALUES(@Nombre)
					END
	
	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH

END