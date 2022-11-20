using BLL.Models.Post;
using Common;
using Common.Const;
using Domain.Entity.Attach;
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

        // Метод добавления поста вместе с файлами
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

            var result = await _postService.InsertPost(model);

            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    var meta = await UploadFile(file);

                    meta.PostId = result;

                    var tempFi = new FileInfo(Path.Combine(Path.GetTempPath(), meta.TempId.ToString()));

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "attaches", meta.TempId.ToString());

                    var destFi = new FileInfo(path);

                    if (destFi.Directory != null && !destFi.Directory.Exists)
                        destFi.Directory.Create();

                    System.IO.File.Copy(tempFi.FullName, path, true);

                    await _attachService.InsertAttach(meta, path);
                }
            }

            return result;
        }

        // Метод вывода всех постов
        [HttpGet]
        public async Task<IEnumerable<GetPostModel>> GetAllPosts()
        {
            var result = await _postService.GetAllAsync();

            return result;
        }

        // Метод вывода постов по id
        [HttpGet]
        public async Task<GetPostModel> GetPost(Guid id)
        {
            var result = await _postService.GetPost(id);

            return result;
        }

        // Метод удаление поста по id
        [HttpDelete]
        public async Task<bool> DeletePost(Guid id)
        {
            var result = await _postService.DeleteAsync(id);

            return result;
        }

        private async Task<MetaDataModel> UploadFile(IFormFile file)
        {
            var tempPath = Path.GetTempPath();

            var meta = new MetaDataModel
            {
                TempId = Guid.NewGuid(),
                Name = file.FileName,
                MimeType = file.ContentType,
                Size = file.Length,
            };

            var newPath = Path.Combine(tempPath, meta.TempId.ToString());

            var fileInfo = new FileInfo(newPath);

            if (fileInfo.Exists)
            {
                throw new Exception("file exist");
            }

            using (var stream = System.IO.File.Create(newPath))
            {
                await file.CopyToAsync(stream);
            }

            return meta;
        }
    }
}
