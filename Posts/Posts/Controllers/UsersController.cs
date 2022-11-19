using BLL.Models.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<Guid> InsertUser([FromBody] CreateUserModel model)
        {
            var result = await _userService.Insert(model);

            return result;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<GetUserModel>> GetAllUsers()
        {
            var result = await _userService.GetUsers();

            return result;
        }
    }
}
