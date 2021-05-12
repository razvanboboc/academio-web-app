using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public DateTime DatePosted { get; set; }
        public string Content { get; set; }
    }
}
