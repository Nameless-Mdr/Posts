using BLL.Models.User;
using DAL.Interfaces;
using Service.Interfaces;

namespace Service.Implements
{
    public class UserService : IUserService
    {
        private readonly IUserRepo _userRepo;

        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public async Task<Guid> Insert(CreateUserModel model)
        {
            var response = await _userRepo.Insert(model);

            return response;
        }

        public async Task<IEnumerable<GetUserModel>> GetUsers()
        {
            var response = await _userRepo.GetUsers();

            return response;
        }

        public async Task<GetUserModel> GetUserModelById(Guid id)
        {
            var response = await _userRepo.GetUserModelById(id);

            return response;
        }
    }
}
