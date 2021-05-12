CREATE TABLE [dbo].[PostFlair]
(
	PostId int not null,
	FlairId int not null,
	
	foreign key (PostId) references Post(Id),
	foreign key (FlairId) references Flair(Id),
	UNIQUE (PostId, FlairId)
)
