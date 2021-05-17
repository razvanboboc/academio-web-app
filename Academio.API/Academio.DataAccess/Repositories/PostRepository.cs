using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository<Post>
    {
        public PostRepository(AcademioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
