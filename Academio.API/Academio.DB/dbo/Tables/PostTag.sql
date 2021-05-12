CREATE TABLE [dbo].[PostTag]
(
	PostId int not null,
	TagId int not null,
	
	foreign key (PostId) references Post(Id),
	foreign key (TagId) references Tag(Id),
	UNIQUE (PostId, TagId)
)
