namespace Domain.Entity
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Attach.Attach>? Attaches { get; set; }
    }
}