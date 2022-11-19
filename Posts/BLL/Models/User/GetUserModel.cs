namespace BLL.Models.User
{
    public class GetUserModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public DateTimeOffset BirthDate { get; set; }
    }
}
