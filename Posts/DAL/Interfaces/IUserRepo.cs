using BLL.Models.User;
using Domain.Entity.User;

namespace DAL.Interfaces
{
    public interface IUserRepo
    {
        public Task<Guid> Insert(CreateUserModel model);

        public Task<IEnumerable<GetUserModel>> GetUsers();

        public Task<User> GetUserByCredentials(string login, string password);

        public Task<User> GetUserById(Guid id);
    }
}
