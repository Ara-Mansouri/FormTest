using FormTest.Application.DTOs;
using FormTest.Core.Entities;
using FormTest.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace FormTest.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserRepository _userRepository;

        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            if (_userRepository.GetByEmail(dto.Email) != null)
            {
                ModelState.AddModelError("Email", "ایمیل قبلاً ثبت شده است.");
                return View(dto);
            }
            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                IsApproved = false,
                Role = "BrandingUser"
            };
            _userRepository.Add(user);
            return RedirectToAction("RegisterSuccess");
        }
        public IActionResult RegisterSuccess()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }


            var user = _userRepository.GetByEmailAndPassword(dto.Email, dto.Password);
            if (user == null)
            {
                ViewBag.ErrorMessage = "کاربری با این مشخصات یافت نشد";
                return View(dto);
            }
            if (!user.IsApproved)
            {
                ViewBag.ErrorMessage = "حساب کاربری شما هنوز تأیید نشده است";
                return View(dto);
            }
            ViewBag.Message = $"خوش آمدید {user.Name}";
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role);
            return RedirectToAction("Dashboard", "Home"); // change if needed
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return RedirectToAction("Login");
        }
    }
}
