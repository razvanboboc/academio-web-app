CREATE PROCEDURE [dbo].[spGetUserById]

@Id int

AS
begin
	SELECT Id Id, 
		Username Username, 
		EmailAddress EmailAddress,
		PasswordHash PasswordHash,
		FirstName FirstName, 
		LastName LastName, 
		DateJoined DateJoined 
	FROM   dbo.[user]
	WHERE  Id = @Id
End