using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Post
{
    public class PostLikeDto
    {
        public int PostId { get; set; }
        public Guid LikeBy { get; set; }
        public DateTime LikedOn { get; set; } = DateTime.UtcNow;
    }
}
