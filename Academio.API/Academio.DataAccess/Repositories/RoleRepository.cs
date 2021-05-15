using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Repositories
{
    public class RoleRepository : BaseRepository<Role>, IRoleRepository<Role>
    {
        public RoleRepository(AcademioDbContext dbContext) : base(dbContext)
        {

        }

    }
}
