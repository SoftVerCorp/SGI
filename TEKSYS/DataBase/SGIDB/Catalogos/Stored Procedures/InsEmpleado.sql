-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[InsEmpleado]
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(100),
	@FechaDeContratacion DATE,
	@PathImage VARCHAR(1024) = NULL,
	@Email	VARCHAR(60) = NULL,
	@EnviarNotificaciones BIT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	INSERT INTO [Catalogos].[Empleados]([Nombre],[FechaDeContratacion],[PathImage],[Email],[EnviarNotificaciones] )
	VALUES (@Nombre,@FechaDeContratacion,@PathImage,@Email,@EnviarNotificaciones)
END