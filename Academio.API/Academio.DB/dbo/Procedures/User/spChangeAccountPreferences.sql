CREATE PROCEDURE [dbo].[spChangeAccountPreferences]
	@Id int,
	@EmailAddress nvarchar(320),
	@PasswordHash nvarchar(max),
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
begin  

	DECLARE @Updated table( [Id] int,
							[Username] nvarchar(100),
							[EmailAddress] nvarchar(320),
							[PasswordHash] nvarchar(max),
							[FirstName] nvarchar(50),
							[LastName] nvarchar(50),
							[DateJoined] datetime);
	update dbo.[User] set
	[EmailAddress] = @EmailAddress,
	[PasswordHash] = @PasswordHash,
	[FirstName] = @FirstName,
	[LastName] = @LastName
	OUTPUT Inserted.[Id], Inserted.[Username], Inserted.[EmailAddress], Inserted.[PasswordHash], Inserted.[FirstName], Inserted.[LastName], Inserted.[DateJoined]
	INTO @Updated
	Where Id = @Id

	select Id Id, 
		Username Username,
		EmailAddress EmailAddress, 
		PasswordHash PasswordHash,
		FirstName FirstName,
		LastName LastName, 
		DateJoined DateJoined
	from @Updated

End  