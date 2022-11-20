using BLL.Models.Attach;
using Domain.Entity.Attach;

namespace Service.Interfaces
{
    public interface IAttachService
    {
        Task<GetAttachModel> GetAttach(string path);

        Task<Guid> InsertAttach (MetaDataModel meta, string path);
    }
}
