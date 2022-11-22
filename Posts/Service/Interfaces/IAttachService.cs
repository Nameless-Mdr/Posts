using BLL.Models.Attach;
using Domain.Entity.MetaData;

namespace Service.Interfaces
{
    public interface IAttachService
    {
        Task<GetAttachModel> GetAttach(string path);

        Task<Guid> InsertContent(MetaDataModel meta, string path, Guid postId);

        Task<Guid> InsertAvatar(MetaDataModel meta, string path, Guid ownerId);

        Task<Guid> UpdateAvatar(MetaDataModel meta, string path, Guid ownerId);

        Task<bool> UserExists(Guid userId);
    }
}
