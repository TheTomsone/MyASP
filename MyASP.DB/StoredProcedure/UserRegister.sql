CREATE PROCEDURE [dbo].[UserRegister]
	@email VARCHAR(100),
	@pwd VARCHAR(100),
	@username VARCHAR(100)
AS
BEGIN

	DECLARE @salt VARCHAR(100)
	SET @salt = CONCAT(NEWID(), NEWID(), NEWID())

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @email, [dbo].[GetSecretKey]()))

	INSERT INTO [dbo].[U_USER] ([u_email], [u_pwd_hash], [u_name], [u_salt]) VALUES
	(@email, @pwdHash, @username, @salt)

END
