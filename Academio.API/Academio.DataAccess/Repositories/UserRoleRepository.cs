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
    public class UserRoleRepository : BaseRepository<UserRole>, IUserRoleRepository<UserRole>
    {
        public UserRoleRepository(AcademioDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<Role> GetRoleByName(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                return await connection.QuerySingleOrDefaultAsync<Role>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task UpdateUserRole(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                await connection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }


        public async Task<IEnumerable<Role>> GetRolesOfUserById(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                return await connection.QueryAsync<Role>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task AddUserRole(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                await connection.QueryAsync(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
