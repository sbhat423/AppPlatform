using DataAccess.DataServices;
using Models.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class CommentService : ICommentDataService
    {
        public Task<CommentDto> Create(CommentDto commentDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CommentDto>> ListByPostId(int postId)
        {
            throw new NotImplementedException();
        }

        public Task<CommentDto> Update(CommentDto commentDto)
        {
            throw new NotImplementedException();
        }
    }
}
