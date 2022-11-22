namespace BLL.Models.Comment
{
    public class CreateCommentModel
    {
        public string Text { get; set; } = null!;

        public Guid PostId { get; set; }

        public Guid? AuthorId { get; set; }
    }
}
