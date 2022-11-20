using BLL.Models.Token;
using BLL.Models.User;

namespace Service.Interfaces
{
    public interface IUserService
    {
        public Task<Guid> Insert(CreateUserModel model);

        public Task<IEnumerable<GetUserModel>> GetUsers();
    }
}
