using BLL.Models.Attach;
using BLL.Models.User;
using Common;
using Common.Const;
using Domain.Entity.MetaData;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        private readonly IAttachService _attachService;

        public UsersController(IUserService userService, IAttachService attachService)
        {
            _userService = userService;
            _attachService = attachService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<Guid> InsertUser([FromForm] CreateUserModel model)
        {
            var result = await _userService.Insert(model);

            return result;
        }

        [HttpGet]
        public async Task<IEnumerable<GetUserModel>> GetAllUsers()
        {
            var result = await _userService.GetUsers();

            return result;
        }

        [HttpPost]
        public async Task<GetUserModel> GetCurrentUser()
        {
            var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

            if (userId == default)
                throw new Exception("you are not authorized");

            return await _userService.GetUserModelById(userId);
        }

        [HttpPost]
        public async Task<Guid> AddAvatarToUser([FromForm] CreateAvatarModel file)
        {
            var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

            if (userId == default)
                throw new Exception("you are not authorized");

            MetaDataModel meta = await FileHelper.UploadFile(file.file);

            var tempFi = new FileInfo(Path.Combine(Path.GetTempPath(), meta.TempId.ToString()));

            if (!tempFi.Exists)
                throw new Exception("file not found");

            var path = Path.Combine(Directory.GetCurrentDirectory(), "attaches", meta.TempId.ToString());

            var destFi = new FileInfo(path);

            if (destFi.Directory != null && !destFi.Directory.Exists)
                destFi.Directory.Create();

            System.IO.File.Copy(tempFi.FullName, path, true);

            if (await _attachService.UserExists(userId))
            {
                return await _attachService.UpdateAvatar(meta, path, userId);
            }

            return await _attachService.InsertAvatar(meta, path, userId);
        }
    }
}
