using BLL.Models.Token;
using Domain.Entity;

namespace Service.Interfaces
{
    public interface IAuthService
    {
        public Task<TokenModel> GetToken(string login, string password);

        public Task<TokenModel> GetTokenByRefreshToken(string refreshToken);
    }
}
