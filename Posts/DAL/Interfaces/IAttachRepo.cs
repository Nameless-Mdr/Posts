using BLL.Models.Attach;
using Domain.Entity.MetaData;

namespace DAL.Interfaces
{
    public interface IAttachRepo
    {
        public Task<GetAttachModel> GetAttach(string path);

        public Task<Guid> InsertContent(MetaDataModel meta, string path, Guid postId);

        public Task<Guid> InsertAvatar(MetaDataModel meta, string path, Guid ownerId);

        public Task<Guid> UpdateAvatar(MetaDataModel meta, string path, Guid ownerId);

        public Task<bool> UserExists(Guid userId);
    }
}
