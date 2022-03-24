using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.DataModels
{
    public class PostLike
    {
        [Key]
        [Column(Order = 1)]
        public int PostId { get; set; }
        [Key]
        [Column(Order = 2)]
        public Guid LikeBy { get; set; }
        public DateTime LikedOn { get; set; } = DateTime.UtcNow;
    }
}
