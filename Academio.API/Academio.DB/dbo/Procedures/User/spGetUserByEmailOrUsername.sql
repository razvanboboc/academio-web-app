CREATE PROCEDURE [dbo].[spGetUserByEmailOrUsername]

@EmailAddress nvarchar(320),
@Username nvarchar(100)

AS
begin

	select Id Id, 
		Username Username,
		EmailAddress EmailAddress, 
		PasswordHash PasswordHash,
		FirstName FirstName,
		LastName LastName, 
		DateJoined DateJoined
	FROM   dbo.[User]
	WHERE  EmailAddress = @EmailAddress or Username = @Username

End
