using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Abstractions
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll(string storedProcedure);
        Task<T> Get(DynamicParameters dynamicParameters, string storedProcedure);
        Task<T> Add(DynamicParameters dynamicParameters, string storedProcedure);
        Task<T> Update(DynamicParameters dynamicParameters, string storedProcedure);
        Task<T> Delete(DynamicParameters dynamicParameters, string storedProcedure);
    }
}
