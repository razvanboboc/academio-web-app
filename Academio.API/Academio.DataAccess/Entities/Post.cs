using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CommunityId { get; set; }
        public DateTime DatePosted { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageSource { get; set; }
        public string VideoSource { get; set; }
        public string Link { get; set; }
    }
}
