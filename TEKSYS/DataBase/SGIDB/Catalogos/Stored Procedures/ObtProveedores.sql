-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtProveedores]
	-- Add the parameters for the stored procedure here
	@Nombre varchar(60) null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
	 P.[Id]
	,P.[Nombre]
	,P.[RFC]
	,P.[Direccion]

	  FROM 
	  [Catalogos].[Proveedores] P 
	   WHERE 
	(@Nombre IS NULL OR @Nombre = '' OR P.Nombre = @Nombre)
	AND Activo = 1
END