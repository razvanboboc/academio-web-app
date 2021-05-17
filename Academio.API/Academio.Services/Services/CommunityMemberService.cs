using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Services
{
    public class CommunityMemberService : ICommunityMemberService
    {
        readonly ICommunityMemberRepository<CommunityMember> _communityMemberRepository;
        readonly ICommunityRoleService _communityRoleService;
        public CommunityMemberService(ICommunityMemberRepository<CommunityMember> communityMemberRepository, ICommunityRoleService communityRoleService)
        {
            _communityMemberRepository = communityMemberRepository;
            _communityRoleService = communityRoleService;
        }

        public async Task<CommunityMemberDto> Add(int communityId, int userId, int communityRoleId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CommunityId", communityId);
            dynamicParameters.Add("@UserId", userId);
            dynamicParameters.Add("@CommunityRoleId", communityRoleId);
            var communityMember = await _communityMemberRepository.Add(dynamicParameters, @"spAddCommunityMember");

            var communityMemberDto = new CommunityMemberDto()
            {
                CommunityId = communityMember.CommunityId,
                CommunityRoleId = communityMember.CommunityRoleId,
                UserId = communityMember.UserId
            };
            return communityMemberDto;
        }
        
        public async Task<CommunityMemberDto> JoinCommunity(int userId, int communityId)
        {
            var communityRole = await _communityRoleService.GetCommunityRoleByName("Member");

            var newRegularMember = await Add(communityId, userId, communityRole.Id);

            if(newRegularMember == null)
            {
                throw new Exception("Failed to add new regular member.");
            }

            var communityMemberDto = new CommunityMemberDto()
            {
                CommunityId = newRegularMember.CommunityId,
                CommunityRoleId = newRegularMember.CommunityRoleId,
                UserId = newRegularMember.UserId
            };
            return communityMemberDto;
        }

        public async Task<CommunityMemberDto> LeaveCommunity(int userId, int communityId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@UserId", userId);
            dynamicParameters.Add("@CommunityId", communityId);
            var deletedMember = await _communityMemberRepository.Delete(dynamicParameters, @"spDeleteCommunityMember");
            
            var communityMemberDto = new CommunityMemberDto()
            {
                CommunityId = deletedMember.CommunityId,
                CommunityRoleId = deletedMember.CommunityRoleId,
                UserId = deletedMember.UserId
            };
            return communityMemberDto;
        }
    }
}
