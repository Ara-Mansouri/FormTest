using System.ComponentModel.DataAnnotations;

namespace FormTest.Application.DTOs
{
    public class LoginUserDto
    {

        [Required(ErrorMessage = "ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string Email { get; set; }

        [Required(ErrorMessage = "رمز عبور الزامی است")]
        public string Password { get; set; }
    }
}
