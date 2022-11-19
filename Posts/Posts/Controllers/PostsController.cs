using BLL.Models;
using Domain.Entity.Attach;
using Microsoft.AspNetCore.Mvc;
using Posts.Migrations;
using Service.Interfaces;
using System.IO;

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

        // Метод добавления поста вместе с файлами
        [HttpPost]
        public async Task<Guid> InsertPost([FromForm] CreatePostModel model)
        {
            var resDict = new Dictionary<string, MetaDataModel>();

            if (model.Files != null)
            {
                foreach (var file in model.Files)
                {
                    var meta = await UploadFile(file);

                    var tempFi = new FileInfo(Path.Combine(Path.GetTempPath(), meta.TempId.ToString()));

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "attaches", meta.TempId.ToString());

                    var destFi = new FileInfo(path);

                    if (destFi.Directory != null && !destFi.Directory.Exists)
                        destFi.Directory.Create();

                    System.IO.File.Copy(tempFi.FullName, path, true);

                    resDict.Add(path, meta);
                }
            }

            var result = await _postService.InsertAsync(model, resDict);

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
