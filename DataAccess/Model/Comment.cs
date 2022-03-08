using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedOn { get; set; }
        public bool IsFlagged { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Post Post { get; set; }
    }
}
