using BLL.Models;
using Domain.Entity.Attach;

namespace DAL.Interfaces
{
    public interface IPostRepo
    {
        Task<Guid> InsertAsync(CreatePostModel entity, Dictionary<string, MetaDataModel> files);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<GetPostModel> GetPost(Guid id);

        Task<bool> DeleteAsync(Guid id);
    }
}
