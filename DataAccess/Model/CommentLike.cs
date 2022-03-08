using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
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
