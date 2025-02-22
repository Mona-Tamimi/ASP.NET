using Microsoft.AspNetCore.Mvc;

namespace _20_2_2025_task.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Sign_up()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SaveUserData(string name, string email, string password, string Rpassword)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(Rpassword))
            {
                ViewData["ErrorMesage"] = "All fields are required!";
                return View("Sign_up");
            }
            if (password != Rpassword)
            {
                ViewData["ErrorMesage"] = "Passwords do not match!";
                return View("Sign_up");
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
        public IActionResult CheckData(string email, string password, string rem)
        {
            var storedEmail = HttpContext.Session.GetString("email");
            var storedPassword = HttpContext.Session.GetString("password");

            if ((storedEmail == email && storedPassword == password) || (email == "admin@gmail.com" && password == "111"))
            {
                if (rem != null)
                {
                    CookieOptions obj = new CookieOptions();
                    obj.Expires = DateTime.Now.AddDays(2);
                    Response.Cookies.Append("userInfo", email, obj);
                }
                HttpContext.Session.SetString("email", email);
                HttpContext.Session.SetString("password", password);
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
            var data = Request.Cookies["userInfo"];
            TempData["data"] = data;
            return View();
        }

        [HttpPost]
        public IActionResult UpdateProfile(string name, string phone, string address)
        {
            HttpContext.Session.SetString("name", name);
            HttpContext.Session.SetString("phone", phone);
            HttpContext.Session.SetString("address", address);

            return RedirectToAction("Profile");
        }

    }
}