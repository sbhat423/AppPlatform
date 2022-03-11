using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Models.DTOs.Post;

namespace Business.Services
{
    public class PostLikeService : IPostLikeService
    {
        private readonly ApplicationDbContext _db;

        public PostLikeService(ApplicationDbContext db)
        {
            _db = db;
        }
        public async Task LikeUnlike(int postId, Guid userId)
        {
            var isLiked = await IsLiked(postId, userId);
            if (isLiked)
            {
                await UnLike(postId, userId);
            }
            else
            {
                await Like(postId, userId);
            }
        }

        private async Task Like(int postId, Guid likedBy)
        {
            var dbPostLike = PostLikeMapper.Map(postId, likedBy);
            _db.PostLikes.Add(dbPostLike);
            await _db.SaveChangesAsync();
        }

        private async Task UnLike(int postId, Guid unlikedBy)
        {
            var dbPostLike = await _db.PostLikes.FindAsync(postId, unlikedBy);
            if (dbPostLike == null)
            {
                throw new Exception("like for the post not found");
            }
            _db.PostLikes.Remove(dbPostLike);
            await _db.SaveChangesAsync();
        }


        private async Task<bool> IsLiked(int postId, Guid userId)
        {
            var dbPostLike = await _db.PostLikes.FindAsync(postId, userId);
            if (dbPostLike != null)
            {
                return true;
            }
            return false;
        }
    }
}
