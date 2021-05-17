CREATE PROCEDURE [dbo].[spGetCommunityRoleByName]
	@CommunityRoleName nvarchar(255)
AS
begin
	
	SELECT Id Id,
		Name Name 
	from dbo.CommunityRole
	where Name = @CommunityRoleName

end
