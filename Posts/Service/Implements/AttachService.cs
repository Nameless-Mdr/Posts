using BLL.Models;
using DAL.Interfaces;
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
    }
}
