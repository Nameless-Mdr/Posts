using BLL.Models.Like;

namespace DAL.Interfaces
{
    public interface ILikeRepo
    {
        public Task<Guid> InsertLike(CreateLikeModel model);

        public Task<bool> DeleteLike(Guid id);

        public bool LikeExists(CreateLikeModel model, out Guid likeId);
    }
}
