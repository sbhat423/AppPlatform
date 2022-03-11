using Models.DataModels;
using Models.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
