using Microsoft.AspNetCore.Http;

namespace BLL.Models.Post
{
    public class CreatePostModel
    {
        public string Text { get; set; } = null!;

        public ICollection<IFormFile>? Files { get; set; }

        public Guid? AuthorId { get; set; }
    }
}