using Business.Interfaces;
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
        private readonly IFileStorageService _azureStorageService;

        public PostService(ApplicationDbContext db,
            IFileStorageService azureStorageService)
        {
            _db = db;
            _azureStorageService = azureStorageService;
        }

        public async Task<PostDto> Create(PostDto postDto)
        {
            try
            {
                if (postDto.ImageContent != null)
                {
                    postDto.Image = await _azureStorageService.SaveFile(postDto.ImageContent, ".jpg", "posts");
                }

                var dbPost = PostMapper.Map(postDto);
                await _db.Posts.AddAsync(dbPost);
                await _db.SaveChangesAsync();
                return await Get(dbPost.Id);
            }
            catch (Exception)
            {

                throw;
            }
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
            var dbPost = await _db.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dbPost == null)
            {
                throw new Exception("Post for the given Id not found");
            }

            return PostMapper.Map(dbPost);
        }

        public async Task<IEnumerable<PostDto>> List()
        {
            var dbPosts = await _db.Posts
                .Include(x => x.Author)
                .Include(x => x.Comments)
                .Include(x => x.PostLikes)
                .OrderByDescending(x => x.CreatedOn)
                .ToListAsync();
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
