using Academio.DataAccess.Abstractions;
using Academio.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Repositories
{
    public class CommunityMemberRepository : BaseRepository<CommunityMember>, ICommunityMemberRepository<CommunityMember>
    {
        public CommunityMemberRepository(AcademioDbContext dbContext) : base(dbContext)
        {
        }
    }
}
