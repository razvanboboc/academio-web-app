CREATE TABLE [dbo].[Community]
(
	Id int identity(1,1) primary key, 
	[Name] nvarchar(60) not null, 
	[Description] nvarchar(1000), 
	Guidelines nvarchar(max), 
	Wiki nvarchar(max),
	DateCreated datetime not null,
)
