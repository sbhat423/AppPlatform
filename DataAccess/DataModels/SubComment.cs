using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class SubComment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Comment")]
        public int CommentId { get; set; }
        [Required]
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedOn { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
