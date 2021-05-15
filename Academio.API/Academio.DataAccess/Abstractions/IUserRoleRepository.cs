using Academio.DataAccess.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Abstractions
{
    public interface IUserRoleRepository<UserRole> : IBaseRepository<UserRole>
    {
        Task<IEnumerable<Role>> GetRolesOfUserById(DynamicParameters dynamicParameters, string storedProcedure);
        Task<Role> GetRoleByName(DynamicParameters dynamicParameters, string storedProcedure);
        Task UpdateUserRole(DynamicParameters dynamicParameters, string storedProcedure);
        Task AddUserRole(DynamicParameters dynamicParameters, string storedProcedure);
    }
}
