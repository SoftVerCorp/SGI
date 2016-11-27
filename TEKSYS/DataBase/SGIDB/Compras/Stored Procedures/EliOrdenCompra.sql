-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[EliOrdenCompra] 
	-- Add the parameters for the stored procedure here
	
	@Id INT,
	@Error INT OUTPUT,
	@ErrorMessage VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	BEGIN TRAN

		BEGIN TRY

					--DELETE FROM [Compras].HistoricoEstatusOrdenCompra
					--WHERE IdOrderBuy = @Id
	
					--DELETE FROM [Compras].DetalleOrdenCompra
					--WHERE IdOrdenCompra = @Id

					--DELETE FROM
					--[Compras].[OrdenCompra]
					--WHERE Id = @Id

					UPDATE
					[Compras].[OrdenCompra]
					SET Activo = 0
					WHERE Id = @Id
										
					COMMIT
					SET @Error = 1;
					SET @ErrorMessage = '';
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH
END