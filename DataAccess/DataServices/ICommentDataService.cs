﻿using Models.DTOs.Comment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public interface ICommentDataService
    {
        public Task<IEnumerable<CommentDto>> ListByPostId(int postId);
        public Task<CommentDto> Create(CommentDto commentDto);
        public Task<CommentDto> Update(CommentDto commentDto);
        public Task Delete(int id);
    }
}
