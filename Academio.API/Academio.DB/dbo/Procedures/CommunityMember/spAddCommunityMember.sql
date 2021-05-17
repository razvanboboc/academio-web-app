CREATE PROCEDURE [dbo].[spAddCommunityMember]
	@CommunityId int,
	@UserId int,
	@CommunityRoleId int
AS
begin
	
	declare @inserted table ([CommunityId] int, [UserId] int, [CommunityRoleId] int);

	insert into dbo.CommunityMember ([CommunityId], [UserId], [CommunityRoleId])
		output Inserted.[CommunityId], Inserted.[UserId], Inserted.[CommunityRoleId]
		into @inserted
	values (@CommunityId, @UserId, @CommunityRoleId)

	select 
		CommunityId,
		UserId,
		CommunityRoleId
	from @inserted

end;