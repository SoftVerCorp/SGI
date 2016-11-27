-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtEstatusCompra] 
	-- Add the parameters for the stored procedure here
	@Nombre VARCHAR(60) = NULL		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here


	SELECT A.Id,A.Nombre,A.EnviaNotificacion
	FROM [Catalogos].[Estatus_Compra] A 
	WHERE 
	(@Nombre IS NULL OR @Nombre = '' OR A.Nombre = @Nombre)
			
			

END