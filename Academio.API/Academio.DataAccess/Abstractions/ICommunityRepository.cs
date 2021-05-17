
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Abstractions
{
    public interface ICommunityRepository<Community> : IBaseRepository<Community>
    {
        Task<Community> GetCommunityByName(DynamicParameters dynamicParameters, string storedProcedure);
    }
}
