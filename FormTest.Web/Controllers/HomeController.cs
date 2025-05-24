using Microsoft.AspNetCore.Mvc;

namespace FormTest.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            var name = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(name))
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Name = name;
            return View();
        }
    }
}
