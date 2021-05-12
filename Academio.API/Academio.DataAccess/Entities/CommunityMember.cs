using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Entities
{
    public class CommunityMember
    {
        public int CommunityId { get; set; }
        public int CommunityRoleId { get; set; }
        public int UserId { get; set; }
    }
}
