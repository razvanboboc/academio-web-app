CREATE PROCEDURE [dbo].[spGetCommunityByName]
	@Name nvarchar(60)
AS
begin

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from dbo.Community
	where Name = @Name;

end;
