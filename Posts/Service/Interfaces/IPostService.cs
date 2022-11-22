using BLL.Models.Post;

namespace Service.Interfaces
{
    public interface IPostService
    {
        Task<Guid> InsertPost(CreatePostModel entity);

        Task<IEnumerable<GetPostModel>> GetAllAsync();

        Task<bool> DeleteAsync(Guid postId, Guid authorId);
    }
}
