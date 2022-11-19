using AutoMapper;
using AutoMapper.QueryableExtensions;
using BLL.Models.Comment;
using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class CommentRepo : ICommentRepo
    {
        private readonly IMapper _mapper;

        private readonly DataContext _context;

        public CommentRepo(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Guid> InsertAsync(CreateCommentModel entity)
        {
            var dbComment = _mapper.Map<Comment>(entity);
            await _context.Comments.AddAsync(dbComment);
            await _context.SaveChangesAsync();

            return dbComment.Id;
        }

        public async Task<IEnumerable<GetCommentModel>> GetAllAsync()
        {
            return await _context.Comments.AsNoTracking().ProjectTo<GetCommentModel>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<GetCommentModel> GetComment(Guid id)
        {
            var comment = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return _mapper.Map<GetCommentModel>(comment) ?? new GetCommentModel();
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var comment = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            if (comment == null)
                return false;

            _context.Comments.Remove(comment);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
