using BLL.Models.Attach;

namespace DAL.Interfaces
{
    public interface IAttachRepo
    {
        Task<GetAttachModel> GetAttach(string path);
    }
}
