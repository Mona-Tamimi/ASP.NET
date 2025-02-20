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
        public IActionResult SaveUserData(string name, string email, string password, string Rpassword)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Rpassword))
            {
                ViewData["ErrorMesage"] = "All fields are required!";
                return View("Register");
            }
            if (password != Rpassword)
            {
                ViewData["ErrorMesage"] = "Passwords do not match!";
                return View("Register");
            }
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("email", email);
            HttpContext.Session.SetString("password", password);

            TempData["name"] = name;
            TempData["email"] = email;
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckData(string email, string password)
        {
            var storedEmail = HttpContext.Session.GetString("email");
            var storedPassword = HttpContext.Session.GetString("password");

            if (storedEmail == email && storedPassword == password)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ErrorMesage"] = "Invalid email or password";
                return View("Login");
            }
        }
        public IActionResult Profile()
        {
            return View();
        }

    }
}