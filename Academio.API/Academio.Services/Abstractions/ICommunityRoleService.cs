using Academio.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface ICommunityRoleService
    {
        Task<CommunityRole> GetCommunityRoleByName(string communityRoleName);
        Task<CommunityRole> GetCommunityRoleOfUser(int userId, int communityId);
    }
}
