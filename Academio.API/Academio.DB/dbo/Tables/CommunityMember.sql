CREATE TABLE [dbo].[CommunityMember]
(
	CommunityId int not null,
	CommunityRoleId int not null,
	UserId int not null,
	
	foreign key (CommunityId) references dbo.Community(Id),
	foreign key (CommunityRoleId) references dbo.CommunityRole(Id),
	foreign key (UserId) references dbo.[User](Id),
	UNIQUE (CommunityId, CommunityRoleId, UserId)
)
