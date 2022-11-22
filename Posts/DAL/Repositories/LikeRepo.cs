using AutoMapper;
using BLL.Models.Like;
using DAL.Interfaces;
using Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class LikeRepo : ILikeRepo
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public LikeRepo(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Guid> InsertLike(CreateLikeModel model)
        {
            var like = _mapper.Map<Like>(model);

            await _context.AddAsync(like);

            await _context.SaveChangesAsync();

            return like.Id;
        }

        public async Task<bool> DeleteLike(Guid id)
        {
            var deleteLike = await _context.Likes.FirstOrDefaultAsync(x => x.Id == id);

            _context.Likes.Remove(deleteLike!);

            return await _context.SaveChangesAsync() > 0;
        }

        public bool LikeExists(CreateLikeModel model, out Guid likeId)
        {
            var flag = _context.Likes.AsNoTracking().Any(x => x.AuthorId == model.AuthorId && x.PostId == model.PostId);

            likeId = flag ? _context.Likes.FirstOrDefault(x => x.AuthorId == model.AuthorId && x.PostId == model.PostId)!.Id : Guid.Empty;

            return flag;
        }
    }
}
