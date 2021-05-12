CREATE TABLE [dbo].[Vote]
(
	Id int identity(1,1) primary key, 
	UserId int not null foreign key references [User](Id),
	PostId int foreign key references Post(Id),
	CommentId int foreign key references Comment(Id),
	VoteType nvarchar(20) not null
)
