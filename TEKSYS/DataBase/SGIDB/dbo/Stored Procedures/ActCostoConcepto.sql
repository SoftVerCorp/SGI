-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[ActCostoConcepto] 
	-- Add the parameters for the stored procedure here
	@Id INT ,
	@Nombre varchar(60)
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

		UPDATE [dbo].[Costo_Concepto]
	SET  [Concepto] = @Nombre
	WHERE
	Id = @Id
			
	


END