using Academio.DataAccess.Entities;
using Academio.DTOs.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.Services.Abstractions
{
    public interface IUserService
    {
        Task<UserDto> Add(UserDto userDto);
        Task<UserDto> Update(UserDto userDto);
        Task<UserDto> ChangeAccountPreferences(UserDto userDto);
        Task<IEnumerable<UserDto>> GetAll();
        Task<User> Get(int id);
        Task<User> Delete(int id);
    }
}
