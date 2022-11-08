using BLL.Models;

namespace Service.Interfaces
{
    public interface ICommentService
    {
        Task<Guid> InsertAsync(CreateCommentModel entity);

        Task<IEnumerable<GetCommentModel>> GetAllAsync();

        Task<GetCommentModel> GetComment(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
