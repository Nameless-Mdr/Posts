using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using BLL.Models.Token;
using BLL.Models.User;
using Config.Configs;
using DAL.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
    }
}
