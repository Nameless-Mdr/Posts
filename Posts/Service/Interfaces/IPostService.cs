using BLL.Models;
using Domain.Entity.Attach;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Task<Guid> InsertAsync(CreatePostModel entity, Dictionary<string, MetaDataModel> files);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<GetPostModel> GetPost(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
