using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace Posts.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        // Метод добавления комментария
        [HttpPost]
        public async Task<Guid> InsertComment([FromForm] CreateCommentModel model)
        {
            var result = await _commentService.InsertAsync(model);

            return result;
        }

        // Метод вывода всех комментариев
        [HttpGet]
        public async Task<IEnumerable<GetCommentModel>> GetAllComments()
        {
            var result = await _commentService.GetAllAsync();

            return result;
        }

        // Метод вывода комментария по id
        [HttpGet]
        public async Task<GetCommentModel> GetComment(Guid id)
        {
            var result = await _commentService.GetComment(id);

            return result;
        }

        // Метод удаления комментария по id
        [HttpDelete]
        public async Task<bool> DeleteComment(Guid id)
        {
            var result = await _commentService.DeleteAsync(id);

            return result;
        }
    }
}
