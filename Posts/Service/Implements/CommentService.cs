using BLL.Models;
using DAL.Interfaces;
using Service.Interfaces;

namespace Service.Implements
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepo _commentRepo;

        public CommentService(ICommentRepo commentRepo)
        {
            _commentRepo = commentRepo;
        }

        public async Task<Guid> InsertAsync(CreateCommentModel entity)
        {
            var response = await _commentRepo.InsertAsync(entity);

            return response;
        }

        public async Task<IEnumerable<GetCommentModel>> GetAllAsync()
        {
            var response = await _commentRepo.GetAllAsync();

            return response;
        }

        public async Task<GetCommentModel> GetComment(Guid id)
        {
            var response = await _commentRepo.GetComment(id);

            return response;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _commentRepo.DeleteAsync(id);

            return response;
        }
    }
}
