CREATE PROCEDURE [dbo].[spGetRolesByUserId]
	@UserId int
AS
BEGIN

	IF EXISTS (select Id from dbo.[User]
			where dbo.[User].Id = @UserId)
	BEGIN
		select r.Name from
		dbo.[User] u
		INNER JOIN dbo.[UserRole] ur ON u.Id = ur.UserId
		INNER JOIN dbo.[Role] r ON ur.RoleId = r.Id
		WHERE u.Id = @UserId
	END

END