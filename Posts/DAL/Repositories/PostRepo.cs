using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models.Post;
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

        public async Task<bool> DeleteAsync(Guid postId, Guid authorId)
        {
            if (await _context.Posts.AsNoTracking().AnyAsync(x => x.Id == postId && x.AuthorId != authorId))
                throw new Exception("Not enough rights");

            var post = await _context.Posts.AsNoTracking().FirstOrDefaultAsync(x => x.Id == postId);

            if (post == null)
                throw new Exception("Post not found");

            _context.Posts.Remove(post);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
