using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DTOs.DTOs
{
    public class CommunityMemberDto
    {
        public int CommunityId { get; set; }
        public int CommunityRoleId { get; set; }
        public int UserId { get; set; }
    }
}
