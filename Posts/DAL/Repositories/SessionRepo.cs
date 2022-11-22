using AutoMapper;
using DAL.Interfaces;
using Domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SessionRepo : ISessionRepo
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public SessionRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> InsertSession(UserSession insertSession)
        {
            await _context.UserSessions.AddAsync(insertSession);

            await _context.SaveChangesAsync();

            return insertSession.Id;
        }

        public async Task<UserSession> GetSessionById(Guid id)
        {
            var session = await _context.UserSessions.FirstOrDefaultAsync(x => x.Id == id);

            if (session == null)
                throw new Exception("session is not found");

            return session;
        }

        public async Task<UserSession> GetSessionByRefreshToken(Guid refreshToken)
        {
            var session = await _context.UserSessions.Include(x 
                => x.User).FirstOrDefaultAsync(x => x.RefreshToken == refreshToken);

            if (session == null)
                throw new Exception("session is not found");

            return session;
        }

        public async Task<Guid> UpdateRefreshToken(UserSession updateSession)
        {
            _context.UserSessions.Update(updateSession);

            await _context.SaveChangesAsync();

            return updateSession.Id;
        }
    }
}
