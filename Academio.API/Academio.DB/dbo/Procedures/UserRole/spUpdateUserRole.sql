
CREATE PROCEDURE [dbo].[spUpdateUserRole]
	@UserId int,
	@RoleId int 
AS
BEGIN

	IF EXISTS (select Id from dbo.[Role]
			where dbo.[Role].Id = @RoleId) AND
	   EXISTS (select id from dbo.[User]
			where dbo.[User].Id = @UserId)
	BEGIN
		UPDATE UserRole
		SET UserRole.RoleId= @RoleId
		WHERE UserRole.UserId= @UserId
	END

END

