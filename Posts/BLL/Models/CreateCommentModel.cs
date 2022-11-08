namespace BLL.Models
{
    public class CreateCommentModel
    {
        public string Text { get; set; } = null!;

        public Guid PostId { get; set; }
    }
}
