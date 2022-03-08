using DataAccess.Model;
using Models.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class CommentMapper
    {
        public static Comment Map(int postId, CommentDto commentDto)
        {
            return new Comment
            {
                PostId = postId,
                Content = commentDto.Content,
                CreatedBy = commentDto.CreatedBy,
            };
        }

        public static CommentDto Map(Comment comment)
        {
            return new CommentDto
            {
                PostId = comment.PostId,
                Content = comment.Content,
                CreatedBy = comment.CreatedBy,
            };
        }
    }
}
