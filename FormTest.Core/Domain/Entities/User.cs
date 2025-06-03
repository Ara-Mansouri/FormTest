using FormTest.Core.Domain.Enums;


namespace FormTest.Core.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserRole Role { get; set; } = UserRole.pending;

        public bool IsApproved { get; set; } = false;

    }
}
