using Models.DTOs.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataServices
{
    public interface IPostDataService
    {
        public Task<IEnumerable<PostDto>> List();
        public Task<PostDto> Get(int id);
        public Task<PostDto> Create(PostDto postDto);
        public Task<PostDto> Update(int id, PostDto postDto);
        public Task Delete(int id);
    }
}
