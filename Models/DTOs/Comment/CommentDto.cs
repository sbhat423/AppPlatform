using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Comment
{
    public class CommentDto
    {
        public int PostId { get; set; }
        public string Content { get; set; }
        public Guid CreatedBy { get; set; }
    }
}
