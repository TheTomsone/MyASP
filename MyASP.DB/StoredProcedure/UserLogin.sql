CREATE PROCEDURE [dbo].[UserLogin]
	@email VARCHAR(100),
	@pwd VARCHAR(100)
AS
BEGIN

	DECLARE @salt VARCHAR(100)
	SELECT @salt = [u_salt] FROM [dbo].[U_USER] WHERE [u_email] = @email

	DECLARE @pwdHash VARBINARY(64)
	SET @pwdHash = HASHBYTES('SHA2_512', CONCAT(@salt, @pwd, @email, [dbo].[GetSecretKey]()))

	SELECT [u_id], [u_name], [u_email], [u_role_id] FROM [dbo].[U_USER]
	WHERE [u_email] = @email AND [u_pwd_hash] = @pwdHash

END