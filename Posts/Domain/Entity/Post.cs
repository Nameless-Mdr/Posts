using Domain.Entity.Attach;

namespace Domain.Entity
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Text { get; set; } = null!;

        public DateTimeOffset DateCreated { get; set; }

        public Guid AuthorId { get; set; }


        public User.User Author { get; set; } = null!;

        public virtual ICollection<Comment>? Comments { get; set; }

        public virtual ICollection<Content>? Contents { get; set; }

        public virtual ICollection<Like>? Likes { get; set; }
    }
}