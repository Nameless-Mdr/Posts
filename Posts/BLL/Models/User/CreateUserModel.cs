using System.ComponentModel.DataAnnotations;

namespace BLL.Models.User
{
    public class CreateUserModel
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;

        [Compare(nameof(Password))]
        public string RetryPassword { get; set; } = null!;

        public DateTimeOffset BirthDate { get; set; }
    }
}
