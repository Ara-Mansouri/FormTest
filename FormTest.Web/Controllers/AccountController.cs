using FormTest.Core.Application.DTOs;
using FormTest.Core.Domain.Interfaces;
using FormTest.Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using FormTest.Core.Application.Contracts;
using Microsoft.Extensions.Localization;
using FormTest.Web;


namespace FormTest.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _UserService;
        private readonly IStringLocalizer<SharedResource> _localizer;

        public AccountController(IUserService UserService, IStringLocalizer<SharedResource> localizer)
        {
            _UserService = UserService;
            _localizer = localizer;
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
                ModelState.AddModelError("Email", _localizer["EmailAlreadyRegistered"]);
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
                ViewBag.ErrorMessage = _localizer["UserNotFound"];
                return View(dto);
            }
            if (!user.IsApproved)
            {
                ViewBag.ErrorMessage = _localizer["UserNotApproved"];
                return View(dto);
            }
            ViewBag.Message = string.Format(_localizer["WelcomeUser"], user.Name);
            HttpContext.Session.SetString("UserName", user.Name);
            HttpContext.Session.SetString("UserEmail", user.Email);
            HttpContext.Session.SetString("UserRole", user.Role.ToString());
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
