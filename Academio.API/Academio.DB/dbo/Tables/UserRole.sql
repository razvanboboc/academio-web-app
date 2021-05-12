CREATE TABLE [dbo].[UserRole]
(
	UserId int not null,
	RoleId int not null,
	
	foreign key (UserId) references dbo.[User](Id),
	foreign key (RoleId) references dbo.[Role](Id),
	UNIQUE (UserId, RoleId)
)
