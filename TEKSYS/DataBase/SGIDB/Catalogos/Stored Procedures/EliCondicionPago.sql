-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[EliCondicionPago] 
	-- Add the parameters for the stored procedure here
	@Id INT		
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
					--DELETE FROM [Catalogos].[Condicion_Pago]					
					--WHERE Id = @Id

					UPDATE [Catalogos].[Condicion_Pago]	 SET Activo = 0
					WHERE Id = @Id

END