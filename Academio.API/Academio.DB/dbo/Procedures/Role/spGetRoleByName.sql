CREATE PROCEDURE [dbo].[spGetRoleByName]
	@Name nvarchar(50) 
AS
begin
	SELECT Id Id, 
		Name Name
	from dbo.Role
	where Name = @Name
end 
