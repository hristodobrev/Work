CREATE PROCEDURE [dbo].[add_user]
	@p_username VARCHAR(50),
	@p_password VARCHAR(50),
	@p_response_message VARCHAR(250) OUTPUT
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @p_salt UNIQUEIDENTIFIER = NEWID()
	BEGIN TRY
		
		INSERT INTO users (username, password_hash, salt)
		VALUES (@p_username, hashbytes('sha2_512', @p_password + cast(@p_salt as varchar(36))), @p_salt)

		SET @p_response_message = 'success'

	END TRY
	BEGIN CATCH
		SET @p_response_message = error_message()
	END CATCH
END