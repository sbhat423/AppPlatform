using Models.DataModels;

namespace Business.Mappers
{
    public static class CommentLikeMapper
    {
        public static CommentLike Map(int commentId, Guid userId)
        {
            return new CommentLike
            {
                CommentId = commentId,
                CommentedBy = userId,
            };
        }
    }
}
