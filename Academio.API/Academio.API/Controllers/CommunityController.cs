﻿using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Academio.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _communityService;
        public CommunityController(ICommunityService communityService)
        {
            _communityService = communityService;
        }
        //[Authorize(Roles = "Administrator, User")]
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(CommunityDto communityDto)
        {
            var community = await _communityService.Add(communityDto);
            if(community != null)
            {
                return Ok(community);
            }
            return StatusCode(500, "This community already exists");
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpGet]
        [Route("getAll")]
        public async Task<ActionResult> GetAll()
        {
            var data = await _communityService.GetAll();
            return Ok(data);
        }

        //[Authorize(Roles = "Administrator, User")]
        [HttpDelete]
        [Route("delete")]
        public async Task<ActionResult> Delete(int id)
        {
            var community = await _communityService.Delete(id);
            if (community != null)
            {
                return Ok(community);
            }
            return NotFound();
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(CommunityDto communityDto)
        {

            var community = await _communityService.Update(communityDto);
            if(community != null)
            {
                return Ok(community);
            }
            return StatusCode(501, "You are not authorized to change the community details.");
        }

        //[Authorize(Roles = "Administrator")]
        [HttpPut]
        [Route("access")]
        public async Task<ActionResult> Access(CommunityDto communityDto)
        {

            var community = await _communityService.Update(communityDto);
            if (community != null)
            {
                return Ok(community);
            }
            return StatusCode(501, "You are not authorized to change the community details.");
        }
    }
}
