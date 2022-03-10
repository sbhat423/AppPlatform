using Business.Mappers;
using DataAccess.Data;
using DataAccess.DataServices;
using Microsoft.EntityFrameworkCore;
using Models.DTOs.Post;

namespace Business.Services
{
    public class PostService : IPostDataService
    {
        private readonly ApplicationDbContext _db;

        public PostService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<PostDto> Create(PostDto postDto)
        {
            var dbPost = PostMapper.Map(postDto);
            await _db.Posts.AddAsync(dbPost);
            await _db.SaveChangesAsync();
            return PostMapper.Map(dbPost);
        }

        public async Task Delete(int id)
        {
            var dbPost = await _db.Posts.FindAsync(id);
            if (dbPost == null)
            {
                throw new Exception("Post for the given Id not found");
            }

            _db.Posts.Remove(dbPost);
            await _db.SaveChangesAsync();
        }

        public async Task<PostDto> Get(int id)
        {
            var dbPost = await _db.Posts.FindAsync(id);
            if (dbPost == null)
            {
                throw new Exception("Post for the given Id not found");
            }

            return PostMapper.Map(dbPost);
        }

        public async Task<IEnumerable<PostDto>> List()
        {
            var dbPosts = await _db.Posts.Include(x => x.Comments).ToListAsync();
            return dbPosts.Select(x => PostMapper.Map(x));
        }

        public async Task<PostDto> Update(int id, PostDto postDto)
        {
            var dbPost = await _db.Posts.FindAsync(id);
            if (dbPost == null)
            {
                throw new Exception("Post for the given Id not found");
            }

            dbPost.Name = postDto.Name;
            dbPost.Description = postDto.Description;
            dbPost.UpdatedOn = DateTime.UtcNow;

            _db.Posts.Update(dbPost);
            return PostMapper.Map(dbPost);
        }
    }
}
