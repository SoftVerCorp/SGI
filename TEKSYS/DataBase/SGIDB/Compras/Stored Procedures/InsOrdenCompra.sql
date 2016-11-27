-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[InsOrdenCompra] 
	-- Add the parameters for the stored procedure here
	
	@IdProveedor INT,
	@IdEmpleadoComprador INT,
	@IdEmpleadoValidador INT,
	@IdCondicionPago INT,
	@OrdenCompra VARCHAR(30),
	@FechaColocacion DATE = NULL,
	@FechaValidacion DATE  =NULL,
	@IdStatus INT,
	@Error INT OUTPUT,
	@ErrorMessage VARCHAR(200) OUTPUT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	BEGIN TRAN

	DECLARE @IdAux AS INT

		BEGIN TRY
					INSERT INTO 
					[Compras].[OrdenCompra]
					(
						[IdProveedor],
						[IdEmpleadoComprador],
						[IdEmpleadoValidador],
						[IdCondicionPago],
						[OrdenCompra],
						[FechaColocacion],
						[FechaValidacion],
						[IdStatus]
					)
					VALUES
					(
						@IdProveedor,
						@IdEmpleadoComprador,
						@IdEmpleadoValidador,
						@IdCondicionPago,
						@OrdenCompra,
						@FechaColocacion,
						@FechaValidacion,
						@IdStatus
					)

					
					SELECT @IdAux = SCOPE_IDENTITY()

					INSERT INTO Compras.HistoricoEstatusOrdenCompra([IdOrderBuy],[IdStatus])
					VALUES(@IdAux,@IdStatus)

					SET @Error = 0	
					SET @ErrorMessage = '';
		
	COMMIT
		END TRY
		BEGIN CATCH

			ROLLBACK TRAN
			SET @Error = -1	
			SET @ErrorMessage = (SELECT ERROR_MESSAGE());
		END CATCH
END