using BLL.Models;

namespace DAL.Interfaces
{
    public interface IPostRepo
    {
        Task<Guid> InsertAsync(CreatePostModel entity);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<IEnumerable<GetPostModel>> GetPost(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
