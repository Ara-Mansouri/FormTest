using System.ComponentModel.DataAnnotations;

namespace FormTest.Core.Application.DTOs
{
    public class LoginUserDto
    {

        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        public string Email { get; set; }

        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        public string Password { get; set; }
    }
}
