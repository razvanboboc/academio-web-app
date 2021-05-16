CREATE PROCEDURE [dbo].[spAddCommunity]
	@Name nvarchar(60),
	@Description nvarchar(1000),
	@Guidelines nvarchar(max),
	@Wiki nvarchar(max),
	@DateCreated datetime
AS
begin
	declare @inserted table ([Id] int, [Name] nvarchar(60), [Description] nvarchar(1000),
							 [GuideLines] nvarchar(max), [Wiki] nvarchar(max), [DateCreated] datetime);

	Insert into dbo.[Community]([Name], [Description], [Guidelines], [Wiki], [DateCreated])
		output Inserted.[Id], Inserted.[Name], Inserted.[Description], Inserted.[Guidelines], 
		       Inserted.[Wiki], Inserted.[DateCreated]
		into @inserted
	values(@Name, @Description, @Guidelines, @Wiki, @DateCreated)

	select Id Id,
		Name Name,
		Description Description,
		Guidelines Guidelines,
		Wiki Wiki,
		DateCreated DateCreated
	from @inserted

end;
