namespace BLL.Models.Comment
{
    public class GetCommentModel
    {
        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }

        public string PostText { get; set; } = null!;
    }
}