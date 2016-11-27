-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Productos].[Act_Tipo_Oferta] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Nombre varchar(60)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
	UPDATE Productos.Tipo_Oferta SET Tipo_Oferta = @Nombre
	WHERE Id = @Id


END