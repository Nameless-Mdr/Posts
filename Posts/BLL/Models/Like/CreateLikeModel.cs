namespace BLL.Models.Like
{
    public class CreateLikeModel
    {
        public Guid PostId { get; set; }

        public Guid? AuthorId { get; set; }
    }
}
