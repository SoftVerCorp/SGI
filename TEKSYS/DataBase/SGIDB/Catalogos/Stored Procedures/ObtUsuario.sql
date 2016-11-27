-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [Catalogos].[ObtUsuario]
	-- Add the parameters for the stored procedure here
	@UserName varchar(60),
	@PassWord nvarchar(300)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	DECLARE @PassResult VARCHAR(300)
	DECLARE @UserExist INT

	SET @PassResult = ( SELECT CONVERT(VARCHAR(300), DECRYPTBYPASSPHRASE('password',c.[Password]))
	FROM Catalogos.Usuarios c
	WHERE C.IdUsuario = @UserName)

	IF @PassResult = @PassWord
	SET @UserExist = 1
	ELSE
	SET @UserExist = 0

	SELECT @UserExist
END