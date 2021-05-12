CREATE TABLE [dbo].[Flair]
(
	Id int identity(1,1) primary key, 	
	CommunityId int foreign key references Community(Id),
	[Name] nvarchar(100) not null
)
