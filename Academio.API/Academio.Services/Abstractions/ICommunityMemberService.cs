using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface ICommunityMemberService
    {
        Task<CommunityMemberDto> Add(int communityId, int userId, int communityRoleId);
        Task<CommunityMemberDto> JoinCommunity(int userId, int communityId);
        Task<CommunityMemberDto> LeaveCommunity(int userId, int communityId);
    }
}
