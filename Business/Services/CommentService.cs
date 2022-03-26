using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Comment;

namespace Business.Services
{
    public class CommentService : ICommentDataService
    {
        private readonly ApplicationDbContext _db;

        public CommentService(ApplicationDbContext db)
        {
            _db = db;
        }

        private async Task<CommentDto> Get(int id)
        {
            var dbComment = await _db.Comments
                .Include(x => x.SubComments)
                .Include(x => x.UserProfile)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbComment == null)
            {
                throw new Exception("Comment with the given Id not found");
            }
            return CommentMapper.Map(dbComment);
        }

        public async Task<CommentDto> Create(int postId, CommentDto commentDto)
        {
            var dbComment = CommentMapper.Map(postId, commentDto);
            await _db.Comments.AddAsync(dbComment);
            await _db.SaveChangesAsync();
            var newComment = await Get(dbComment.Id);
            return newComment;
        }

        public async Task Delete(int id)
        {
            var dbComment = await _db.Comments.FindAsync(id);
            if (dbComment == null)
            {
                throw new Exception("Comment for the given Id not found");
            }

            _db.Comments.Remove(dbComment);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<CommentDto>> ListByPostId(int postId)
        {
            var dbComments = await _db.Comments
                .Include(x => x.UserProfile)
                .Include(x => x.SubComments)
                .Where(x => x.PostId == postId)
                .Include(x => x.CommentLikes)
                .ToListAsync();
            return dbComments.Select(x => CommentMapper.Map(x));
        }

        public async Task<CommentDto> Update(int id, CommentDto commentDto)
        {
            var dbComment = await _db.Comments.FindAsync(id);
            if (dbComment == null)
            {
                throw new Exception("Comment for the given Id not found");
            }

            dbComment.UpdatedOn = DateTime.UtcNow;

            _db.Comments.Update(dbComment);
            await _db.SaveChangesAsync();

            return CommentMapper.Map(dbComment);
        }
    }
}
