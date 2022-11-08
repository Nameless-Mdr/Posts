using BLL.Models;

namespace DAL.Interfaces
{
    public interface ICommentRepo
    {
        Task<Guid> InsertAsync(CreateCommentModel entity);

        Task<IEnumerable<GetCommentModel>> GetAllAsync();

        Task<GetCommentModel> GetComment(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
