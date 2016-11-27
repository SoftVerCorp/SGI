-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[EliCostoConcepto]
	-- Add the parameters for the stored procedure here
	@Id INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	--DELETE FROM [dbo].[Costo_Concepto]
	--WHERE
	--Id = @Id

	UPDATE [dbo].[Costo_Concepto] SET Activo = 0
	WHERE Id = @Id
END