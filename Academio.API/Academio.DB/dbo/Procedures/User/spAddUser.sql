CREATE PROCEDURE [dbo].[spAddUser]
	
	@Username nvarchar(100),
	@EmailAddress nvarchar(320),
	@PasswordHash nvarchar(MAX),
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@DateJoined datetime

AS
begin   

	declare @inserted table ([Id] int, [Username] nvarchar(100), [EmailAddress] nvarchar(320), [PasswordHash] nvarchar(max), [FirstName] nvarchar(50), [LastName] nvarchar(50), [DateJoined] datetime);
	
	Insert into dbo.[User]([Username], [EmailAddress], [PasswordHash], [FirstName], [LastName], [DateJoined])
	OUTPUT Inserted.[Id], Inserted.[Username], Inserted.[EmailAddress], Inserted.[PasswordHash], Inserted.[FirstName], Inserted.[LastName], Inserted.[DateJoined]
	into @inserted 
	values (@Username, @EmailAddress, @PasswordHash, @FirstName, @FirstName, @DateJoined)

	select Id Id, 
		Username Username,
		EmailAddress EmailAddress, 
		PasswordHash PasswordHash,
		FirstName FirstName,
		LastName LastName, 
		DateJoined DateJoined
	from @inserted

End  
