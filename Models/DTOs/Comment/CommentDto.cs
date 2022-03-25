using Models.DTOs.UserProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Likes { get; set; }
        public UserProfileDto UserProfile { get; set; }
    }
}
