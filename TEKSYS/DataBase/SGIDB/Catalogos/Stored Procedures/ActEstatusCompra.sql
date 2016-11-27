-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ActEstatusCompra] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Nombre varchar(60)	,
	@EnviaNotificacion BIT,
	@Error INT OUTPUT,
	@ErrorMessage VARCHAR(200) OUTPUT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	DECLARE @Counter AS INT;	

	SET @Counter = (SELECT COUNT(*) FROM [Catalogos].[Estatus_Compra] A WHERE A.EnviaNotificacion = 1);
			
				IF @Counter > 0 
					BEGIN
						SET @Error = -1	
						SET @ErrorMessage = 'Ya Existe un concepto que envia notificaciones';
					END 
				ELSE
					BEGIN

						SET @Error = 0;	
							
						UPDATE [Catalogos].[Estatus_Compra]
						SET  Nombre = @Nombre,
						     EnviaNotificacion = @EnviaNotificacion
						WHERE Id = @Id
					END   

END