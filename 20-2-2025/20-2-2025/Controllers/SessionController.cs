using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _20_2_2025.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Store data in session
        public IActionResult SetSession()
        {
            HttpContext.Session.SetString("Username", "Mona Altamimi");
            HttpContext.Session.SetString("UserId", "123");

            return Content("Session data has been set!");
        }

        // Retrieve data from session
        public IActionResult GetSession()
        {
            string username = HttpContext.Session.GetString("Username");
            string userId = HttpContext.Session.GetString("UserId");

            if (username != null || userId !=null)
            {
                return Content($"Stored Session Data: Username = {username}, UserId = {userId}");
            }
            else
            {
                return Content("No session data found.");
            }
        }

        // Remove session data
        public IActionResult RemoveSession()
        {
            //HttpContext.Session.Remove("Username");
            HttpContext.Session.Remove("UserId");

            return Content("Session data has been removed!");
        }

        // Clear all session data
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return Content("All session data has been cleared!");
        }
    }
}
