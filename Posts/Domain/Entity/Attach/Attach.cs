namespace Domain.Entity.Attach
{
    public class Attach
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string MimeType { get; set; } = null!;

        public string FilePath { get; set; } = null!;

        public long? Size { get; set; }

        public Guid PostId { get; set; }

        public Post Post { get; set; } = null!;
    }
}
