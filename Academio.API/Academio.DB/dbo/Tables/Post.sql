CREATE TABLE [dbo].[Post]
(
	Id int identity(1,1) primary key, 
	UserId int foreign key references [User](Id),
	CommunityId int foreign key references Community(Id),
	DatePosted datetime not null, 
	Title nvarchar(255) not null, 
	Content nvarchar(max) not null, 
	ImageSource nvarchar(max) not null, 
	VideoSource nvarchar(max) not null, 
	Link nvarchar(max) not null, 
)
