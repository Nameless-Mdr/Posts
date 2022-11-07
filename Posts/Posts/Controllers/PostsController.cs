using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpPost]
        public async Task<Guid> InsertPost(CreatePostModel model)
        {
            var result = await _postService.InsertAsync(model);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<GetPostModel>> GetAllPosts()
        {
            var result = await _postService.GetAllAsync();

            return result;
        }

        [HttpGet]
        public async Task<GetPostModel> GetPost(Guid id)
        {
            var result = await _postService.GetPost(id);

            return result;
        }

        [HttpDelete]
        public async Task<bool> DeletePost(Guid id)
        {
            var result = await _postService.DeleteAsync(id);

            return result;
        }
    }
}
