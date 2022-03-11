using Models.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public interface IPostLikeService
    {
        public Task Like(int postId, Guid likedBy); 
        public Task UnLike(int postId, Guid unlikedBy);
    }
}
