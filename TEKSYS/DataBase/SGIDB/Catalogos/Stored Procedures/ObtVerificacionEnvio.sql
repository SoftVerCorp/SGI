-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtVerificacionEnvio] 
	-- Add the parameters for the stored procedure here
	@IdStatus 	INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @Counter AS INT

	SET @Counter = (SELECT COUNT(*) FROM [Catalogos].[Estatus_Compra] A 
	WHERE  A.Id = @IdStatus AND A.EnviaNotificacion = 1)
	 
	SELECT @Counter
			

END