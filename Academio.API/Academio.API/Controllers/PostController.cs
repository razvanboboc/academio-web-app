using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }
        //[Authorize(Roles = "Administrator, User")]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(PostDto postDto)
        {
            var user = await _postService.Add(postDto);
            return Ok(user);
        }
    }
}
