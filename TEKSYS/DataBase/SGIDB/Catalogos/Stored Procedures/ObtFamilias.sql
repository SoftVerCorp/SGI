-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtFamilias]
	-- Add the parameters for the stored procedure here
	@Familia AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,Familia
	FROM Catalogos.Familias
	WHERE
	(@Familia IS NULL OR @Familia = '' OR Familia LIKE '%'+ @Familia +'%')
	AND Activo = 1
END