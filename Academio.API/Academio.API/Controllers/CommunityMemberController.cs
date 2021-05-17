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
    public class CommunityMemberController : ControllerBase
    {
        private readonly ICommunityMemberService _communityMemberService;
        public CommunityMemberController(ICommunityMemberService communityMemberService)
        {
            _communityMemberService = communityMemberService;
        }
        //[Authorize(Roles = "Administrator, User")]
        [HttpPost]
        [Route("join")]
        public async Task<ActionResult> Join(int userId, int communityId)
        {
            var data = await _communityMemberService.JoinCommunity(userId, communityId);
            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode(501, "Failed to add new regular member.");
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpDelete]
        [Route("leave")]
        public async Task<ActionResult> Leave(int userId, int communityId)
        {
            var data = await _communityMemberService.LeaveCommunity(userId, communityId);
            if (data != null)
            {
                return Ok(data);
            }
            return StatusCode(501, "Failed to delete community member.");
        }
    }
}
