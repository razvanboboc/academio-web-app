CREATE PROCEDURE [dbo].[spAddPost]
	@UserId int,
	@CommunityId int,
	@DatePosted datetime,
	@Title nvarchar(255),
	@Content nvarchar(Max),
	@ImageSource nvarchar(Max),
	@VideoSource nvarchar(Max),
	@Link nvarchar(Max)
AS
begin 

	declare @inserted table([Id] int,
							[UserId] int,
							[CommunityId] int,
							[DatePosted] datetime,
							[Title] nvarchar(255),
							[Content] nvarchar(Max),
							[ImageSource] nvarchar(Max),
							[VideoSource] nvarchar(Max),
							[Link] nvarchar(Max));

	insert into dbo.Post([UserId],
						 [CommunityId],
						 [DatePosted], 
						 [Title],
						 [Content],
						 [ImageSource],
						 [VideoSource],
						 [Link])

		 output inserted.[Id],
				inserted.[UserId],
				inserted.[CommunityId],
				inserted.[DatePosted],
				inserted.[Title],
				inserted.[Content],
				inserted.[ImageSource],
				inserted.[VideoSource],
				inserted.[Link]
		 into @inserted

						 values(
						 @UserId,
						 @CommunityId,
						 @DatePosted,
						 @Title,
						 @Content,
						 @ImageSource,
						 @VideoSource,
						 @Link);

	select * from @inserted;

end;