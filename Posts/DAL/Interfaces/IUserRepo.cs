using BLL.Models.User;
using Domain.Entity.User;

namespace DAL.Interfaces
{
    public interface IUserRepo
    {
        public Task<Guid> InsertUser(CreateUserModel model);

        public Task<IEnumerable<GetUserModel>> GetUsers();

        public Task<User> GetUserByCredentials(string login, string password);

        public Task<GetUserModel> GetUserModelById(Guid id);
    }
}
