using Models.DTOs.UserProfile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Comment
{
    public class CommentDto
    {
        public int Id { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid CreatedBy { get; set; }
        [Required]
        public DateTime CreatedOn { get; set; }
        public int Likes { get; set; }
        public UserProfileDto UserProfile { get; set; }
    }
}
