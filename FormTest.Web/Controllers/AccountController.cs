using FormTest.Core.Application.DTOs;
using FormTest.Core.Domain.Interfaces;
using FormTest.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FormTest.Core.Application.Contracts;


namespace FormTest.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _UserService;

        public AccountController(IUserService UserService)
        {
            _UserService = UserService;
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
            if (_UserService.IsEmailTaken(dto.Email))
            {
                ModelState.AddModelError("Email", "ایمیل قبلاً ثبت شده است.");
                return View(dto);
            }

            _UserService.Register(dto);
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


            var user = _UserService.Login(dto);
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
            return RedirectToAction("Dashboard", "Home"); 
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
