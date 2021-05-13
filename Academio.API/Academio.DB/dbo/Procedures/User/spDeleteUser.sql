CREATE PROCEDURE [dbo].[spDeleteUser]
	@Id int
AS
BEGIN
	DECLARE @Deleted table( [Id] int,
							[Username] nvarchar(100),
							[EmailAddress] nvarchar(320),
							[PasswordHash] nvarchar(MAX),
							[FirstName] nvarchar(50),
							[LastName] nvarchar(50),
							[DateJoined] datetime);

	--Delete from dbo.[user_role] 
	--where user_id = @id;

	Delete from dbo.[User]
	OUTPUT deleted.Id, deleted.Username, deleted.EmailAddress, deleted.PasswordHash, deleted.FirstName, deleted.LastName, deleted.DateJoined
	INTO @Deleted
	Where Id = @Id

	select Id Id,
		Username Username, 
		EmailAddress EmailAddress, 
		PasswordHash PasswordHash, 
		FirstName FirstName,
		LastName LastName, 
		DateJoined DateJoined
	from @Deleted
END