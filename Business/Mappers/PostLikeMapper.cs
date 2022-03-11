using Models.DataModels;

namespace Business.Mappers
{
    public static class PostLikeMapper
    {
        public static PostLike Map(int postId, Guid likedBy)
        {
            return new PostLike
            {
                PostId = postId,
                LikeBy = likedBy,
            };
        }
    }
}
