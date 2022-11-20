using BLL.Models.Post;
using Domain.Entity.Attach;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Task<Guid> InsertPost(CreatePostModel entity);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<GetPostModel> GetPost(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
