namespace Domain.Entity.Attach
{
    public class Content : Attach
    {
        public Guid PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
