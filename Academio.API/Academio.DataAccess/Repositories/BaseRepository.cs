using Academio.DataAccess.Abstractions;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Academio.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        protected readonly AcademioDbContext _dbContext;
        public BaseRepository(AcademioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var entity = await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, dynamicParameters, transaction, commandType: CommandType.StoredProcedure);

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

        public async Task<T> Delete(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var entity = await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, dynamicParameters, transaction, commandType: CommandType.StoredProcedure);

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

        public async Task<T> Get(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                var results = connection.QuerySingleOrDefaultAsync<T>(storedProcedure, dynamicParameters, commandType: CommandType.StoredProcedure);

                return await results;
            }

        }

        public async Task<IEnumerable<T>> GetAll(string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                var results = connection.QueryAsync<T>(storedProcedure, commandType: CommandType.StoredProcedure);

                return await results;
            }

        }
        public async Task<T> Update(DynamicParameters dynamicParameters, string storedProcedure)
        {
            using (var connection = _dbContext.connection())
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var entity = await connection.QuerySingleOrDefaultAsync<T>(storedProcedure, dynamicParameters, transaction, commandType: CommandType.StoredProcedure);

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
