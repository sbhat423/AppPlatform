﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public interface ICommentLikeService
    {
        public Task LikeUnlike(int postId, Guid userId);
    }
}
