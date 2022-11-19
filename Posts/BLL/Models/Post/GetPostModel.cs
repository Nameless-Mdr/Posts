using BLL.Models.Attach;
using BLL.Models.Comment;

namespace BLL.Models.Post
{
    public class GetPostModel
    {
        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }

        public ICollection<CommentTextModel>? Comments { get; set; }

        public ICollection<AttachPathModel>? Attaches { get; set; }
    }
}