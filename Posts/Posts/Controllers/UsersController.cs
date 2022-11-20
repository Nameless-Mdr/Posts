using BLL.Models.User;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
    }
}
