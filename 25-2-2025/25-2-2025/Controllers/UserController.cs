using _25_2_2025.Models;
using Microsoft.AspNetCore.Mvc;

namespace _25_2_2025.Controllers
{
    public class UserController : Controller
    {
        private readonly MyDbContext _context;

        public UserController(MyDbContext context)
        {
            _context = context;
        }
        // GET: UserController/Create
        public ActionResult SignUp()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(User user, string Rpassword)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "user";
                    _context.Add(user);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Login));
                }
                return View(user);
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Login()
        {
            return View();
        }

        // POST: UserController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            var existingUser = _context.Users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetString("UserName", existingUser.Name);
                HttpContext.Session.SetInt32("UserID", existingUser.Id);
                if (existingUser.Role == "user")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid email or password.");
                return View(user);
            }
        }


        public IActionResult Profile(int Id)
        {
            var user = _context.Users.Find(Id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProfile(User user)
        {
            var existingUser = _context.Users.Find(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Phone = user.Phone;
                existingUser.Address = user.Address;
                _context.Update(existingUser);
                _context.SaveChanges();
            }
            return RedirectToAction("Profile", new { Id = user.Id });
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
