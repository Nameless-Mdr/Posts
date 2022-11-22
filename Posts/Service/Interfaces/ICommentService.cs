using BLL.Models.Comment;

namespace Service.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> InsertComment(CreateCommentModel entity);

        Task<bool> DeleteComment(Guid commentId, Guid authorId);
    }
}
