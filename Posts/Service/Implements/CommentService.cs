using BLL.Models.Comment;
using DAL.Interfaces;
using Service.Interfaces;

namespace Service.Implements
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<Guid> InsertComment(CreateCommentModel entity)
        {
            var response = await _commentRepo.InsertComment(entity);

            return response;
        }

        public async Task<bool> DeleteComment(Guid commentId, Guid authorId)
        {
            var response = await _commentRepo.DeleteComment(commentId, authorId);

            return response;
        }
    }
}
