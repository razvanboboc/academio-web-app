using Influencers.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Influencers.BusinessLogic.DTOs
{
    public class CommentDto
    {
        public Comment Comment { get; set; }
        public IEnumerable<CommentDto> ChildComments { get; set; }
    }
}
