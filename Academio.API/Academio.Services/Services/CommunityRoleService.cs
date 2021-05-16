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
    public class CommunityRoleService : ICommunityRoleService
    {
        readonly ICommunityRoleRepository<CommunityRole> _communityRoleRepository;
        public CommunityRoleService(ICommunityRoleRepository<CommunityRole> communityRoleRepository)
        {
            _communityRoleRepository = communityRoleRepository;
        }

        public Task<CommunityRole> GetCommunityRoleByName(string communityRoleName)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@CommunityRoleName", communityRoleName);
            return _communityRoleRepository.GetCommunityRoleByName(dynamicParameters, @"spGetCommunityRoleByName");
        }
    }
}
