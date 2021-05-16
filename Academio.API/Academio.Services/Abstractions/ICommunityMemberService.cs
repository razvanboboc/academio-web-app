using Academio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface ICommunityMemberService
    {
        Task<CommunityMember> Add(int communityId, int userId, int communityRoleId);
    }
}
