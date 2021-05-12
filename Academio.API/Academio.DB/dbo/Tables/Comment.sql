CREATE TABLE [dbo].[Comment]
(
	Id int identity(1,1) primary key, 
	UserId int foreign key references [User](Id),
	PostId int foreign key references Post(Id),
	DatePosted datetime not null, 
	Content nvarchar(max) not null, 
)
