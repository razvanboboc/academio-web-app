CREATE PROCEDURE [dbo].[spGetCommunityRoleOfUser]
	@UserId int,
	@CommunityId int
AS
begin

	select CommunityRole.Id, CommunityRole.Name
	from CommunityRole
	inner join CommunityMember
	on CommunityRole.Id = CommunityMember.CommunityRoleId
	where CommunityMember.CommunityId = @CommunityId and CommunityMember.UserId  = @UserId;

end;
