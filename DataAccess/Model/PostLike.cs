using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
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
