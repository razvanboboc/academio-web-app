CREATE PROCEDURE [dbo].[spUpdateCommunity]
	@Id int,
	@Description nvarchar(1000),
	@Guidelines nvarchar(max),
	@Wiki nvarchar(max)
AS
begin
	declare @updated table ([Id] int, 
							[Name] nvarchar(60), 
							[Description] nvarchar(1000),
							[GuideLines] nvarchar(max), 
							[Wiki] nvarchar(max), 
							[DateCreated] datetime);

	update dbo.Community set 
	[Description] = @Description,
	[GuideLines] = @Guidelines,
	[Wiki] = @Wiki
		output Inserted.[Id], Inserted.[Name], Inserted.[Description], Inserted.[Guidelines], 
		       Inserted.[Wiki], Inserted.[DateCreated]
		into @updated
	where Id = @Id;

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from @updated;

end;
