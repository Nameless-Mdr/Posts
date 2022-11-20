using Domain.Entity.User;

namespace Service.Interfaces
{
    public interface ISessionService
    {
        public Task<UserSession> GetSessionById(Guid id);
    }
}
