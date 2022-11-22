using BLL.Models.Like;

namespace Service.Interfaces
{
    public interface ILikeService
    {
        public Task<Guid> InsertLike(CreateLikeModel model);

        public Task<bool> DeleteLike(Guid id);

        public bool LikeExists(CreateLikeModel model, out Guid likeId);
    }
}
