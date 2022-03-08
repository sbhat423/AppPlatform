using DataAccess.Model;
using Models.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mappers
{
    public static class PostMapper
    {
        public static Post Map(PostDto postDto)
        {
            return new Post
            {
                Name = postDto.Name,
                Description = postDto.Description,
                AuthorId = postDto.AuthorId,
            };
        }

        public static PostDto Map(Post post)
        {
            return new PostDto
            {
                Name = post.Name,
                Description = post.Description,
                AuthorId = post.AuthorId,
            };
        }
    }
}
