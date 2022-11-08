namespace Domain.Entity
{
    public class Comment
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public Guid PostId { get; set; }

        public virtual Post Post { get; set; } = null!;
    }
}
