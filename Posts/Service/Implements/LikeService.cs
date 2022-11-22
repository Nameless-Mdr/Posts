using BLL.Models.Like;
using DAL.Interfaces;
using Service.Interfaces;

namespace Service.Implements
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepo _likeRepo;

        public LikeService(ILikeRepo likeRepo)
        {
            _likeRepo = likeRepo;
        }

        public async Task<Guid> InsertLike(CreateLikeModel model)
        {
            var response = await _likeRepo.InsertLike(model);

            return response;
        }

        public async Task<bool> DeleteLike(Guid id)
        {
            var response = await _likeRepo.DeleteLike(id);

            return response;
        }

        public bool LikeExists(CreateLikeModel model, out Guid likeId)
        {
            var response = _likeRepo.LikeExists(model, out likeId);

            return response;
        }
    }
}
