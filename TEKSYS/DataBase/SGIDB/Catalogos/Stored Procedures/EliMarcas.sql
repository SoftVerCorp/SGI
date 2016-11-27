-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[EliMarcas]
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	--DELETE FROM [Catalogos].[Marcas]
	--WHERE
	--Id = @Id

	UPDATE Catalogos.Marcas SET Activo = 0 WHERE Id = @Id
END