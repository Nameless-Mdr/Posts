namespace BLL.Models
{
    public class GetPostModel
    {
        public string Text { get; set; } = null!;

        public ICollection<CommentTextModel>? Comments { get; set; }

        public ICollection<AttachPathModel>? Attaches { get; set; }
    }
}