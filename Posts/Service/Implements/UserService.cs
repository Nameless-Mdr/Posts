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
        private readonly AuthConfig _config;

        public UserService(IUserRepo userRepo, IOptions<AuthConfig> config)
        {
            _userRepo = userRepo;
            _config = config.Value;
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
        
        public async Task<TokenModel> GetToken(string login, string password)
        {
            var user = await _userRepo.GetUserByEmail(login, password);

            var claims = new Claim[]
            {
                new("displayName", user.FirstName),
                new("id", user.Id.ToString()),
            };

            var dateNow = DateTime.Now;

            var jwt = new JwtSecurityToken(
                issuer: _config.Issuer,
                audience: _config.Audience,
                notBefore: dateNow,
                claims: claims,
                expires: dateNow.AddMinutes(_config.LifeTime),
                signingCredentials: new SigningCredentials(_config.SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenModel(encodeJwt);
        }
    }
}
