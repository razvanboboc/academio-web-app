using Influencers.BusinessLogic.DTOs;
using Influencers.Models;
using Influencers.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Influencers.BusinessLogic.Services
{
    public class CommentService
    {
        private ICommentRepository commentRepository;

        public CommentService(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        public IEnumerable<CommentDto> GetCommentsByArticleId(int id)
        {
            var comments = commentRepository.GetCommentsByArticleId(id).ToList();
            var nestedComments = CreateNestedComments(comments, null);
            return nestedComments;
        }

        public List<CommentDto> CreateNestedComments(List<Comment> comments, int? parentId)
        {
            List<CommentDto> commentDtos = new List<CommentDto>();
            foreach(var comment in comments)
            {
                if(comment.ParentCommentId == parentId)
                {
                    var commentDto = new CommentDto()
                    {
                        ParentComment = comment,
                        ChildComments = CreateNestedComments(comments, comment.Id)
                    };
                    commentDtos.Add(commentDto);
                }
            }
            return commentDtos;
        }

        public void Add(Article article, Author author, string content,int? parentCommentId)
        {
            commentRepository.Add(new Comment
            {
                Article = article,
                ArticleId = article.AuthorId,
                Author = author,
                AuthorId = author.Id,
                Content = content,
                AddedTime = DateTime.Now,
                Votes = 0,
                ParentCommentId = parentCommentId
            });
        }

        public void UpdateCommentVotes(int commentId, int flag)
        {
            commentRepository.UpdateCommentVotes(commentId, flag);
        }
    }
}
