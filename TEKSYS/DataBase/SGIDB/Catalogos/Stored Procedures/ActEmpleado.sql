-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ActEmpleado]
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Nombre VARCHAR(100),
	@PathImage VARCHAR(1024) = NULL,
	@FechaDeContratacion DATE,
	@Email	VARCHAR(60) = NULL,
	@EnviarNotificaciones BIT = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	UPDATE 
	[Catalogos].[Empleados]
	 SET [Nombre] = @Nombre,
	     [FechaDeContratacion] = @FechaDeContratacion,
		 [PathImage] = @PathImage,
		 [Email] = @Email,
		 [EnviarNotificaciones] = @EnviarNotificaciones
		 WHERE Id = @Id
END