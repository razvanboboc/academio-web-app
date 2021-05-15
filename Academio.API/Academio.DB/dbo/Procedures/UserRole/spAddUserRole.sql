CREATE PROCEDURE [dbo].[spAddUserRole]
	@UserId int,
	@RoleId int
AS
BEGIN
	
	IF EXISTS (select * from dbo.[user] 
					where dbo.[User].Id = @UserId) 
	 AND EXISTS (select role.Id from dbo.[role]
					where dbo.[Role].Id = @RoleId)
	begin 
		insert into UserRole values (@UserId, @RoleId)
	end

END
