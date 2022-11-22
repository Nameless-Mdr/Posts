using BLL.Models.Like;
using Common.Const;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class LikesController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikesController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task Like([FromForm] CreateLikeModel model)
        {
            if (!model.AuthorId.HasValue)
            {
                var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

                if (userId == default)
                    throw new Exception("you are not authorize");

                model.AuthorId = userId;
            }

            if (_likeService.LikeExists(model, out var likeId))
                await _likeService.DeleteLike(likeId);
            else
                await _likeService.InsertLike(model);
        }
    }
}
