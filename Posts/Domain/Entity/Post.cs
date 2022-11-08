namespace Domain.Entity
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public virtual Comment? Comment { get; set; }
    }
}