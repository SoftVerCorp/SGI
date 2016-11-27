-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtMarcas]
	-- Add the parameters for the stored procedure here
	@Marcas AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,[Marca]
	FROM [Catalogos].[Marcas]
	WHERE
	(@Marcas IS NULL OR @Marcas = '' OR [Marca] LIKE '%'+ @Marcas +'%')
	AND Activo = 1
END