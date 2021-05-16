CREATE TABLE [dbo].[CommunityMember] (
    [CommunityId]     INT NOT NULL,
    [CommunityRoleId] INT NOT NULL,
    [UserId]          INT NOT NULL,
    CONSTRAINT [FK_Community_CommunityMember_Cascade] FOREIGN KEY ([CommunityId]) REFERENCES [dbo].[Community] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CommunityRole_CommunityMember_Cascade] FOREIGN KEY ([CommunityRoleId]) REFERENCES [dbo].[CommunityRole] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_User_CommunityMember_Cascade] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]) ON DELETE CASCADE,
    UNIQUE NONCLUSTERED ([CommunityId] ASC, [CommunityRoleId] ASC, [UserId] ASC)
);


