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
    public class UserRepository : BaseRepository<User>, IUserRepository<User>
    {
        public UserRepository(AcademioDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<User> ChangeAccountPreferences(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var entity = await connection.QuerySingleOrDefaultAsync<User>(storedProcedure, dynamicParameters, transaction, commandType: CommandType.StoredProcedure);

                        transaction.Commit();

                        return entity;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw;
                    }
                }

            }
        }

    }
}
