using BLL.Models.Post;
using Common;
using Common.Const;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;

        private readonly IAttachService _attachService;

        public PostsController(IPostService postService, IAttachService attachService)
        {
            _postService = postService;
            _attachService = attachService;
        }
        
        [HttpPost]
        public async Task<Guid> InsertPost([FromForm] CreatePostModel model)
        {
            if (!model.AuthorId.HasValue)
            {
                var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

                if (userId == default)
                    throw new Exception("you are not authorized");

                model.AuthorId = userId;
            }

            var postId = await _postService.InsertPost(model);

            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    var meta = await FileHelper.UploadFile(file);

                    var tempFi = new FileInfo(Path.Combine(Path.GetTempPath(), meta.TempId.ToString()));

                    if (!tempFi.Exists)
                        throw new Exception("file not found");

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "attaches", meta.TempId.ToString());

                    var destFi = new FileInfo(path);

                    if (destFi.Directory != null && !destFi.Directory.Exists)
                        destFi.Directory.Create();

                    System.IO.File.Copy(tempFi.FullName, path, true);

                    await _attachService.InsertContent(meta, path, postId);
                }
            }

            return postId;
        }
        
        [HttpGet]
        public async Task<IEnumerable<GetPostModel>> GetAllPosts()
        {
            var result = await _postService.GetAllAsync();

            return result;
        }
        
        [HttpDelete]
        public async Task<bool> DeletePost(Guid id)
        {
            var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

            if (userId == default)
                throw new Exception("you are not authorized");

            var result = await _postService.DeleteAsync(id, userId);

            return result;
        }
    }
}
