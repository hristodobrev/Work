CREATE PROCEDURE dbo.user_login
	@p_username VARCHAR(50),
	@p_password VARCHAR(50),
	@p_response_message VARCHAR(250) = '' OUTPUT
AS
BEGIN
	SET NOCOUNT ON

	DECLARE @p_user_id INT
	IF EXISTS (SELECT id FROM users WHERE username = @p_username)
	BEGIN
		SET @p_user_id = (SELECT id FROM users WHERE username = @p_username AND password_hash = HASHBYTES('sha2_512', @p_password + CAST(salt AS VARCHAR(36))))

		IF(@p_user_id IS NULL)
			SET @p_response_message = 'Incorrect password'
		ELSE
			SET @p_response_message = 'User successfully logged in'
	END
	ELSE
		SET @p_response_message = 'Invalid login'
END