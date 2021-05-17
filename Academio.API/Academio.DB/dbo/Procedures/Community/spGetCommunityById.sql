CREATE PROCEDURE [dbo].[spGetCommunityById]
	@Id int
AS
begin

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from dbo.[Community]
	where Id = @Id;

end;
