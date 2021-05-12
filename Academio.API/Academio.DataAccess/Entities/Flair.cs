using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Entities
{
    public class Flair
    {
        public int Id { get; set; }
        public int CommunityId { get; set; }
        public string Name { get; set; }
    }
}
