using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using Academio.DTOs.Models;
using Academio.Services.Abstractions;
using Dapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository<User> _userRepository;
        private readonly IUserRoleService _userRoleService;
        private IConfiguration _config;
        public UserService(IUserRepository<User> userRepository, IUserRoleService userRoleService, IConfiguration config)
        {
            _userRepository = userRepository;
            _userRoleService = userRoleService;
            _config = config;
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

            if (addedUser != null)
            {
                var role = await _userRoleService.GetRoleByName(userDto.Role);

                await _userRoleService.AddUserRole(addedUser.Id, role.Id);
            }

            userDto.Id = addedUser.Id;

            userDto.PasswordHash = null;

            return userDto;
        }

        public async Task<SessionModel> Authenticate(UserDto userDto)
        {
            try
            {
                var authenticatedUser = await GetUserByEmailOrUsername(userDto);

                if (authenticatedUser is null)
                {
                    throw new Exception("User not found");
                }

                var passwordVerificationResult = new PasswordHasher<object>().VerifyHashedPassword(null, authenticatedUser.PasswordHash, userDto.PasswordHash);

                if (passwordVerificationResult == PasswordVerificationResult.Failed)
                {
                    throw new Exception("Password verification failed");
                }

                var roles = await _userRoleService.GetRolesOfUserById(authenticatedUser.Id);

                var mainRole = roles.OrderBy(x => x.Name).FirstOrDefault().Name;

                var user = new UserDto
                {
                    Id = authenticatedUser.Id,
                    Username = authenticatedUser.Username,
                    EmailAddress = authenticatedUser.EmailAddress,
                    PasswordHash = null,
                    FirstName = authenticatedUser.FirstName,
                    LastName = authenticatedUser.LastName,
                    DateJoined = authenticatedUser.DateJoined,
                    Role = mainRole
                };

                if (user == null)
                    return null;

                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.EmailAddress),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };


                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                    _config["Jwt:Issuer"],
                    claims,
                    expires: DateTime.Now.AddMinutes(120),
                    signingCredentials: credentials);

                var tokenModel = new TokenModel { Token = new JwtSecurityTokenHandler().WriteToken(token) };

                var sessionModel = new SessionModel { UserDto = WithoutPassword(user), Token = tokenModel };

                return sessionModel;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public static UserDto WithoutPassword(UserDto userDto)
        {
            if (userDto == null) return null;

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

            if (updatedUser != null)
            {
                var role = await _userRoleService.GetRoleByName(userDto.Role);

                await _userRoleService.UpdateUserRole(updatedUser.Id, role.Id);
            }

            userDto.Id = updatedUser.Id;
            userDto.Username = updatedUser.Username;
            userDto.PasswordHash = null;

            return userDto;
        }

        public async Task<User> Delete(int id)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@Id", id);
            var user = await _userRepository.Delete(dynamicParameters, @"spDeleteUser");
            user.PasswordHash = null;

            return user;
        }

        public async Task<User> Get(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            var user = await _userRepository.Get(parameters, @"spGetUserById");
            user.PasswordHash = null;

            return user;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            var users = await _userRepository.GetAll(@"spGetAllUsers");

            List<UserDto> userDtos = new List<UserDto>();
            foreach (var user in users)
            {
                var role = await _userRoleService.GetRolesOfUserById(user.Id);
                var userWithRole = new UserDto
                {
                    Id = user.Id,
                    Username = user.Username,
                    EmailAddress = user.EmailAddress,
                    PasswordHash = null,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateJoined = user.DateJoined,
                    Role = role.FirstOrDefault<Role>().Name
                };
                userDtos.Add(userWithRole);
            }

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

            if (updatedUser != null)
            {
                var role = await _userRoleService.GetRoleByName(userDto.Role);

                await _userRoleService.UpdateUserRole(updatedUser.Id, role.Id);
            }

            userDto.Id = updatedUser.Id;
            userDto.PasswordHash = null;

            return userDto;
        }
        public async Task<User> GetUserByEmailOrUsername(UserDto userDto)
        {
            var dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("@EmailAddress", userDto.EmailAddress);
            dynamicParameters.Add("@Username", userDto.Username);
            return await _userRepository.GetUserByEmail(dynamicParameters, @"spGetUserByEmailOrUsername");
        }
    }
}
