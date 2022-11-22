using Domain.Entity.Attach;

namespace Domain.Entity.User
{
    public class User
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string PasswordHash { get; set; } = null!;

        public DateTimeOffset BirthDate { get; set; }


        public virtual ICollection<UserSession>? Sessions { get; set; }

        public virtual ICollection<Post>? Posts { get; set; }

        public virtual Avatar? Avatar { get; set; }
    }
}
