using DAL.Interfaces;
using Domain.Entity.User;
using Service.Interfaces;

namespace Service.Implements
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepo _sessionRepo;

        public SessionService(ISessionRepo sessionRepo)
        {
            _sessionRepo = sessionRepo;
        }

        public async Task<UserSession> GetSessionById(Guid id)
        {
            var response = await _sessionRepo.GetSessionById(id);

            return response;
        }
    }
}
