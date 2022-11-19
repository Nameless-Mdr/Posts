using BLL.Models;

namespace Service.Interfaces
{
    public interface IAttachService
    {
        Task<GetAttachModel> GetAttach(string path);
    }
}
