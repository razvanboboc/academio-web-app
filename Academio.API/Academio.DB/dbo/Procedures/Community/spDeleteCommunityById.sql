CREATE PROCEDURE [dbo].[spDeleteCommunityById]
	@Id int
AS
begin
	
	declare @deleted table ([Id] int, [Name] nvarchar(60), [Description] nvarchar(1000),
							 [Guidelines] nvarchar(max), [Wiki] nvarchar(max), [DateCreated] datetime);

	Delete from dbo.[Community]
		OUTPUT deleted.Id, deleted.Name, deleted.Description, deleted.Guidelines, deleted.Wiki, deleted.DateCreated
		INTO @deleted
	Where Id = @Id;

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from @deleted;

end;
