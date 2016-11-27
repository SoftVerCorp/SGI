-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtListaCorreosEmpleados]
	-- Add the parameters for the stored procedure here
		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT E.Email
	FROM [Catalogos].[Empleados] E 
	WHERE E.Activo = 1 AND E.EnviarNotificaciones = 1
END