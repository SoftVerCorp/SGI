-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[ActOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@IdProveedor INT,
	@IdEmpleadoComprador INT,
	@IdEmpleadoValidador INT,
	@IdCondicionPago INT,
	@OrdenCompra VARCHAR(30),
	@FechaColocacion DATE NULL,
	@FechaValidacion DATE = NULL,
	@IdStatus INT,
	@Error AS int OUTPUT,
	@Message AS VARCHAR(500) OUTPUT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	BEGIN TRANSACTION -- O solo BEGIN TRAN

BEGIN TRY
    -- Insert statements for procedure here
	DECLARE @FlagStatus AS INT;
	
					UPDATE 
					[Compras].[OrdenCompra]
					SET 
					[IdProveedor] = @IdProveedor,
					[IdEmpleadoComprador] = @IdEmpleadoComprador,
					[IdEmpleadoValidador] = @IdEmpleadoComprador,
					[IdCondicionPago] = @IdCondicionPago,
					[OrdenCompra] = @OrdenCompra,
					[FechaColocacion] = @FechaColocacion,
					[FechaValidacion] = @FechaValidacion,
					[IdStatus] = @IdStatus
					WHERE Id = @Id

					SET @FlagStatus = (SELECT COUNT(*) FROM Catalogos.Estatus_Compra EC 
					WHERE EC.Id = @IdStatus AND EC.EnviaNotificacion = 1)

					IF @FlagStatus > 0
					BEGIN
					SELECT 1

					UPDATE P
					SET P.Piezas = TA.Piezas + p.Piezas
					FROM Catalogos.Productos P
					INNER JOIN Compras.DetalleOrdenCompra TA
					ON P.Id = TA.IdProducto AND P.Id_Marca = TA.IdMarca
					WHERE TA.IdOrdenCompra = @Id

					END
	--				UPDATE P
	--SET P.Piezas = TA.Piezas + p.Piezas
	--FROM Catalogos.Productos P
	--INNER JOIN @TableAux TA
	--ON P.Id = TA.IdProducto AND P.Id_Marca = TA.IdMarca

					SET @Error  = 0;
					SET @Message = '';
					COMMIT TRAN

END TRY
	BEGIN CATCH

	  ROLLBACK TRANSACTION 

	SET @Error  = -1
	SET @Message = (select ERROR_MESSAGE())

   SELECT ERROR_NUMBER() AS ErrorNumber,
          ERROR_SEVERITY() AS ErrorSeverity,
          ERROR_STATE() AS ErrorState,
          ERROR_MESSAGE() AS ErrorMessage	

	END CATCH
END