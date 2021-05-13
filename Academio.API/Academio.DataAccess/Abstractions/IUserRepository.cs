using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Abstractions
{
    public interface IUserRepository<User> : IBaseRepository<User>
    {
        Task<User> ChangeAccountPreferences(DynamicParameters dynamicParameters, string storedProcedure);
    }
}
