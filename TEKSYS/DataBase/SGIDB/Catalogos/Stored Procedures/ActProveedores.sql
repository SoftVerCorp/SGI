-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ActProveedores] 
	-- Add the parameters for the stored procedure here
	@Id INT ,
	@Nombre varchar(100),
	@RFC varchar(20),
	@Direccion varchar(100) = NULL
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	UPDATE Catalogos.Proveedores
	SET Nombre = @Nombre,
		RFC = @RFC,
		Direccion = @Direccion 
		WHERE Id = @Id

		
			
	


END