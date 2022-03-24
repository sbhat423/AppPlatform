using Models.DTOs.UserProfile;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public string Content { get; set; }
        [Required]
        [ForeignKey("UserProfile")]
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Post Post { get; set; }
        public virtual IList<CommentLike> CommentLikes { get; set; }
        public virtual UserProfile UserProfile { get; set; }
    }
}
