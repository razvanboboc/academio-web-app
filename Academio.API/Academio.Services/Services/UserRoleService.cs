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
    public class UserRoleService : IUserRoleService
    {
        readonly IUserRoleRepository<UserRole> _userRoleRepository;
        public UserRoleService(IUserRoleRepository<UserRole> userRoleRepository, IRoleRepository<Role> roleRepository)
        {
            _userRoleRepository = userRoleRepository;
        }

        public async Task<IEnumerable<Role>> GetRolesOfUserById(int userId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            return await _userRoleRepository.GetRolesOfUserById(parameters, @"spGetRolesByUserId");
        }

        public async Task<Role> GetRoleByName(string roleName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Name", roleName);
            return await _userRoleRepository.GetRoleByName(parameters, @"spGetRoleByName");

        }

        public async Task UpdateUserRole(int userId, int roleId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@RoleId", roleId);
            await _userRoleRepository.UpdateUserRole(parameters, @"spUpdateUserRole");
        }

        public async Task AddUserRole(int userId, int roleId)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@UserId", userId);
            parameters.Add("@RoleId", roleId);
            await _userRoleRepository.UpdateUserRole(parameters, @"spAddUserRole");
        }
    }
}
