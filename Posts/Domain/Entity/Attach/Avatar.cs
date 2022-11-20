namespace Domain.Entity.Attach
{
    public class Avatar : Attach
    {
        public Guid OwnerId { get; set; }

        public virtual User.User Owner { get; set; } = null!;
    }
}
