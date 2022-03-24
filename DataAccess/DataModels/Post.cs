using DataAccess.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [ForeignKey("Author")]
        public Guid AuthorId { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; }
        public bool IsFlagged { get; set; } = false;
        public virtual IList<Comment> Comments { get; set; }
        public virtual IList<PostLike> PostLikes { get; set; }
        public virtual UserProfile Author { get; set; }
    }
}
