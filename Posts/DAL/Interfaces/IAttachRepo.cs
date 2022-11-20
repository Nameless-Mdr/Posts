using BLL.Models.Attach;
using Domain.Entity.Attach;

namespace DAL.Interfaces
{
    public interface IAttachRepo
    {
        public Task<GetAttachModel> GetAttach(string path);

        public Task<Guid> InsertAttach(MetaDataModel meta, string path);
    }
}
