-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtEmpleado]
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(60) NULL	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT E.[Id], E.[Nombre],E.[FechaDeContratacion],E.PathImage ,E.Email,E.EnviarNotificaciones,E.Activo
	FROM [Catalogos].[Empleados] E 
	WHERE (@Nombre IS NULL OR @Nombre = '' OR E.Nombre = @Nombre)
END