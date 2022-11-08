using BLL.Models;

namespace DAL.Interfaces
{
    public interface IAttachRepo
    {
        Task<GetAttachModel> GetAttach(string path);
    }
}
