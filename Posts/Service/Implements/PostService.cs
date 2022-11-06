using BLL.Models;
using DAL.Interfaces;
using Service.Interfaces;

namespace Service.Implements
{
    public class PostService : IPostService
    {
        private readonly IPostRepo _postRepo;

        public PostService(IPostRepo postRepo)
        {
            _postRepo = postRepo;
        }

        public async Task<Guid> InsertAsync(CreatePostModel entity)
        {
            var response = await _postRepo.InsertAsync(entity);

            return response;
        }

        public async Task<IEnumerable<GetPostModel>> GetAllAsync()
        {
            var response = await _postRepo.GetAllAsync();

            return response;
        }

        public async Task<GetPostModel> GetPost(Guid id)
        {
            var response = await _postRepo.GetPost(id);

            return response;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var response = await _postRepo.DeleteAsync(id);

            return response;
        }
    }
}
