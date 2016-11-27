-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ObtCostoConcepto]
	-- Add the parameters for the stored procedure here
	@Nombre AS VARCHAR(60) = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT Id,[Concepto]
	FROM [dbo].[Costo_Concepto]
	WHERE
	(@Nombre IS NULL OR @Nombre = '' OR  [Concepto] LIKE '%'+ @Nombre +'%')
	AND ACTIVO = 1
END