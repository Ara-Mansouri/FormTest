using System.ComponentModel.DataAnnotations;

namespace FormTest.Core.Application.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessageResourceName = "NameRequired", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        public string Name { get; set; }

        [Required(ErrorMessageResourceName = "EmailRequired", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        [EmailAddress(ErrorMessageResourceName = "InvalidEmail", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        public string Email { get; set; }


        [Required(ErrorMessageResourceName = "PasswordRequired", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        [MinLength(6, ErrorMessageResourceName = "PasswordMinLength", ErrorMessageResourceType = typeof(FormTest.Localization.Resources.SharedResource))]
        public string Password { get; set; }
    }
}
