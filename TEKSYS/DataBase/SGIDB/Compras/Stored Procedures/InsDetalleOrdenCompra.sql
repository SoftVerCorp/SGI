-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Compras].[InsDetalleOrdenCompra] 
	-- Add the parameters for the stored procedure here
	@IdOrdenCompra  INT,
	@IdStatusOrderBuy AS INT,
	@String NVARCHAR(MAX),
	@Error AS int OUTPUT,
	@Message AS VARCHAR(500) OUTPUT	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here

BEGIN TRANSACTION -- O solo BEGIN TRAN

BEGIN TRY

DECLARE @Xml AS XML;

DECLARE @Counter AS INT;	
DECLARE @Handle AS  INT;
DECLARE @Version AS INT;
--DECLARE @FlagStatus AS INT;

DECLARE @TableAux AS TABLE
(
	[IdProducto] INT ,
	[IdProveedor]  INT,
	[IdMarca] INT ,
	[IdOrdenCompra] INT ,
	[Piezas] INT ,
	[Precio] DECIMAL 
)
--SET @String = '<ROOT>';
--SET @String += '<Product>';
--SET @String += '<IdProducto>1</IdProducto><IdProvider>12</IdProvider><OrderBuy>1111</OrderBuy><Pieces>0</Pieces>';
--SET @String += '</Product>';
--SET @String += '<Product>';
--SET @String += '<IdProducto>2</IdProducto><IdProvider>12</IdProvider><OrderBuy>1111</OrderBuy><Pieces>0</Pieces>';
--SET @String += '</Product></ROOT>';

SET @Xml = @String;

--SELECT @Xml;

	EXEC sp_xml_preparedocument @Handle OUTPUT,@Xml

	INSERT INTO @TableAux(IdProducto,IdProveedor,IdMarca,IdOrdenCompra,Piezas,Precio)
	SELECT 
	A.[IdProducto], 
	A.[IdProveedor],
	A.[IdMarca],
	A.[OrdenCompra],
	A.[Piezas],
	A.[Precio]
	 FROM OPENXML(@Handle,'ROOT/Product')
	WITH(
	
	[IdProducto] INT 'IdProducto',
	[IdProveedor] INT 'IdProvider',
	[IdMarca] INT 'IdTrademark',
	[OrdenCompra] INT 'OrderBuy',
	[Piezas] INT 'Pieces',
	[Precio] DECIMAL 'Price'
	)A

	SET @Counter = (SELECT COUNT(*) FROM [Compras].[DetalleOrdenCompra] a WHERE a.IdOrdenCompra = @IdOrdenCompra);
		
	IF @Counter = 0
	BEGIN

	INSERT INTO [Compras].[DetalleOrdenCompra](IdProducto,IdProveedor,IdMarca,IdOrdenCompra,Piezas,Precio)
	SELECT 
	A.[IdProducto], 
	A.[IdProveedor],
	A.[IdMarca],
	A.[IdOrdenCompra],
	A.[Piezas],
	A.[Precio]
	FROM @TableAux A

	END
	ELSE
	BEGIN

	
	DELETE FROM [Compras].[DetalleOrdenCompra]
	WHERE  Id NOT IN (
	SELECT  DC2.Id FROM @TableAux DC,[Compras].[DetalleOrdenCompra] DC2
	WHERE
	DC.IdOrdenCompra = @IdOrdenCompra
	AND DC.IdProveedor = DC2.IdProveedor
	AND DC.IdMarca = DC2.IdMarca
	AND DC.IdProducto = DC2.IdProducto
	)
	AND IdOrdenCompra = @IdOrdenCompra

	INSERT INTO [Compras].[DetalleOrdenCompra](IdProducto,IdProveedor,IdMarca,IdOrdenCompra,Piezas,Precio)
	SELECT TA.IdProducto,TA.IdProveedor,TA.IdMarca,TA.IdOrdenCompra,TA.Piezas,TA.Precio
	FROM @TableAux TA WHERE TA.IdProducto NOT IN
	(
	SELECT DC.IdProducto FROM [Compras].[DetalleOrdenCompra] DC,@TableAux TA 
	WHERE  DC.IdOrdenCompra = @IdOrdenCompra
	AND DC.IdProveedor = TA.IdProveedor
	AND DC.IdProducto = TA.IdProducto
	AND DC.IdMarca = TA.IdMarca
	)



	--SET @FlagStatus = (SELECT COUNT(*) FROM Catalogos.Estatus_Compra EC 
	--WHERE EC.Id = @IdStatusOrderBuy AND EC.EnviaNotificacion = 1)

	--IF(@FlagStatus > 0)
	--BEGIN 
	
	--UPDATE P
	--SET P.Piezas = TA.Piezas + p.Piezas
	--FROM Catalogos.Productos P
	--INNER JOIN @TableAux TA
	--ON P.Id = TA.IdProducto AND P.Id_Marca = TA.IdMarca

	UPDATE P
	SET P.Piezas = TA.Piezas
	FROM  [Compras].[DetalleOrdenCompra] P
	INNER JOIN @TableAux TA
	ON P.IdProducto = TA.IdProducto AND P.IdMarca = TA.IdMarca
	WHERE P.IdOrdenCompra = @IdOrdenCompra

	--END
	END
		
	PRINT 'SE INSERTARON DATOS EN [Catalogs].[Alarms]'

	EXEC sp_xml_removedocument @Handle

	set @Message = @String;
	
	SET @Error = 0

COMMIT TRAN

END TRY
	BEGIN CATCH

	  ROLLBACK TRANSACTION 

	SET @Error  = -1
	SET @Message = (select ERROR_MESSAGE())

   SELECT ERROR_NUMBER() AS ErrorNumber,
          ERROR_SEVERITY() AS ErrorSeverity,
          ERROR_STATE() AS ErrorState,
          ERROR_MESSAGE() AS ErrorMessage	

	END CATCH
					

END