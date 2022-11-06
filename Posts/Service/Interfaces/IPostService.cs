using BLL.Models;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Task<Guid> InsertAsync(CreatePostModel entity);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<GetPostModel> GetPost(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
