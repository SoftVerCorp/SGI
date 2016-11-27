-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[EliFamilias]
	-- Add the parameters for the stored procedure here
	@Id INT
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	--DELETE FROM Catalogos.Familias WHERE Id = @Id
	UPDATE Catalogos.Familias SET Activo = 0 WHERE Id = @Id
END