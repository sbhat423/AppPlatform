using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.SubComment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class SubCommentService : ISubCommentService
    {
        private readonly ApplicationDbContext _db;

        public SubCommentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Create(SubCommentDto subCommentDto)
        {
            var dbSubComment = SubCommentMapper.Map(subCommentDto);
            _db.SubComments.Add(dbSubComment);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(int subCommentId)
        {
            var dbSubComment = await _db.SubComments.FindAsync(subCommentId);
            if (dbSubComment == null)
            {
                throw new Exception("Subcomment to delete is not found");
            }
            _db.SubComments.Remove(dbSubComment);
            await _db.SaveChangesAsync();
        }

        public async Task<IEnumerable<SubCommentDto>> List(int commentId)
        {
            var dbSubComments = await _db.SubComments
                .Where(x => x.CommentId == commentId)
                .ToListAsync();
            return dbSubComments.Select(x => SubCommentMapper.Map(x));

        }

        public async Task<SubCommentDto> Update(int subCommentId, SubCommentDto subCommentDto)
        {
            var dbSubComment = await _db.SubComments.FindAsync(subCommentId);
            if (dbSubComment == null)
            {
                throw new Exception("Subcomment to delete is not found");
            }
            dbSubComment.Content = subCommentDto.Content;
            dbSubComment.UpdatedOn = DateTime.UtcNow;
            _db.SubComments.Update(dbSubComment);
            await _db.SaveChangesAsync();
            return SubCommentMapper.Map(dbSubComment);
        }
    }
}
