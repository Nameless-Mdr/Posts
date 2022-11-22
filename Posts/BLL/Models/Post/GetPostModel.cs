using BLL.Models.Comment;
using BLL.Models.User;

namespace BLL.Models.Post
{
    public class GetPostModel
    {
        public GetUserModel Author { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }

        public ICollection<CommentModel>? Comments { get; set; }

        public ICollection<string>? PathContents { get; set; }

        public int CountOfLikes { get; set; }
    }
}