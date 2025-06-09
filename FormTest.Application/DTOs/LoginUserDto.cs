using System.ComponentModel.DataAnnotations;
using FormTest.Web;

namespace FormTest.Application.DTOs
{
    public class LoginUserDto
    {

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "EmailRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "InvalidEmail")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(SharedResource), ErrorMessageResourceName = "PasswordRequired")]
        public string Password { get; set; }
    }
}
