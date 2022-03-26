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
        public async Task<int> LikeUnlike(int postId, Guid userId)
        {
            var isLiked = await IsLiked(postId, userId);
            if (isLiked)
            {
                return await UnLike(postId, userId);
            }
            else
            {
                return await Like(postId, userId);
            }
        }

        private async Task<int> Like(int postId, Guid likedBy)
        {
            var dbPostLike = PostLikeMapper.Map(postId, likedBy);
            _db.PostLikes.Add(dbPostLike);
            await _db.SaveChangesAsync();
            return GetLikes(postId);
        }

        private async Task<int> UnLike(int postId, Guid unlikedBy)
        {
            var dbPostLike = await _db.PostLikes.FindAsync(postId, unlikedBy);
            if (dbPostLike == null)
            {
                throw new Exception("like for the post not found");
            }
            _db.PostLikes.Remove(dbPostLike);
            await _db.SaveChangesAsync();
            return GetLikes(postId);
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

        private int GetLikes(int postId)
        {
            var dbPostLikes = _db.PostLikes.Count(x => x.PostId == postId);
            return dbPostLikes;
        }
    }
}
