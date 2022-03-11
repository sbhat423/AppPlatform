using Models.DataModels;
using Models.DTOs.Post;

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
                Id = post.Id,
                Name = post.Name,
                Description = post.Description,
                AuthorId = post.AuthorId,
                CommentsCount = post.Comments.Count(),
                Likes = post.PostLikes.Count(),
            };
        }
    }
}
