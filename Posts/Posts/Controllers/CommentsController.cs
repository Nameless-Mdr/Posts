using BLL.Models.Comment;
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
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        
        [HttpPost]
        public async Task<Guid> InsertComment([FromForm] CreateCommentModel model)
        {
            if (!model.AuthorId.HasValue)
            {
                var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

                if (userId == default)
                    throw new Exception("you are not authorize");

                model.AuthorId = userId;
            }

            var result = await _commentService.InsertComment(model);

            return result;
        }
        
        [HttpDelete]
        public async Task<bool> DeleteComment(Guid commentId)
        {
            var userId = User.GetClaimValue<Guid>(ClaimNames.Id);

            if (userId == default)
                throw new Exception("you are not authorize");

            var result = await _commentService.DeleteComment(commentId, userId);

            return result;
        }
    }
}
