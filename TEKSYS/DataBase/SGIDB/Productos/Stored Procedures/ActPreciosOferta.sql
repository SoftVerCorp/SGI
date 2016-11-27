-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Productos].[ActPreciosOferta] 
	-- Add the parameters for the stored procedure here
	@Id INT,
	@Id_Producto INT,
	@Id_Producto_Tipo_Oferta INT,
	@Precio DECIMAL,
	@Fecha_Inicio DATE = NULL,
	@Fecha_Final DATE = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
UPDATE [Productos].[Precios_Oferta]
SET 
[Id_Producto] = @Id_Producto,
[Id_Producto_Tipo_Oferta] = @Id_Producto_Tipo_Oferta,
[Precio]= @Precio,
[fecha_Inicio] =@Fecha_Inicio ,
[Fecha_Final] =@Fecha_Final
WHERE Id = @Id
	
					

END