using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CommentLikeService : ICommentLikeService
    {
        private readonly ApplicationDbContext _db;

        public CommentLikeService(ApplicationDbContext db)
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

        private async Task Like(int commentId, Guid userId)
        {
            var dbCommentLike = CommentLikeMapper.Map(commentId, userId);
            _db.CommentLikes.Add(dbCommentLike);
            await _db.SaveChangesAsync();
        }

        private async Task UnLike(int commentId, Guid userId)
        {
            var dbCommentLike = await _db.CommentLikes.FindAsync(commentId, userId);
            if (dbCommentLike == null)
            {
                throw new Exception("like for the post not found");
            }
            _db.CommentLikes.Remove(dbCommentLike);
            await _db.SaveChangesAsync();
        }


        private async Task<bool> IsLiked(int commentId, Guid userId)
        {
            var dbCommentLike = await _db.CommentLikes.FindAsync(commentId, userId);
            if (dbCommentLike != null)
            {
                return true;
            }
            return false;
        }
    }
}
