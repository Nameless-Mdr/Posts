using AutoMapper;
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

        public async Task<Guid> InsertComment(CreateCommentModel entity)
        {
            var dbComment = _mapper.Map<Comment>(entity);
            await _context.Comments.AddAsync(dbComment);
            await _context.SaveChangesAsync();

            return dbComment.Id;
        }

        public async Task<bool> DeleteComment(Guid commentId, Guid authorId)
        {
            if (await _context.Comments.AsNoTracking().AnyAsync(x => x.Id == commentId && x.AuthorId != authorId))
                throw new Exception("Not enough rights");

            var comment = await _context.Comments.AsNoTracking().FirstOrDefaultAsync(x => x.Id == commentId);

            if (comment == null)
                throw new Exception("Comment not found");

            _context.Comments.Remove(comment);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
