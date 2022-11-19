using BLL.Models.User;
using Domain.Entity;

namespace DAL.Interfaces
{
    public interface IUserRepo
    {
        public Task<Guid> Insert(CreateUserModel model);

        public Task<IEnumerable<GetUserModel>> GetUsers();

        public Task<User> GetUserByEmail(string login, string password);
    }
}
