using System.ComponentModel.DataAnnotations;
using FormTest.Web;

namespace FormTest.Core.Application.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "NameRequired")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "PasswordRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "PasswordMinLength")]
        public string Password { get; set; }
    }
}
