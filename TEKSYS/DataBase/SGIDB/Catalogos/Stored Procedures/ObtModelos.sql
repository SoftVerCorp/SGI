-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtModelos]
	-- Add the parameters for the stored procedure here
	@Modelo AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,Modelo
	FROM Catalogos.Modelos 
	WHERE
	(@Modelo IS NULL OR @Modelo = '' OR Modelo LIKE '%'+ @Modelo +'%')
	AND Activo = 1
END