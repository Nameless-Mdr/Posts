namespace BLL.Models.Comment
{
    public class CommentModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }
    }
}