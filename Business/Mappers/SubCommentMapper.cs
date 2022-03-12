using Models.DataModels;
using Models.DTOs.SubComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class SubCommentMapper
    {
        public static SubComment Map(SubCommentDto subCommentDto)
        {
            return new SubComment
            {
                CommentId = subCommentDto.CommentId,
                Content = subCommentDto.Content,
                CreatedBy = subCommentDto.CreatedBy
            };
        }

        public static SubCommentDto Map(SubComment subComment)
        {
            return new SubCommentDto
            {
                Id = subComment.Id,
                CommentId = subComment.CommentId,
                Content = subComment.Content,
                CreatedBy = subComment.CreatedBy
            };
        }
    }
}
