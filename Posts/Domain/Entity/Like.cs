namespace Domain.Entity
{
    public class Like
    {
        public Guid Id { get; set; }

        public DateTimeOffset DateCreated { get; set; }

        public Guid AuthorId { get; set; }

        public Guid PostId { get; set; }


        public User.User Author { get; set; } = null!;

        public Post Post { get; set; } = null!;
    }
}
