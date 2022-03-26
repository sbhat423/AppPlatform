using DataAccess.DataModels;
using Models.DTOs.Comment;

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
                Id = comment.Id,
                PostId = comment.PostId,
                Content = comment.Content,
                CreatedBy = comment.CreatedBy,
                CreatedOn = comment.CreatedOn,
                Likes = comment.CommentLikes == null ? 0 : comment.CommentLikes.Count(),
                SubCommentsCount = comment.SubComments == null ? 0 : comment.SubComments.Count(),
                UserProfile = UserProfilesMapper.Map(comment.UserProfile),
            };
        }
    }
}
