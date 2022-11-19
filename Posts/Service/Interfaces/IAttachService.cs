using BLL.Models.Attach;

namespace Service.Interfaces
{
    public interface IAttachService
    {
        Task<GetAttachModel> GetAttach(string path);
    }
}
