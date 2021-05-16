using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Abstractions
{
    public interface ICommunityRoleRepository<CommunityRole> : IBaseRepository<CommunityRole>
    {
        Task<CommunityRole> GetCommunityRoleByName(DynamicParameters dynamicParameters, string storedProcedure);
    }
}
