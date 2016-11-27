-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Productos].[ObtTipo_Oferta]
	-- Add the parameters for the stored procedure here
	@TipoOferta AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,Tipo_Oferta
	FROM [Productos].[Tipo_Oferta]
	WHERE
	(@TipoOferta IS NULL OR @TipoOferta = '' OR Tipo_Oferta LIKE '%'+ @TipoOferta +'%')
	AND Activo = 1
END