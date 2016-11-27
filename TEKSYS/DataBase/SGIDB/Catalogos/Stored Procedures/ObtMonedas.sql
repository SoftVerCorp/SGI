-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtMonedas]
	-- Add the parameters for the stored procedure here
	@Monedas AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,[Moneda]
	FROM [Catalogos].[Monedas]
	WHERE
	(@Monedas IS NULL OR @Monedas = '' OR [Moneda] LIKE '%'+ @Monedas +'%')
	AND Activo = 1
END