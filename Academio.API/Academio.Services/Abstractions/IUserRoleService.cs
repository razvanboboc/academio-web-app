using Academio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface IUserRoleService
    {
        Task<IEnumerable<Role>> GetRolesOfUserById(int userId);
        Task<Role> GetRoleByName(string roleName);
        Task UpdateUserRole(int userId, int roleId);
        Task AddUserRole(int userId, int roleId);
    }
}
