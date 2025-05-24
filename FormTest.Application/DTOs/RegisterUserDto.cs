using System.ComponentModel.DataAnnotations;

namespace FormTest.Application.DTOs
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نیست")]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [MinLength(6, ErrorMessage = "رمز عبور باید حداقل ۶ کاراکتر باشد")]
        public string Password { get; set; }
    }
}
