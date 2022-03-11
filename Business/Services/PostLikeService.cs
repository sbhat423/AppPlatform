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
        public async Task Like(int postId, Guid likedBy)
        {
            var dbPostLike = PostLikeMapper.Map(postId, likedBy);
            _db.PostLikes.Add(dbPostLike);
            await _db.SaveChangesAsync();
        }

        public async Task UnLike(int postId, Guid unlikedBy)
        {
            var dbPostLike = await _db.PostLikes.FindAsync(postId, unlikedBy);
            if (dbPostLike == null)
            {
                throw new Exception("like for the post not found");
            }
            _db.PostLikes.Remove(dbPostLike);
            await _db.SaveChangesAsync();
        }
    }
}
