using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Academio.DataAccess.Repositories;
using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository<Post> _postRepository;
        public PostService(IPostRepository<Post> postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<PostDto> Add(PostDto postDto)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", postDto.UserId);
            dynamicParameters.Add("@CommunityId", postDto.CommunityId);
            dynamicParameters.Add("@DatePosted", postDto.DatePosted);
            dynamicParameters.Add("@Title", postDto.Title);
            dynamicParameters.Add("@Content", postDto.Content);
            dynamicParameters.Add("@ImageSource", postDto.ImageSource);
            dynamicParameters.Add("@VideoSource", postDto.VideoSource);
            dynamicParameters.Add("@Link", postDto.Link);

            var addedPost = await _postRepository.Add(dynamicParameters, @"spAddPost");

            var addedPostDto = new PostDto()
            {
                Id = addedPost.Id,
                UserId = addedPost.UserId,
                CommunityId = addedPost.CommunityId,
                DatePosted = addedPost.DatePosted,
                Title = addedPost.Title,
                Content = addedPost.Content,
                ImageSource = addedPost.ImageSource,
                VideoSource = addedPost.VideoSource,
                Link = addedPost.Link
            };

            return addedPostDto;
        }
    }
}
