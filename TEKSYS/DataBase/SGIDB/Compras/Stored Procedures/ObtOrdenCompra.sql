-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[ObtOrdenCompra] 
	-- Add the parameters for the stored procedure here
		
	@BeginDate DATE NULL,
	@EndDate DATE NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
					SELECT
						A.[Id],
						A.[IdProveedor],
						P.Nombre AS Proveedor,
						A.[IdEmpleadoComprador],
						E.Nombre AS EmpComprador,
						A.[IdEmpleadoValidador],
						E1.Nombre AS EmpValidador,
						A.[IdCondicionPago],
						CP.Nombre AS CondicionPago,
						A.[OrdenCompra],
						A.[FechaColocacion],
						A.[FechaValidacion],
						A.[IdStatus],
						EC.[EnviaNotificacion],
						EC.Nombre AS EstatusCompra
					FROM [Compras].[OrdenCompra] A
					INNER JOIN Catalogos.Proveedores P ON A.IdProveedor = P.Id
					INNER JOIN Catalogos.Empleados E ON A.IdEmpleadoComprador = E.Id
					INNER JOIN Catalogos.Empleados E1 ON A.IdEmpleadoValidador = E1.Id
					INNER JOIN Catalogos.Condicion_Pago CP ON A.IdCondicionPago = CP.Id
					INNER JOIN Catalogos.Estatus_Compra EC ON A.IdStatus = EC.Id
					WHERE A.FechaColocacion BETWEEN @BeginDate AND @EndDate
					AND A.Activo = 1
					
					

END