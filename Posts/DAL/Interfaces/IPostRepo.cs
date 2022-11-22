using BLL.Models.Post;

namespace DAL.Interfaces
{
    public interface IPostRepo
    {
        Task<Guid> InsertAsync(CreatePostModel entity);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<bool> DeleteAsync(Guid postId, Guid authorId);
    }
}
