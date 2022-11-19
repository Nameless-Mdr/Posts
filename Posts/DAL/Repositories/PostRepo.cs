using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models;
using DAL.Interfaces;
using Domain.Entity;
using Domain.Entity.Attach;
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

        public async Task<Guid> InsertAsync(CreatePostModel entity, Dictionary<string, MetaDataModel> files)
        {
            var dbPost = _mapper.Map<Post>(entity);
            await _context.Posts.AddAsync(dbPost);

            foreach (var meta in files)
            {
                var attach = new Attach()
                {
                    Id = Guid.NewGuid(),
                    Name = meta.Value.Name,
                    MimeType = meta.Value.MimeType,
                    FilePath = meta.Key,
                    Size = meta.Value.Size,
                    Post = dbPost,
                };

                await _context.Attaches.AddAsync(attach);
            }

            await _context.SaveChangesAsync();

            return dbPost.Id;
        }

        public async Task<IEnumerable<GetPostModel>> GetAllAsync()
        {
            return await _context.Posts.AsNoTracking().ProjectTo<GetPostModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<GetPostModel> GetPost(Guid id)
        {
            var comment = await _context.Posts.AsNoTracking().Where(x => x.Id == id)
                .ProjectTo<GetPostModel>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            return comment ?? new GetPostModel();
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
