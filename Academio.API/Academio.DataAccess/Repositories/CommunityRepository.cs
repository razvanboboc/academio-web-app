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
    public class CommunityRepository : BaseRepository<Community>, ICommunityRepository<Community>
    {
        public CommunityRepository(AcademioDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Community> GetCommunityByName(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                var results = connection.QuerySingleOrDefaultAsync<Community>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return await results;
            }
        }
    }
}
