CREATE TABLE [dbo].[User]
(
	Id int identity(1,1) primary key, 
	Username nvarchar(100) not null, 
	EmailAddress nvarchar(320) not null, 
	PasswordHash nvarchar(max) not null, 
	FirstName nvarchar(50) not null,
	LastName nvarchar(50) not null,
	DateJoined datetime not null,
)
