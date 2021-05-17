CREATE PROCEDURE [dbo].[spDeleteCommunityMember]
	@UserId int,
	@CommunityId int
AS
begin
	
	declare @deleted table ([CommunityId] int, [UserId] int, [CommunityRoleId] int);

	delete from dbo.CommunityMember 
		output deleted.[CommunityId], deleted.[UserId], deleted.[CommunityRoleId]
		into @deleted
	where CommunityMember.UserId = @UserId and CommunityMember.CommunityId = @CommunityId;

	select 
		CommunityId,
		UserId,
		CommunityRoleId
	from @deleted;

end;