using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models;
using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepo : IPostRepo
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public PostRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> InsertAsync(CreatePostModel entity)
        {
            var dbPost = _mapper.Map<Post>(entity);
            await _context.Posts.AddAsync(dbPost);
            await _context.SaveChangesAsync();

            return dbPost.Id;
        }

        public async Task<IEnumerable<GetPostModel>> GetAllAsync()
        {
            return await _context.Posts.AsNoTracking().ProjectTo<GetPostModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<GetPostModel> GetPost(Guid id)
        {
            var post = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
                return new GetPostModel();

            return _mapper.Map<GetPostModel>(post);
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var post = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (post == null)
                return false;

            _context.Posts.Remove(post);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
