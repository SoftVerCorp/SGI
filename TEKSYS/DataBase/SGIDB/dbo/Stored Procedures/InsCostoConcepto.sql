-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[InsCostoConcepto] 
	-- Add the parameters for the stored procedure here
	@Nombre varchar(60),
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
			SET @Counter = (SELECT COUNT(*) FROM dbo.Costo_Concepto a WHERE a.Concepto like '%'+ @Nombre+'%' );
			
			IF @Counter > 0 
				BEGIN
					SET @Error = -1	
					SET @ErrorMessage = 'Ya Existe un elemento con el mismo nombre';
				END 
			ELSE
				BEGIN
					SET @Error = 0;
					INSERT INTO dbo.Costo_Concepto (Concepto) VALUES(@Nombre);
					
				END
	
	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH
	


END