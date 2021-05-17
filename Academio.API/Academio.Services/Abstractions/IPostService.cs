using Academio.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface IPostService
    {
        Task<PostDto> Add(PostDto postDto);
    }
}
