using BLL.Models.Comment;

namespace DAL.Interfaces
{
    public interface ICommentRepo
    {
        Task<Guid> InsertComment(CreateCommentModel entity);

        Task<bool> DeleteComment(Guid commentId, Guid authorId);
    }
}
