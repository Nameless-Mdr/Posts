using BLL.Models.Attach;
using DAL.Interfaces;
using Domain.Entity.MetaData;
using Service.Interfaces;

namespace Service.Implements
{
    public class AttachService : IAttachService
    {
        private readonly IAttachRepo _attachRepo;

        public AttachService(IAttachRepo attachRepo)
        {
            _attachRepo = attachRepo;
        }

        public async Task<GetAttachModel> GetAttach(string path)
        {
            var response = await _attachRepo.GetAttach(path);

            return response;
        }

        public async Task<Guid> InsertContent(MetaDataModel meta, string path, Guid postId)
        {
            var response = await _attachRepo.InsertContent(meta, path, postId);

            return response;
        }

        public async Task<Guid> InsertAvatar(MetaDataModel meta, string path, Guid ownerId)
        {
            var response = await _attachRepo.InsertAvatar(meta, path, ownerId);

            return response;
        }

        public async Task<Guid> UpdateAvatar(MetaDataModel meta, string path, Guid ownerId)
        {
            var response = await _attachRepo.UpdateAvatar(meta, path, ownerId);

            return response;
        }

        public async Task<bool> UserExists(Guid userId)
        {
            var response = await _attachRepo.UserExists(userId);

            return response;
        }
    }
}
