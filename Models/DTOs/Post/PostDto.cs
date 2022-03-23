using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DTOs.Post
{
    public class PostDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a title")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please provide a description")]
        public string Description { get; set; }
        public Guid AuthorId { get; set; }
        public int CommentsCount { get; set; }
        public int Likes { get; set; }
        public string Image { get; set; }
        public byte[] ImageContent { get; set; }
    }
}
