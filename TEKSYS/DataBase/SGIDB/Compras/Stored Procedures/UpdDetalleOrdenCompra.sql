-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[UpdDetalleOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@IdOrdenCompra INT,
	@IdProducto INT,
	@Costo DECIMAL(18,0),
	@NPiezas INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

	
					UPDATE [Compras].[DetalleOrdenCompra]					
					
						 SET [IdProducto] = @IdProducto
						,[IdOrdenCompra] = @IdOrdenCompra
						,[Costo] = @Costo
						,[Piezas] = @NPiezas
					WHERE Id = @Id
					

END