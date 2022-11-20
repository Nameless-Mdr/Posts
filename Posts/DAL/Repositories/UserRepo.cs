using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models.User;
using Common;
using DAL.Interfaces;
using Domain.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public UserRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> Insert(CreateUserModel model)
        {
            var dbUser = _mapper.Map<User>(model);

            await _context.Users.AddAsync(dbUser);
            await _context.SaveChangesAsync();

            return dbUser.Id;
        }

        public async Task<IEnumerable<GetUserModel>> GetUsers()
        {
            return await _context.Users.AsNoTracking().ProjectTo<GetUserModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<User> GetUserByCredentials(string login, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == login.ToLower());

            if (user == null)
                throw new Exception("user not found");

            if (!HashHelper.Verify(password, user.PasswordHash))
                throw new Exception("password is incorrect");

            return user;
        }

        public async Task<User> GetUserById(Guid id)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (user == null)
                throw new Exception("user not found");

            return user;
        }
    }
}
