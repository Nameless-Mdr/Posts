using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AttachesController : ControllerBase
    {
        private readonly IAttachService _attachService;

        public AttachesController(IAttachService attachService)
        {
            _attachService = attachService;
        }

        [HttpGet]
        public async Task<FileStreamResult> GetAttach(string path, bool download = false)
        {
            var attach = await _attachService.GetAttach(path);

            if (attach.FilePath == null)
                throw new Exception("Файла с таким путем не существует");

            var fs = new FileStream(path, FileMode.Open);

            return download ? File(fs, attach.MimeType, attach.Name) : File(fs, attach.MimeType);
        }
    }
}
