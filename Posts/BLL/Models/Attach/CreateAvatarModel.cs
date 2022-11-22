using Microsoft.AspNetCore.Http;

namespace BLL.Models.Attach
{
    public class CreateAvatarModel
    {
        public IFormFile file { get; set; } = null!;
    }
}
