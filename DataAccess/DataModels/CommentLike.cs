using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class CommentLike
    {
        [Key]
        [Column(Order = 1)]
        public int CommentId { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid CommentedBy { get; set; }
        public DateTime LikedOn { get; set; } = DateTime.UtcNow;
    }
}
