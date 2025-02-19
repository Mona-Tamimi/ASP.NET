using Microsoft.AspNetCore.Mvc;

namespace _19_2_2025_task.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ProcessRegister(string name, string email, string password, string confirmPassword)
        {
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && password == confirmPassword)
            {
                HttpContext.Session.SetString("UserName", name);
                HttpContext.Session.SetString("UserEmail", email);
                HttpContext.Session.SetString("UserPassword", password);
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessLogin(string email, string password)
        {
            if (HttpContext.Session.GetString("UserEmail") == email && HttpContext.Session.GetString("UserPassword") == password)
                return RedirectToAction("Index", "Home");
            ViewBag.Error = "Invalid credentials";
            return View();
        }


        public IActionResult Profile()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("UserEmail")))
                return RedirectToAction("Login");
            ViewBag.Name = HttpContext.Session.GetString("UserName");
            ViewBag.Email = HttpContext.Session.GetString("UserEmail");
            return View();
        }
    }
}
