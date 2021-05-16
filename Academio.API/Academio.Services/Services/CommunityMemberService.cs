using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
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
        public CommunityMemberService(ICommunityMemberRepository<CommunityMember> communityMemberRepository)
        {
            _communityMemberRepository = communityMemberRepository;
        }

        public async Task<CommunityMember> Add(int communityId, int userId, int communityRoleId)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CommunityId", communityId);
            dynamicParameters.Add("@UserId", userId);
            dynamicParameters.Add("@CommunityRoleId", communityRoleId);
            var communityMember = await _communityMemberRepository.Add(dynamicParameters, @"spAddCommunityMember");
            return communityMember;
        }
    }
}
