using Microsoft.AspNetCore.Http;

namespace BLL.Models
{
    public class CreatePostModel
    {
        public string Text { get; set; } = null!;

        public ICollection<IFormFile>? Files { get; set; }
    }
}