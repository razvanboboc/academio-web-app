using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using Academio.Services.Abstractions;
using Dapper;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        public UserService(IUserRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<UserDto> Add(UserDto userDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Username", userDto.Username);
            parameters.Add("@EmailAddress", userDto.EmailAddress);
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, userDto.PasswordHash);
            parameters.Add("@PasswordHash", hashedPassword);
            parameters.Add("@FirstName", userDto.FirstName);
            parameters.Add("@LastName", userDto.LastName);
            parameters.Add("@DateJoined", userDto.DateJoined);
            var addedUser = await _userRepository.Add(parameters, @"spAddUser");

            //if (addedUser != null)
            //{
            //    var role = await _userRoleService.GetRoleByName(userDto.Role);

            //    await _userRoleService.AddUserRole(addedUser.Id, role.Id);
            //}

            userDto.Id = addedUser.Id;

            userDto.PasswordHash = null;

            return userDto;
        }

        public async Task<UserDto> ChangeAccountPreferences(UserDto userDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", userDto.Id);
            parameters.Add("@EmailAddress", userDto.EmailAddress);
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, userDto.PasswordHash);
            parameters.Add("@PasswordHash", hashedPassword);
            parameters.Add("@FirstName", userDto.FirstName);
            parameters.Add("@LastName", userDto.LastName);

            var updatedUser = await _userRepository.ChangeAccountPreferences(parameters, @"spChangeAccountPreferences");

            //if (updatedUser != null)
            //{
            //    var role = await _userRoleService.GetRoleByName(userDto.Role);

            //    await _userRoleService.UpdateUserRole(updatedUser.Id, role.Id);
            //}
            userDto.Id = updatedUser.Id;
            userDto.Username = updatedUser.Username;
            userDto.PasswordHash = null;

            return userDto;
        }

        public async Task<User> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            var user =  await _userRepository.Delete(dynamicParameters, @"spDeleteUser");
            user.PasswordHash = null;

            return user;
        }

        public async Task<User> Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var user =  await _userRepository.Get(parameters, @"spGetUserById");
            user.PasswordHash = null;
            
            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll(@"spGetAllUsers");
            
            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                userDtos.Add(new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    EmailAddress = user.EmailAddress,
                    PasswordHash = null,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateJoined= user.DateJoined,
                    Role= null,
                });
            }

            //foreach (var user in users)
            //{
            //    var role = await _userRoleService.GetRolesOfUserById(user.Id);
            //    var userWithRole = new UserDto
            //    {
            //        Id = user.Id,
            //        FirstName = user.FirstName,
            //        LastName = user.LastName,
            //        EmailAddress = user.EmailAddress,
            //        Role = role.FirstOrDefault<Role>().Name
            //    };
            //    userDtos.Add(userWithRole);
            //}

            //return userDtos;

            return userDtos;
        }

        public async Task<UserDto> Update(UserDto userDto)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", userDto.Id);
            parameters.Add("@Username", userDto.Username);
            parameters.Add("@EmailAddress", userDto.EmailAddress);
            var hashedPassword = new PasswordHasher<object?>().HashPassword(null, userDto.PasswordHash);
            parameters.Add("@PasswordHash", hashedPassword);
            parameters.Add("@FirstName", userDto.FirstName);
            parameters.Add("@LastName", userDto.LastName);
            parameters.Add("@DateJoined", userDto.DateJoined);

            var updatedUser = await _userRepository.Update(parameters, @"spUpdateUser");

            //if (updatedUser != null)
            //{
            //    var role = await _userRoleService.GetRoleByName(userDto.Role);

            //    await _userRoleService.UpdateUserRole(updatedUser.Id, role.Id);
            //}

            userDto.Id = updatedUser.Id;
            userDto.PasswordHash = null;

            return userDto;
        }
    }
}
