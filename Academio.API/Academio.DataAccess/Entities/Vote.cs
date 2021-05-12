using System;
using System.Collections.Generic;
using System.Text;

namespace Academio.DataAccess.Entities
{
    public class Vote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int CommentId { get; set; }
        public enum VoteType
        {
            Upvote, Downvote
        }

        public VoteType voteType { get; set; }
    }
}
