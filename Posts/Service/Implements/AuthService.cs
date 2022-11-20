using BLL.Models.Token;
using Domain.Entity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Config.Configs;
using DAL.Interfaces;
using Microsoft.Extensions.Options;
using Service.Interfaces;

namespace Service.Implements
{
    public class AuthService : IAuthService
    {
        private readonly AuthConfig _authConfig;

        private readonly IUserRepo _userRepo;

        public AuthService(IOptions<AuthConfig> authConfig, IUserRepo userRepo)
        {
            _authConfig = authConfig.Value;
            _userRepo = userRepo;
        }

        private TokenModel GenerateTokens(User user)
        {
            var dateNow = DateTime.Now;

            var jwt = new JwtSecurityToken(
                issuer: _authConfig.Issuer,
                audience: _authConfig.Audience,
                notBefore: dateNow,
                claims: new Claim[]
                {
                    new("displayName", user.FirstName),
                    new("id", user.Id.ToString())
                },
                expires: dateNow.AddMinutes(_authConfig.LifeTime),
                signingCredentials: new SigningCredentials(_authConfig.SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var jwrRefresh = new JwtSecurityToken(
                notBefore: dateNow,
                claims: new Claim[]
                {
                    new("id", user.Id.ToString())
                },
                expires: dateNow.AddMinutes(_authConfig.LifeTime),
                signingCredentials: new SigningCredentials(_authConfig.SymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
            );

            var encodeJwtRefresh = new JwtSecurityTokenHandler().WriteToken(jwrRefresh);

            return new TokenModel(encodeJwt, encodeJwtRefresh);
        }

        public async Task<TokenModel> GetToken(string login, string password)
        {
            var user = await _userRepo.GetUserByCredentials(login, password);

            return GenerateTokens(user);
        }

        public async Task<TokenModel> GetTokenByRefreshToken(string refreshToken)
        {
            var validParams = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                ValidateLifetime = true,
                IssuerSigningKey = _authConfig.SymmetricSecurityKey()
            };

            var principal = new JwtSecurityTokenHandler().ValidateToken(refreshToken, validParams, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtToken
                || !jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("invalid token");
            }

            if (principal.Claims.FirstOrDefault(x => x.Type == "id")?.Value is String userIdString &&
                Guid.TryParse(userIdString, out var userId))
            {
                var user = await _userRepo.GetUserById(userId);

                return GenerateTokens(user);
            }

            throw new SecurityTokenException("invalid token");
        }
    }
}
