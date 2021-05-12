using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Academio.DataAccess
{
    public class AcademioDbContext
    {
        private SqlConnection _sqlConnection;
        private readonly IConfiguration _configuration;
        public AcademioDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection connection()
        {
            setConnection();
            return _sqlConnection;
        }

        private void setConnection()
        {
            string connectionString = _configuration.GetConnectionString("dbconnection");
            _sqlConnection = new SqlConnection(connectionString);
        }
    }
}
