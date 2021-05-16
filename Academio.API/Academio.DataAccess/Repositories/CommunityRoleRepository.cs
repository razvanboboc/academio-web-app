using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Repositories
{
    public class CommunityRoleRepository : BaseRepository<CommunityRole>, ICommunityRoleRepository<CommunityRole>
    {
        public CommunityRoleRepository(AcademioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<CommunityRole> GetCommunityRoleByName(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                return await connection.QuerySingleOrDefaultAsync<CommunityRole>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
