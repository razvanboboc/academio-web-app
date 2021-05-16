CREATE PROCEDURE [dbo].[spGetAllCommunities]

AS
begin

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from dbo.Community;

end;
